class Program
{
    static void Main()
    {
        ReportGenerator studentReport = new StudentReportGenerator();
        studentReport.GenerateReport();

        ReportGenerator courseReport = new CourseReportGenerator();
        courseReport.GenerateReport();
    }
}

abstract class ReportGenerator
{
    public void GenerateReport()
    {
        CollectData();
        ProcessData();
        FormatReport();
        ExportReport();
    }

    public abstract void CollectData();
    public abstract void ProcessData();
    public abstract void FormatReport();

    public void ExportReport()
    {
        Console.WriteLine("Report has been exported.");
    }
}

class StudentReportGenerator : ReportGenerator
{
    public override void CollectData()
    {
        Console.WriteLine("collect...");
    }

    public override void ProcessData()
    {
        Console.WriteLine("data...");
    }

    public override void FormatReport()
    {
        Console.WriteLine("report...");
    }
}

class CourseReportGenerator : ReportGenerator
{
    public override void CollectData()
    {
        Console.WriteLine("Collecting...");
    }

    public override void ProcessData()
    {
        Console.WriteLine("processing data...");
    }

    public override void FormatReport()
    {
        Console.WriteLine("formatting report...");
    }
}
