using System;
using System.Threading.Tasks;
using SpotifyAPI.Web;
using System.Collections.Generic;
using SongFinder.DTO;
using System.Linq;

namespace SongFinder.StreamingServices
{
    public class SpotifyService
    {

        public async Task<SongResponseDTO> SearchSong(SongSearchDTO query)
        {
            SpotifyClient spotify = GetSpotifyClient();
            SearchRequest searchRequest = new SearchRequest(SearchRequest.Types.Track,query.Artist + " " + query.Title);
            searchRequest.Market = "MX";

            SearchResponse response = await spotify.Search.Item(searchRequest);
            SongResponseDTO track = SetSingleSongResponse(response);
            return track;
        }

        public async Task<List<SongResponseDTO>> SearchSongs(SongSearchDTO query)
        {
            SpotifyClient spotify = GetSpotifyClient();
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

        private SpotifyClient GetSpotifyClient()
        {
            var config = SpotifyClientConfig
                        .CreateDefault()
                        .WithAuthenticator(new ClientCredentialsAuthenticator("0e3d1df9a33443b0a63e23a7772f1940","97b6e6c8eb7c455f809e4acd7f5d0f5c")); // TODO: Use appsettings values
            var spotify = new SpotifyClient(config);
            return spotify;
        }
    }
}
