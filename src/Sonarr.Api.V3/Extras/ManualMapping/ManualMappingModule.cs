using System;
using System.Collections.Generic;
using NzbDrone.Core.Datastore.Events;
using NzbDrone.Core.Messaging.Events;
using NzbDrone.SignalR;
using Sonarr.Http;

namespace Sonarr.Api.V3.Extras.ManualMapping
{
    public class ManualMappingModule : SonarrRestModuleWithSignalR<ManualMappingResource, NzbDrone.Core.DataAugmentation.Manual.ManualMapping>, IHandle<CommandExecutedEvent>
    {
        public ManualMappingModule(IBroadcastSignalRMessage broadcastSignalRMessage)
            : base(broadcastSignalRMessage, "extras/manualmapping")
        {
            GetResourceAll = GetAll;
        }

        private List<ManualMappingResource> GetAll()
        {
            return new List<ManualMappingResource>()
            {
                ConvertToResource(new NzbDrone.Core.DataAugmentation.Manual.ManualMapping
                {
                    TvdbId = 123,
                    Id = 123,
                    ManualMappingTitle = new Random().Next().ToString()
                })
            };
        }

        private static ManualMappingResource ConvertToResource(NzbDrone.Core.DataAugmentation.Manual.ManualMapping manualMapping)
        {
            return new ManualMappingResource
            {
                Id = manualMapping.Id,
                TvdbId = manualMapping.TvdbId,
                ManualMappingTitle = manualMapping.ManualMappingTitle
            };
        }

        public void Handle(CommandExecutedEvent message)
        {
            BroadcastResourceChange(ModelAction.Sync);
        }
    }
}
