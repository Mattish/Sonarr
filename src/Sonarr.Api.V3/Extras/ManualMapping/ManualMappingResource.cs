using Sonarr.Http.REST;

namespace Sonarr.Api.V3.Extras.ManualMapping
{
    public class ManualMappingResource : RestResource
    {
        public int TvdbId { get; set; }
        public string ManualMappingTitle { get; set; }
    }
}
