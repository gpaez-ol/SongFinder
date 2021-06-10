using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E.Deezer;
using E.Deezer.Api;
using SongFinder.DTO;

namespace SongFinder.StreamingServices
{
    public class DeezerService
    {
        private Deezer GetDeezerClient()
        {
            var deezer = DeezerSession.CreateNew();
            return deezer;
        }

        public async Task<SongResponseDTO> SearchSong(SongSearchDTO query)
        {
            Deezer deezer = GetDeezerClient();
            var queryString = query.Title + " " + query.Artist;
            var tracks = await deezer.Search.Tracks(queryString,0,1);
            var track = tracks.FirstOrDefault();
            var result = SetSingleSongResponse(track);
            return result;
        }
        public async Task<List<SongResponseDTO>> SearchSongs(SongSearchDTO query)
        {
            Deezer deezer = GetDeezerClient();
            var queryString = query.Title + " " + query.Artist;
            var tracks = await deezer.Search.Tracks(queryString);
            List<SongResponseDTO> result = SetSongResponseList(tracks.ToList());
            return result;
        }
        private SongResponseDTO SetSingleSongResponse(ITrack response)
        {
            SongResponseDTO track = null;
            if(response != null)
            {
                track = new SongResponseDTO()
                    {
                        Title = response.Title,
                        Artist = new List<string>(){response.ArtistName},
                        Url = response.Link
                    };
            }
            return track;
        }
        private List<SongResponseDTO> SetSongResponseList(List<ITrack> response)
        {
            List<SongResponseDTO> tracks = new List<SongResponseDTO>();
            response.ForEach(item => 
            {
                tracks.Add(new SongResponseDTO()
                    {
                        Title = item.Title,
                        Artist = new List<string>(){item.ArtistName},
                        Url = item.Link
                    });
            });
            return tracks;
        }
    }
}
