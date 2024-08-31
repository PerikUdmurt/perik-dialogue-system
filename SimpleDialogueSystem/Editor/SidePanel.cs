using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class SidePanel : EditorWindow
{
    [SerializeField]
    private VisualTreeAsset m_VisualTreeAsset = default;

    [MenuItem("Window/UI Toolkit/SidePanel")]
    public static void ShowExample()
    {
        SidePanel wnd = GetWindow<SidePanel>();
        wnd.titleContent = new GUIContent("SidePanel");
    }

    public void CreateGUI()
    {
        VisualElement root = rootVisualElement;

        // Instantiate UXML
        VisualElement labelFromUXML = m_VisualTreeAsset.Instantiate();
        root.Add(labelFromUXML);
    }
}
