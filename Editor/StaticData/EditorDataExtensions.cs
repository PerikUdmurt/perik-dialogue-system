﻿using SimpleDialogueSystem.Editors.Nodes;
using SimpleDialogueSystem.Events;
using SimpleDialogueSystem.Infrastructure.EventBus;
using SimpleDialogueSystem.StaticDatas;
using System.Collections.Generic;
using System.Linq;

namespace SimpleDialogueSystem.Editors
{
    public static class EditorDataExtensions
    {
        public static DialogueNodeStaticData ToDialogueNode(this SimpleNode editorNode)
            => new DialogueNodeStaticData()
            {
                ID = editorNode.ID,
                Position = editorNode.GetPosition().position.ToVector2Data(),
                NextNodesID = new(),
                EventDatas = CreateEventStaticDatas(editorNode.Events)
            };

        private static List<EventStaticData> CreateEventStaticDatas(List<IEvent> events)
        {
            List<EventStaticData> eventDatas = new List<EventStaticData>();

            foreach (var e in events)
            {
                EventStaticData eventData = e.ToEventStaticData();

                eventDatas.Add(eventData);
            }

            return eventDatas;
        }

        public static NoteData ToNoteData(this NoteNode note)
        {
            return new NoteData()
            {
                Text = note.contents,
                Position = note.GetPosition().position
            };
        }
    }
}