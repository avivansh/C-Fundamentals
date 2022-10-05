namespace GradeBook
{
    public class Book
    {
        public Book(string name)
        {
            grades = new List<double>();
            Name = name;
        }

        public Statistics GetStatistics()
        {
            var statistics = new Statistics();
            foreach (var num in grades)
            {
                statistics.average += num;
                statistics.high = Math.Max(statistics.high, num);
                statistics.low = Math.Min(statistics.low, num);
            }

            statistics.average /= grades.Count;

            return statistics;
        }

        public void AddGrade(double grade)
        {
            if (grade >= 0 && grade <= 100) grades.Add(grade);
            else throw new ArgumentException($"Invalid {nameof(grade)} !");
        }

        List<double> grades;
        public string Name;
    }
}