﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTubeViewers.Domain.Models;
using YouTubeViewers.Stores;
using YouTubeViewers.ViewModels;

namespace YouTubeViewers.Commands
{
    public class OpenEditYouTubeViewerCommand : CommandBase
    {
        private readonly YouTubeViewersListingItemViewModel _youTubeViewersListingItemViewModel;
        private readonly YouTubeViewersStore _youTubeViewersStore;
        private readonly ModalNavigationStore _modalNavigationStore;

        public OpenEditYouTubeViewerCommand(YouTubeViewersListingItemViewModel youTubeViewersListingItemViewModel,
                                            YouTubeViewersStore youTubeViewersStore,
                                            ModalNavigationStore modalNavigationStore)
        {
            _youTubeViewersListingItemViewModel = youTubeViewersListingItemViewModel;
            _youTubeViewersStore = youTubeViewersStore;
            _modalNavigationStore = modalNavigationStore;
        }

        public YouTubeViewersListingItemViewModel YouTubeViewersListingItemViewModel { get; }
        public YouTubeViewersStore YouTubeViewersStore { get; }
        public ModalNavigationStore ModalNavigationStore { get; }

        public override void Execute(object parameter)
        {
            YouTubeViewer youTubeViewer = _youTubeViewersListingItemViewModel.YouTubeViewer;
            
            EditYouTubeViewerViewModel editYouTubeViewerViewModel = 
                new EditYouTubeViewerViewModel(youTubeViewer, _youTubeViewersStore,_modalNavigationStore);
            _modalNavigationStore.CurrentViewModel = editYouTubeViewerViewModel;
        }
    }
}
