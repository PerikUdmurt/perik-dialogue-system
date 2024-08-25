﻿using SimpleDialogueSystem.Infrastructure.EventBus;
using UnityEngine;
using UnityEngine.UIElements;

namespace SimpleDialogueSystem.Editors.Nodes
{
    public class NoteNode : BaseNode
    {
        public override string NodeName { get; set; }
        public string NoteText { get; set; }

        public override void Initialize(Vector2 position)
        {
            NodeName = "noname";
            NoteText = "Введите текст заметки / Write text to the note";

            SetPosition(new Rect(position, Vector2.zero));

            SetStyles();
        }

        private void SetStyles()
        {
            mainContainer.AddToClassList("ds-node__main-container");
            extensionContainer.AddToClassList("ds-node__extension-container");
        }

        public override void Draw()
        {
            DrawTitleContainer();
            DrawExtensionContainer();
            RefreshExpandedState();
        }

        private void DrawTitleContainer()
        {
            TextField testTextField = MyElementUtility.AddTextField("Note", NodeName);

            titleContainer.Insert(0, testTextField);
        }

        private void DrawExtensionContainer()
        {
            Foldout foldout = new Foldout()
            {
                text = name
            };

            TextField textField = MyElementUtility.AddTextField("",NoteText);
            foldout.Add(textField);



            extensionContainer.Add(foldout);
        }
    }
}