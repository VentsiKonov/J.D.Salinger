﻿using System;
using NAudio.Wave;

namespace Waits
{

    public static class PlayerMP3
    {


        private const int NUM_OF_SONGS = 10;
        private const string PATH = @"../../SongStorage/song";
        private const string EXT = @".mp3";

        public static void Play(Song songNumber)
        {
            using (DirectSoundOut output = new DirectSoundOut())
            {
                using (Mp3FileReader reader = new Mp3FileReader(PATH + ((int)songNumber+1) + EXT))
                {
                    output.Init(reader);
                    output.Play();

                    while (reader.Position < reader.Length && !Console.KeyAvailable)
                    {

                    }
                }

            }
        }

        public static string SongName(Song songNumber)
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

            return songName[(int)songNumber];
        }

    }
}
