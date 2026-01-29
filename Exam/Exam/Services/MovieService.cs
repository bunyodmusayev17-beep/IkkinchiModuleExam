using Exam.Dtos;
using Exam.Entities;

namespace Exam.Services;

public class MovieService : IMovieService
{

    private List<Movie> movies;

    public MovieService()
    {
        movies = new List<Movie>();
    }
    
 


    public Guid CreateMovie(CreateMovieDto createMovieDto)
    {
        var movie = new Movie()
        {
            Id = Guid.NewGuid(),
            Titile = createMovieDto.Titile,
            Director = createMovieDto.Director,
            DurationMinuts = createMovieDto.DurationMinuts,
            Rating = createMovieDto.Rating,
            BoxOfficeEarnings = createMovieDto.BoxOfficeEarnings,
            ReleaseDate = createMovieDto.ReleaseDate

        };
        
        
        
        movies.Add(movie);
        return movie.Id;
    }

    public bool DeleteMovie(Guid movieId)
    {

        foreach (var movie in movies)
        {
            if (movie.Id == movieId)
            {
                movies.Remove(movie);
            }

        }
        return false;

    }

    public List<GetMovieDto> GetAllMovies()
    {
        var movieDtos = ToMovieGetDtos(movies);
        return movieDtos;


    }

    public GetMovieDto? GetMovieById(Guid movieId)
    {
        foreach (var movie in movies)
        {
            if (movie.Id == movieId)
            {
                return ToMovieGetDto(movie);
            }
        }
        return null;
    }



    public bool UpdateMovie(Guid movieId, UpdateMovieDto newmovie)
    {
        foreach (var movie in movies)
        {
            if (movie.Id == movieId)
            {
                movie.Titile = newmovie.Titile;
                movie.Director = newmovie.Director;
                movie.DurationMinuts = newmovie.DurationMinuts;
                movie.BoxOfficeEarnings = newmovie.BoxOfficeEarnings;
                movie.Rating = newmovie.Rating;
                movie.ReleaseDate = newmovie.ReleaseDate;
                return true;
            }
        }
        return false;
    }



    public List<GetMovieDto> GetAllMoviesByDirector(string director)
    {
        var movies = new List<GetMovieDto>();
        foreach (var movie in movies)
        {
            if (movie.Director == director)
            {
                movies.Add(movie);
            }
        }
        return movies;
    }

    public GetMovieDto? GetHighestGrossingMovie()
    {
        if (movies.Count() == 0)
        {
            return null;
        }

        var highestGrossingMovie = movies[0];

        foreach (var movie in movies)
        {
            if (movie.BoxOfficeEarnings > highestGrossingMovie.BoxOfficeEarnings)
            {
                highestGrossingMovie = movie;
            }

        }

        return ToMovieGetDto(highestGrossingMovie);
    }



    public List<GetMovieDto> GetMoviesByDurationRange(int minMinutes, int maxMinutes)
    {
        var movieListByDuration = new List<Movie>();
        foreach (var movie in movies)
        {
            if (movie.DurationMinuts >= minMinutes && movie.DurationMinuts <= maxMinutes)
            {
                movieListByDuration.Add(movie);
            }
        }
        return ToMovieGetDtos(movieListByDuration);
    }

    public List<GetMovieDto>? GetMoviesReleasedAfterYear(int year)
    {
        if (movies.Count() == 0)
        {
            return null;
        }
        var moviesReleasedAfterYear = new List<Movie>();

        foreach (var movie in movies)
        {
            if (movie.DurationMinuts < year)
            {
                moviesReleasedAfterYear.Add(movie);
            }
        }
        return ToMovieGetDtos(moviesReleasedAfterYear);

    }

    public List<GetMovieDto> GetMoviesSortedByRating()
    {
        var movieRatings = new List<Movie>();

        var minRating = movies[0];

        foreach (var movie in movies)
        {
            if (movie.Rating > minRating.Rating)
            {
                movieRatings.Add(movie);
            }
        }
        return ToMovieGetDtos(movieRatings);
    }

    public List<GetMovieDto> GetRecentMovies(int years)
    {
        var recentMovies = new List<Movie>();

        var lastMovie = movies[0];

        foreach (var movie in movies)
        {
            if (movie.ReleaseDate > lastMovie.ReleaseDate)
            {
                recentMovies.Add(movie);
            }
        }

        return ToMovieGetDtos(recentMovies);
    }

    public GetMovieDto? GetTopRatedMovie()
    {
        if (movies.Count() == 0)
        {
            return null;
        }


        var topRatedMovie = movies[0];

        foreach (var movie in movies)
        {
            if (movie.Rating > topRatedMovie.Rating)
            {
                topRatedMovie = movie;
            }
        }
        return ToMovieGetDto(topRatedMovie);
    }

    public long GetTotalBoxOfficeEarningsByDirector(string director)
    {
        long totalBoxOfficeEarnings = 0;


        foreach (var movie in movies)
        {
            if (movie.Director == director)
            {
                totalBoxOfficeEarnings++;
            }
        }
        return totalBoxOfficeEarnings;
    }

    public List<GetMovieDto> SearchMovieByTitle(string title)
    {
        var moviesWithTitle = new List<Movie>();

        foreach (var movie in movies)
        {
            if (movie.Titile == title)
            {
                moviesWithTitle.Add(movie);
            }
        }
        return ToMovieGetDtos(moviesWithTitle);
    }










    private GetMovieDto ToMovieGetDto(Movie movies)
    {
        return new GetMovieDto()
        {
            Id = movies.Id,
            Titile = movies.Titile,
            Director = movies.Director,
            DurationMinuts = movies.DurationMinuts,
            Rating = movies.Rating,
            BoxOfficeEarnings = movies.BoxOfficeEarnings,
            ReleaseDate = movies.ReleaseDate,

        };
    }

    private List<GetMovieDto> ToMovieGetDtos(List<Movie> movies)
    {
        var movieGetDtos = new List<GetMovieDto>();

        foreach (var movie in movies)
        {
            movieGetDtos.Add(ToMovieGetDto(movie));
        }

        return movieGetDtos;
    }



}
