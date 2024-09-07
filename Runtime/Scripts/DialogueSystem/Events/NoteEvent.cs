using SimpleDialogueSystem.Infrastructure.EventBus;
using System;

namespace SimpleDialogueSystem.Events
{
    [NodeEvent("Заметка"), Serializable]
    public struct NoteEvent: IEvent
    {
        public string text;

        public NoteEvent(string text)
        {  this.text = text; }
    }
}