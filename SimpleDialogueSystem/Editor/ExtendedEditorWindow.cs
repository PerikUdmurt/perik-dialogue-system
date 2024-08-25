using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

public static class EditorWindowExtension
{
    public static void AddProperties(this VisualElement rootVisualElement, SerializedProperty prop, bool drawChildren)
    {
        string lastPropPath = string.Empty;
        foreach (SerializedProperty p in prop)
        {
            if (p.isArray && p.propertyType == SerializedPropertyType.Generic)
            {
                Foldout foldout = new Foldout()
                {
                    text = p.displayName
                };
                Debug.Log(p.displayName);
                rootVisualElement.Add(foldout);

                if (p.isExpanded)
                {
                    foldout.AddProperties(p, drawChildren);
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(lastPropPath) && p.propertyPath.Contains(lastPropPath))
                {
                    continue;
                }
                lastPropPath = p.propertyPath;

                PropertyField field = new PropertyField(p, p.displayName);
                Debug.Log("Field");
            }
        }
    }
}
