using DataLib;
using utils;

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

            Console.WriteLine("7. ----------------------------------------------");
            Utilities.FormatedPrint(ex7);


            // 8. Obtener todos los campos de todos los clientes de 'Madrid'
            var ex8 =
                from cliente in LoadData.GetClientes()
                where cliente.ciudad == "Madrid"
                select cliente;

            var ex8b = LoadData.GetClientes()
                .Where(elem => elem.ciudad == "Madrid");

            Console.WriteLine("8. ----------------------------------------------");
            Utilities.FormatedPrint(ex8);


            // 9. Obtener los nombres de todas las MARCAS de coches ordenadas alfabéticamente
            var ex9 =
                from marca in LoadData.GetMarcas()
                orderby marca.nombre
                select new { nombre = marca.nombre };

            var ex9b = LoadData.GetMarcas()
                .OrderBy(marca => marca.nombre)
                .Select(marca => new { nombre = marca.nombre});

            Console.WriteLine("9. ----------------------------------------------");
            Utilities.FormatedPrint(ex9);


            // 10. Obtener el cifc de todos los concesionarios cuya cantidad en la tabla DISTRIBUCION es mayor que 18
            var ex10 =
                from distribucion in LoadData.GetDistribucion()
                where distribucion.cantidad > 18
                select new { cifc = distribucion.cifc };

            var ex10b = LoadData.GetDistribucion()
                .Where(distribucion => distribucion.cantidad > 18)
                .Select(distribucion => new { cifc = distribucion.cifc });

            Console.WriteLine("10. ----------------------------------------------");
            Utilities.FormatedPrint(ex10);


            // 11. Obtener el cifc de todos los concesionarios cuya cantidad en la tabla DISTRIBUCION está comprendida entre 10 y 18 ambos inclusive
            var ex11 =
                from distribucion in LoadData.GetDistribucion()
                where distribucion.cantidad >= 10 && distribucion.cantidad <= 18
                select new { cifc = distribucion.cifc };

            var ex11b = LoadData.GetDistribucion()
                .Where(distribucion => distribucion.cantidad >= 10 && distribucion.cantidad <= 18)
                .Select(distribucion => new { cifc = distribucion.cifc });

            Console.WriteLine("11. ----------------------------------------------");
            Utilities.FormatedPrint(ex11);


            // 12. Obtener el cifc de todos los concesionarios cuya cantidad en la tabla DISTRIBUCION está comprendida entre 10 y 18 ambos inclusive
            // No hay otra forma en Linq


            // 13. Obtener el cifc de todos los concesionarios que han adquirido más de 10 coches o menos de 5
            var ex13 =
                from distribucion in LoadData.GetDistribucion()
                where distribucion.cantidad > 10 || distribucion.cantidad < 5
                select new { cifc = distribucion.cifc };

            var ex13b = LoadData.GetDistribucion()
                .Where(distribucion => distribucion.cantidad > 10 || distribucion.cantidad < 5)
                .Select(distribucion => new { cifc = distribucion.cifc });

            Console.WriteLine("13. ----------------------------------------------");
            Utilities.FormatedPrint(ex13);


            // 14. Obtener todas las parejas de cifm de marcas y dni de clientes que sean de una misma ciudad
            var ex14 =
                from marcas in LoadData.GetMarcas() join clientes in LoadData.GetClientes()
                on marcas.ciudad equals clientes.ciudad
                select new { marcas.cifm, clientes.dni };

            var ex14b = LoadData.GetDistribucion()
                .Where(distribucion => distribucion.cantidad > 10 || distribucion.cantidad < 5)
                .Select(distribucion => new { cifc = distribucion.cifc });

            Console.WriteLine("14. ----------------------------------------------");
            Utilities.FormatedPrint(ex14);
        }
    }
}
