namespace FrequencyDictionary;
class Program
{
    public static void Main(string[] args)
    {
      
        string sourceFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Voyna i mir.txt");
        new App().Start(sourceFile);

    }

   




}