using GradeBook;

var book = new Book("Vansh's GradeBook");

while (true)
{
    Console.WriteLine($"Enter the grade or q to quit:- ");
    var input = Console.ReadLine();
    if (input == null || input == "q") break;
    try
    {
        var grade = double.Parse(input);
        book.AddGrade(grade);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
    finally
    {
        Console.WriteLine("do something after input is taken!");
    }

}

var statistics = book.GetStatistics();

System.Console.WriteLine($"average is:- {statistics.average}");
