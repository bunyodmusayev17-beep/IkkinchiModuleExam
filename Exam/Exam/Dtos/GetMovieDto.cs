namespace Exam.Dtos;

public class GetMovieDto
{
    public Guid Id { get; set; }
    public string Titile { get; set; }
    public string Director { get; set; }
    public int DurationMinuts { get; set; }
    public double Rating { get; set; }
    public long BoxOfficeEarnings { get; set; }
    public DateTime ReleaseDate { get; set; }
}
