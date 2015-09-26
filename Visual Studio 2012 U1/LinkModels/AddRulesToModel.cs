// Copyright © Microsoft Corporation.  All Rights Reserved.
// This code released under the terms of the 
// Apache License, Version 2.0. Please see http://www.apache.org/licenses/LICENSE-2.0.html

using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Modeling;
using Microsoft.VisualStudio.Modeling.Diagrams;
using Microsoft.VisualStudio.Modeling.Validation;
using Microsoft.VisualStudio.Uml.AuxiliaryConstructs;

namespace UmlElementLink
{
  /// <summary>
  /// This class sets rules that are invoked when the model changes.
  /// 
  /// See http://msdn.microsoft.com/en-us/library/ee329482(VS.100).aspx
  /// </summary>
  internal static class AddRulesToModel
  {
    /// <summary>
    /// This isn't actually a validation rule. It's just a way of running some initializations
    /// when the model first opens. It is run only once on opening the model.
    /// </summary>
    /// <param name="context"></param>
    /// <param name="elementToValidate"></param>
    [Export(typeof(System.Action<ValidationContext, object>))]
    [ValidationMethod(ValidationCategories.Open)]
    private static void SetUpRules(ValidationContext context, IModel model)
    {
      // Get the underlying VMSDK store (not the wrapping UML ModelStore):
      Store store = (model as ModelElement).Store;


      // List of rules we want to add:

      // Set a rule that listens for elements being displayed on a diagram:
      SetRule<PresentationAddRule>(store,
        store.DomainDataDirectory.GetDomainRelationship(PresentationViewsSubject.DomainClassId));

      // Add more rules here.

    }

    #region Rule mechanics
    /// <summary>
    /// General procedure to register a rule. See http://msdn.microsoft.com/library/gg616043.aspx
    /// Normally, you set a rule by prefixing the rule class with 
    /// [RuleOn(typeof(TargetClass))]
    /// but we are adding the rule to an existing design at runtime, so must add
    /// the rules to the relevant dictionaries.
    /// </summary>
    /// <typeparam name="T">Rule class</typeparam>
    /// <param name="classInfo">Class or relationship to which to attach the rule.</param>
    private static void SetRule<T>(Store store, DomainClassInfo classInfo) where T : Rule, new()
    {
      T rule = new T();
      rule.FireTime = TimeToFire.TopLevelCommit;

      System.Type tt = typeof(T);
      string ruleSet = (typeof(AddRule).IsAssignableFrom(tt)) ? "AddRules" :
        (typeof(ChangeRule).IsAssignableFrom(tt)) ? "ChangeRules" :
        (typeof(DeleteRule).IsAssignableFrom(tt)) ? "DeleteRules" :
        (typeof(DeletingRule).IsAssignableFrom(tt)) ? "DeletingRules" : "";

      // Rest of this method prises opens the hood to do the following:
      // store.RuleManager.RegisterRule(rule);
      // classInfo.AddRules.Add(rule);

      System.Reflection.BindingFlags privateBinding = System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic;
      System.Reflection.MethodInfo mi = typeof(RuleManager).GetMethod("RegisterRule", privateBinding);
      mi.Invoke(store.RuleManager, new object[] { rule });

      store.RuleManager.EnableRule(typeof(T));

      System.Reflection.PropertyInfo pi = typeof(DomainClassInfo).GetProperty(ruleSet, privateBinding);
      dynamic rules = pi.GetValue(classInfo, null);
      System.Type ruleListType = rules.GetType();
      System.Reflection.FieldInfo listpi = ruleListType.GetField("list", privateBinding);
      dynamic list = listpi.GetValue(rules);
      System.Type listType = list.GetType();
      System.Reflection.MethodInfo addmi = listType.GetMethod("Add");
      addmi.Invoke(list, new object[] { rule });


      System.Reflection.MethodInfo resetRulesCache = typeof(DomainClassInfo).GetMethod("ResetRulesCache", privateBinding);
      resetRulesCache.Invoke(classInfo, null);

    }
    #endregion


  }

}
