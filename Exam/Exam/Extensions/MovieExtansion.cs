using Exam.Dtos;
using Exam.Entities;

namespace Exam.Extensions;

 static class MovieExtansion 
{
    static int DurationMin(this GetMovieDto minutes)
    {
        var hour = minutes.DurationMinuts / 60;
        return hour;
    }

    static long BoxOfficeEarnings(this List<GetMovieDto> earnings)
    {
        var sum = 0;


        foreach (var e in earnings)
        {
            sum++;
        }
        return sum;

    }
}
