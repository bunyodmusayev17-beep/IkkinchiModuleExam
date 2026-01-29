using Exam.Dtos;

namespace Exam.Services
{
    public interface IMovieService
    {
        public Guid CreateMovie(CreateMovieDto createMovieDto);



        public bool DeleteMovie(Guid movieId);

        public List<GetMovieDto> GetAllMovies();

        public GetMovieDto? GetMovieById(Guid movieId);

        public bool UpdateMovie(Guid movieId,UpdateMovieDto movie);

        public List<GetMovieDto> GetAllMoviesByDirector(string director);

        public GetMovieDto? GetTopRatedMovie();

        public List<GetMovieDto>? GetMoviesReleasedAfterYear(int year);

        public GetMovieDto? GetHighestGrossingMovie();

        public List<GetMovieDto> SearchMovieByTitle(string title);
        
        public List<GetMovieDto> GetMoviesByDurationRange(int minMinutes, int maxMinutes);

        public long GetTotalBoxOfficeEarningsByDirector(string director);

        public List<GetMovieDto> GetMoviesSortedByRating();

        public List<GetMovieDto> GetRecentMovies(int years);

    }
}