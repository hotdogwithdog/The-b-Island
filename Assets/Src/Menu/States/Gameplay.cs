using Menu.Interfaces;
using UnityEngine;

namespace Menu.States
{
    public class Gameplay : IMenuState
    {
        // En este estado de gameplay se podría llegar a tener una submáquina de estados que controlase los niveles o algo del estilo.
        public Gameplay() { }

        public void Enter()
        {
            // No necesita hacer nada
        }

        public void Exit()
        {
            // No necesita hacer nada
        }

        public void Update(float deltaTime)
        {
            // aquí podría ir sin problemas la gestion del input para abrir el menu de pausa
            if (Input.GetKeyDown(KeyCode.Escape)) MenuManager.Instance.SetState(new Pause());
        }
    }
}
