using Menu.Enums;
using UnityEngine;
using UnityEditor;

namespace Menu.States
{
    public class MainMenu : AMenuState
    {
        public MainMenu() : base("Menus/Main_Menu") { }

        protected override void OnMenuNavigation(MenuButtons type)
        {
            switch (type)
            {
                case MenuButtons.Play:
                    Debug.Log("Has pulsado Play");
                    break;
                case MenuButtons.Options:
                    MenuManager.Instance.SetState(new Options());
                    break;
                case MenuButtons.Credits:
                    MenuManager.Instance.SetState(new Credits());
                    break;
                case MenuButtons.Quit:
                    #if UNITY_EDITOR
                        EditorApplication.isPlaying = false;
                    #else
                        Application.Quit();
                    #endif
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
