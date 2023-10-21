using Enums;
using Scenes;
using UnityEngine;

namespace Menus
{
    public class WinMenuController : MonoBehaviour
    {
        public void ContinueButtonOnClick()
        {
            SceneController.Instance.OpenScene(SceneNameEnum.StartScreen);
        }
    }
}
