using Menu.Enums;
using UnityEngine;
using UnityEditor;

namespace Menu.States
{
    public class Options : AMenuState
    {
        public Options() : base("Menus/Options") { }

        protected override void OnMenuNavigation(MenuButtons type)
        {
            switch (type)
            {
                case MenuButtons.Back:
                    // Aquí habrá que diferenciar entre estabas en gameplay o estabas en menu principal,
                    // probablemente con un parámetro en el constructor de Options
                    MenuManager.Instance.SetState(new MainMenu());
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
