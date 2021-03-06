using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SongFinder.DTO;
using SongFinder.StreamingServices;

namespace SongFinder.Controllers
{
    [ApiController]
    [Route("song")]
    public class SongController : ControllerBase
    {
        public SongController()
        {
        }

        //GET health
        /// <summary>
        /// This GET method returns a 200 Ok Response to check if the instance is healthy 
        /// </summary>
        /// <returns>Ok()</returns>
        [HttpGet("health")]
        [ProducesResponseType(200)]
        public ActionResult GetHealth()
        {
            return Ok();
        }

        //GET 
        /// <summary>
        /// This GET method returns a possible list of all results found by the streaming services with a song
        /// </summary>
        /// <returns>Ok(List< Song >)</returns>
        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<ActionResult<StreamingServicesSongResponseDTO>> GetSongResults([FromQuery] SongSearchDTO songSearch)
        {
            var spotifyService = new SpotifyService();
            var deezerService = new DeezerService();
            var lastFMService = new LastFMService();
            List<SongResponseDTO> spotifyResult = await spotifyService.SearchSongs(songSearch);
            List<SongResponseDTO> deezerResult = await deezerService.SearchSongs(songSearch);
            List<SongResponseDTO> lastFmResult = await lastFMService.SearchSongs(songSearch);
            StreamingServicesSongResponseDTO result = new StreamingServicesSongResponseDTO
                                                    {
                                                        SpotifySongResponse = spotifyResult,
                                                        DeezerResponse = deezerResult,
                                                        LastFMMusicResponse = lastFmResult
                                                    };
            return Ok(result);
        }

        //GET lastfm-music-search
        /// <summary>
        /// This GET method returns a possible song found by lastfm  music        
        /// </summary>
        /// <returns>Ok(Song)</returns>
        [HttpGet("lastfm-music-search")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<SongResponseDTO>> GetLastFmSongResults([FromQuery] SongSearchDTO songSearch)
        {
            var lastFmService = new LastFMService();
            SongResponseDTO result =  await lastFmService.SearchSong(songSearch);
            return Ok(result);
        }

         //GET lastfm-music-search-list
        /// <summary>
        /// This GET method returns a possible list of songs found by lastfm  music        
        /// </summary>
        /// <returns>Ok(Song)</returns>
        [HttpGet("lastfm-music-search-list")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<List<SongResponseDTO>>> GetLastFmSongListResults([FromQuery] SongSearchDTO songSearch)
        {
            var lastFmService = new LastFMService();
            List<SongResponseDTO> result =  await lastFmService.SearchSongs(songSearch);
            return Ok(result);
        }

        //GET spotify-search
        /// <summary>
        /// This GET method returns a possible song found by spotify music       
        /// </summary>
        /// <returns>Ok(Song)</returns>
        [HttpGet("spotify-search")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<SongResponseDTO>> GetSingleSpotifySongResults([FromQuery] SongSearchDTO songSearch)
        {
            var spotifyService = new SpotifyService();
            SongResponseDTO result =  await spotifyService.SearchSong(songSearch);
            return Ok(result);
        }

        //GET spotify-search-list
        /// <summary>
        /// This GET method returns a list of possible song found by spotify music       
        /// </summary>
        /// <returns>Ok(List(Song))</returns>
        [HttpGet("spotify-search-list")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<List<SongResponseDTO>>> GetSpotifySongResultsList([FromQuery] SongSearchDTO songSearch)
        {
            var spotifyService = new SpotifyService();
            List<SongResponseDTO> result =  await spotifyService.SearchSongs(songSearch);
            return Ok(result);
        }

        //GET deezer-search
        /// <summary>
        /// This GET method returns a possible song found by deezer music       
        /// </summary>
        /// <returns>Ok(Song)</returns>
        [HttpGet("deezer-search")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<SongResponseDTO>> GetDeezerSongResults([FromQuery] SongSearchDTO songSearch)
        {
            var deezerService = new DeezerService();
            SongResponseDTO result =  await deezerService.SearchSong(songSearch);
            return Ok(result);
        }

        //GET deezer-search-list
        /// <summary>
        /// This GET method returns a list of possible song found by deezer music       
        /// </summary>
        /// <returns>Ok(List(Song))</returns>
        [HttpGet("deezer-search-list")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<List<SongResponseDTO>>> GetDeezerSongResultsList([FromQuery] SongSearchDTO songSearch)
        {
            var deezerService = new DeezerService();
            List<SongResponseDTO> result =  await deezerService.SearchSongs(songSearch);
            return Ok(result);
        }


    }
}
