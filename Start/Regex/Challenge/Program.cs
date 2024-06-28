using System;
using System.Text.RegularExpressions;

public class Program
{
    public static void Main()
    {
        while (true)
        {
            Console.Write("Enter a date (mm/dd/yyyy): ");
            string input = Console.ReadLine();

            try
            {
                string output = ReverseDateFormat(input);
                Console.WriteLine("Converted date: " + output);
            }
            catch (RegexMatchTimeoutException)
            {
                Console.WriteLine("The operation timed out. Please try again.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid date format. Please try again.");
            }
        }
    }

    public static string ReverseDateFormat(string date)
    {
        if (!DateTime.TryParse(date, out _))
        {
            throw new FormatException();
        }
        var regex = new Regex(@"^(?<mon>\d{1,2})/(?<day>\d{1,2})/(?<year>\d{2,4})$", RegexOptions.Compiled, TimeSpan.FromMilliseconds(500));
        return regex.Replace(date, "${year}-${mon}-${day}");
    }
}
