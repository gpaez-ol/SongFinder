using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SongFinder.DTO;
using SongFinder.Songs;

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
        public ActionResult<List<Song>> GetSongResults([FromQuery] SongSearchDTO songSearch)
        {
            return Ok();
        }

        //GET amazon-music-search
        /// <summary>
        /// This GET method returns a possible song found by amazon  music        
        /// </summary>
        /// <returns>Ok(Song)</returns>
        [HttpGet("amazon-music-search")]
        [ProducesResponseType(200)]
        public ActionResult<Song> GetAmazonMusicSongResults([FromQuery] SongSearchDTO songSearch)
        {
            return Ok();
        }

        //GET spotify-search
        /// <summary>
        /// This GET method returns a possible song found by spotify music       
        /// </summary>
        /// <returns>Ok(Song)</returns>
        [HttpGet("spotify-search")]
        [ProducesResponseType(200)]
        public ActionResult<Song> GetSpotifySongResults([FromQuery] SongSearchDTO songSearch)
        {
            return Ok();
        }

        //GET deezer-search
        /// <summary>
        /// This GET method returns a possible song found by deezer music       
        /// </summary>
        /// <returns>Ok(Song)</returns>
        [HttpGet("deezer-search")]
        [ProducesResponseType(200)]
        public ActionResult<Song> GetDeezerSongResults([FromQuery] SongSearchDTO songSearch)
        {
            return Ok();
        }


    }
}
