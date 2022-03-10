﻿using DataLib;

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
            FormatedPrint(ex7);


            // 8. Obtener todos los campos de todos los clientes de 'Madrid'
            var ex8 =
                from cliente in LoadData.GetClientes()
                where cliente.ciudad == "Madrid"
                select cliente;

            var ex8b = LoadData.GetClientes()
                .Where(elem => elem.ciudad == "Madrid");

            Console.WriteLine("8. ----------------------------------------------");
            FormatedPrint(ex8);


            // 9. Obtener los nombres de todas las MARCAS de coches ordenadas alfabéticamente
            var ex9 =
                from marca in LoadData.GetMarcas()
                orderby marca.nombre
                select new { nombre = marca.nombre };

            var ex9b = LoadData.GetMarcas()
                .OrderBy(marca => marca.nombre)
                .Select(marca => new { nombre = marca.nombre});

            Console.WriteLine("9. ----------------------------------------------");
            FormatedPrint(ex9);


            // 10. Obtener el cifc de todos los concesionarios cuya cantidad en la tabla DISTRIBUCION es mayor que 18
            var ex10 =
                from distribucion in LoadData.GetDistribucion()
                where distribucion.cantidad > 18
                select new { cifc = distribucion.cifc };

            var ex10b = LoadData.GetDistribucion()
                .Where(distribucion => distribucion.cantidad > 18)
                .Select(distribucion => new { cifc = distribucion.cifc });

            Console.WriteLine("10. ----------------------------------------------");
            FormatedPrint(ex10);


            // 11. Obtener el cifc de todos los concesionarios cuya cantidad en la tabla DISTRIBUCION está comprendida entre 10 y 18 ambos inclusive
            var ex11 =
                from distribucion in LoadData.GetDistribucion()
                where distribucion.cantidad >= 10 && distribucion.cantidad <= 18
                select new { cifc = distribucion.cifc };

            var ex11b = LoadData.GetDistribucion()
                .Where(distribucion => distribucion.cantidad >= 10 && distribucion.cantidad <= 18)
                .Select(distribucion => new { cifc = distribucion.cifc });

            Console.WriteLine("11. ----------------------------------------------");
            FormatedPrint(ex11);
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
            Console.WriteLine();
        }
    }

}
