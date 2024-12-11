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
                Console.WriteLine("\nCommands: ");
                Console.WriteLine("1 - Add track");
                Console.WriteLine("2 - Remove track");
                Console.WriteLine("3 - Play");
                Console.WriteLine("4 - Pause");
                Console.WriteLine("5 - Stop");
                Console.WriteLine("6 - Next");
                Console.WriteLine("7 - Previous");
                Console.WriteLine("8 - Shuffle");
                Console.WriteLine("9 - Print playlist");
                Console.WriteLine("10 - Select track");
                Console.WriteLine("0 - Exit");

                Console.Write("\nEnter command: ");
                string command = Console.ReadLine();

                switch (command)
                {
                    case "1":
                        Console.Write("Enter path to audio file: ");
                        string path = Console.ReadLine();
                        player.AddToPlaylist(path);
                        break;
                    case "2":
                        Console.Write("Enter index of track to remove: ");
                        if (int.TryParse(Console.ReadLine(), out int removeIndex))
                        {
                            player.RemoveFromPlaylist(removeIndex - 1);
                        }
                        else
                        {
                            Console.WriteLine("Invalid input.");
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
                        Console.Write("Enter track index: ");
                        if (int.TryParse(Console.ReadLine(), out int selectIndex))
                        {
                            player.SelectTrack(selectIndex - 1);
                        }
                        else
                        {
                            Console.WriteLine("Invalid input.");
                        }
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Unknown command.");
                        break;
                }
            }
        }
    }
}
