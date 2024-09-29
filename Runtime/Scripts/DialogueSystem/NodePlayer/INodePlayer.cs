namespace SimpleDialogueSystem.DialogueSystem.NodePlayers
{
    public interface INodePlayer
    {
        public void PlayNode(string nodeId);
        public void PlayNextNode();
    }
}