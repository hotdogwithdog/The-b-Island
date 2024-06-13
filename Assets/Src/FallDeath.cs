using UnityEngine;
using System.Collections.Generic;
using Observer.Subjects;
using Observer.Observers;

namespace Limits
{
    public class FallDeath : MonoBehaviour, ISubject_void
    {
        private List<IObserver_void> _observers = new List<IObserver_void>();


        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                Invoke();
            }
        }

        public void Invoke()
        {
            foreach(IObserver_void observer in _observers)
            {
                observer.Notify();
            }
        }

        public void Suscribe(IObserver_void observer)
        {
            _observers.Add(observer);
        }

        public void Unsuscribe(IObserver_void observer)
        {
            _observers.Remove(observer);
        }
    }
}

