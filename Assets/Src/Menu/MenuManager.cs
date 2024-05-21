using UnityEngine;
using Menu.Interfaces;
using Menu.States;

namespace Menu
{
    public class MenuManager : GeneralPurpose.Singleton<MenuManager>
    {
        private IMenuState _currentState;

        public IMenuState CurrentState { get { return _currentState; }}


        public void Start()
        {
            SetState(new MainMenu());
        }

        public void SetState(IMenuState newState)
        {
            if (_currentState != null) _currentState.Exit();

            _currentState = newState;

            _currentState.Enter();
        }
    }
}
