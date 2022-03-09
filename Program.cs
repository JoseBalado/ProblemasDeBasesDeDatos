using DataLib;

namespace ProblemasDeBasesDeDatos
{
    class Program
    {
        static void Main(string[] args)
        {
            // 7. Obtener todos los campos de todos los concesionarios
            var ex7 =
                from concesionario in LoadData.GetConcesionarios()
                select concesionario;

            var ex7b = LoadData.GetConcesionarios()
                .Select(elem => elem); // Select(elm => elm); Is really not needed

            FormatedPrint(ex7);

            // 8. Obtener todos los campos de todos los clientes de 'Madrid'
            var ex8 =
                from cliente in LoadData.GetClientes()
                where cliente.ciudad == "Madrid"
                select cliente;

            var ex8b = LoadData.GetClientes()
                .Where(elem => elem.ciudad == "Madrid");

            FormatedPrint(ex8);

            // 9. Obtener los nombres de todas las MARCAS de coches ordenadas alfábeticamente
            var ex9 =
                from marca in LoadData.GetMarcas()
                orderby marca.nombre
                select new { nombre = marca.nombre };

            var ex9b = LoadData.GetMarcas()
                .OrderBy(marca => marca.nombre)
                .Select(marca => new { nombre = marca.nombre});

            FormatedPrint(ex9);
        }

        static void FormatedPrint(IEnumerable<object> list)
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
            Console.WriteLine("--------------------------------------------------");
        }
    }

}
