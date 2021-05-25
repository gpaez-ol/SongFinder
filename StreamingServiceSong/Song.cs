using System;

namespace SongFinder.Songs
{
    public class Song
    {
        /// <summary>
        /// Date when the Song was created
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Title of the Song
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Artist of the song
        /// </summary>
        public string Artist{get; set;}
    }
}
