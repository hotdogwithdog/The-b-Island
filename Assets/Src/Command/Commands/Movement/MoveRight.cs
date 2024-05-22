using UnityEngine;
using Command.Interfaces;

namespace Command.Commands.Movement
{
    public class MoveRight : ICommand
    {
        private IMoveableReceiver _receiver;

        public MoveRight(IMoveableReceiver receiver)
        {
            _receiver = receiver;
        }

        public void Execute()
        {
            _receiver.Move(new Vector2(1.0f, 0.0f));
        }
    }
}
