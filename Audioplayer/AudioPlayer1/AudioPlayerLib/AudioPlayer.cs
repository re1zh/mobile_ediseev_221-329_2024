using System;
using System.Collections.Generic;
using WMPLib;

namespace AudioPlayerLib
{
    public class AudioPlayer
    {
        private readonly WindowsMediaPlayer wmp = new();

        private readonly List<string> playlistPaths = new();
        private readonly List<string> safeFileNames = new();

        private int currentTrackIndex = -1;

        public AudioPlayer()
        {
            wmp.settings.volume = 25;
            wmp.PlayStateChange += OnPlayStateChange; // Подписываемся на событие
        }


        public List<string> GetPlaylist() => new List<string>(safeFileNames);
        public int GetCurrentTrackIndex() => currentTrackIndex;
        public WMPPlayState CurrentState => wmp.playState;
        public int GetVolume()
        {
            return wmp?.settings.volume ?? 25;
        }
        public double GetCurrentPosition()
        {
            return wmp.controls.currentPosition;
        }
        public void SetCurrentPosition(double position)
        {
            wmp.controls.currentPosition = position;
        }
        public double GetDuration()
        {
            return wmp.currentMedia?.duration ?? 0;
        }
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


        public void AddToPlaylist(string filePath)
        {
            playlistPaths.Add(filePath);
            safeFileNames.Add(System.IO.Path.GetFileName(filePath));
        }

        public void RemoveFromPlaylist(int index)
        {
            if (index >= 0 && index < playlistPaths.Count)
            {
                if (index == currentTrackIndex) Stop();

                playlistPaths.RemoveAt(index);
                safeFileNames.RemoveAt(index);
            }
        }

        public void SelectTrack(int index)
        {
            if (index >= 0 && index < playlistPaths.Count)
            {
                currentTrackIndex = index;
                Play();
            }
            else
            {
                Console.WriteLine("Неверный номер трека.");
            }
        }

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
            else
            {
                Console.WriteLine("Трек не выбран или плейлист пуст.");
            }
        }

        public void Pause()
        {
            if (!isNull() && isPlaying())
            {
                wmp.controls.pause();
                Console.WriteLine("На паузе.");
            }
        }

        public void Stop()
        {
            wmp.controls.stop();
            Console.WriteLine("Стоп.");
        }

        public void Next()
        {
            if (playlistPaths.Count > 0 && currentTrackIndex >= 0)
            {
                currentTrackIndex = (currentTrackIndex + 1) % playlistPaths.Count;
                Console.WriteLine($"Следующий трек: {safeFileNames[currentTrackIndex]}");
                Play();
            }
            else
            {
                Console.WriteLine("Плейлист пуст.");
                return;
            }
        }
        public void Previous()
        {
            if (playlistPaths.Count > 0 && currentTrackIndex >= 0)
            {
                currentTrackIndex = (currentTrackIndex - 1 + playlistPaths.Count) % playlistPaths.Count;
                Play();
            } 
            else
            {
                Console.WriteLine("Плейлист пуст.");
                return;
            }
        }

        public void SetVolume(int volume)
        {
            if (!isNull())
            {
                wmp.settings.volume = volume;
            }
        }

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
            currentTrackIndex = -1;
        }

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
                Console.WriteLine($"{prefix}{i + 1}. {playlistPaths[i]}");
            }
        }
        private void OnPlayStateChange(int newState)
        {
            //Console.WriteLine($"Состояние изменилось: {(WMPPlayState)newState}");

            if ((WMPPlayState)newState == WMPPlayState.wmppsMediaEnded)
            {
                Console.WriteLine("Трек завершён. Переход к следующему.");
                Next();
            }
            else if ((WMPPlayState)newState == WMPPlayState.wmppsReady && currentTrackIndex != -1)
            {
                Console.WriteLine("Плеер остановлен. Запуск текущего трека.");
                Play();
            }
        }
    }
}