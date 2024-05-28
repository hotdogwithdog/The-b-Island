using UnityEngine;
using Command.Interfaces;

namespace Command.Commands.Movement
{
    public class Jump : ICommand
    {
        private IJumperReceiver _receiver;

        public Jump(IJumperReceiver receiver)
        {
            _receiver = receiver;
        }

        public void Execute()
        {
            _receiver.Jump();
        }
    }
}
