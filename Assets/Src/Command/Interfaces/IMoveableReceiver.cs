using UnityEngine;

namespace Command.Interfaces
{
    public interface IMoveableReceiver
    {
        public void Move(Vector2 direction);
    }
}
