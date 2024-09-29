using SimpleDialogueSystem.DialogueSystem;
using SimpleDialogueSystem.Editors;
using SimpleDialogueSystem.Infrastructure.EventBus;
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MonoDialogueSystem))]
public class DialogueSystemCustomInspector : Editor
{
    private MonoDialogueSystem _dialogueSystem;

    public void Awake()
    {
        _dialogueSystem = (MonoDialogueSystem)target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        ShowEventBusFoldoutGroup();
    }

    //EVENT BUS
    private bool _eventBusIsFolding = false;
    private List<string> _eventNames => EventFinder.EventNames;
    private int _indexOfCurrentEvent = 0;

    private void ShowEventBusFoldoutGroup()
    {
        _eventBusIsFolding = EditorGUILayout.BeginFoldoutHeaderGroup(_eventBusIsFolding, "EventBus");

        if (_eventBusIsFolding)
        {
            int newIndex = _indexOfCurrentEvent;

            newIndex = EditorGUILayout.Popup("Events", newIndex, _eventNames.ToArray());
            if (newIndex != _indexOfCurrentEvent)
            {
                _indexOfCurrentEvent = newIndex;
                EventFinder.TryGetEventType(_eventNames[_indexOfCurrentEvent], out Type eventType);
                IEvent @event = (IEvent)Activator.CreateInstance(eventType);
                _dialogueSystem.EditorData.Event = @event;
            }
            
            EditorGUILayout.PropertyField(serializedObject.FindProperty("EditorData.Event"), true);

            if (GUILayout.Button("Trigger Event"))
            {
                Debug.Log($"Triggered Event {_dialogueSystem.EditorData.Event}");
                _dialogueSystem.Trigger(_dialogueSystem.EditorData.Event);
            }
        }
        EditorGUILayout.EndFoldoutHeaderGroup();
    }
}

