using UnityEngine;
using System.Collections.Generic;
using Observer.Subjects;
using Observer.Observers;
using Menu.Enums;

namespace Menu.Navigation
{
    public class MenuButtonGroup : MonoBehaviour, ISubject_void_MenuButtons, IObserver_void_MenuButtons
    {
        private List<IObserver_void_MenuButtons> _observers = new List<IObserver_void_MenuButtons>();

        // si fuera con delegates (patron observador ya presente en el lenguaje)
        // public delegate void ButtonClicked(Menu.Enums.MenuButtons type);
        // public ButtonClicked OnButtonClicked;


        public void Start()
        {
            foreach (MenuButton button in this.GetComponentsInChildren<MenuButton>())
            {
                // button.OnButtonClick += OnButtonCall;

                button.Subscribe(this);
            }
        }

        public void OnDestroy()
        {
            foreach (MenuButton button in this.GetComponentsInChildren<MenuButton>())
            {
                // button.OnButtonClick -= OnButtonCall;

                button.Unsuscribe(this);
            }
        }


        // private void OnButtonCall(Menu.Enums.MenuButtons type)
        // {
        //     OnButtonClicked?.Invoke(type);
        // }

        public void Invoke(MenuButtons buttonType)
        {
            foreach (IObserver_void_MenuButtons observer in _observers)
            {
                observer.Notify(buttonType);
            }
        }

        public void Subscribe(IObserver_void_MenuButtons observer)
        {
            _observers.Add(observer);
        }

        public void Unsuscribe(IObserver_void_MenuButtons observer)
        {
            _observers.Remove(observer);
        }

        public void Notify(MenuButtons buttonType)
        {
            Invoke(buttonType);
        }
    }
}
