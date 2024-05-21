using UnityEngine;

namespace Menu.States
{
    public abstract class AMenuState : Interfaces.IMenuState
    {
        protected Canvas _canvas;
        protected readonly string _menuName;
        protected GameObject _menu;

        protected AMenuState(string nameMenu)
        {
            _menuName = nameMenu;
        }


        public void Enter()
        {
            _canvas = GameObject.FindWithTag("Canvas").GetComponent<Canvas>();
            GameObject menuPrefab = (GameObject)Resources.Load(_menuName);
            _menu = GameObject.Instantiate(menuPrefab, _canvas.transform);

            // suscripcion al observer para la logica de los menus, me lo llevo a sobrescribir  el método en cada menu en concreto
            _menu.GetComponentInChildren<Menu.Navigation.MenuButtonGroup>().OnButtonClicked += OnMenuNavigation;
        }

        protected abstract void OnMenuNavigation(Menu.Enums.MenuButtons type);

        public void Exit()
        {
            GameObject.Destroy(_menu);
        }

        public abstract void Update(float deltaTime);
    }
}
