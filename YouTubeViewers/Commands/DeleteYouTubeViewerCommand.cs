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
    public class DeleteYouTubeViewerCommand : AsyncCommandBase
    {
        private readonly YouTubeViewersListingItemViewModel _youTubeViewersListingItemViewModel;
        private readonly YouTubeViewersStore _youTubeViewersStore;

        public DeleteYouTubeViewerCommand(YouTubeViewersListingItemViewModel youTubeViewersListingItemViewModel,
                                            YouTubeViewersStore youTubeViewersStore)
        {
            _youTubeViewersListingItemViewModel = youTubeViewersListingItemViewModel;
            _youTubeViewersStore = youTubeViewersStore;
        }

        public YouTubeViewersListingItemViewModel YouTubeViewersListingItemViewModel { get; }
        public YouTubeViewersStore YouTubeViewersStore { get; }
        public ModalNavigationStore ModalNavigationStore { get; }

        public override async Task ExecuteAsync(object parameter)
        {
            YouTubeViewer youTubeViewer = _youTubeViewersListingItemViewModel.YouTubeViewer;

            try
            {
                await _youTubeViewersStore.Delete(youTubeViewer.Id);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
