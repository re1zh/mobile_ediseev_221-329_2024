using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using WMPLib;

namespace AudioPlayerLib
{
    public class AudioPlayer
    {
        #region Поля
        private readonly WindowsMediaPlayer wmp = new();
        private readonly List<string> playlistPaths = new();
        private readonly List<string> safeFileNames = new();
        private int currentTrackIndex = -1;
        public event Action<int>? OnTrackChanged;
        public enum PlayerState
        {
            Playing,
            Paused,
            Stopped
        }
        public event Action<PlayerState> OnPlayStateChanged;
        #endregion

        public AudioPlayer()
        {
            wmp.settings.volume = 25;
            wmp.PlayStateChange += OnPlayStateChange;
        }

        // Обработчик события изменения состояния плеера
        private void OnPlayStateChange(int newState)
        {
            WMPPlayState state = (WMPPlayState)newState;

            switch (state)
            {
                case WMPPlayState.wmppsPlaying:
                    OnPlayStateChanged?.Invoke(PlayerState.Playing);
                    break;
                case WMPPlayState.wmppsPaused:
                    OnPlayStateChanged?.Invoke(PlayerState.Paused);
                    break;
                case WMPPlayState.wmppsStopped:
                    OnPlayStateChanged?.Invoke(PlayerState.Stopped);
                    break;
                case WMPPlayState.wmppsMediaEnded:
                    Next();
                    OnTrackChanged?.Invoke(currentTrackIndex);
                    break;
                case WMPPlayState.wmppsReady:
                    if (currentTrackIndex != -1)
                    {
                        Play();
                    }
                    break;
                        
            }
        }

        #region Геттеры
        public List<string> GetPlaylistPaths() => new List<string>(playlistPaths);
        public List<string> GetPlaylist() => new List<string>(safeFileNames);
        public int GetCurrentTrackIndex() => currentTrackIndex;
        public int GetVolume()
        {
            return wmp?.settings.volume ?? 25;
        }
        public double GetCurrentPosition()
        {
            return wmp.controls.currentPosition;
        }
        public string GetCurrentPositionString()
        {
            return wmp.controls.currentPositionString;
        }
        public double GetDuration()
        {
            return wmp.currentMedia?.duration ?? 0;
        }
        public string GetDurationString()
        {
            return wmp.controls.currentItem.durationString;
        }
        public string GetTrackDuration(string filePath)
        {
            try
            {
                WindowsMediaPlayer tempPlayer = new WindowsMediaPlayer();
                IWMPMedia media = tempPlayer.newMedia(filePath);

                double durationInSeconds = media.duration;

                int minutes = (int)(durationInSeconds / 60);
                int seconds = (int)(durationInSeconds % 60);

                return $"{minutes:D2}:{seconds:D2}";
            }
            catch (Exception)
            {
                return "00:00";
            }
        }
        public double GetTrackDurationSeconds(string filePath)
        {
            WindowsMediaPlayer tempPlayer = new WindowsMediaPlayer();
            IWMPMedia media = tempPlayer.newMedia(filePath);

            double durationInSeconds = media.duration;

            return durationInSeconds;
        }
        #endregion

        #region Сеттеры
        public void SetCurrentPosition(double position)
        {
            wmp.controls.currentPosition = position;
        }
        public void SetVolume(int volume)
        {
            if (!isNull())
            {
                wmp.settings.volume = volume;
            }
        }
        public void SetRate(float speed)
        {
            if (!isNull())
            {
                if (speed >= 0.5f && speed <= 2.0f)
                {
                    wmp.settings.rate = speed;
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(speed),
                        "Скорость должна быть в диапазоне от 0.5x до 2.0x.");
                }
            }
        }
        #endregion

        #region Проверки состояний
        public bool isPlaying()
        {
            return wmp.playState == WMPLib.WMPPlayState.wmppsPlaying;
        }
        public bool isPaused()
        {
            return wmp.playState == WMPLib.WMPPlayState.wmppsPaused;
        }
        public bool isStopped()
        {
            return wmp.playState == WMPLib.WMPPlayState.wmppsStopped;
        }
        public bool isNull()
        {
            return wmp == null;
        }
        #endregion

        // Добавление трека в плейлист
        public void AddToPlaylist(string filePath)
        {
            if (System.IO.File.Exists(filePath))
                playlistPaths.Add(filePath);
            safeFileNames.Add(System.IO.Path.GetFileName(filePath));
        }

        // Удаление трека из плейлиста
        public void RemoveFromPlaylist(int index)
        {
            if (index >= 0 && index < playlistPaths.Count)
            {
                if (index == currentTrackIndex) Stop();

                playlistPaths.RemoveAt(index);
                safeFileNames.RemoveAt(index);

                if (currentTrackIndex >= playlistPaths.Count)
                {
                    currentTrackIndex = playlistPaths.Count - 1;
                }
                else
                {
                    currentTrackIndex = -1;
                }
            }
        }

        // Выбор трека
        public void SelectTrack(int index)
        {
            if (index >= 0 && index < playlistPaths.Count)
            {
                currentTrackIndex = index;
                wmp.URL = playlistPaths[currentTrackIndex];
                OnTrackChanged?.Invoke(currentTrackIndex);
                Play();
            }
            else
            {
                Console.WriteLine("Неверный номер трека.");
            }
        }

        // Проигрывание трека
        public void Play()
        {
            if (currentTrackIndex >= 0 && currentTrackIndex < playlistPaths.Count)
            {
                if (!isPlaying())
                {
                    if (wmp.URL != playlistPaths[currentTrackIndex])
                    {
                        wmp.URL = playlistPaths[currentTrackIndex];
                    }
                    wmp.controls.play();
                }
            }
            else if (isPlaying())
            {
                Console.WriteLine("Трек уже играет.");
            }
            else
            {
                Console.WriteLine("Трек не выбран или плейлист пуст.");
            }
        }

        // Пауза
        public void Pause()
        {
            if (!isNull() && isPlaying())
            {
                wmp.controls.pause();
                Console.WriteLine("На паузе.");
            }
        }

        // Стоп
        public void Stop()
        {
            wmp.controls.stop();
            Console.WriteLine("Стоп.");
        }

        // Следующий трек
        public void Next()
        {
            if (playlistPaths.Count > 0 && currentTrackIndex >= 0)
            {
                currentTrackIndex = (currentTrackIndex + 1) % playlistPaths.Count;

                Console.WriteLine($"Следующий трек: {safeFileNames[currentTrackIndex]}");

                wmp.URL = playlistPaths[currentTrackIndex];
                Play();
            }
            else
            {
                Console.WriteLine("Плейлист пуст.");
                return;
            }
        }

        // Предыдущий трек
        public void Previous()
        {
            if (playlistPaths.Count > 0 && currentTrackIndex >= 0)
            {
                currentTrackIndex = (currentTrackIndex - 1 + playlistPaths.Count) % playlistPaths.Count;
                wmp.URL = playlistPaths[currentTrackIndex];
                Play();
            } 
            else
            {
                Console.WriteLine("Плейлист пуст.");
                return;
            }
        }

        // Перемешивание плейлиста
        public void Shuffle()
        {
            var rand = new Random();
            var count = playlistPaths.Count;

            for (int i = 0; i < count; i++)
            {
                int j = rand.Next(i, count);
                (playlistPaths[i], playlistPaths[j]) = (playlistPaths[j], playlistPaths[i]);
                (safeFileNames[i], safeFileNames[j]) = (safeFileNames[j], safeFileNames[i]);
            }

            currentTrackIndex = 0;
            if (playlistPaths.Count > 0)
            {
                wmp.URL = playlistPaths[currentTrackIndex];
                Play();
            }
        }

        // Сортировка по алфавиту
        public void SortAlphabet(bool isAscending)
        {
            if (isAscending)
            {
                var sortedPlaylist = safeFileNames
                    .Zip(playlistPaths, (name, path) => new { Name = name, Path = path })
                    .OrderBy(track => track.Name)
                    .ToList();

                safeFileNames.Clear();
                playlistPaths.Clear();

                foreach (var track in sortedPlaylist)
                {
                    safeFileNames.Add(track.Name);
                    playlistPaths.Add(track.Path);
                }
            }
            else
            {
                var sortedPlaylist = safeFileNames
                    .Zip(playlistPaths, (name, path) => new { Name = name, Path = path })
                    .OrderByDescending(track => track.Name)
                    .ToList();

                safeFileNames.Clear();
                playlistPaths.Clear();

                foreach (var track in sortedPlaylist)
                {
                    safeFileNames.Add(track.Name);
                    playlistPaths.Add(track.Path);
                }
            }
        }

        // Сортировка по длине трека
        public void SortDuration(bool isAscendingDur)
        {
            if (isAscendingDur)
            {
                var sortedPlaylist = safeFileNames
                    .Zip(playlistPaths, (name, path) => new { Name = name, Path = path, Duration = GetTrackDurationSeconds(path) })
                    .OrderBy(track => track.Duration)
                    .ToList();

                safeFileNames.Clear();
                playlistPaths.Clear();

                foreach (var track in sortedPlaylist)
                {
                    safeFileNames.Add(track.Name);
                    playlistPaths.Add(track.Path);
                }
            }
            else
            {
                var sortedPlaylist = safeFileNames
                    .Zip(playlistPaths, (name, path) => new { Name = name, Path = path, Duration = GetTrackDurationSeconds(path) })
                    .OrderByDescending(track => track.Duration)
                    .ToList();

                safeFileNames.Clear();
                playlistPaths.Clear();

                foreach (var track in sortedPlaylist)
                {
                    safeFileNames.Add(track.Name);
                    playlistPaths.Add(track.Path);
                }
            }
        }

        // Вывод плейлиста в консоль
        public void PrintPlaylist()
        {
            if (playlistPaths.Count == 0)
            {
                Console.WriteLine("Плейлист пуст.");
                return;
            }

            Console.WriteLine("Плейлист:");
            for (int i = 0; i < playlistPaths.Count; i++)
            {
                string prefix = i == currentTrackIndex ? "-> " : "   ";
                Console.WriteLine($"{prefix}{i + 1}. {safeFileNames[i], -30}\t{GetTrackDuration(playlistPaths[i])}");
            }
        }

        // Перемещение трека в плейлисте с помощью мыши
        public void MoveTrack(int oldIndex, int newIndex)
        {
            if (oldIndex >= 0 && oldIndex < playlistPaths.Count && newIndex >= 0 && newIndex < playlistPaths.Count)
            {
                var tempPath = playlistPaths[oldIndex];
                var tempFileName = safeFileNames[oldIndex];

                playlistPaths.RemoveAt(oldIndex);
                safeFileNames.RemoveAt(oldIndex);

                playlistPaths.Insert(newIndex, tempPath);
                safeFileNames.Insert(newIndex, tempFileName);

                if (currentTrackIndex == oldIndex)
                {
                    currentTrackIndex = newIndex;
                }
                else if (oldIndex < currentTrackIndex && newIndex >= currentTrackIndex)
                {
                    currentTrackIndex--;
                }
                else if (oldIndex > currentTrackIndex && newIndex <= currentTrackIndex)
                {
                    currentTrackIndex++;
                }
            }
        }

        // Сохранить плейлист
        public void SavePlaylist(string filePath)
        {
            try
            {
                System.IO.File.WriteAllLines(filePath, playlistPaths);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при сохранении плейлиста: {ex.Message}");
            }
        }

        // Загрузить плейлист
        public string LoadPlaylist(string filePath)
        {
            try
            {
                var loadedPaths = System.IO.File.ReadAllLines(filePath).ToList();

                playlistPaths.Clear();
                safeFileNames.Clear();

                foreach (var path in loadedPaths)
                {
                    if (System.IO.File.Exists(path))
                    {
                        AddToPlaylist(path);
                    }
                }

                if (playlistPaths.Count > 0)
                {
                    currentTrackIndex = 0;
                }
                else
                {
                    currentTrackIndex = -1;
                }

                return "Плейлист успешно загружен.";
            }
            catch (Exception ex)
            {
                return $"Ошибка загрузки плейлиста: {ex.Message}";
            }
        }

        // Экспорт плейлиста
        public string ExportPlaylist(string destinationFolder)
        {
            if (playlistPaths.Count == 0)
            {
                return "Плейлист пуст. Нечего экспортировать.";
            }

            try
            {
                for (int i = 0; i < playlistPaths.Count; i++)
                {
                    string sourcePath = playlistPaths[i];
                    string fileName = $"{i + 1}. {safeFileNames[i]}";
                    string destinationPath = Path.Combine(destinationFolder, fileName);

                    File.Copy(sourcePath, destinationPath, overwrite: true);
                }
                return "Файлы успешно экспортированы.";
            }
            catch (Exception ex)
            {
                return $"Ошибка при экспорте файлов: {ex.Message}";
            }
        }
    }
}