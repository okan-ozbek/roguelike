using System;
using System.ComponentModel;
using Entities.Player;
using Enums;
using Exceptions;
using Generics;
using UnityEngine.SceneManagement;

namespace Scenes
{
    public class StaticSceneManager : SingletonMonoBehaviour<StaticSceneManager>
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
                throw new SceneNameNotFoundException();
            }

            SceneManager.LoadScene(sceneName.ToString());
        }
        
        public void OpenScene(string sceneName)
        {
            if (!Enum.IsDefined(typeof(SceneNameEnum), sceneName))
            {
                throw new SceneNameNotFoundException();
            }

            SceneManager.LoadScene(sceneName);
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
