
using System;

namespace MusicArrays
{
    public enum MusicGenre
    {
        Rock,
        Pop,
        HipHop,
        Jazz,
        Electronic
    }

    public struct Music
    {
        public string Title;
        public string Artist;
        public string Album;
        public int Length;
        public MusicGenre Genre;

        // Display method
        public string Display()
        {
            return $"Title: {Title}\nArtist: {Artist}\nAlbum: {Album}\nLength: {Length} seconds\nGenre: {Genre}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("How many songs would you like to enter?");
            int size;
            if (!int.TryParse(Console.ReadLine(), out size) || size <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a positive integer.");
                return;
            }

            Music[] collection = new Music[size];

            try
            {
                for (int i = 0; i < size; i++)
                {
                    Console.WriteLine($"Song {i + 1}");
                    collection[i].Title = PromptInput("Title");
                    collection[i].Artist = PromptInput("Artist");
                    collection[i].Album = PromptInput("Album");
                    collection[i].Length = int.Parse(PromptInput("Length (seconds)"));
                    collection[i].Genre = PromptGenre();
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                // Display songs
                foreach (var song in collection)
                {
                    Console.WriteLine($"{song.Display()}\n");
                }
            }
        }

        static string PromptInput(string prompt)
        {
            Console.WriteLine($"Please enter the {prompt}:");
            return Console.ReadLine();
        }

        static MusicGenre PromptGenre()
        {
            Console.WriteLine("Please enter the genre:");
            Console.WriteLine("0. Rock\n1. Pop\n2. HipHop\n3. Jazz\n4. Electronic");
            int genreIndex = int.Parse(Console.ReadLine());

            if (!Enum.IsDefined(typeof(MusicGenre), genreIndex))
            {
                throw new ArgumentException("Invalid genre index.");
            }

            return (MusicGenre)genreIndex;
        }
    }
}