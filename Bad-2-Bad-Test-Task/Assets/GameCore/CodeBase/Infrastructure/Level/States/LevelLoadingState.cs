using GameCore.CodeBase.Infrastructure.Services.SceneLoader;
using GameCore.CodeBase.Infrastructure.Services.StateMachine;
using GameCore.CodeBase.Infrastructure.Services.StateMachine.States;
using Zenject;

namespace GameCore.CodeBase.Infrastructure.Level.States
{
    public class LevelLoadingState : StateBase, IEnterState
    {
        private ISceneLoader _sceneLoader;
        private ISceneLoaderScreen _loadingScreen;
        private ScenesStaticData _scenesData;

        [Inject]
        private void Construct(ISceneLoader sceneLoader, ISceneLoaderScreen loadingScreen,
            ScenesStaticData scenesData)
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