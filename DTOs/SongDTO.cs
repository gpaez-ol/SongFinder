using System;
using System.Collections.Generic;

namespace SongFinder.DTO
{

    public class SongSearchDTO
    {
        /// <summary>
        /// Possible Title of the Song
        /// </summary>
        public string? Title { get; set; }
        /// <summary>
        /// Posible Artist of the Song
        /// </summary>
        public string? Artist { get; set; }
    }

    public class StreamingServicesSongResponseDTO
    {
        /// <summary>
        /// Spotify Song  Result 
        /// </summary>
        public SongResponseDTO SpotifySongResponse {get;set;}
        /// <summary>
        /// Amazon Music Result
        /// </summary>
        public SongResponseDTO AmazonMusicResponse {get;set;}
        /// <summary>
        /// Deezer Music Result
        /// </summary>
        public SongResponseDTO DeezerResponse {get;set;}
    }
    public class SongResponseDTO
    {
        /// <summary>
        /// Title of the Song
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Artist of the Song
        /// </summary>
        public List<string> Artist { get; set; }
        /// <summary>
        /// Url of the Song
        /// </summary>
        public string Url { get; set; }
    }

    public class PossibleSongsResponseDTO
    {
        public List<SongResponseDTO> Songs{get;set;}
    }

}