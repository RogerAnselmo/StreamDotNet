using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StreamDOtNetCore.Results
{
    public class PushStreamResult : IActionResult
    {
        private readonly Action<Stream, CancellationToken> _onStreamAvailable;
        private readonly string _contentType;
        private readonly CancellationToken _requestAborted;


        public PushStreamResult(Action<Stream, CancellationToken> onStreamAvailable, 
            string contentType, 
            CancellationToken requestAborted)
        {
            _contentType = contentType;
            _onStreamAvailable = onStreamAvailable;
            _requestAborted = requestAborted;
        }


        public Task ExecuteResultAsync(ActionContext context)
        {
            var stream = context.HttpContext.Response.Body;
            context.HttpContext.Response.GetTypedHeaders().ContentType = new Microsoft.Net.Http.Headers.MediaTypeHeaderValue(_contentType);
            _onStreamAvailable(stream, _requestAborted);

            return Task.CompletedTask;
        }
    }
}
