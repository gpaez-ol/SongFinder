
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IF.Lastfm.Core.Api;
using IF.Lastfm.Core.Objects;
using SongFinder.DTO;
using SongFinder.StreamingServices.Factory;
using SongFinder.StreamingServices.Interfaces;

namespace SongFinder.StreamingServices
{
    public class LastFMService : IStreamingService
    {
        private LastfmClient lastFM;

        public LastFMService()
        {
            var factory = new StreamingServiceFactory();
            lastFM = (LastfmClient)factory.getStreamingService(StreamingServiceType.LastFM);
        }
        public async Task<SongResponseDTO> SearchSong(SongSearchDTO query)
        {
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
