
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
            var client = new LastfmClient("1dc640749935e63a85413195795cf56d", "74cd7c7f98189e6b1e073783c9282928"); // TODO: Add api key and secrets
            return client;
        }

        public async Task<SongResponseDTO> SearchSong(SongSearchDTO query)
        {
            LastfmClient lastFM = GetLastfmClient();
            string queryParam = query.Title + " " + query.Artist;
            var tracks = await lastFM.Track.SearchAsync(queryParam);
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
            string queryParam = query.Title + " " + query.Artist;
            var response = await lastFM.Track.SearchAsync(queryParam);
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
