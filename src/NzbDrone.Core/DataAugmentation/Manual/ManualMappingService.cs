using System;
using System.Collections.Generic;
using NLog;
using NzbDrone.Common.Cache;
using NzbDrone.Core.DataAugmentation.Scene;
using NzbDrone.Core.Datastore;
using NzbDrone.Core.Messaging.Events;
using NzbDrone.Core.Tv;
using NzbDrone.Core.Tv.Events;

namespace NzbDrone.Core.DataAugmentation.Manual
{
    public class ManualMapping : ModelBase
    {
        public int TvdbId { get; set; }
        public string ManualMappingTitle { get; set; }
    }

    public class ManualMappingService : ISceneMappingProvider, IHandle<SeriesUpdatedEvent>, IHandle<SeriesRefreshStartingEvent>
    {
        private readonly ISeriesService _seriesService;
        private readonly Logger _logger;
        private readonly ICachedDictionary<bool> _cache;

        public ManualMappingService(ISeriesService seriesService, ICacheManager cacheManager, Logger logger)
        {
            _seriesService = seriesService;
            _logger = logger;
            _cache = cacheManager.GetCacheDictionary<bool>(GetType(), "mappedTvdbid");
        }

        private void PerformUpdate(Series series)
        {

        }

        public List<SceneMapping> GetSceneMappings()
        {
            return new List<SceneMapping>
            {
                new SceneMapping
                {
                    FilterRegex = String.Empty,
                    TvdbId = 270065,
                    ParseTerm = String.Empty,
                    SceneSeasonNumber = null,
                    SearchTerm = "Manual Mapping - Search Term - Free!",
                    SeasonNumber = null,
                    Title = "Manual Mapping - Title - Free!",
                    Type = "Manual"
                }
            };
        }

        public void Handle(SeriesUpdatedEvent message)
        {
            if (_cache.IsExpired(TimeSpan.FromHours(3)))
            {

            }

            if (_cache.Count == 0)
            {
                _logger.Debug("Scene numbering is not available");
                return;
            }

            if (!_cache.Find(message.Series.TvdbId.ToString()) && !message.Series.UseSceneNumbering)
            {
                _logger.Debug("Scene numbering is not available for {0} [{1}]", message.Series.Title, message.Series.TvdbId);
                return;
            }

            PerformUpdate(message.Series);
        }

        public void Handle(SeriesRefreshStartingEvent message)
        {
            if (message.ManualTrigger && _cache.IsExpired(TimeSpan.FromMinutes(1)))
            {

            }
        }
    }
}
