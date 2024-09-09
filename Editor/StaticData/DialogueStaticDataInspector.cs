using SimpleDialogueSystem.Editors;
using SimpleDialogueSystem.StaticDatas;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(DialogueStaticData))]
public class DialogueStaticDataInspector : Editor
{
    private DialogueStaticData _data;

    public void Awake()
    {
        _data = (DialogueStaticData)target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("Open in Editor"))
        {
            DialogueSystemWindowEditor.Open(_data);
        }

        //EditorGUILayout.LabelField("DialogueName", _data.DialogueName);
        //EditorGUILayout.LabelField("Nodes", _data.NodeDatas.Count.ToString());
    }
}
