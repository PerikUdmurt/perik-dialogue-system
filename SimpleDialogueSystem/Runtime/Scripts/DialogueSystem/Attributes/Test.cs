using SimpleDialogueSystem;
using SimpleDialogueSystem.Events;
using System;
using System.Linq;
using System.Reflection;
using UnityEngine;

[Serializable]
public class Test : MonoBehaviour
{
    public OnBeginPhraseEventData data;
    public float field;
    public Test test;
    public Test2 test2;

    [ContextMenu("GetAssembly")]
    public void GetAssebly()
    {

        Assembly assembly = Assembly.Load("Assembly-CSharp-firstpass");

        Debug.Log(assembly.FullName);

        var events = from m in assembly.GetTypes()
                      from a in m.GetCustomAttributes(typeof(NodeEventAttribute), false)
                      select m;

        foreach ( var @event in events )
        {
            Debug.Log(@event);
            NodeEventAttribute attribute = (NodeEventAttribute)@event.GetCustomAttribute(typeof(NodeEventAttribute));
            Debug.Log(attribute.Rgba + attribute.Name);
        }
    }

    [Serializable]
     public class Test2
    {
        public float field;
        public float field2;
    }
    
}
