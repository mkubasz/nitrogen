using System;
using System.IO;
using EnvDTE;
using Microsoft.VisualStudio.ArchitectureTools.Extensibility.Presentation;
using Microsoft.VisualStudio.ArchitectureTools.Extensibility.Uml;
using Microsoft.VisualStudio.Modeling.Diagrams;
using Microsoft.VisualStudio.Uml.Classes;

namespace UmlElementLink
{
  partial class GestureExtension : UmlElementLinkCommand
  {
    /// <summary>
    /// Called when the user double-clicks anywhere on a diagram.
    /// Called in addition to any other double-click functionality.
    /// </summary>
    /// <param name="targetShapeElement"></param>
    /// <param name="diagramPointEventArgs"></param>
    public void OnDoubleClick(ShapeElement sourceShapeElement, DiagramPointEventArgs diagramPointEventArgs)
    {
      string reference = "";
      IElement element = CurrentElement;
      if (element != null)
      {
        reference = ChooseOne(GetReferenceValues(element));
      }
      if (string.IsNullOrWhiteSpace(reference))
      {
        return;
      }
      diagramPointEventArgs.Handled = OpenReference(reference);
    }
  }

  /// <summary>
  /// Base of GestureExtension and Commands.
  /// </summary>
  abstract partial class UmlElementLinkCommand
  {
    /// <summary>
    /// Open the file referenced by an element, and select any element pointed to by the reference.
    /// Reference is in form: {prefix}:{link}#{qualifier}
    /// </summary>
    /// <param name="referenceValue"></param>
    /// <returns>False if no reference was found.</returns>
    protected bool OpenReference(string referenceValue)
    {
      // {prefix}:{link}#{qualifier}
      string[] refBits = referenceValue.Split(new char[] { ':' }, 2);
      string prefix = "", link = "", qualifier = "";
      if (refBits.Length == 1)
      {
        prefix = "file";
        link = refBits[0];
      }
      else
      {
        prefix = refBits[0];
        link = refBits[1];
      }
      string[] linkBits = link.Split(new char[] { '#', '|' }, 2);
      if (linkBits.Length == 2)
      {
        link = linkBits[0];
        qualifier = linkBits[1];
      }

      string filePath = prefix == "http" ? referenceValue : AbsoluteFilePath(link);

      switch (prefix)
      {
        case "http":
          Dte.ExecuteCommand("View.WebBrowser", referenceValue);
          break;
        case "doc":
          return Office.TryOpenFileInWord(filePath, qualifier);
        case "ppt":
          return Office.TryOpenFileInPpt(filePath, qualifier);
        case "file":
        case "uml":
          TryOpenFile(filePath, qualifier);
          break;
        default:
          System.Diagnostics.Debug.Fail("OpenReference " + prefix);
          break;
      }
      return true;
    }

    /// <summary>
    /// Try opening the file as a UML diagram, then as a general file.
    /// Open the file in VS if it can; otherwise, in the appropriate application.
    /// Select a specific element if it is referenced.
    /// </summary>
    /// <param name="filePath">absolute path of a diagram or other file</param>
    /// <param name="qualifier">GUID of an element in the target model</param>
    private void TryOpenFile(string filePath, string qualifier)
    {

      // Try finding a UML diagram in the current solution:
      IDiagram targetDiagram = null;
      if (TryOpenDiagramInThisSolution(filePath, out targetDiagram))
      {
        if (targetDiagram != null && !string.IsNullOrEmpty(qualifier))
        {
          Guid targetElementGuid;
          if (Guid.TryParse(qualifier, out targetElementGuid))
          {
            // Select the target element:
            IModelStore targetModelStore = targetDiagram.ModelStore;
            IElement targetModelElement = targetModelStore.FindElement(targetElementGuid);
            targetDiagram.SelectShapes(targetModelElement.Shapes(targetDiagram));
          }
        }
      }
      else
      {
        try
        {
          // Open in VS, if it knows how:
          Dte.ItemOperations.OpenFile(filePath);
        }
        catch (Exception)
        {
          // Open in appropriate application:
          System.Diagnostics.Process.Start(filePath);
        }
      }
    }


    /// <summary>
    /// If the file is in the current solution, open it and bring it to the front.
    /// If it is a diagram file, pass out the diagram so that we can process its bits.
    /// </summary>
    /// <param name="modelFileName"></param>
    /// <param name="diagram"></param>
    /// <returns></returns>
    private bool TryOpenDiagramInThisSolution(string modelFileName, out IDiagram diagram)
    {
      diagram = null;
      try
      {
        ProjectItem projectItem = Dte.Solution.FindProjectItem(modelFileName);
        if (projectItem == null) return false;
        if (projectItem.IsOpen)
        {
          projectItem.Document.Activate();
        }
        else
        {
          EnvDTE.Window window = projectItem.Open();
          if (window != null)
          {
            window.Activate();
          }
        }
        IDiagramContext context = projectItem as IDiagramContext;
        if (context != null)
        {
          diagram = context.CurrentDiagram;
        }
        return true;
      }
      catch (System.Runtime.InteropServices.COMException)
      {
        return false;
      }
      catch (IOException)
      {
        // Typically, this is because the file is a Word or other non-VS doc that is already open.
        return false;
      }
    }

  }
}
