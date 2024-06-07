using UnityEngine;
using Menu.Enums;
using UnityEngine.EventSystems;
using Observer.Subjects;
using Observer.Observers;
using System.Collections.Generic;

namespace Menu.Navigation
{
    public class MenuButton : MonoBehaviour, IPointerClickHandler, ISubject_void_MenuButtons
    {
        [SerializeField] private MenuButtons _type;

        private List<IObserver_void_MenuButtons> _observers = new List<IObserver_void_MenuButtons>();

        // Si se hiciera con delegates (Patron observador ya creado por el lenguaje)
        // public delegate void ButtonClick(MenuButtons type);
        // public ButtonClick OnButtonClick;


        public void OnPointerClick(PointerEventData eventData)
        {
            // OnButtonClick?.Invoke(_type);

            Invoke(_type);
        }

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
    }
}
