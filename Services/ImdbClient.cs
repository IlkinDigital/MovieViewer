using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieViewer.Model;
using MovieViewer.Services.Interfaces;
using System.Text.Json;
using System.Net;

// https://www.omdbapi.com/?s=MOVIE_NAME_HERE&apikey=d5c16a03

namespace MovieViewer.Services
{
    public class ImdbClient : IMovieClient
    {
        private WebClient webClient = new();
        private string _url = "https://www.omdbapi.com/?apikey=";
        private string _apiKey = "d5c16a03";

        public string FetchJson(string movieName)
        {
            return webClient.DownloadString($"{_url}{_apiKey}&s={movieName}");
        }

        public MovieModel[]? Fetch(string movieName)
        {
            string rawJson = FetchJson(movieName);
            return JsonSerializer.Deserialize<MovieListModel>(rawJson).Search;
        }
    }
}
