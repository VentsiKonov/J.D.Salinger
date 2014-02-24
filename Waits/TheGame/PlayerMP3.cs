using System;
using NAudio.Wave;

namespace Waits
{

    public static class PlayerMP3
    {

        private const string path = @"../../SongStorage/song";
        private const string ext = @".mp3";
        public static void Play(int songNumber)
        {

            using (DirectSoundOut output = new DirectSoundOut())
            {
                using (Mp3FileReader reader = new Mp3FileReader(path + songNumber + ext))
                {
                    output.Init(reader);
                    output.Play();

                    while (reader.Position < reader.Length && !Console.KeyAvailable)
                    {

                    }
                }
            }
        }

    }
}
