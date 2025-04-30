using System.Net.NetworkInformation;
using System.Security.Cryptography.Xml;
using Microsoft.AspNetCore.Mvc;
using modul10_103022300147.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace modul10_103022300147.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private static List<Movie> _MovieList = new List<Movie>
        {
            new Movie { Title = "The Shawshank", Director = "Frank Darabont", Stars = ["Tim Robbins","Morgan Freeman", "Bob Gunton"], Description = "A banker convicted of uxoricide " +
                "forms a friendship over a quarter century with a hardened convict, while maintaining his innocence and trying to remain hopeful through simple compassion."},
            new Movie { Title = "The Godfather", Director = "Francis Ford Coppola", Stars = ["Marlon Brando","Al Pacino", "James Caan"], Description = "An organized crime dynasty's aging patriarch transfers control of his clandestine empire to his reluctant son."},
            new Movie { Title = "The Dark Knight", Director = "Christopher Nolan", Stars = ["Christian Bale","Heath Ledger", "Aaron Eckhart"], Description = "When the menace known as the Joker emerges from his mysterious past, he wreaks havoc and chaos on the people of Gotham."},
        };

        [HttpGet]
        public ActionResult<List<Movie>> GetMovies()
        {
            return _MovieList;
        }

        [HttpGet("{index}")]
        public ActionResult<Movie> GetMovie(int index)
        {
            if (index < 0 || index >= _MovieList.Count)
            {
                return NotFound("Film dengan index tersebut tidak ditemukan.");
            }
            return _MovieList[index];
        }

        [HttpPost]
        public ActionResult<IEnumerable<Movie>> PostMovie([FromBody] Movie movie)
        {
            _MovieList.Add(movie);
            return _MovieList;
        }

        [HttpDelete("{index}")]
        public ActionResult DeleteMovie(int index)
        {
            if (index < 0 || index >= _MovieList.Count)
            {
                return NotFound("Film dengan index tersebut tidak ditemukan.");
            }
            _MovieList.RemoveAt(index);
            return NoContent();
        }
    }
}
