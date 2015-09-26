// Copyright © Microsoft Corporation.  All Rights Reserved.
// This code released under the terms of the 
// Apache License, Version 2.0. Please see http://www.apache.org/licenses/LICENSE-2.0.html

using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.ArchitectureTools.Extensibility.Presentation;
using Microsoft.VisualStudio.ArchitectureTools.Extensibility.Uml;
using Microsoft.VisualStudio.Modeling.ExtensionEnablement;
using Microsoft.VisualStudio.Uml.Classes;
using System.Collections.Generic;

namespace UmlElementLink
{
  /// <summary>
  /// User command to add or edit a link to another diagram.
  /// Appears on all shapes on all UML diagrams.
  /// You can also drag things onto a shape.
  /// </summary>
  [Export(typeof(ICommandExtension))]
  [ClassDesignerExtension]
  [ActivityDesignerExtension]
  [SequenceDesignerExtension]
  [UseCaseDesignerExtension]
  [ComponentDesignerExtension]
  class AddLinkCommand : UmlElementLinkCommand, ICommandExtension
  {
    /// <summary>
    /// Called when the user selects this menu command.
    /// </summary>
    /// <param name="command"></param>
    public void Execute(IMenuCommand command)
    {
      IElement element = CurrentElement;
      if (element == null) return;

      // If there is an existing reference, initialize the dialog with it:
      string previousFile = "";
      foreach (IReference reference in GetReference(element))
      {
        if (reference.Value.StartsWith("file:"))
        {
          previousFile = AbsoluteFilePath(reference.Value.Substring("file:".Length));
        }
      }

      using (System.Windows.Forms.FileDialog fileDialog = new System.Windows.Forms.OpenFileDialog())
      {
        if (!string.IsNullOrEmpty(previousFile))
        {
          fileDialog.InitialDirectory = Path.GetDirectoryName(previousFile);
          fileDialog.FileName = Path.GetFileName(previousFile);
        }
        else
        {
          fileDialog.InitialDirectory = Path.GetDirectoryName(context.CurrentDiagram.FileName);
        }
        fileDialog.CheckFileExists = true;
        fileDialog.Title = Properties.Resources.SelectTargetFileTitle;
        fileDialog.Filter = Properties.Resources.AnyFileFilter;

        // If the user did not cancel...
        if (fileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        {
          // Add (or overwrite) a reference:
          SetReference(element, "file:" + this.RelativeFilePath(fileDialog.FileName));
        }
      }
    }

    /// <summary>
    /// Called when the user right-clicks the diagram.
    /// Determines whether this command should appear on the menu.
    /// Also sets the menu item text.
    /// </summary>
    /// <param name="command"></param>
    public void QueryStatus(IMenuCommand command)
    {
      command.Enabled = command.Visible = CurrentElement != null;
      //if (HasReference(CurrentElement))
      //  command.Text = Properties.Resources.EditLinkedFile;
      //else
        command.Text = Properties.Resources.AddLinkedFile;
    }

    /// <summary>
    /// The default text for the menu item.
    /// </summary>
    public string Text
    {
      get { return Properties.Resources.AddLinkedFile; }
    }

  }

  /// <summary>
  /// User command to delete a link.
  /// 
  /// </summary>
  [Export(typeof(ICommandExtension))]
  [ClassDesignerExtension]
  [ActivityDesignerExtension]
  [SequenceDesignerExtension]
  [UseCaseDesignerExtension]
  [ComponentDesignerExtension]
  class DeleteLinkCommand : UmlElementLinkCommand, ICommandExtension
  {
    [Import]
    ILinkedUndoContext linkedUndoContext { get; set; }

    /// <summary>
    /// Called when the user selects this menu command.
    /// </summary>
    /// <param name="command"></param>
    public void Execute(IMenuCommand command)
    {
      IEnumerable<IReference> references = GetReference(CurrentElement);
      if (references != null && references.Count() > 0)
      {
        if (references.Count() == 1)
        {
          references.FirstOrDefault().Delete();
        }
        else
        {
          string value = ChooseOne(new[]{"ALL"}.Concat(GetReferenceValues(CurrentElement)));
          if (value != null)
          {
            // Because we might delete several, we should group them in a transaction:
            using (ILinkedUndoTransaction t = linkedUndoContext.BeginTransaction("Delete links"))
            {
              foreach (var reference in references)
              {
                if (value == "ALL" || value == reference.Value)
                {
                  reference.Delete();
                }
              }
              t.Commit();
            }
          }
        }
      }
    }

    /// <summary>
    /// Called when the user right-clicks the diagram.
    /// Determines whether this menu item appears.
    /// </summary>
    /// <param name="command"></param>
    public void QueryStatus(IMenuCommand command)
    {
      command.Visible = CurrentElement != null;
      command.Enabled = HasReference(CurrentElement);
    }

    /// <summary>
    /// The text of the menu item.
    /// </summary>
    public string Text
    {
      get { return "Delete links"; }
    }

  }
}
