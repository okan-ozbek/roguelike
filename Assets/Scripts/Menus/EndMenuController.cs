using Enums;
using Scenes;
using UnityEngine;

namespace Menus
{
    public class EndMenuController : MonoBehaviour
    {
        public void ContinueButtonOnClick()
        {
            SceneController.Instance.OpenScene(SceneNameEnum.StartScreen);
        }
    }
}