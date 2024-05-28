using UnityEngine;
using Command.Receivers;
using Command.Commands.Movement;

namespace Command.Clients
{
    public class InputManager : MonoBehaviour
    {
        // Es el cliente que acuta sobre el jugador, y a la hora de abrir el menu de pausa
        // actua también sobre el MenuManager pero como es singleton no le hace falta una referencia.

        private Player _player; // Ref to Receiver
        private Invoker.CommandManager _playerCommandManager; // Player Invoker
        // private Invoker.CommandManager _menuCommandManager;

        private void Start()
        {
            _player = GameObject.FindWithTag("Player").GetComponent<Player>();
            _playerCommandManager = new Invoker.CommandManager();
            // _menuCommandManager = new Invoker.CommandManager();
        }


        public void Update()
        {
            // Inputs y su gestion
            if (Input.anyKey)
            {
                switch (Input.inputString)
                {
                    case "d":
                    case "D":
                        _playerCommandManager.ExecuteCommand(new MoveRight(_player));
                        break;
                    case "a":
                    case "A":
                        _playerCommandManager.ExecuteCommand(new MoveLeft(_player));
                        break;
                    case " ":
                        _playerCommandManager.ExecuteCommand(new Jump(_player));
                        break;

                }
            }
        }

    }
}
