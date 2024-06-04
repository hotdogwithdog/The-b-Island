using Menu.Enums;
using UnityEngine;
using UnityEditor;

namespace Menu.States
{
    public class Pause : AMenuState
    {
        public Pause() : base("Menus/Pause") { }

        protected override void OnMenuNavigation(MenuButtons type)
        {
            switch (type)
            {
                case MenuButtons.Options:
                    MenuManager.Instance.SetState(new Options());
                    break;
                case MenuButtons.Back:
                    //MenuManager.Instance.SetState(new Gameplay());
                    break;
                default:
                    Debug.LogError("ERROR UNKONW MENUBUTTON TYPE: " + type);
                    return;
            }
        }

        public override void Update(float deltaTime)
        {
        }
    }
}
