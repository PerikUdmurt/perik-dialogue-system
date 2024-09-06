using System;

namespace SimpleDialogueSystem
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    public class NodeEventAttribute : Attribute
    {
        public string Name {  get; }
        public (float, float, float, float) Rgba {  get; }
        public NodeEventAttribute(string name, float R, float G, float B, float A)
        {
            Name = name;
            Rgba = (R, G, B, A);
        }
    }
}