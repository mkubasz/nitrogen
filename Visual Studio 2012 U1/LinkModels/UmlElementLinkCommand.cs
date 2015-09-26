// Copyright © Microsoft Corporation.  All Rights Reserved.
// This code released under the terms of the 
// Apache License, Version 2.0. Please see http://www.apache.org/licenses/LICENSE-2.0.html

using System;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using EnvDTE;
using Microsoft.VisualStudio.ArchitectureTools.Extensibility.Presentation;
using Microsoft.VisualStudio.ArchitectureTools.Extensibility.Uml;
using Microsoft.VisualStudio.Modeling.ExtensionEnablement;
using Microsoft.VisualStudio.Uml.Classes;
using System.Collections.Generic;

namespace UmlElementLink
{

  abstract partial class UmlElementLinkCommand
  {
    /// <summary>
    /// Tag that identifies our references.
    /// </summary>
    private const string ModelLinkReferenceTag = "UmlModelLinkReferenceTag";

    #region Context
    [Import]
    protected IDiagramContext context { get; set; }

    [Import]
    public Microsoft.VisualStudio.Shell.SVsServiceProvider ServiceProvider { get; set; }
    
    [Import]
    public ILinkedUndoContext LinkedUndoContext { get; set; }
    
    internal EnvDTE.DTE Dte
    {
      get
      {
        if (dte == null)
        {
          dte = ServiceProvider.GetService(typeof(EnvDTE.DTE)) as EnvDTE.DTE;
        }
        return dte;
      }
    }
    private EnvDTE.DTE dte = null;


    /// <summary>
    /// IElement of the single currently selected shape, or null.
    /// </summary>
    protected IElement CurrentElement
    {
      get
      {
        var diagram = CurrentDiagram;
        if (diagram == null) return null;
        if (diagram.SelectedShapes.Count() > 1 && !(diagram is ISequenceDiagram)) return null;
        IShape currentShape = diagram.SelectedShapes.FirstOrDefault();
        if (currentShape == null || currentShape is IDiagram) return null;
        return currentShape.GetElement();
      }
    }

    protected IDiagram CurrentDiagram
    {
      get { return context.CurrentDiagram; }
    }

    #endregion

    #region Manage references.
    /// <summary>
    /// Model reference attached to the element. Null if there is none.
    /// </summary>
    /// <param name="element"></param>
    /// <returns></returns>
    protected static IEnumerable<IReference> GetReference(IElement element)
    {
      return element == null ? null : element.GetReferences(ModelLinkReferenceTag);
    }


    /// <summary>
    /// True if there is a model reference attached to the element.
    /// False if the element is null.
    /// </summary>
    /// <param name="element"></param>
    /// <returns></returns>
    public static bool HasReference(IElement element)
    {
      return element != null && GetReference(element).Count() > 0;
    }

    /// <summary>
    /// Set the reference on an element to point to a UML diagram file.
    /// </summary>
    /// <param name="element">source element</param>
    /// <param name="fullFilePath">UML diagram file path</param>
    protected static void SetReference(IElement element, string fullFilePath)
    {
      element.AddReference(ModelLinkReferenceTag, fullFilePath, true);
    }
    #endregion

    #region Convert between relative and absolute file paths.
    /// <summary>
    /// File path relative to the current diagram.
    /// </summary>
    /// <param name="filePath"></param>
    /// <returns></returns>
    protected string RelativeFilePath(string filePath)
    {
      // Current diagram path:
      string localFileName = CurrentDiagram.FileName;
      if (string.IsNullOrEmpty(localFileName)) return filePath;
      return RelativePath(localFileName.ToLowerInvariant(), filePath.ToLowerInvariant());
    }

    /// <summary>
    /// Target path relative to the source.
    /// </summary>
    /// <param name="source">Lowercase local absolute file path</param>
    /// <param name="target">Lowercase local absolute file path</param>
    /// <returns></returns>
    protected static string RelativePath(string source, string target)
    {
      // Absolute and local?
      if (target.Length < 3 || target[1] != ':')
      {
        // Already relative; or
        // Network filename: \\machine\...
        return target;
      }
      // Same volume?
      if (source.Substring(0, 3).ToLowerInvariant() != target.Substring(0, 3).ToLowerInvariant())
      {
        // On a different disk  C:\... != D:\...
        return target;
      }
      return RelativePath(source.Split('\\'), target.Split('\\'), 0, 0);
    }

    /// <summary>
    /// The target path relative to the source.
    /// </summary>
    /// <param name="source">Source path as an array of bits</param>
    /// <param name="target">Target path as an array of bits</param>
    /// <param name="sourceIx">Source element before which all items are equal</param>
    /// <param name="targetIx">Target element before which all items are equal</param>
    /// <returns></returns>
    protected static string RelativePath(string[] source, string[] target, int sourceIx, int targetIx)
    {
      if (targetIx == target.Length) return target[target.Length - 1];
      if (sourceIx == targetIx && source[sourceIx].Equals(target[targetIx], StringComparison.InvariantCultureIgnoreCase))
        return RelativePath(source, target, sourceIx + 1, targetIx + 1);
      if (sourceIx + 1 < source.Length)
        return "..\\" + RelativePath(source, target, sourceIx + 1, targetIx);
      else
        return string.Join("\\", target, targetIx, target.Length - targetIx);
    }

    /// <summary>
    /// Get an absolute file path from a model reference: {relative path}[#{element id}]
    /// </summary>
    /// <param name="umlModelReference">Path relative to the current file, or an absolute path, or a 
    /// reference in which '#' terminates the path.</param>
    /// <returns></returns>
    protected string AbsoluteFilePath(string umlModelReference)
    {
      string filePath = umlModelReference.Split(new char[] { '|', '#' }, 2)[0];
      if (filePath.IndexOf("://") > 0 || filePath.IndexOf("\\\\")==0)
      {
        return filePath;
      }
      else
      {
        return Path.GetFullPath(Path.Combine(Path.GetDirectoryName(CurrentDiagram.FileName), filePath));
      }
    }
    #endregion

    #region Resolve references

    protected IEnumerable<string> GetReferenceValues(IElement element)
    {
      IEnumerable<IReference> references = GetReference(element);
      if (references == null) return null;
      return references.Select(r => r.Value);
    }


    /// <summary>
    /// Display a form that lets the user choose an item.
    /// </summary>
    /// <param name="items"></param>
    /// <returns>Null if the user closed the dialog</returns>
    protected string ChooseOne(IEnumerable<string> items)
    {
      if (items == null || items.Count() == 0) return null;
      if (items.Count() == 1) return items.First();
      using (ChooseReferenceForm form = new ChooseReferenceForm(items))
      {
        if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        {
          return form.Selection;
        }
        return null;
      }
    }

    #endregion
  }

}
