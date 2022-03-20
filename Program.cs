using DataLib;
using utils;
using System.Text.RegularExpressions;

namespace ProblemasDeBasesDeDatos
{
    class Program
    {
        static void Main(string[] args)
        {
            // 7. Obtener todos los campos de todos los concesionarios.
            var ex7 =
                from concesionario in LoadData.GetConcesionarios()
                select concesionario;

            var ex7m = LoadData.GetConcesionarios()
                .Select(elem => elem); // Select(elm => elm); Is really not needed.

            Console.WriteLine("7. ----------------------------------------------");
            Utilities.FormatedPrint(ex7);


            // 8. Obtener todos los campos de todos los clientes de 'Madrid'.
            var ex8 =
                from cliente in LoadData.GetClientes()
                where cliente.ciudad == "Madrid"
                select cliente;

            var ex8m = LoadData.GetClientes()
                .Where(elem => elem.ciudad == "Madrid");

            Console.WriteLine("8. ----------------------------------------------");
            Utilities.FormatedPrint(ex8);


            // 9. Obtener los nombres de todas las MARCAS de coches ordenadas alfabéticamente.
            var ex9 =
                from marca in LoadData.GetMarcas()
                orderby marca.nombre
                select new { nombre = marca.nombre };

            var ex9m = LoadData.GetMarcas()
                .OrderBy(marca => marca.nombre)
                .Select(marca => new { nombre = marca.nombre});

            Console.WriteLine("9. ----------------------------------------------");
            Utilities.FormatedPrint(ex9);


            // 10. Obtener el cifc de todos los concesionarios cuya cantidad en la tabla DISTRIBUCION es mayor que 18.
            var ex10 =
                from distribucion in LoadData.GetDistribucion()
                where distribucion.cantidad > 18
                select new { cifc = distribucion.cifc };

            var ex10m = LoadData.GetDistribucion()
                .Where(distribucion => distribucion.cantidad > 18)
                .Select(distribucion => new { cifc = distribucion.cifc });

            Console.WriteLine("10. ----------------------------------------------");
            Utilities.FormatedPrint(ex10);


            // 11. Obtener el cifc de todos los concesionarios cuya cantidad en la tabla DISTRIBUCION 
            // está comprendida entre 10 y 18 ambos inclusive.
            var ex11 =
                from distribucion in LoadData.GetDistribucion()
                where distribucion.cantidad >= 10 && distribucion.cantidad <= 18
                select new { cifc = distribucion.cifc };

            var ex11m = LoadData.GetDistribucion()
                .Where(distribucion => distribucion.cantidad >= 10 && distribucion.cantidad <= 18)
                .Select(distribucion => new { cifc = distribucion.cifc });

            Console.WriteLine("11. ----------------------------------------------");
            Utilities.FormatedPrint(ex11);


            // 12. Obtener el cifc de todos los concesionarios cuya cantidad en la tabla DISTRIBUCION
            // está comprendida entre 10 y 18 ambos inclusive.
            // No hay otra forma en Linq.


            // 13. Obtener el cifc de todos los concesionarios que han adquirido más de 10 coches o menos de 5.
            var ex13 =
                from distribucion in LoadData.GetDistribucion()
                where distribucion.cantidad > 10 || distribucion.cantidad < 5
                select new { cifc = distribucion.cifc };

            var ex13m = LoadData.GetDistribucion()
                .Where(distribucion => distribucion.cantidad > 10 || distribucion.cantidad < 5)
                .Select(distribucion => new { cifc = distribucion.cifc });

            Console.WriteLine("13. ----------------------------------------------");
            Utilities.FormatedPrint(ex13);


            // 14. Obtener todas las parejas de cifm de marcas y dni de clientes que sean de una misma ciudad.
            var ex14 =
                from marcas in LoadData.GetMarcas() join clientes in LoadData.GetClientes()
                on marcas.ciudad equals clientes.ciudad
                select new { marcas.cifm, clientes.dni };

            var ex14m = LoadData.GetMarcas().Join(
                        LoadData.GetClientes(),
                        marcas => marcas.ciudad,
                        clientes => clientes.ciudad,
                        (marcas, clientes) =>  new { marcas.cifm, clientes.dni }
                );

            Console.WriteLine("14. ----------------------------------------------");
            Utilities.FormatedPrint(ex14);


            // 15. Obtener todas las parejas de dni de clientes y cifm de marcas que NO sean de la misma ciudad.
            var ex15 =
                from marcas in LoadData.GetMarcas()
                from clientes in LoadData.GetClientes()
                where marcas.ciudad != clientes.ciudad
                select new { marcas.cifm, clientes.dni };

            var ex15m = LoadData.GetMarcas().Join(
                        LoadData.GetClientes(),
                        marcas => true,
                        clientes => true,
                        (marcas, clientes) =>  new { marcas.cifm, mc = marcas.ciudad, clientes.dni, cc = clientes.ciudad }
                )
                .Where(r => r.mc != r.cc);

            Console.WriteLine("15. ----------------------------------------------");
            Utilities.FormatedPrint(ex15);


            // 16. Obtener los codcoche suministrados por algún concesionario de 'Barcelona'.
            var ex16 =
                from concesionario in LoadData.GetConcesionarios() join distribucion in LoadData.GetDistribucion()
                on concesionario.cifc equals distribucion.cifc
                where concesionario.ciudad == "Barcelona"
                select new { distribucion.codcoche };

            var ex16m = LoadData.GetConcesionarios().Join(
                        LoadData.GetDistribucion(),
                        concesionario => concesionario.cifc,
                        distribucion => distribucion.cifc,
                        (concesionario, distribucion) =>  new { distribucion.codcoche, concesionario.ciudad }
                )
                .Where(r => r.ciudad == "Barcelona");

            Console.WriteLine("16. ----------------------------------------------");
            Utilities.FormatedPrint(ex16m);
            

            // 17. Obtener el codcoche de aquellos coches vendidos a clientes de 'Madrid'.
            var ex17 =
                from venta in LoadData.GetVentas() join cliente in LoadData.GetClientes()
                on venta.dni equals cliente.dni
                where cliente.ciudad == "Madrid"
                select new { venta.codcoche };

            var ex17m = LoadData.GetVentas().Join(
                        LoadData.GetClientes(),
                        venta => venta.dni,
                        cliente => cliente.dni,
                        (venta, cliente) =>  new { venta.codcoche, cliente.ciudad }
                )
                .Where(r => r.ciudad == "Madrid");

            Console.WriteLine("17. ----------------------------------------------");
            Utilities.FormatedPrint(ex17);


            // 18. Obtener el codcoche de los coches que han sido adquiridos por
            // un cliente de 'Madrid' a un concesionario de 'Madrid'.
            var ex18 =
                from venta in LoadData.GetVentas()
                join cliente in LoadData.GetClientes() on venta.dni equals cliente.dni
                join concesionario in LoadData.GetConcesionarios() on venta.cifc equals concesionario.cifc
                where cliente.ciudad == "Madrid" && concesionario.ciudad == "Madrid"
                select new { venta.codcoche };

            var ex18m = LoadData.GetVentas().Join(
                        LoadData.GetClientes(),
                        venta => venta.dni,
                        cliente => cliente.dni,
                        (venta, cliente) =>  new { venta.codcoche, venta.cifc, clienteCiudad = cliente.ciudad }
                        ).Join(LoadData.GetConcesionarios(),
                        ventaCliente => ventaCliente.cifc,
                        concesionario => concesionario.cifc,
                        (ventaCliente, concesionario) => new { ventaCliente.codcoche, ventaCliente.clienteCiudad, concesionario.ciudad }
                )
                .Where(r => r.ciudad == "Madrid" && r.clienteCiudad == "Madrid")
                .Select(r => new { r.codcoche });

            Console.WriteLine("18. ----------------------------------------------");
            Utilities.FormatedPrint(ex18);


            // 19. Obtener los codcoche de los coches comprados en un
            // concesionario de la misma ciudad que el cliente que lo compra.
            var ex19 =
                from venta in LoadData.GetVentas()
                join cliente in LoadData.GetClientes() on venta.dni equals cliente.dni
                join concesionario in LoadData.GetConcesionarios() on venta.cifc equals concesionario.cifc
                where cliente.ciudad == concesionario.ciudad
                select new { venta.codcoche };

            var ex19m = LoadData.GetVentas().Join(
                        LoadData.GetClientes(),
                        venta => venta.dni,
                        cliente => cliente.dni,
                        (venta, cliente) =>  new { venta.codcoche, venta.cifc, clienteCiudad = cliente.ciudad }
                        ).Join(LoadData.GetConcesionarios(),
                        ventaCliente => ventaCliente.cifc,
                        concesionario => concesionario.cifc,
                        (ventaCliente, concesionario) => new { ventaCliente.codcoche, ventaCliente.clienteCiudad, concesionario.ciudad }
                )
                .Where(r => r.ciudad == r.clienteCiudad)
                .Select(r => new { r.codcoche });

            Console.WriteLine("19. ----------------------------------------------");
            Utilities.FormatedPrint(ex19);


            // 20. Obtener los codcoche de los coches comprados en un
            // concesionario de distinta ciudad que el cliente que lo compra.
            var ex20 =
                from venta in LoadData.GetVentas()
                join cliente in LoadData.GetClientes() on venta.dni equals cliente.dni
                join concesionario in LoadData.GetConcesionarios() on venta.cifc equals concesionario.cifc
                where cliente.ciudad != concesionario.ciudad
                select new { venta.codcoche };

            var ex20m = LoadData.GetVentas().Join(
                        LoadData.GetClientes(),
                        venta => venta.dni,
                        cliente => cliente.dni,
                        (venta, cliente) =>  new { venta.codcoche, venta.cifc, clienteCiudad = cliente.ciudad }
                        ).Join(LoadData.GetConcesionarios(),
                        ventaCliente => ventaCliente.cifc,
                        concesionario => concesionario.cifc,
                        (ventaCliente, concesionario) => new { ventaCliente.codcoche, ventaCliente.clienteCiudad, concesionario.ciudad }
                )
                .Where(r => r.ciudad != r.clienteCiudad)
                .Select(r => new { r.codcoche });

            Console.WriteLine("20. ----------------------------------------------");
            Utilities.FormatedPrint(ex20);


            // 21. Obtener todas las parejas de nombre de marcas que sean de la
            // misma ciudad.
            // var ex21 = ??

            var ex21m = LoadData.GetMarcas().Join(
                        LoadData.GetMarcas(),
                        marca1 => marca1.ciudad,
                        marca2 => marca2.ciudad,
                        (m1, m2) =>
                        {
                            if (string.Compare(m1.nombre, m2.nombre) > 0)
                            {
                                return new { marca1 = m2.nombre, marca2 = m1.nombre };

                            }
                            return new { marca1 = m1.nombre, marca2 = m2.nombre };
                        })
                        .Distinct()
                        .Where(r => r.marca1 != r.marca2);

            Console.WriteLine("21. ----------------------------------------------");
            Utilities.FormatedPrint(ex21m);


            // 22. Obtener las parejas de modelos de coches cuyo nombre es el
            // mismo y cuya marca es de 'Bilbao'.
            // En la solución parece suponer que cuando un nombre de coche es igual
            // pertecene a la mima marca.
            // var ex22 = ??

            var ex22m = LoadData.GetCoches()
                        .Join
                        (
                            LoadData.GetCoches(),
                            coche1 => coche1.nombre,
                            coche2 => coche2.nombre,
                            (coche1, coche2) => 
                            new 
                            { 
                                coche1.nombre,
                                modelo1 = coche1.modelo,
                                modelo2 = coche2.modelo,
                                codcoche1 = coche1.codcoche,
                                codcoche2 = coche2.codcoche
                            }
                        )
                        .Where(r => r.modelo1 != r.modelo2)
                        .Select(r =>
                        {
                            if (string.Compare(r.modelo1, r.modelo2) > 0)
                            {
                                return new { nombre = r.nombre, modelo1 = r.modelo2, modelo2 = r.modelo1, codcoche1 = r.codcoche2, codcoche2 = r.codcoche1 };

                            }
                            return new { nombre = r.nombre, modelo1 = r.modelo1, modelo2 = r.modelo2, codcoche1 = r.codcoche1, codcoche2 = r.codcoche2 };
                        })
                        .Distinct()
                        .Join
                        (
                            LoadData.GetMarco(),
                            pareja => pareja.codcoche1,
                            marco => marco.codcoche,
                            (pareja, marco) => new { pareja.nombre, pareja.modelo1, pareja.modelo2, pareja.codcoche1, pareja.codcoche2, marco.cifm }
                        )
                        .Join
                        (
                            LoadData.GetMarcas(),
                            pareja => pareja.cifm,
                            marca => marca.cifm,
                            (pareja, marca) => new { pareja.nombre, pareja.modelo1, pareja.modelo2, pareja.codcoche1, pareja.codcoche2, marca.ciudad }
                        )
                        .Where(pareja => pareja.ciudad == "Bilbao");
            Console.WriteLine("22. ----------------------------------------------");
            Utilities.FormatedPrint(ex22m);


            // 23. Obtener todos los codcoche de los coches cuyo nombre empiece
            // por 'C'.
            // ex23?

            var ex23m = LoadData.GetCoches()
                        .Where(r => r.nombre.StartsWith("C"));

            Console.WriteLine("23. ----------------------------------------------");
            Utilities.FormatedPrint(ex23m);


            // 24. Obtener todos los codcoche de los coches cuyo nombre no 
            // contiene ninguna 'A'.
            // ex24?

            var ex24m = LoadData.GetCoches()
                        .Where(r => Regex.Match(r.nombre, @"^[^Aa]*$").Success);

            Console.WriteLine("24. ----------------------------------------------");
            Utilities.FormatedPrint(ex24m);


        }
    }
}
