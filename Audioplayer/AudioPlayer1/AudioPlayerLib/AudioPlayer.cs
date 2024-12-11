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

        public List<string> GetPlaylist() => new List<string>(safeFileNames);
        public int GetCurrentTrackIndex() => currentTrackIndex;

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
                Console.WriteLine("Неверный индекс трека.");
            }
        }

        public void Play()
        {
            if (currentTrackIndex >= 0 && currentTrackIndex < playlistPaths.Count)
            {
                wmp.URL = playlistPaths[currentTrackIndex];
                wmp.controls.play();
            }
            else
            {
                Console.WriteLine("Трэк не выбран или плейлист пуст.");
            }
        }
        public void Stop()
        {
            wmp.controls.stop();
            Console.WriteLine("Стоп.");
        }

        public void Pause()
        {
            wmp.controls.pause();
            Console.WriteLine("На паузе.");
        }

        public void Next()
        {
            if (playlistPaths.Count > 0)
            {
                currentTrackIndex = (currentTrackIndex + 1) % playlistPaths.Count;
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
            if (playlistPaths.Count > 0)
            {
                currentTrackIndex = (currentTrackIndex - 1 + playlistPaths.Count) % playlistPaths.Count;
                Play();
            } else
            {
                Console.WriteLine("Плейлист пуст.");
                return;
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
                Console.WriteLine("Playlist is empty.");
                return;
            }

            Console.WriteLine("Плейлист:");
            for (int i = 0; i < playlistPaths.Count; i++)
            {
                string prefix = i == currentTrackIndex ? "-> " : "   ";
                Console.WriteLine($"{prefix}{i + 1}. {playlistPaths[i]}");
            }
        }
    }
}
