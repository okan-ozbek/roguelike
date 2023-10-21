using System;
using System.ComponentModel;
using Entities.Player;
using Enums;
using Generics;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scenes
{
    public class SceneController : SingletonMonoBehaviour<SceneController>
    {
        private void OnEnable()
        {
            PlayerController.Dead += EndScene;
            PlayerController.Win += WinScene;
        }

        private void OnDisable()
        {
            PlayerController.Dead -= EndScene;
            PlayerController.Win -= WinScene;
        }

        public void OpenScene(SceneNameEnum sceneName)
        {
            if (!Enum.IsDefined(typeof(SceneNameEnum), sceneName))
            {
                throw new InvalidEnumArgumentException(nameof(sceneName), (int)sceneName, typeof(SceneNameEnum));
            }

            SceneManager.LoadScene(sceneName.ToString());
        }

        private void EndScene()
        {
            OpenScene(SceneNameEnum.EndScreen);
        }

        private void WinScene()
        {
            OpenScene(SceneNameEnum.WinScreen);
        }
    }
}
