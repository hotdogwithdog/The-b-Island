using UnityEngine;
using System.Collections.Generic;



namespace Menu.Navigation
{
    public class MenuButtonGroup : MonoBehaviour
    {
        private List<MenuButton> _buttons;

        public delegate void ButtonClicked(Menu.Enums.MenuButtons type);
        public ButtonClicked OnButtonClicked;


        public void Start()
        {
            foreach (MenuButton button in this.GetComponentsInChildren<MenuButton>())
            {
                button.OnButtonClick += OnButtonCall;
            }
        }


        private void OnButtonCall(Menu.Enums.MenuButtons type)
        {
            OnButtonClicked?.Invoke(type);
        }
    }
}
