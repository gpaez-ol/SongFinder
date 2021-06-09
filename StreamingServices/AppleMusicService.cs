
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Web;
namespace SongFinder.StreamingServices
{
    public class AppleMusicService
    {
        private static string searchCatalogUrl = "https://api.music.apple.com/v1/catalog/mx/search";
        private string getAppleMusicToken()
        {
            string token = MusicToken.TokenGenerator.GenerateToken(privateKey:"",teamId:"",keyId:"",lifeSpan: TimeSpan.FromDays(2));
            return token;
        }

        public async Task<HttpWebResponse> searchCatalogForResource(string songName)
        {
            string songParamName = songName.Replace(" ","+");
            string songParam = "?term="+ songParamName + "&types=artists,songs";
            string searchUrl = searchCatalogUrl + songParam;
            
            var request = WebRequest.Create(searchUrl);
            var response = (HttpWebResponse) await Task.Factory
            .FromAsync<WebResponse>(request.BeginGetResponse,
                                    request.EndGetResponse,
                                    null);
            Debug.Assert(response.StatusCode == HttpStatusCode.OK);
            return response;
        }

    }
}
