using System;
using NAudio.Wave;

namespace Waits
{
    public static class PlayerMP3
    {

        public static void Play(string fileName)
        {
            using (DirectSoundOut output = new DirectSoundOut())
            {
                using (Mp3FileReader reader = new Mp3FileReader(fileName))
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
