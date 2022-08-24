using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTubeViewers.Models;
using YouTubeViewers.Stores;

namespace YouTubeViewers.ViewModels
{
    public class YouTubeViewersListingViewModel : ViewModelBase
    {
        private readonly SelectedYouTubeViewerStore _selectedYouTubeViewerStore;
        private readonly ObservableCollection<YouTubeViewersListingItemViewModel> _youTubeViewersListingItemViewModels;

        public IEnumerable<YouTubeViewersListingItemViewModel> YouTubeViewersListingItemViewModels => _youTubeViewersListingItemViewModels;

        private YouTubeViewersListingItemViewModel _selectedYouTubeViewerListingItemViewModel;

        public YouTubeViewersListingItemViewModel SelectedYouTubeViewerListingItemViewModel
        {
            get
            {
                return _selectedYouTubeViewerListingItemViewModel;
            }
            set
            {
                _selectedYouTubeViewerListingItemViewModel = value;
                OnPropertyChanged(nameof(SelectedYouTubeViewerListingItemViewModel));

                _selectedYouTubeViewerStore.SelectedYouTubeViewer = _selectedYouTubeViewerListingItemViewModel?.YouTubeViewer;
            }
        }


        public YouTubeViewersListingViewModel(SelectedYouTubeViewerStore selectedYouTubeViewerStore)
        {
            _youTubeViewersListingItemViewModels = new ObservableCollection<YouTubeViewersListingItemViewModel>();
            _youTubeViewersListingItemViewModels.Add(new YouTubeViewersListingItemViewModel(new YouTubeViewer("Mary", true, false)));
            _youTubeViewersListingItemViewModels.Add(new YouTubeViewersListingItemViewModel(new YouTubeViewer("Sean", false, false)));
            _youTubeViewersListingItemViewModels.Add(new YouTubeViewersListingItemViewModel(new YouTubeViewer("Alan", true, true)));
            _selectedYouTubeViewerStore = selectedYouTubeViewerStore;
        }
    }
}
