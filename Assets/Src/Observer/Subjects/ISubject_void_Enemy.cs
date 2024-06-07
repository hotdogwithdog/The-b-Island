

namespace Observer.Subjects
{
    public interface ISubject_void_Enemy
    {
        public void Invoke(Command.Receivers.Enemy enemy);

        public void Subscribe(Observers.IObserver_void_Enemy observer);

        public void Unsuscribe(Observers.IObserver_void_Enemy observer);
    }
}
