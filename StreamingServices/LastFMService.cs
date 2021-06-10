
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IF.Lastfm.Core.Api;
using IF.Lastfm.Core.Objects;
using SongFinder.DTO;

namespace SongFinder.StreamingServices
{
    public class LastFMService
    {
        private LastfmClient GetLastfmClient()
        {
            var client = new LastfmClient("apikey", "apisecret"); // TODO: Add api key and secrets
            return client;
        }

        public async Task<SongResponseDTO> SearchSong(SongSearchDTO query)
        {
            LastfmClient lastFM = GetLastfmClient();
            var tracks = await lastFM.Track.SearchAsync(query.Title);
            var track = tracks.FirstOrDefault();
            var response = new SongResponseDTO(){
                         Title = track.Name,
                         Artist = new List<string>(){track.ArtistName},
                         Url = track.Url.ToString()
                         };
            return response;
        }

        public async Task<List<SongResponseDTO>> SearchSongs(SongSearchDTO query)
        {
            LastfmClient lastFM = GetLastfmClient();
            var response = await lastFM.Track.SearchAsync(query.Title);
            List<SongResponseDTO> tracks = SetSongResponseList(response.ToList());
            return tracks;
        }

        private List<SongResponseDTO> SetSongResponseList(List<LastTrack> response)
        {
            List<SongResponseDTO> tracks = new List<SongResponseDTO>();
            response.ForEach(item => 
            {
                tracks.Add(new SongResponseDTO {
                    Title=  item.Name,
                    Artist= new List<string>(){item.ArtistName},
                    Url = item.Url.ToString()
                });
            });
            return tracks;
        }


    }
}
