using Microsoft.Extensions.Logging;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace TheWorld.Services
{
    public class CoordService
    {
        private ILogger<CoordService> _logger;

        public CoordService(ILogger<CoordService> logger)
        {
            _logger = logger;
        }

        public async Task<CoordServiceResult> Lookup(string location)
        {
            var result = new CoordServiceResult()
            {
                Success = false,
                Message = "Undetermined failure while looking up coordinates"
            };

            var encodedName = WebUtility.UrlEncode(location);
            var bingKey = Startup.Configuration["AppSettings:BingKey"];
            // Look up coord
            var url = $"http://dev.virtualearth.net/REST/v1/Locations?q={encodedName}&key={bingKey}";

            var client = new HttpClient();

            var json = await client.GetStringAsync(url);

            // Would do the json parsing here ..

            return result;
        }
    }
}
