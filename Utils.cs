namespace utils
{
    class Utilities
    {
        public static void FormatedPrint(IEnumerable<object> list)
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
    }
}
}