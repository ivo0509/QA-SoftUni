using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp;

public class AverageGrade
{
    public static string GetGradeDefinition(List<double> grades)
    {
        double avg = grades.Average();

        if(avg >= 2 && avg < 3)
        {
            return "Fail";
        }
        else if(avg >= 3 && avg < 3.5)
        {
            return "Poor";
        }
        else if(avg >= 3.5 &&  avg < 4.5)
        {
            return "Good";
        }
        else if(avg >= 4.5 && avg < 5.5)
        {
            return "Very good";
        }
        else if(avg >= 5.5 && avg <= 6)
        {
            return "Excellent";
        }
        else
        {
            return "Incorrect grades";
        }
    }
}

