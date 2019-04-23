using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AzureStream.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AzureStream.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class StreamController : ControllerBase
    {
        private IAzureVideoStreamService _streamingService;

        public StreamController(IAzureVideoStreamService streamingService)
        {
            _streamingService = streamingService;
        }

        [HttpGet("{name}")]
        public async Task<FileStreamResult> Get(string name)
        {
            var stream = await _streamingService.GetVideoByName(name);
            return new FileStreamResult(stream, "video/mp4");
        }
    }
}