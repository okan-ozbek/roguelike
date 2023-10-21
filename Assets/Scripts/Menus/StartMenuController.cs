using Enums;
using Scenes;
using UnityEngine;

namespace Menus
{
    public class StartMenuController : MonoBehaviour
    {
        public void StartButtonOnClick()
        {
            SceneController.Instance.OpenScene(SceneNameEnum.Game);
        }

        public void SettingsButtonOnClick()
        {
            // TODO: Not implemented yet.
        }

        public void ExitButtonOnClick()
        {
            Application.Quit();
        }
    }
}