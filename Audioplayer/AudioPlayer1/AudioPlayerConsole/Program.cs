using AudioPlayerLib;
using System;

namespace AudioPlayerApp
{
    internal class Program
    {
        static bool ParseTime(string input, out double seconds)
        {
            seconds = 0;
            string[] parts = input.Split(':');

            if (parts.Length == 2
                && int.TryParse(parts[0], out int mins)
                && int.TryParse(parts[1], out int secs))
            {
                seconds = mins * 60 + secs;
                return true;
            }

            return false;
        }
        static void Main(string[] args)
        {
            AudioPlayer player = new AudioPlayer();
            bool isAscending = true;

            while (true)
            {
                Console.WriteLine("\nКомманды: ");
                Console.WriteLine("1 - Добавить трек в плейлист");
                Console.WriteLine("2 - Убрать трек из плейлиста");
                Console.WriteLine("3 - Играть");
                Console.WriteLine("4 - Пауза");
                Console.WriteLine("5 - Стоп");
                Console.WriteLine("6 - След. трек");
                Console.WriteLine("7 - Пред. трек");
                Console.WriteLine("8 - Перемешать");
                Console.WriteLine("9 - Сортировать по алфавиту");
                Console.WriteLine("10 - Сортировать по длине трека");
                Console.WriteLine("11 - Выбрать трек");
                Console.WriteLine("12 - Установить громкость");
                Console.WriteLine("13 - Перемотка трека");
                Console.WriteLine("14 - Сохранить плейлист");
                Console.WriteLine("15 - Загрузить плейлист");
                Console.WriteLine("16 - Экспорт плейлиста");
                Console.WriteLine("17 - Вывести плейлист");
                Console.WriteLine("0 - Выход");

                Console.Write("\nВведите команду: ");
                string command = Console.ReadLine();

                switch (command)
                {
                    case "1":
                        Console.Write("Введите путь до аудиофайла: ");
                        string path = Console.ReadLine();
                        player.AddToPlaylist(path);
                        break;
                    case "2":
                        Console.Write("Введите номер трека для удаления: ");
                        if (int.TryParse(Console.ReadLine(), out int removeIndex))
                        {
                            player.RemoveFromPlaylist(removeIndex - 1);
                        }
                        else
                        {
                            Console.WriteLine("Ошибка.");
                        }
                        break;
                    case "3":
                        player.Play();
                        break;
                    case "4":
                        player.Pause();
                        break;
                    case "5":
                        player.Stop();
                        break;
                    case "6":
                        player.Next();
                        break;
                    case "7":
                        player.Previous();
                        break;
                    case "8":
                        player.Shuffle();
                        break;
                    case "9":
                        player.SortAlphabet(isAscending);
                        if (isAscending)
                        {
                            isAscending = false;
                        }
                        else
                        {
                            isAscending = true;
                        }
                        break;
                    case "10":
                        break;
                    case "11":
                        Console.Write("Введите номер трека для выбора: ");
                        if (int.TryParse(Console.ReadLine(), out int selectIndex))
                        {
                            player.SelectTrack(selectIndex - 1);
                        }
                        else
                        {
                            Console.WriteLine("Ошибка.");
                        }
                        break;
                    case "12":
                        Console.Write("Введите уровень громкости (0-100): ");
                        if (int.TryParse(Console.ReadLine(), out int volume) && volume >= 0 && volume <= 100)
                        {
                            player.SetVolume(volume);
                            Console.WriteLine($"Громкость установлена на {volume}%.");
                        }
                        else
                        {
                            Console.WriteLine("Некорректное значение громкости. Введите число от 0 до 100.");
                        }
                        break;
                    case "13":
                        double duration = player.GetDuration();
                        int min = (int)duration / 60;
                        int sec = (int)duration % 60;

                        Console.WriteLine($"Длина текущего трека: {min:D2}:{sec:D2}");
                        Console.Write("Введите момент для перемотки (ММ:СС): ");
                        string input = Console.ReadLine();

                        if (ParseTime(input, out double newPosition) && newPosition <= duration)
                        {
                            player.SetCurrentPosition(newPosition);
                            Console.WriteLine($"Перемотано на {input}");
                        }
                        else
                        {
                            Console.WriteLine("Ошибка. Неверный формат или превышено время трека.");
                        }
                        break;
                    case "14":
                        Console.Write("Введите имя файла для сохранения (например, playlist.txt): ");
                        string filePath = Console.ReadLine();

                        try
                        {
                            player.SavePlaylist(filePath);
                            Console.WriteLine("Плейлист успешно сохранен.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Ошибка при сохранении: {ex.Message}");
                        }
                        Console.WriteLine("Нажмите любую клавишу для продолжения...");
                        Console.ReadKey();
                        break;
                    case "15":
                        Console.Write("Введите имя файла для загрузки (например, playlist.txt): ");
                        string filePath_ = Console.ReadLine();

                        try
                        {
                            player.LoadPlaylist(filePath_);
                            Console.WriteLine("Плейлист успешно загружен.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Ошибка при загрузке: {ex.Message}");
                        }
                        Console.WriteLine("Нажмите любую клавишу для продолжения...");
                        Console.ReadKey();
                        break;
                    case "16":
                        Console.Write("Введите путь для экспорта плейлиста : ");
                        string destinationPath = Console.ReadLine();

                        try
                        {
                            player.LoadPlaylist(destinationPath);
                            Console.WriteLine("Плейлист успешно экспортирован.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Ошибка: {ex.Message}");
                        }
                        Console.WriteLine("Нажмите любую клавишу для продолжения...");
                        Console.ReadKey();
                        break;
                    case "17":
                        player.PrintPlaylist();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Такой команды не существует.");
                        break;
                }
            }
        }
    }
}
