﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace YouTubeViewers.ViewModels
{
    public class YouTubeViewersViewModel : ViewModelBase
    {
        public YouTubeViewersListingViewModel YouTubeViewersListingViewModel { get; }
        public YouTubeViewersDetailsViewModel YouTubeViewersDetailsViewModel { get; }
        public ICommand AddYouTubeViewerCommand { get; }

        public YouTubeViewersViewModel()
        {
            YouTubeViewersListingViewModel = new YouTubeViewersListingViewModel();
            YouTubeViewersDetailsViewModel = new YouTubeViewersDetailsViewModel();
        }
    }
}
