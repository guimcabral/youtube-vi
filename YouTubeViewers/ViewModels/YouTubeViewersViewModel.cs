using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using YouTubeViewers.Commands;
using YouTubeViewers.Stores;

namespace YouTubeViewers.ViewModels
{
    public class YouTubeViewersViewModel : ViewModelBase
    {
        public YouTubeViewersListingViewModel YouTubeViewersListingViewModel { get; }
        public YouTubeViewersDetailsViewModel YouTubeViewersDetailsViewModel { get; }
        public ICommand AddYouTubeViewerCommand { get; }

        public YouTubeViewersViewModel(
            YouTubeViewersStore youTubeViewersStore,
            SelectedYouTubeViewerStore selectedYouTubeViewerStore,
            ModalNavigationStore modalNavigationStore)
        {
            YouTubeViewersListingViewModel = YouTubeViewersListingViewModel.LoadViewModel(
                youTubeViewersStore,
                selectedYouTubeViewerStore,
                modalNavigationStore);

            YouTubeViewersDetailsViewModel = new YouTubeViewersDetailsViewModel(selectedYouTubeViewerStore);
            AddYouTubeViewerCommand = new OpenAddYouTubeViewerCommand(youTubeViewersStore, modalNavigationStore);
        }
    }
}
