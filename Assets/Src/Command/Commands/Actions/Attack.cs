using UnityEngine;
using Command.Interfaces;

namespace Command.Commands.Actions
{
    public class Attack : ICommand
    {
        private IAttackReceiver _receiver;

        public Attack(IAttackReceiver receiver)
        {
            _receiver = receiver;
        }

        public void Execute()
        {
            _receiver.Attack();
        }
    }
}
