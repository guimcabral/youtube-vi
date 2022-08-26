using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTubeViewers.Stores;

namespace YouTubeViewers.Commands
{
    public class LoadYouTubeViewersCommand : AsyncCommandBase
    {
        private readonly YouTubeViewersStore _youTubeViewersStore;

        public LoadYouTubeViewersCommand(YouTubeViewersStore youTubeViewersStore)
        {
            _youTubeViewersStore = youTubeViewersStore;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                await _youTubeViewersStore.Load();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
