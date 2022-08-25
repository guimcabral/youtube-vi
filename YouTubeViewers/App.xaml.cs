using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using YouTubeViewers.Stores;
using YouTubeViewers.ViewModels;

namespace YouTubeViewers
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ModalNavigationStore _modalNavigationStore;
        private readonly SelectedYouTubeViewerStore _selectedYouTubeViewerStore;

        public App()
        {
            _modalNavigationStore = new ModalNavigationStore();
            _selectedYouTubeViewerStore = new SelectedYouTubeViewerStore();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_modalNavigationStore, new YouTubeViewersViewModel(_selectedYouTubeViewerStore))
            };
            MainWindow.Show();

            base.OnStartup(e);
        }
    }
}
