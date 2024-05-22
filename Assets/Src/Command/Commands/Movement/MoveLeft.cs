using UnityEngine;
using Command.Interfaces;

namespace Command.Commands.Movement
{
    public class MoveLeft : ICommand
    {
        private IMoveableReceiver _receiver;

        public MoveLeft(IMoveableReceiver receiver)
        {
            _receiver = receiver;
        }

        public void Execute()
        {
            Debug.Log("SI");
            _receiver.Move(new Vector2(-1.0f, 0.0f));
        }
    }
}
