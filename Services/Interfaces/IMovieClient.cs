using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieViewer.Model;

namespace MovieViewer.Services.Interfaces
{
    public interface IMovieClient
    {
        public string? FetchJson(string movieName);
        public MovieModel[] Fetch(string movieName);
    }
}
