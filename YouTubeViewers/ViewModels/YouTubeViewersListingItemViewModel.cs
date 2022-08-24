using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using YouTubeViewers.Models;

namespace YouTubeViewers.ViewModels
{
    public class YouTubeViewersListingItemViewModel : ViewModelBase
    {
        public YouTubeViewer YouTubeViewer { get; }

        public string Username => YouTubeViewer.Username;
        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }

        public YouTubeViewersListingItemViewModel(YouTubeViewer youTubeViewer)
        {
            YouTubeViewer = youTubeViewer;
        }

    }
}
