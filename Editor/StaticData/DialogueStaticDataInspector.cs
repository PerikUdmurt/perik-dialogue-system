using SimpleDialogueSystem.Editors;
using SimpleDialogueSystem.StaticDatas;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(DialogueStaticData))]
public class DialogueStaticDataInspector : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("Open in Editor"))
        {
            DialogueSystemWindowEditor.Open((DialogueStaticData)target);
        }
    }
}
