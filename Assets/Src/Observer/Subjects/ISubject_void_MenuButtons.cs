

namespace Observer.Subjects
{
    public interface ISubject_void_MenuButtons
    {
        public void Invoke(Menu.Enums.MenuButtons buttonType);

        public void Subscribe(Observers.IObserver_void_MenuButtons observer);

        public void Unsuscribe(Observers.IObserver_void_MenuButtons observer);
    }
}
