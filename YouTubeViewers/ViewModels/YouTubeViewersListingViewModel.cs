using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using YouTubeViewers.Commands;
using YouTubeViewers.Domain.Models;
using YouTubeViewers.Stores;

namespace YouTubeViewers.ViewModels
{
    public class YouTubeViewersListingViewModel : ViewModelBase
    {
        private readonly YouTubeViewersStore _youTubeViewersStore;
        private readonly SelectedYouTubeViewerStore _selectedYouTubeViewerStore;
        private readonly ModalNavigationStore _modalNavigationStore;
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

        public ICommand LoadYouTubeViewersCommand { get; }


        public YouTubeViewersListingViewModel(YouTubeViewersStore youTubeViewersStore,
                                              SelectedYouTubeViewerStore selectedYouTubeViewerStore,
                                              ModalNavigationStore modalNavigationStore)
        {
            _youTubeViewersStore = youTubeViewersStore;
            _selectedYouTubeViewerStore = selectedYouTubeViewerStore;
            _modalNavigationStore = modalNavigationStore;
            _youTubeViewersListingItemViewModels = new ObservableCollection<YouTubeViewersListingItemViewModel>();

            LoadYouTubeViewersCommand = new LoadYouTubeViewersCommand(youTubeViewersStore);

            _youTubeViewersStore.YouTubeViewersLodaded += YouTubeViewersStore_YouTubeViewersLodaded;
            _youTubeViewersStore.YouTubeViewerAdded += YouTubeViewersStore_YouTubeViewerAdded;
            _youTubeViewersStore.YouTubeViewerUpdated += YouTubeViewersStore_YouTubeViewerUpdated;
            _youTubeViewersStore.YouTubeViewerDeleted += YouTubeViewersStore_YouTubeViewerDeleted;
        }


        public static YouTubeViewersListingViewModel LoadViewModel(YouTubeViewersStore youTubeViewersStore,
                                                                   SelectedYouTubeViewerStore selectedYouTubeViewerStore,
                                                                   ModalNavigationStore modalNavigationStore)
        {
            YouTubeViewersListingViewModel viewModel =
                new YouTubeViewersListingViewModel(youTubeViewersStore, selectedYouTubeViewerStore, modalNavigationStore);

            viewModel.LoadYouTubeViewersCommand.Execute(null);

            return viewModel;
        }

        protected override void Dispose()
        {
            _youTubeViewersStore.YouTubeViewersLodaded -= YouTubeViewersStore_YouTubeViewersLodaded;
            _youTubeViewersStore.YouTubeViewerUpdated -= YouTubeViewersStore_YouTubeViewerUpdated;
            _youTubeViewersStore.YouTubeViewerAdded -= YouTubeViewersStore_YouTubeViewerAdded;
            base.Dispose();
        }

        private void YouTubeViewersStore_YouTubeViewersLodaded()
        {
            _youTubeViewersListingItemViewModels.Clear();

            foreach (YouTubeViewer youTubeViewer in _youTubeViewersStore.YouTubeViewers)
            {
                AddYouTubeViewer(youTubeViewer);
            }
        }

        private void YouTubeViewersStore_YouTubeViewerUpdated(YouTubeViewer youTubeViewer)
        {
            YouTubeViewersListingItemViewModel youTubeViewerViewModel =
                _youTubeViewersListingItemViewModels.FirstOrDefault(y => y.YouTubeViewer.Id == youTubeViewer.Id);

            if (youTubeViewerViewModel != null)
            {
                youTubeViewerViewModel.Update(youTubeViewer);
            }
        }

        private void YouTubeViewersStore_YouTubeViewerAdded(YouTubeViewer youTubeViewer)
        {
            AddYouTubeViewer(youTubeViewer);
        }

        private void YouTubeViewersStore_YouTubeViewerDeleted(Guid id)
        {
            YouTubeViewersListingItemViewModel itemViewModel = 
                _youTubeViewersListingItemViewModels.FirstOrDefault(y => y.YouTubeViewer.Id == id);

            if (itemViewModel != null)
            {
                _youTubeViewersListingItemViewModels.Remove(itemViewModel);
            }
        }

        private void AddYouTubeViewer(YouTubeViewer youTubeViewer)
        {
            YouTubeViewersListingItemViewModel itemViewModel =
                new YouTubeViewersListingItemViewModel(youTubeViewer, _youTubeViewersStore, _modalNavigationStore);
            _youTubeViewersListingItemViewModels.Add(itemViewModel);
        }
    }
}
