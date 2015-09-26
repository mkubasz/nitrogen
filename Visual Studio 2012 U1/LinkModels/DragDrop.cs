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
using Microsoft.VisualStudio.Modeling.ExtensionEnablement;
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
  partial class GestureExtension : UmlElementLinkCommand, IGestureExtension
  {

    /// <summary>
    /// Called repeatedly as the user drags over the diagram.
    /// Determines whether drop is allowed on the shape currently under the arrow.
    /// </summary>
    /// <param name="targetMergeElement">Shape under the arrow</param>
    /// <param name="diagramDragEventArgs">Object being dragged</param>
    /// <returns>True to allow drop</returns>
    public bool CanDragDrop(ShapeElement targetMergeElement, DiagramDragEventArgs diagramDragEventArgs)
    {
      // Drag a selection from Word:
      bool wordLink = diagramDragEventArgs.Data.GetDataPresent("ObjectLink");

      //  Only Word selections are acceptable on the diagram surface:
      if (targetMergeElement is Diagram) return wordLink;
      
      string link = "";

      // Element from another diagram:
      bool uml = diagramDragEventArgs.Prototype != null;
      // Drag project item from solution explorer:
      bool projectItem = diagramDragEventArgs.Data.GetDataPresent(SolutionExplorerNodeData.ClipFormatProjectItem);
      // Drag file from Windows Explorer:
      bool file = diagramDragEventArgs.Data.GetDataPresent(System.Windows.Forms.DataFormats.FileDrop);
      // Drag URL from browser address bar:
      bool url = diagramDragEventArgs.Data.GetDataPresent("UniformResourceLocator");
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
      System.Windows.Forms.IDataObject data = diagramDragEventArgs.Data;
      
      string link, text;

      if (targetDropElement is Diagram)
      {
        // Dropping on a blank part of the diagram. We only deal with Word selections:
        if (TryGetWordSelection(data, out link, out text))
        {
          CreateAppropriateElementAndShape(link, text, diagramDragEventArgs.MousePosition);
        }
        return;
      }
      else
      {
        // Dropping on an existing element. Find out what the source is:
        if (
             TryGetUmlShape(diagramDragEventArgs.Prototype, out link) // uml:{file path}#{model element id}
          || TryGetSolutionExplorerFile(data, out link) // file:..\a\b
          || TryGetWindowsExplorerFile(data, out link) // file:..\a\b  or http://www.etc
          || TryGetBrowserUrl(data, out link) // http://www.etc/page#anchor
          || TryGetPptSlide(data, out link) // ppt:{file path}#{slide number}
          || TryGetWordSelection(data, out link, out text) // doc:{file path}#{bookmark name} 
          )
        {
          IElement dropElement = targetDropElement.ModelElement as IElement;
          SetReference(dropElement, link);
        }
      }
    }

    /// <summary>
    /// Add a new shape to the current diagram, with a specified title.
    /// We just create the most common type of shape for the diagram.
    /// </summary>
    /// <param name="link"></param>
    /// <param name="text"></param>
    /// <param name="where"></param>
    private void CreateAppropriateElementAndShape(string link, string text, PointD where)
    {
      // Get the package associated with this diagram, or the root Model:
      IPackage diagramPackage = context.CurrentDiagram.GetObject<IPackage>();
      string name = text;
      if (name.Length > 30)
      {
        name = text.Substring(0, 30);
      }

      // Try all the different diagram types until one works:
      bool created =
      CreateElement<IClassDiagram>(link, d =>
      {
        var iclassifier = diagramPackage.CreateClass();
        iclassifier.Name = name;
        d.Display(iclassifier, null, where.X, where.Y);
        return iclassifier;
      }) ||
      CreateElement<IUseCaseDiagram>(link, d =>
      {
        var iclassifier = diagramPackage.CreateUseCase();
        iclassifier.Name = name;
        d.Display(iclassifier, null, where.X, where.Y);
        return iclassifier;
      }) ||
      CreateElement<IComponentDiagram>(link, d =>
        {
          var iclassifier = diagramPackage.CreateComponent();
          iclassifier.Name = name;
          d.Display(iclassifier, where.X, where.Y);
          return iclassifier;
        }) ||
      CreateElement<IActivityDiagram>(link, d =>
        {
          var action = d.Activity.CreateOpaqueAction();
          action.Name = name;
          action.Shapes().First().Move(where.X, where.Y);
          return action;
        }) ||
      CreateElement<ISequenceDiagram>(link, d =>
      {
        var lifeline = d.Interaction.CreateLifeline();
        lifeline.SetInstanceType(name);
        d.UpdateShapePositions();
        return lifeline;
      });
    }

    /// <summary>
    /// If the current diagram is of the specified type,
    /// perform the create function and add the link to the element.
    /// </summary>
    /// <typeparam name="DiagramType"></typeparam>
    /// <param name="link">reference string to add to the element</param>
    /// <param name="create">create an element and display it</param>
    /// <returns>True if the element was created</returns>
    private bool CreateElement<DiagramType>
      (string link, Func<DiagramType, IElement> create)
      where DiagramType : class, IDiagram
    {
      DiagramType diagram = context.CurrentDiagram as DiagramType;
      if (diagram == null) return false;
      using (ILinkedUndoTransaction t = LinkedUndoContext.BeginTransaction("create element"))
      {
        IElement element = create(diagram);
        SetReference(element, link);
        t.Commit();
      }
      return true;
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
    /// <param name="link">doc:{file path}#{bookmark name}</param>
    /// <param name="text">The selected text fragment</param>
    /// <returns></returns>
    private bool TryGetWordSelection(System.Windows.Forms.IDataObject data, out string link, out string text)
    {
      link = ""; 
      text = "";
      System.IO.Stream stream = data.GetData("ObjectLink") as System.IO.Stream;
      if (stream == null)
      {
        return false;
      }
      string s = new System.IO.StreamReader(stream).ReadToEnd();     
      string[] ss = s.Split('\0');
      if (ss[1].Length > 4 && ss[1].IndexOf(":\\") == 1 && ss[0].StartsWith("Word"))
      {
        link = "doc:" + RelativeFilePath(ss[1]) + "#" + ss[2]; // Filename # bookmarkName
        text = (data.GetData("System.String") as string).Trim();
        // Remove list item numbers, bullets, section numbers:
        int tab = text.IndexOf('\t');
        if (tab >= 0 && tab < 20)
        {
          text = text.Substring(tab + 1);
        }
        return true;
      }
      return false;
    }

    /// <summary>
    /// User drags from the Powerpoint slide index.
    /// </summary>
    /// <param name="data"></param>
    /// <param name="link">ppt:{file path}#{slide number}</param>
    /// <returns></returns>
    private bool TryGetPptSlide(System.Windows.Forms.IDataObject data, out string link)
    {
      link = "";
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
          link = "ppt:" + RelativeFilePath(uri.Replace('!', '#'));  // filename # slideNumber
          return seenPpt;
        }
      }
      return false;
    }
  }
}
