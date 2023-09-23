using System;
using UnityEngine.SceneManagement;

namespace GameCore.CodeBase.Infrastructure.Services.SceneLoader
{
    public class SceneLoader : ISceneLoader
    {
        public void LoadSceneAsync(string sceneName, Action afterLoading = null)
        {
            SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single).completed +=
                _ => afterLoading?.Invoke();
        }
    }
}