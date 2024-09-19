using SimpleDialogueSystem.Infrastructure.EventBus;
using System;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public static class EditorWindowExtension
{
    public static void DrawProperties(this VisualElement rootVisualElement, ref object obj)
    {
        if (obj == null) return;

        Type type = obj.GetType();

        FieldInfo[] fields = type.GetFields();

        foreach (FieldInfo field in fields)
        {
            
            if (field.FieldType.IsStruct())
            {
                Foldout foldout = new Foldout()
                {
                    text = field.Name,
                };

                var sda = field.GetValue(obj);

                foldout.DrawProperties(ref sda);
                rootVisualElement.Add(foldout);
            }
            

            if (field.FieldType == typeof(int))
            {
                IntegerField intField = new IntegerField(field.Name)
                { value = (int)field.GetValue(obj) };
                intField.Bind(obj, field);
                rootVisualElement.Add(intField);
            }

            if (field.FieldType == typeof(float))
            {
                FloatField floatField = new FloatField(field.Name)
                { value = (float)field.GetValue(obj) };
                floatField.Bind(obj, field);
                rootVisualElement.Add(floatField);
            }

            if (field.FieldType == typeof(string))
            {
                TextField textField = new TextField(field.Name)
                { value = (string)field.GetValue(obj) };
                textField.Bind(obj, field);
                rootVisualElement.Add(textField);
            }

            if (field.FieldType.IsEnum)
            {
                EnumField enumField = new EnumField(field.Name, (Enum)field.GetValue(obj));
                enumField.Bind(obj, field);
                rootVisualElement.Add(enumField);
            }

            if (field.FieldType == typeof(double))
            {
                DoubleField doubleField = new DoubleField(field.Name)
                { value = (double)field.GetValue(obj) };
                doubleField.Bind(obj, field);
                rootVisualElement.Add(doubleField);
            }

            if (field.FieldType == typeof(Vector3))
            {
                Vector3Field vector3Field = new Vector3Field(field.Name)
                { value = (Vector3)field.GetValue(obj) };
                vector3Field.Bind(obj, field);
                rootVisualElement.Add(vector3Field);
            }

            if (field.FieldType == typeof(Vector2))
            {
                Vector2Field vector3Field = new Vector2Field(field.Name)
                { value = (Vector2)field.GetValue(obj) };
                vector3Field.Bind(obj, field);
                rootVisualElement.Add(vector3Field);
            }

            if (field.FieldType == typeof(Vector4))
            {
                Vector4Field vector3Field = new Vector4Field(field.Name)
                { value = (Vector4)field.GetValue(obj) };
                vector3Field.Bind(obj, field);
                rootVisualElement.Add(vector3Field);
            }
        }
    }

    private static void Bind<T>(this INotifyValueChanged<T> visualElement, object targetObj, FieldInfo field)
        => visualElement.RegisterValueChangedCallback((c) => OnChangeValue(targetObj, field, visualElement));

    private static void OnChangeValue<T>(object targetObj, FieldInfo field, INotifyValueChanged<T> visualElement)
        => field.SetValue(targetObj, visualElement.value);
}
