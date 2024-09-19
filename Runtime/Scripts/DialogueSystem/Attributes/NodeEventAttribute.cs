using System;
using UnityEngine;

namespace SimpleDialogueSystem
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    public class NodeEventAttribute : Attribute
    {
        public string Name {  get; }
        public string Hex { get; }
        public NodeEventAttribute(string name)
        {
            Name = name;
            Hex = "ffffff";
        }

        public NodeEventAttribute(string name, string hex)
        {
            Name = name;
            Hex = hex;
        }
    }
}