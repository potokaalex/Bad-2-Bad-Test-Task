namespace GameCore.CodeBase.Infrastructure.Services.ProgressSaveLoader.Watcher
{
    public interface IProgressWriter<in T> : IProgressWatcher where T : IProgressData
    {
        public void OnProgressSave(T progress);
    }
}