public class CustomConverter
{
    public static bool ConvertTo(string value, out int result)
    {
        return int.TryParse(value, out result);
    }

    public static bool ConvertTo(string value, out double result)
    {
        return double.TryParse(value, out result);
    }
}

class Program
{
    static void Main()
    {
        string s = Console.ReadLine();
        int intValue;
        CustomConverter.ConvertTo(s, out intValue);
        Console.WriteLine(intValue);

        string a = Console.ReadLine(); //запятая
        double doubleValue;
        CustomConverter.ConvertTo(a, out doubleValue);
        Console.WriteLine(doubleValue);
    }
}