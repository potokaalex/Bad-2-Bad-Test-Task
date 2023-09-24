using UnityEngine;

namespace GameCore.CodeBase.Infrastructure.Services.SceneLoader
{
    public class SceneLoaderScreen : MonoBehaviour, ISceneLoaderScreen
    {
        [SerializeField] private Transform _screen;

        public void Show() => _screen.gameObject.SetActive(true);

        public void Hide() => _screen.gameObject.SetActive(false);
    }
}