namespace SimpleDialogueSystem.Infrastructure.NodePlayer
{
    public interface INodePlayer
    {
        public void PlayNode(string nodeId);
        public void PlayNextNode();
        void StartNodeGraph(string id);
    }
}