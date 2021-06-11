using E.Deezer;
using SongFinder.StreamingServices.Interfaces;
using SpotifyAPI.Web;
using IF.Lastfm.Core.Api;

namespace SongFinder.StreamingServices.Factory
{
    public class StreamingServiceFactory 
    {
        private Deezer GetDeezerClient()
        {
            var deezer = DeezerSession.CreateNew();
            return deezer;
        }

        private SpotifyClient GetSpotifyClient()
        {
            var config = SpotifyClientConfig
                        .CreateDefault()
                        .WithAuthenticator(new ClientCredentialsAuthenticator("0e3d1df9a33443b0a63e23a7772f1940","97b6e6c8eb7c455f809e4acd7f5d0f5c"));
            var spotify = new SpotifyClient(config);
            return spotify;
        }

        private LastfmClient GetLastfmClient()
        {
            var client = new LastfmClient("1dc640749935e63a85413195795cf56d", "74cd7c7f98189e6b1e073783c9282928");
            return client;
        }

        public object getStreamingService(StreamingServiceType Type)
        {
            switch(Type)
            {
                case StreamingServiceType.Spotify:
                return GetSpotifyClient();
                case StreamingServiceType.Deezer:
                return GetDeezerClient();
                case StreamingServiceType.LastFM:
                return GetLastfmClient();
                default:
                return null;
            }
        }
    }
    public enum StreamingServiceType
    {
        Spotify,
        Deezer,
        LastFM,
    }
}