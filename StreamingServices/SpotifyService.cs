using System;
using System.Threading.Tasks;
using SpotifyAPI.Web;
using System.Collections.Generic;
using SongFinder.DTO;
using System.Linq;
using SongFinder.StreamingServices.Interfaces;
using SongFinder.StreamingServices.Factory;

namespace SongFinder.StreamingServices
{
    public class SpotifyService : IStreamingService
    {
        private StreamingServiceFactory factory;
        private SpotifyClient spotify;
        public SpotifyService() : base()
        {
            factory = new StreamingServiceFactory();
            spotify = (SpotifyClient)factory.getStreamingService(StreamingServiceType.Spotify);
         }

        public async Task<SongResponseDTO> SearchSong(SongSearchDTO query)
        {
            SearchRequest searchRequest = new SearchRequest(SearchRequest.Types.Track,query.Artist + " " + query.Title);
            searchRequest.Market = "MX";

            SearchResponse response = await spotify.Search.Item(searchRequest);
            SongResponseDTO track = SetSingleSongResponse(response);
            return track;
        }

        public async Task<List<SongResponseDTO>> SearchSongs(SongSearchDTO query)
        {
            SearchRequest searchRequest = new SearchRequest(SearchRequest.Types.Track,query.Artist + " " + query.Title);
            searchRequest.Market = "MX";
            SearchResponse response = await spotify.Search.Item(searchRequest);
            List<SongResponseDTO> tracks = SetSongResponseList(response);
            return tracks;
        }

        private SongResponseDTO SetSingleSongResponse(SearchResponse response)
        {
            SongResponseDTO track = null;
            if(response.Tracks != null)
            {
                track =  new SongResponseDTO {
                    Title=  response.Tracks.Items[0].Name,
                    Artist= response.Tracks.Items[0].Artists.Select(artist => artist.Name).ToList(),
                    Url = response.Tracks.Items[0].ExternalUrls.Select(url => url.Value).FirstOrDefault()
                };
            }
            return track;
        }

        private List<SongResponseDTO> SetSongResponseList(SearchResponse response)
        {
            List<SongResponseDTO> tracks = new List<SongResponseDTO>();
            response.Tracks.Items.ForEach(item => 
            {
                tracks.Add(new SongResponseDTO {
                    Title=  item.Name,
                    Artist= item.Artists.Select(artist => artist.Name).ToList(),
                    Url = item.ExternalUrls.Select(url => url.Value).FirstOrDefault()
                });
            });
            return tracks;
        }
    }
}
