using AudioPlayerLib;
using System;

namespace AudioPlayerApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AudioPlayer player = new AudioPlayer();

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
                Console.WriteLine("9 - Вывести плейлист");
                Console.WriteLine("10 - Выбрать трек");
                Console.WriteLine("11 - Установить громкость");
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
                        player.PrintPlaylist();
                        break;
                    case "10":
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
                    case "11":
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
