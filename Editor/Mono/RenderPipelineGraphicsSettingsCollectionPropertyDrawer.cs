// Unity C# reference source
// Copyright (c) Unity Technologies. For terms of use, see
// https://unity3d.com/legal/licenses/Unity_Reference_Only_License

using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

namespace UnityEditor.Rendering
{
    [CustomPropertyDrawer(typeof(RenderPipelineGraphicsSettingsCollection))]
    internal class RenderPipelineGraphicsSettingsCollectionPropertyDrawer : PropertyDrawer
    {
        internal static SortedDictionary<string, SortedDictionary<string, PropertyField>> Categorize(SerializedProperty property)
        {
            var showAllHiddenProperties = Unsupported.IsDeveloperMode();
            SortedDictionary<string, SortedDictionary<string, PropertyField>> categories = new();
            foreach (SerializedProperty prop in property.Copy())
            {
                if (prop == null || prop.boxedValue == null)
                    continue;

                var type = prop.boxedValue.GetType();

                //remove array length property
                if (!typeof(IRenderPipelineGraphicsSettings).IsAssignableFrom(type))
                    continue;

                var hideInInspector = type.GetCustomAttribute<HideInInspector>();
                if (!showAllHiddenProperties && hideInInspector != null)
                    continue;

                var typeName = ObjectNames.NicifyVariableName(type.Name);
                var name = type.GetCustomAttribute<CategoryAttribute>()?.Category ?? typeName;

                //sort per type in category
                if (categories.TryGetValue(name, out var categoryElement))
                {
                    if (categoryElement.ContainsKey(typeName))
                        Debug.LogWarning($"{nameof(IRenderPipelineGraphicsSettings)} {typeName} is duplicated. Only showing first one.");
                    else
                    {
                        var field = CreatePropertyField(prop, hideInInspector == null);
                        categoryElement.Add(typeName, field);
                    }
                }
                else
                {
                    //sort per category
                    var field = CreatePropertyField(prop, hideInInspector == null);
                    categories.Add(name, new SortedDictionary<string, PropertyField>()
                    {
                        { typeName, field }
                    });
                }
            }

            return categories;
        }

        private static PropertyField CreatePropertyField(SerializedProperty prop, bool isEnable)
        {
            var propertyField = new PropertyField(prop);
            propertyField.SetEnabled(isEnable);
            return propertyField;
        }

        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            var root = new VisualElement { name = "GlobalSettingsCollection" };
            foreach (var category in Categorize(property.FindPropertyRelative("m_List")))
            {
                var foldout = new Foldout() { text = category.Key };
                foreach (var element in category.Value)
                    foldout.Add(element.Value);
                root.Add(foldout);
            }

            return root;
        }
    }
}
