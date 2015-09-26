// Copyright © Microsoft Corporation.  All Rights Reserved.
// This code released under the terms of the 
// Apache License, Version 2.0. Please see http://www.apache.org/licenses/LICENSE-2.0.html

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Microsoft.VisualStudio.ArchitectureTools.Extensibility;
using Microsoft.VisualStudio.ArchitectureTools.Extensibility.Presentation;
using Microsoft.VisualStudio.ArchitectureTools.Extensibility.Uml;
using Microsoft.VisualStudio.Modeling;
using Microsoft.VisualStudio.Modeling.Diagrams;
using Microsoft.VisualStudio.Modeling.Diagrams.ExtensionEnablement;
using Microsoft.VisualStudio.Uml.Classes;

namespace UmlElementLink
{
  /// <summary>
  /// Custom gesture (drag-drop and/or double-click) extension.
  /// See http://msdn.microsoft.com/en-us/library/ee534033(VS.100).aspx
  /// </summary>
  [Export(typeof(IGestureExtension))]
  [ClassDesignerExtension] 
  [ActivityDesignerExtension]
  [SequenceDesignerExtension]
  [UseCaseDesignerExtension]
  [ComponentDesignerExtension]
  class GestureExtension : UmlElementLinkCommand, IGestureExtension
  {
    /// <summary>
    /// Called when the user double-clicks anywhere on a diagram.
    /// Called in addition to any other double-click functionality.
    /// </summary>
    /// <param name="targetShapeElement"></param>
    /// <param name="diagramPointEventArgs"></param>
    public void OnDoubleClick(ShapeElement sourceShapeElement, DiagramPointEventArgs diagramPointEventArgs)
    {
      diagramPointEventArgs.Handled = OpenReference(CurrentElement);
    }


    /// <summary>
    /// Called repeatedly as the user drags over the diagram.
    /// Determines whether drop is allowed on the shape currently under the arrow.
    /// </summary>
    /// <param name="targetMergeElement">Shape under the arrow</param>
    /// <param name="diagramDragEventArgs">Object being dragged</param>
    /// <returns>True to allow drop</returns>
    public bool CanDragDrop(ShapeElement targetMergeElement, DiagramDragEventArgs diagramDragEventArgs)
    {
      //  We don't allow linking to the diagram:
      if (targetMergeElement is Diagram) return false;
      
      string link = "";

      // Element from another diagram:
      bool uml = diagramDragEventArgs.Prototype != null;
      // Drag project item from solution explorer:
      bool projectItem = diagramDragEventArgs.Data.GetDataPresent(SolutionExplorerNodeData.ClipFormatProjectItem);
      // Drag file from Windows Explorer:
      bool file = diagramDragEventArgs.Data.GetDataPresent(System.Windows.Forms.DataFormats.FileDrop);
      // Drag URL from browser address bar:
      bool url = diagramDragEventArgs.Data.GetDataPresent("UniformResourceLocator");
      // Drag a selection from Word:
      bool wordLink = diagramDragEventArgs.Data.GetDataPresent("ObjectLink");
      // Drag a slide from PowerPoint slide index:
      bool pptLink = TryGetPptSlide(diagramDragEventArgs.Data, out link);
      
      return uml || projectItem || file || url || wordLink || pptLink;
    }

    /// <summary>
    /// Called when the user drops an item onto the diagram.
    /// </summary>
    /// <param name="targetDropElement">Shape under the arrow</param>
    /// <param name="diagramDragEventArgs">Object being dropped</param>
    public void OnDragDrop(ShapeElement targetDropElement, DiagramDragEventArgs diagramDragEventArgs)
    {
      // We don't link the diagram to anything:
      if (targetDropElement is Diagram) return;

      IElement dropElement = targetDropElement.ModelElement as IElement;
      System.Windows.Forms.IDataObject data = diagramDragEventArgs.Data;
      string link;
      if (TryGetPptSlide(data, out link) // ppt:{file path}#{slide number}
        || TryGetWordSelection(data, out link) // doc:{file path}#{bookmark name} 
        || TryGetSolutionExplorerFile(data, out link) // file:..\a\b
        || TryGetWindowsExplorerFile(data, out link) // file:..\a\b  or http://www.etc
        || TryGetBrowserUrl(data, out link) // http://www.etc/page#anchor
        || TryGetUmlShape(diagramDragEventArgs.Prototype, out link) // uml:{file path}#{model element id}
        )
      {
        SetReference(dropElement, link);
      }
    }

    /// <summary>
    /// Get a link when the user drags a shape from another diagram.  
    /// </summary>
    /// <param name="egp">prototype from data; can be null</param>
    /// <param name="value">uml:{file path}#{model element id}</param>
    /// <returns></returns>
    private bool TryGetUmlShape(ElementGroupPrototype egp, out string value)
    {
      value = "";
      if (egp == null) return false;
      ProtoElement pe = egp.RootProtoElements.FirstOrDefault();
      if (pe == null) return false;
        object sourceStoreId;
        if (!egp.SourceContext.ContextInfo.TryGetValue("SourceStore", out sourceStoreId))
          return false;

        Store sourceStore = Dte.Solution.Projects.OfType<IModelingProject>().Select(mp =>
          { IModelStore ms = mp.Store; return ms == null ? null : (ms.Root as ModelElement).Store; })
          .FirstOrDefault(s => s != null && s.Id == (Guid)sourceStoreId);
        if (sourceStore == null) return false;

        // Get the target element:
        ModelElement sourceElement = sourceStore.ElementDirectory.FindElement
          (egp.RootProtoElements[0].ElementId) as ModelElement;
        ShapeElement sourceShapeElement = sourceElement as ShapeElement;
        if (sourceShapeElement != null)
        {
          sourceElement = sourceShapeElement.ModelElement;
        }
        IElement sourceUmlElement = sourceElement as IElement;
        if (sourceUmlElement == null) return false;

        // Find the source diagram file. Easiest access is from the UML IDiagram:
        Guid sourceDiagramGuid = DragSourceContext.GetDiagramId(egp);
        IShape sourceUmlShape = sourceUmlElement.Shapes().FirstOrDefault(
          d => sourceDiagramGuid == null || sourceDiagramGuid.Equals(d.Diagram.GetObject<Diagram>().Id));
        string sourceUmlFile = sourceUmlShape.Diagram.FileName;

        value = "uml:" + RelativeFilePath(sourceUmlFile) + "#" + sourceElement.Id.ToString();
        return true;
    }

    /// <summary>
    /// User drags URL from IE address bar.
    /// </summary>
    /// <param name="data"></param>
    /// <param name="value">http://www.etc/page#anchor</param>
    /// <returns></returns>
    private bool TryGetBrowserUrl(System.Windows.Forms.IDataObject data, out string value)
    {
      value = "";
      if (data.GetDataPresent("UniformResourceLocator")
           && data.GetDataPresent("System.String"))
      {
        value = data.GetData("System.String") as string; //http:...
        return true;
      }
      return false;
    }

    /// <summary>
    /// User drags a file or a URI shortcut from the desktop
    /// </summary>
    /// <param name="data"></param>
    /// <param name="value"> //file:C:\a\b  or http://www.etc</param>
    /// <returns></returns>
    private bool TryGetWindowsExplorerFile(System.Windows.Forms.IDataObject data, out string value)
    {
      value = "";
      // Drags from Windows Explorer have a plain filename format:
      string[] files = data.GetData(System.Windows.Forms.DataFormats.FileDrop) as string[];
      if (files == null || files.Length < 1 /*|| !files[0].EndsWith("diagram")*/) return false;
      value = "file:" + RelativeFilePath(files[0]);

      // Dragging a URL shortcut stores the URL:
      if (files[0].EndsWith(".url", StringComparison.InvariantCultureIgnoreCase)
        || files[0].EndsWith(".website", StringComparison.InvariantCultureIgnoreCase))
      {
        foreach (string url in System.IO.File.ReadAllLines(files[0]))
        {
          if (url.StartsWith("URL="))
          {
            value = url.Substring(4);
            return true;
          }
        }
      }
      return true;
    }

    /// <summary>
    /// User drags a file from VS Solution Explorer.
    /// </summary>
    /// <param name="data"></param>
    /// <param name="value">file:C:\a\b</param>
    /// <returns></returns>
    private bool TryGetSolutionExplorerFile(System.Windows.Forms.IDataObject data, out string value)
    {
      value = "";

      if (data.GetDataPresent(SolutionExplorerNodeData.ClipFormatProjectItem))
      {
        // Each IDataObject has its own more or less weird encoding:
        IList<SolutionExplorerNodeData> nodeData = SolutionExplorerNodeData.DecodeProjectItemData(data, false);
        if (nodeData.Count > 0 && !nodeData[0].IsProjectNode)
        {
          value = "file:" + RelativeFilePath(nodeData[0].FileName);
          return true;
        }
      }
      return false;
    }

    /// <summary>
    /// User drags from a selection in Word.
    /// The action creates a bookmark. The user must save the Word doc.
    /// </summary>
    /// <param name="data"></param>
    /// <param name="value">doc:{file path}#{bookmark name}</param>
    /// <returns></returns>
    private bool TryGetWordSelection(System.Windows.Forms.IDataObject data, out string value)
    {
      value = "";
      System.IO.Stream stream = data.GetData("ObjectLink") as System.IO.Stream;
      if (stream == null) return false;
      string s = new System.IO.StreamReader(stream).ReadToEnd();     
      string[] ss = s.Split('\0');
      if (ss[1].Length > 4 && ss[1].IndexOf(":\\") == 1 && ss[0].StartsWith("Word"))
      {
        value = "doc:" + RelativeFilePath(ss[1]) + "#" + ss[2]; // Filename # bookmarkName
        return true;
      }
      return false;
    }

    /// <summary>
    /// User drags from the Powerpoint slide index.
    /// </summary>
    /// <param name="data"></param>
    /// <param name="value">ppt:{file path}#{slide number}</param>
    /// <returns></returns>
    private bool TryGetPptSlide(System.Windows.Forms.IDataObject data, out string value)
    {
      value = "";
      System.IO.Stream stream = data.GetData("Object Descriptor", true) as System.IO.Stream;
      if (stream == null) return false;

      string[] pptLink = new System.IO.StreamReader(stream, System.Text.Encoding.Unicode).ReadToEnd()
        .Split(new char[] { '\0' }, StringSplitOptions.RemoveEmptyEntries);
      bool seenPpt = false;
      foreach (string uri in pptLink)
      {
        if (uri.IndexOf("Microsoft PowerPoint Slide") >= 0)
        {
          seenPpt = true;
        }
        else if (uri.IndexOf(":\\") == 1)
        {
          value = "ppt:" + RelativeFilePath(uri.Replace('!', '#'));  // filename # slideNumber
          return seenPpt;
        }
      }
      return false;
    }
  }
}
