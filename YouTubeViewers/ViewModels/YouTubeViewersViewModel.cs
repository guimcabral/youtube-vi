﻿using System;
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

        private bool _isLoading;
        public bool IsLoading
        {
            get { return _isLoading; }
            set
            {
                _isLoading = value;
                OnPropertyChanged(nameof(IsLoading));
            }
        }

        private string _errorMessage;
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
                OnPropertyChanged(nameof(HasErrorMessage));
            }
        }

        public bool HasErrorMessage => !string.IsNullOrEmpty(_errorMessage);

        public ICommand AddYouTubeViewerCommand { get; }
        public ICommand LoadYouTubeViewersCommand { get; }

        public YouTubeViewersViewModel(
            YouTubeViewersStore youTubeViewersStore,
            SelectedYouTubeViewerStore selectedYouTubeViewerStore,
            ModalNavigationStore modalNavigationStore)
        {
            YouTubeViewersListingViewModel = new YouTubeViewersListingViewModel(
                youTubeViewersStore,
                selectedYouTubeViewerStore,
                modalNavigationStore);

            YouTubeViewersDetailsViewModel = new YouTubeViewersDetailsViewModel(selectedYouTubeViewerStore);

            LoadYouTubeViewersCommand = new LoadYouTubeViewersCommand(this, youTubeViewersStore);
            AddYouTubeViewerCommand = new OpenAddYouTubeViewerCommand(youTubeViewersStore, modalNavigationStore);
        }
        public static YouTubeViewersViewModel LoadViewModel(YouTubeViewersStore youTubeViewersStore,
                                                                   SelectedYouTubeViewerStore selectedYouTubeViewerStore,
                                                                   ModalNavigationStore modalNavigationStore)
        {
            YouTubeViewersViewModel viewModel =
                new YouTubeViewersViewModel(youTubeViewersStore, selectedYouTubeViewerStore, modalNavigationStore);

            viewModel.LoadYouTubeViewersCommand.Execute(null);

            return viewModel;
        }
    }
}
