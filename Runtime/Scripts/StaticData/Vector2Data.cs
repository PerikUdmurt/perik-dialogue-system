using System;

namespace SimpleDialogueSystem.StaticDatas
{
    [Serializable]
    public struct Vector2Data
    {
        public float x;
        public float y;

        public Vector2Data(float x, float y)
        {
            this.x = x;
            this.y = y;
        }
    }
}