using Menu.Enums;
using UnityEngine;
using UnityEditor;

namespace Menu.States
{
    public class Options : AMenuState
    {
        private bool _comeFromGameplay;
        public Options(bool comeFromGameplay) : base("Menus/Options") 
        {
            _comeFromGameplay = comeFromGameplay;
        }

        protected override void OnMenuNavigation(MenuButtons type)
        {
            switch (type)
            {
                case MenuButtons.Back:
                    if (_comeFromGameplay) MenuManager.Instance.SetState(new Pause());
                    else MenuManager.Instance.SetState(new MainMenu());
                    break;
                default:
                    Debug.LogError("ERROR UNKONW MENUBUTTON TYPE: " + type);
                    return;
            }
        }

        public override void Update(float deltaTime)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (_comeFromGameplay) MenuManager.Instance.SetState(new Pause());
                else MenuManager.Instance.SetState(new MainMenu());
            }
        }
    }
}
