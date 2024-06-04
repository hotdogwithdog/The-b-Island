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
                case MenuButtons.Resume:
                    MenuManager.Instance.SetState(new Gameplay());
                    break;
                case MenuButtons.Options:
                    MenuManager.Instance.SetState(new Options(true));
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
            if (Input.GetKeyDown(KeyCode.Escape)) MenuManager.Instance.SetState(new Gameplay());
        }
    }
}
