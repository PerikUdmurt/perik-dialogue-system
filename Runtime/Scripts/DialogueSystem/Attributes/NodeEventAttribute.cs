using System;
using UnityEngine;

namespace SimpleDialogueSystem
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    public class NodeEventAttribute : Attribute
    {
        public string Name {  get; }
        public NodeEventAttribute(string name)
        {
            Name = name;
        }
    }
}