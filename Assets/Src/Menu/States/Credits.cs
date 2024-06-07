using Menu.Enums;
using UnityEngine;
using UnityEditor;

namespace Menu.States
{
    public class Credits : AMenuState
    {
        public Credits() : base("Menus/Credits") { }

        protected override void OnMenuNavigation(MenuButtons type)
        {
            switch (type)
            {
                case MenuButtons.Back:
                    MenuManager.Instance.SetState(new MainMenu());
                    break;
                default:
                    Debug.LogError("ERROR UNKONW MENUBUTTON TYPE: " + type);
                    return;
            }
        }

        public override void Update(float deltaTime)
        {
            if (Input.GetKeyDown(KeyCode.Escape)) MenuManager.Instance.SetState(new MainMenu());
        }
    }
}
