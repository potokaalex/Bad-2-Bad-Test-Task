namespace GameCore.CodeBase.Infrastructure.Services.ProgressSaveLoader.Watcher
{
    public interface IProgressReader<in T> : IProgressWatcher where T : IProgressData
    {
        public void OnProgressLoad(T progress);
    }
}