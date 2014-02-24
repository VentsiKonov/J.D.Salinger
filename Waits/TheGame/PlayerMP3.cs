using System;
using NAudio.Wave;

namespace Waits
{

    public static class PlayerMP3
    {


        private const int NUM_OF_SONGS = 10;
        private const string PATH = @"../../SongStorage/song";
        private const string EXT = @".mp3";

        public static void Play(int songNumber)
        {
            if (songNumber <= 0 && songNumber > NUM_OF_SONGS) songNumber = 1;

            using (DirectSoundOut output = new DirectSoundOut())
            {
                using (Mp3FileReader reader = new Mp3FileReader(PATH + songNumber + EXT))
                {
                    output.Init(reader);
                    output.Play();

                    while (reader.Position < reader.Length && !Console.KeyAvailable)
                    {

                    }
                }

            }
        }

        public static string SongName(int songNumber)
        {
            string[] songName =  {
                           "Malka Moma",
                           "Koledarska Molitva",
                           "Oi Koledo",
                           "Stara Koledarska",
                           "Vechniat Bog",
                           "Koledarska Kitka",
                           "Kolkoto",
                           "Blagosloven Da Si Gospodi",
                           "Sabrali Sa Tri Delia",
                           "Pesen Za Branko"};

            if (songNumber <= 0 && songNumber > NUM_OF_SONGS) songNumber = 1;

            return songName[songNumber + 1];
        }

    }
}
