using Scenes;
using UnityEngine;

namespace Menus
{
    public sealed class MenuManager : MonoBehaviour
    {
        public void ButtonClick(string sceneName)
        {
            StaticSceneManager.Instance.OpenScene(sceneName);
        }
        
        public void Exit()
        {
            Application.Quit();
        }
    }
}
