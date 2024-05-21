using UnityEngine;
using Menu.Enums;
using UnityEngine.EventSystems;

namespace Menu.Navigation
{
    public class MenuButton : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private MenuButtons _type;

        public delegate void ButtonClick(MenuButtons type);
        public ButtonClick OnButtonClick;


        public void OnPointerClick(PointerEventData eventData)
        {
            OnButtonClick?.Invoke(_type);
        }
    }
}
