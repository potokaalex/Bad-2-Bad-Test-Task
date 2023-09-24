using System.Collections.Generic;
using System.IO;
using GameCore.CodeBase.Infrastructure.Services.ProgressSaveLoader.Watcher;
using UnityEngine;

namespace GameCore.CodeBase.Infrastructure.Services.ProgressSaveLoader
{
    public class ProgressSaveLoader : IProgressSaveLoader
    {
        private const string Extension = ".dat";
        private static readonly string StoragePath = $"{Application.dataPath}/DataStorage";
        private readonly List<IProgressWatcher> _watchers = new();

        public ProgressSaveLoader()
        {
            if (!Directory.Exists(StoragePath))
                Directory.CreateDirectory(StoragePath);
        }

        public void RegisterWatcher(IProgressWatcher watcher) => _watchers.Add(watcher);

        public void UnRegisterWatcher(IProgressWatcher watcher) => _watchers.Remove(watcher);

        public void ClearWatchers() => _watchers.Clear();

        public void Load<T>() where T : IProgressData, new()
        {
            var filePath = GetFilePath<T>();

            if (!File.Exists(filePath))
                return;

            using var streamReader = new StreamReader(filePath, false);
            var data = JsonUtility.FromJson<T>(streamReader.ReadToEnd());

            if (data == null)
                return;

            foreach (var watcher in _watchers)
                if (watcher is IProgressReader<T> progressReader)
                    progressReader.OnProgressLoad(data);
        }

        public void Save<T>() where T : IProgressData, new()
        {
            var data = new T();

            foreach (var watcher in _watchers)
                if (watcher is IProgressWriter<T> progressWriter)
                    progressWriter.OnProgressSave(data);

            using var streamWriter = new StreamWriter(GetFilePath<T>(), false);
            streamWriter.Write(JsonUtility.ToJson(data));
        }

        private static string GetFilePath<T>() where T : IProgressData
            => $"{StoragePath}/{typeof(T).Name + Extension}";
    }
}