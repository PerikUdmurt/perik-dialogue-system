namespace SimpleDialogueSystem.Infrastructure.NodePlayer
{
    public abstract class BaseNodePlayer
    {
        public abstract void SelectNode(int index);
        public abstract void StartDialogue(string id);
        public abstract void PlayNextNode();
    }
}