using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Command.Interfaces;

namespace Command.Invoker
{
    public class CommandManager
    {
        // No tenemos una lista con los comandos ejecutados y posibilidad de deshacelros por dise�o, es decir nuestro command pattern
        // se reduce a tener generalizaci�n a la hora del movimiento, pues jugador y enemigos se van a mover igual.
        // Y para la navegaci�n de los menus tampoco queremos realmente tener un deshacer.
        public void ExecuteCommand(ICommand command)
        {
            command.Execute();
        }
    }
}

