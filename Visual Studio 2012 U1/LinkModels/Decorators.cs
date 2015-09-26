// Copyright © Microsoft Corporation.  All Rights Reserved.
// This code released under the terms of the 
// Apache License, Version 2.0. Please see http://www.apache.org/licenses/LICENSE-2.0.html

using System.Collections.Generic;
using System.ComponentModel.Composition;
using Microsoft.VisualStudio.ArchitectureTools.Extensibility.Presentation;
using Microsoft.VisualStudio.Modeling;
using Microsoft.VisualStudio.Modeling.Diagrams;
using Microsoft.VisualStudio.Modeling.Validation;
using Microsoft.VisualStudio.Uml.AuxiliaryConstructs;
using Microsoft.VisualStudio.Uml.Classes;
using Microsoft.VisualStudio.Uml.CompositeStructures;

/* 
 * This code defines shape decorators that indicate when the element is linked to a diagram.
 * To add the decorators to the shapes, we have to run FixDecorators() once for each shape class.
 * It's easiest to do this when the first instance of each shape is created.
 * To respond when the shape is created, we create a VMSDK rule, PresentationAddRule.
 * 
 * Normally, rules in VMSDK are set up by adding an attribute to the rule class.
 * But because we're adding the rule to an existing design, we have to add the rule
 * using the method in AddRulesToModel.
 * 
 */

namespace UmlElementLink
{

  /// <summary>
  /// Rule invoked when anything is displayed on a diagram.
  /// This rule is included in the list in AddRulesToModel.SetupRules().
  /// </summary>
  class PresentationAddRule : AddRule
  {
    private static Dictionary<System.Type, string> decoratorsFixed = new Dictionary<System.Type, string>();

    public override void ElementAdded(ElementAddedEventArgs e)
    {
      // The rule is actually attached to PresentationViewsSubject, which is the relationship between
      // any shape and its model element.
      // This ensures that when the rule runs, both the shape and the model element and their relationship
      // are all set up. If we were to attach the rule to the shape, it might run before
      // the relationship to the model element is in place, which would be horribly confusing.
      PresentationViewsSubject pvs = e.ModelElement as PresentationViewsSubject;
      if (pvs == null) return;

      // We've decided not to allow references on diagrams or connectors,
      // so we don't need decorators on them:
      ShapeElement shapeElement = pvs.Presentation as NodeShape;
      if (shapeElement == null
        || shapeElement is Diagram
        || shapeElement is IShape<IPort>
        ) return;

      // Decorators are defined per shape class, not per shape instance.
      // So we should only add the decorator once for each shape class:
      if (!decoratorsFixed.ContainsKey(shapeElement.GetType()))
      {
        decoratorsFixed.Add(shapeElement.GetType(), "");

        // Make sure we're dealing with a proper piece of UML, not some sub-shape:
        IElement element = pvs.Subject as IElement;
        if (element != null)
        {
          // Add our decorator:
          FixDecorators(pvs.Presentation as ShapeElement);
        }
      }
    }

    public PresentationAddRule()
    {
      FireTime = TimeToFire.TopLevelCommit;
    }

    /// <summary>
    /// Replace the usual decorators on the shapes to suit our own purposes.
    /// The method runs once only for each class: decorators are defined per shape class, not per instance.
    /// Each decorator is defined by a Decorator and a TextField or a ShapeImageField.
    /// In VMSDK, decorators are usually defined in the DslDefinition model. But we are 
    /// modifying the decorators of an existing design.
    /// http://msdn.microsoft.com/en-us/library/microsoft.visualstudio.modeling.diagrams.textfield.aspx
    /// </summary>
    /// <param name="shapeElement">DSL Shape that displays decisionNode</param>
    private static void FixDecorators(ShapeElement shapeElement)
    {
      /* //Example of how to remove an existing decorator before adding our own:
      Decorator stereotypeDecorator = shapeElement.Decorators.Where(d => d.Field.Name == "Stereotype").FirstOrDefault();
      if (stereotypeDecorator != null)
      {
        // ShapeFields and Decorators are singletons shared between all instances of the same shape class.
        shapeElement.ShapeFields.Remove(stereotypeDecorator.Field);
        shapeElement.Decorators.Remove(stereotypeDecorator);
      }
      */

      // Fields represent text or images within a shape class:
      ShapeField field = new UmlLinkImageField();
      shapeElement.ShapeFields.Add(field);

      // There is a decorator to define the location of each field within a shape:
      ShapeDecorator decorator = new ShapeDecorator(field, ShapeDecoratorPosition.InnerTopRight);
      shapeElement.Decorators.Add(decorator);

    }

    /// <summary>
    /// Image field that is visible when the model element has one of our references.
    /// </summary>
    private class UmlLinkImageField : ImageField
    {
      public UmlLinkImageField()
        : base("UmlLinkImageField", Properties.Resources.ModelLinkIndicator)
      { }

      public override bool GetVisible(ShapeElement parentShape)
      {
        IElement element = parentShape.ModelElement as IElement;
        if (element == null) return false;
        return UmlElementLinkCommand.HasReference(element);
      }
    }

  }

}
