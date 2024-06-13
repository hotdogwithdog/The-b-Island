using Observer.Observers;

namespace Observer.Subjects
{
    public interface ISubject_void
    {
        public void Invoke();

        public void Suscribe(IObserver_void observer);

        public void Unsuscribe(IObserver_void observer);
    }
}
