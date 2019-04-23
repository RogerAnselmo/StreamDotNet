using System.IO;
using System.Threading.Tasks;

namespace AzureStream.Interfaces
{
    public interface IAzureVideoStreamService
    {
        Task<Stream> GetVideoByName(string name);
    }
}
