using Menu.Enums;
using UnityEngine;
using UnityEngine.SceneManagement;
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
                    MenuManager.Instance.SetState(new Gameplay());

                    SceneManager.LoadScene("Level1");

                    break;
                case MenuButtons.Options:
                    MenuManager.Instance.SetState(new Options(false));
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
