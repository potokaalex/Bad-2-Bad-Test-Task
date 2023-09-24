using GameCore.CodeBase.Infrastructure.Services.ProgressSaveLoader.Watcher;

namespace GameCore.CodeBase.Infrastructure.Services.ProgressSaveLoader
{
    public interface IProgressSaveLoader
    {
        public void RegisterWatcher(IProgressWatcher watcher);
        
        public void UnRegisterWatcher(IProgressWatcher watcher);

        public void ClearWatchers();

        public void Save<T>() where T : IProgressData, new();

        public void Load<T>() where T : IProgressData, new();
    }
}