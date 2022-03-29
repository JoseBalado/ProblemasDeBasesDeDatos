namespace utils
{
    class Utilities
    {
        public static void FormatedPrint(IEnumerable<object> list)
        {
            try
            {
                foreach (var property in list.First().GetType().GetProperties())
                {
                    Console.Write($"| {property.Name,-10}");
                }

                Console.WriteLine("|");

                foreach (var element in list)
                {
                    foreach (var property in element.GetType().GetProperties())
                    {
                        Console.Write($"| {property.GetValue(element),-10}");
                    }

                    Console.WriteLine("|");
                }

                Console.WriteLine();
                Console.WriteLine();
            }

            catch(Exception ex)
            {
                Console.WriteLine($"An exception was thrown. Message was: {ex.Message}");
                Console.WriteLine();
            }
        }
    }
}
