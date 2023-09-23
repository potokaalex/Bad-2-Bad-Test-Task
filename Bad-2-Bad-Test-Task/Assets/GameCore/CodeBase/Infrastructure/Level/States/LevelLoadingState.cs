using GameCore.CodeBase.Infrastructure.Services.SceneLoader;
using GameCore.CodeBase.Infrastructure.Services.StateMachine;

namespace GameCore.CodeBase.Infrastructure.Level.States
{
    public class LevelLoadingState : IState
    {
        private readonly ISceneLoader _sceneLoader;
        private readonly ISceneLoaderScreen _loadingScreen;
        private readonly ScenesStaticData _scenesData;

        public LevelLoadingState(ISceneLoader sceneLoader, ISceneLoaderScreen loadingScreen, ScenesStaticData scenesData)
        {
            _sceneLoader = sceneLoader;
            _loadingScreen = loadingScreen;
            _scenesData = scenesData;
        }

        public void Enter()
        {
            _loadingScreen.Show();
            _sceneLoader.LoadSceneAsync(_scenesData.LevelSceneName, () => _loadingScreen.Hide());
        }
    }
}