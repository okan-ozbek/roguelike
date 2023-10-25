using System;
using Entities.Player;
using Exceptions;
using Extendables.Generics;
using Scenes.Enums;
using UnityEngine.SceneManagement;

namespace Scenes
{
    public sealed class StaticSceneManager : SingletonMonoBehaviour<StaticSceneManager>
    {
        private void OnEnable()
        {
            PlayerContext.Dead += EndScene;
            PlayerContext.Win += WinScene;
        }

        private void OnDisable()
        {
            PlayerContext.Dead -= EndScene;
            PlayerContext.Win -= WinScene;
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
