using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MovieViewer.Model;
using MovieViewer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MovieViewer.ViewModel
{
    public class MovieViewModel : ViewModelBase
    {
        public string SearchBox { get; set; }

        private List<MovieModel> _movies = new();
        public List<MovieModel> MovieList 
        {
            get => _movies;
            set => Set(ref _movies, value); 
        }

        private readonly IMovieClient MovieClient;

        public MovieViewModel(IMovieClient movieClient)
        {
            MovieClient = movieClient;
        }

        private RelayCommand? _searchCommand;
        public RelayCommand? SearchCommand
        {
            get => _searchCommand ??= new RelayCommand(
                () =>
                {
                    MovieModel[] searchRes = MovieClient.Fetch(SearchBox);
                    if (searchRes != null)
                        MovieList = new(searchRes);
                    else
                        MessageBox.Show($"Your search \"{SearchBox}\" didn't match any movies/series.", "404", MessageBoxButton.OK, MessageBoxImage.Error);
                });
        }
    }
}
