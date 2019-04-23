using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using AzureStream.Factory;
using AzureStream.Interfaces;

namespace AzureStream.Services
{
    public class AzureVideoStreamService : IAzureVideoStreamService
    {
        private HttpClient _client;

        public AzureVideoStreamService()
        {
            _client = new HttpClient();
        }

        public async Task<Stream> GetVideoByName(string name)
        {            
            return await _client.GetStreamAsync(VideoFactory.GetVideo(name));
        }

        ~AzureVideoStreamService()
        {
            if (_client != null)
                _client.Dispose();
        }
    }
}
