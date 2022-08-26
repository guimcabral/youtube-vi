﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using YouTubeViewers.Commands;
using YouTubeViewers.Domain.Models;
using YouTubeViewers.Stores;

namespace YouTubeViewers.ViewModels
{
    public class YouTubeViewersListingItemViewModel : ViewModelBase
    {
        public YouTubeViewer YouTubeViewer { get; private set; }

        public string Username => YouTubeViewer.Username;
        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }

        public YouTubeViewersListingItemViewModel(YouTubeViewer youTubeViewer,
                                                  YouTubeViewersStore youTubeViewersStore,
                                                  ModalNavigationStore modalNavigationStore)
        {
            YouTubeViewer = youTubeViewer;
            EditCommand = new OpenEditYouTubeViewerCommand(this, youTubeViewersStore, modalNavigationStore);
            DeleteCommand = new DeleteYouTubeViewerCommand(this, youTubeViewersStore);
        }

        public void Update(YouTubeViewer youTubeViewer)
        {
            YouTubeViewer = youTubeViewer;
            OnPropertyChanged(nameof(Username));
        }
    }
}
