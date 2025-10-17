using System;

namespace MusicPlayerConsoleApp
{
    
    public delegate void SongeEventHandler(string songTitle);
    public class MusicPlayer
    {
        public event SongeEventHandler SongPlayed;
        public event SongeEventHandler SongPaused;
        public event SongeEventHandler SongStopped;
        public event SongeEventHandler SongSkipped;

        public void Play(string songTitle)
        {
            Console.WriteLine($"Now playing: {songTitle}");
            SongPlayed?.Invoke(songTitle);
        }

        public void Pause(string songTitle)
        {
            Console.WriteLine($"Now pausing: {songTitle}");
            SongPaused?.Invoke(songTitle);
        }

        public void Stop(string songTitle)
        {
            Console.WriteLine($"Now stopping: {songTitle}");
            SongStopped?.Invoke(songTitle);
        }

        public void Skip(string songTitle)
        {
            Console.WriteLine($"Now skipping: {songTitle}");
            SongSkipped?.Invoke(songTitle);
        }
    }

    public class Subscriber
    {
        public string Name { get; }
        public Subscriber(string name)
        {
            Name = name;
        }

        public void SongPlayedHandler(string songTitle)
        {
            Console.WriteLine($"{Name} is now enjoying: {songTitle}");
        }

        public void SongPausedHandler(string songTitle)
        {
            Console.WriteLine($"{Name} has paused: {songTitle}");
        }

        public void SongStoppedHandler(string songTitle)
        {
            Console.WriteLine($"{Name} has stopped: {songTitle}");
        }

        public void SongSkippedHandler(string songTitle)
        {
            Console.WriteLine($"{Name} has skipped: {songTitle}");
        }
    }

    class MusicPlayerProgram
    {
        public static void Main()
        {
            MusicPlayer musicPlayer = new MusicPlayer();

            Subscriber subscriber1 = new Subscriber("User1");
            Subscriber subscriber2 = new Subscriber("User2");

            musicPlayer.SongPlayed += subscriber1.SongPlayedHandler;
            musicPlayer.SongPaused += subscriber1.SongPausedHandler;
            musicPlayer.SongStopped += subscriber1.SongStoppedHandler;
            musicPlayer.SongSkipped += subscriber1.SongSkippedHandler;

            musicPlayer.SongPlayed += subscriber2.SongPlayedHandler;
            musicPlayer.SongPaused += subscriber2.SongPausedHandler;
            musicPlayer.SongStopped += subscriber2.SongStoppedHandler;
            musicPlayer.SongSkipped += subscriber2.SongSkippedHandler;

            while (true)
            {
                Console.WriteLine("\nEnter the action (play, pause, stop, skip) or 'exit' to end:");
                string action = Console.ReadLine().ToLower();

                if (action == "exit")
                    break;
                Console.WriteLine("Enter the song title:");
                string songTitle = Console.ReadLine();

                switch (action)
                {
                    case "play":
                        musicPlayer.Play(songTitle);
                        break;
                    case "pause":
                        musicPlayer.Pause(songTitle);
                        break;
                    case "stop":
                        musicPlayer.Stop(songTitle);
                        break;
                    case "skip":
                        musicPlayer.Skip(songTitle);
                        break;
                    default:
                        Console.WriteLine("Invalid action. Please enter play, pause, stop, skip or exit");
                        break;
                }
            }
        }
    }
}