namespace SimpleDialogueSystem.Model.DialoguePlayer
{
    public abstract class BaseNodePlayer
    {
        public abstract void PlayNode(BaseDialogueNode node);
        public abstract void SelectNode(int index);
        public abstract void StartDialogue(string id);
        public abstract void PlayNextNode();
    }
}