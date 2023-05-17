using RestSharp;

namespace OmdbAPILab.Models
{
    public class MoviesDAL
    {
        public Movie GetMovie(string title)
        {
            string URL = $"http://www.omdbapi.com/?apikey=bbe2a1e6&t={title}";
            RestClient client = new RestClient(URL);
            RestRequest request = new RestRequest();

            Movie response = client.Get<Movie>(request);

            return response;
        }

    }
}
