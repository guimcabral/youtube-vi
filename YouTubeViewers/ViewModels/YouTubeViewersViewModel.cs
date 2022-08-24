using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using YouTubeViewers.Stores;

namespace YouTubeViewers.ViewModels
{
    public class YouTubeViewersViewModel : ViewModelBase
    {
        public YouTubeViewersListingViewModel YouTubeViewersListingViewModel { get; }
        public YouTubeViewersDetailsViewModel YouTubeViewersDetailsViewModel { get; }
        public ICommand AddYouTubeViewerCommand { get; }

        public YouTubeViewersViewModel(SelectedYouTubeViewerStore _selectedYouTubeViewerStore)
        {
            YouTubeViewersDetailsViewModel = new YouTubeViewersDetailsViewModel(_selectedYouTubeViewerStore);
            YouTubeViewersListingViewModel = new YouTubeViewersListingViewModel(_selectedYouTubeViewerStore);
        }
    }
}
