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

            var ex7em = 
                LoadData.GetConcesionarios()
                .Select(elem => elem); // Select(elm => elm); Is really not needed.

            Console.WriteLine("7. ----------------------------------------------");
            Utilities.FormatedPrint(ex7);


            // 8. Obtener todos los campos de todos los clientes de 'Madrid'.
            var ex8 =
                from cliente in LoadData.GetClientes()
                where cliente.ciudad == "Madrid"
                select cliente;

            var ex8em = 
                LoadData.GetClientes()
                .Where(elem => elem.ciudad == "Madrid");

            Console.WriteLine("8. ----------------------------------------------");
            Utilities.FormatedPrint(ex8);


            // 9. Obtener los nombres de todas las MARCAS de coches ordenadas alfabéticamente.
            var ex9 =
                from marca in LoadData.GetMarcas()
                orderby marca.nombre
                select new { nombre = marca.nombre };

            var ex9em = 
                LoadData.GetMarcas()
                .OrderBy(marca => marca.nombre)
                .Select(marca => new { nombre = marca.nombre});

            Console.WriteLine("9. ----------------------------------------------");
            Utilities.FormatedPrint(ex9);


            // 10. Obtener el cifc de todos los concesionarios cuya cantidad en la tabla DISTRIBUCION es mayor que 18.
            var ex10 =
                from distribucion in LoadData.GetDistribucion()
                where distribucion.cantidad > 18
                select new { cifc = distribucion.cifc };

            var ex10em = 
                LoadData.GetDistribucion()
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

            var ex11em = 
                LoadData.GetDistribucion()
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

            var ex13em = 
                LoadData.GetDistribucion()
                .Where(distribucion => distribucion.cantidad > 10 || distribucion.cantidad < 5)
                .Select(distribucion => new { cifc = distribucion.cifc });

            Console.WriteLine("13. ----------------------------------------------");
            Utilities.FormatedPrint(ex13);


            // 14. Obtener todas las parejas de cifm de marcas y dni de clientes que sean de una misma ciudad.
            var ex14 =
                from marcas in LoadData.GetMarcas()
                join clientes in LoadData.GetClientes()
                on marcas.ciudad equals clientes.ciudad
                select new { marcas.cifm, clientes.dni };

            var ex14em = 
                LoadData.GetMarcas()
                .Join
                (
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

            var ex15em = 
                LoadData.GetMarcas()
                .Join
                (
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
                from concesionario in LoadData.GetConcesionarios() 
                join distribucion in LoadData.GetDistribucion()
                on concesionario.cifc equals distribucion.cifc
                where concesionario.ciudad == "Barcelona"
                select new { distribucion.codcoche };

            var ex16em = 
                LoadData.GetConcesionarios()
                .Join
                (
                    LoadData.GetDistribucion(),
                    concesionario => concesionario.cifc,
                    distribucion => distribucion.cifc,
                    (concesionario, distribucion) =>  new { distribucion.codcoche, concesionario.ciudad }
                )
                .Where(r => r.ciudad == "Barcelona");

            Console.WriteLine("16. ----------------------------------------------");
            Utilities.FormatedPrint(ex16em);
            

            // 17. Obtener el codcoche de aquellos coches vendidos a clientes de 'Madrid'.
            var ex17 =
                from venta in LoadData.GetVentas()
                join cliente in LoadData.GetClientes()
                on venta.dni equals cliente.dni
                where cliente.ciudad == "Madrid"
                select new { venta.codcoche };

            var ex17em =
                LoadData.GetVentas()
                .Join
                (
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
                join cliente in LoadData.GetClientes()
                on venta.dni equals cliente.dni
                join concesionario in LoadData.GetConcesionarios()
                on venta.cifc equals concesionario.cifc
                where cliente.ciudad == "Madrid" && concesionario.ciudad == "Madrid"
                select new { venta.codcoche };

            var ex18em = 
                LoadData.GetVentas()
                .Join
                (
                    LoadData.GetClientes(),
                    venta => venta.dni,
                    cliente => cliente.dni,
                    (venta, cliente) =>  new { venta.codcoche, venta.cifc, clienteCiudad = cliente.ciudad }
                )
                .Join
                (
                    LoadData.GetConcesionarios(),
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
                join cliente in LoadData.GetClientes()
                on venta.dni equals cliente.dni
                join concesionario in LoadData.GetConcesionarios()
                on venta.cifc equals concesionario.cifc
                where cliente.ciudad == concesionario.ciudad
                select new { venta.codcoche };

            var ex19em = 
                LoadData.GetVentas()
                .Join
                (
                    LoadData.GetClientes(),
                    venta => venta.dni,
                    cliente => cliente.dni,
                    (venta, cliente) =>  new { venta.codcoche, venta.cifc, clienteCiudad = cliente.ciudad }
                )
                .Join
                (
                    LoadData.GetConcesionarios(),
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
                join cliente in LoadData.GetClientes() 
                on venta.dni equals cliente.dni
                join concesionario in LoadData.GetConcesionarios()
                on venta.cifc equals concesionario.cifc
                where cliente.ciudad != concesionario.ciudad
                select new { venta.codcoche };

            var ex20em =
                LoadData.GetVentas()
                .Join
                (
                    LoadData.GetClientes(),
                    venta => venta.dni,
                    cliente => cliente.dni,
                    (venta, cliente) =>  new { venta.codcoche, venta.cifc, clienteCiudad = cliente.ciudad }
                )
                .Join
                (
                    LoadData.GetConcesionarios(),
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

            var ex21em = 
                LoadData.GetMarcas()
                .Join
                (
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
                    }
                )
                .Distinct()
                .Where(r => r.marca1 != r.marca2);

            Console.WriteLine("21. ----------------------------------------------");
            Utilities.FormatedPrint(ex21em);


            // 22. Obtener las parejas de modelos de coches cuyo nombre es el
            // mismo y cuya marca es de 'Bilbao'.
            // En la solución parece suponer que cuando un nombre de coche es igual
            // pertecene a la mima marca.
            // var ex22 = ??

            var ex22em = 
                LoadData.GetCoches()
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
                .Select
                (
                    r =>
                    {
                        if (string.Compare(r.modelo1, r.modelo2) > 0)
                        {
                            return new { nombre = r.nombre, modelo1 = r.modelo2, modelo2 = r.modelo1, codcoche1 = r.codcoche2, codcoche2 = r.codcoche1 };

                        }
                        return new { nombre = r.nombre, modelo1 = r.modelo1, modelo2 = r.modelo2, codcoche1 = r.codcoche1, codcoche2 = r.codcoche2 };
                    }
                )
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
            Utilities.FormatedPrint(ex22em);


            // 23. Obtener todos los codcoche de los coches cuyo nombre empiece
            // por 'C'.
            // ex23?

            var ex23em = 
                LoadData.GetCoches()
                .Where(r => r.nombre.StartsWith("C"));

            Console.WriteLine("23. ----------------------------------------------");
            Utilities.FormatedPrint(ex23em);


            // 24. Obtener todos los codcoche de los coches cuyo nombre no 
            // contiene ninguna 'A'.
            // ex24?

            var ex24em = 
                LoadData.GetCoches()
                .Where(r => Regex.Match(r.nombre, @"^[^Aa]*$").Success);

            Console.WriteLine("24. ----------------------------------------------");
            Utilities.FormatedPrint(ex24em);


            // 25. Obtener el número total de nombre de marcas de coches que son
            // de Madrid.
            var ex25 =
                (from marca in LoadData.GetMarcas()
                where marca.ciudad == "Madrid"
                select marca.nombre)
                .Distinct()
                .Count();

            var ex25em = 
                LoadData.GetMarcas()
                .Where(r => r.ciudad == "Madrid")
                .Select(r => r.nombre)
                .Distinct()
                .Count();

            Console.WriteLine("25. ----------------------------------------------");
            Console.WriteLine("Obtener el número total de nombre de marcas de coches que son de Madrid: {0}", ex25);
            Console.WriteLine();


            // 26. Obtener la media de la cantidad de coches que tienen todos los
            // concesionarios.
            var ex26 = 
                (from concesinario in LoadData.GetDistribucion()
                group concesinario by concesinario.cifc into c
                select new { key = c.Key, concesionarioSum = c.Sum(g => g.cantidad ) })
                .Average(r => r.concesionarioSum);


            var ex26em = 
                LoadData.GetDistribucion()
                .GroupBy(r => r.cifc)
                .Select
                (
                    g => new
                    {
                        Group = g,
                        g.Key,
                        Count = (g.Sum(group => group.cantidad ))
                    }
                )
                .Average(r => r.Count);

            Console.WriteLine("26. ----------------------------------------------");
            Console.WriteLine(ex26);
            Console.WriteLine();


            // 27. Obtener el dni con numeración más alta de todos los clientes de
            // 'Madrid'.
            var ex27 =
                (from cliente in LoadData.GetClientes()
                where cliente.ciudad == "Madrid"
                select cliente.dni)
                .Max();


            var ex27em =
                LoadData.GetClientes()
                .Where(r => r.ciudad == "Madrid")
                .Max(r => r.dni);

            Console.WriteLine("27. ----------------------------------------------");
            Console.WriteLine(ex27);
            Console.WriteLine();


            // 28. Obtener el dni con numeración más baja de todos los clientes que
            // han comprado un choche 'Blanco'.
            var ex28 =
                (from venta in LoadData.GetVentas()
                where venta.color == "Blanco"
                select venta.dni)
                .Min();


            var ex28em =
                LoadData.GetVentas()
                .Where(r => r.color == "Blanco")
                .Min(r => r.dni);

            Console.WriteLine("28. ----------------------------------------------");
            Console.WriteLine(ex28);
            Console.WriteLine();


            // 29. Obtener el cifc de todos los concesionarios cuyo número de
            // coches en stock no es nulo.
            var ex29 =
                (from distribucion in LoadData.GetDistribucion()
                where distribucion.cantidad != 0
                select new { distribucion.cifc })
                .Distinct();


            var ex29em =
                LoadData.GetDistribucion()
                .Where(r => r.cantidad != 0)
                .Select(r => new { r.cifc })
                .Distinct();

            Console.WriteLine("29. ----------------------------------------------");
            Utilities.FormatedPrint(ex29);


            // 30. Obtener el cifm y el nombre de las marcas de coches cuya
            // segunda letra del nombre de la ciudad de origen sean una 'I'.
            // var ex30?
            var ex30em =
                LoadData.GetMarcas()
                .Where(r => Regex.Match(r.ciudad, @"^.i.*").Success);

            Console.WriteLine("30. ----------------------------------------------");
            Utilities.FormatedPrint(ex30em);


            // 31. Obtener el dni de los clientes que han comprado algún coche a un
            // concesionario de 'Madrid'.
            // Replacing 'IN' with 'Contains'.
            var ex31 =
                (from concesionario in LoadData.GetConcesionarios()
                join venta in LoadData.GetVentas()
                on concesionario.cifc equals venta.cifc
                where concesionario.ciudad == "Madrid"
                select new { venta.dni })
                .Distinct();

            var ex31em =
                LoadData.GetConcesionarios()
                .Where(r => r.ciudad == "Madrid")
                .Join
                (
                    LoadData.GetVentas(),
                    concecionario => concecionario.cifc,
                    venta => venta.cifc,
                    (concesionario, venta) => new { venta.dni }
                )
                .Distinct();


            var cifcConcesionarios =
                LoadData.GetConcesionarios()
                .Where(r => r.ciudad == "Madrid")
                .Select(r => r.cifc);

            var ex31emb = LoadData.GetVentas()
            .Where(r => cifcConcesionarios.Contains(r.cifc))
            .Select(r => new { r.dni })
            .Distinct();

            Console.WriteLine("31. ----------------------------------------------");
            Utilities.FormatedPrint(ex31);


            // 32. Obtener el color de los coches vendidos por el concesionario
            // 'ACAR'.
            // Replacing 'IN' with 'Contains'.
            var ex32 =
                from concesionario in LoadData.GetConcesionarios()
                join venta in LoadData.GetVentas()
                on concesionario.cifc equals venta.cifc
                where concesionario.nombre == "ACAR"
                select new { concesionario.cifc, concesionario.nombre, venta.color };

            var ex32em =
                LoadData.GetConcesionarios()
                .Join
                (
                    LoadData.GetVentas(),
                    concesionario => concesionario.cifc,
                    venta => venta.cifc,
                    (concesionario, venta) => new { concesionario.cifc, concesionario.nombre, venta.color }
                )
                .Where(r => r.nombre == "ACAR");

            // var ex32b =
            //     from ventas in LoadData.GetVentas()
            //     where concesionario.nombre == "ACAR"
            //     select new { concesionario.cifc };

            var cifc32em =
                LoadData.GetConcesionarios()
                .Where(r => r.nombre == "ACAR")
                .Select(r => new { r.cifc });

            var ex32emb = LoadData.GetVentas()
            .Where(r => cifc32em.Contains(new { r.cifc}))
            .Select(r => new { r.color })
            .Distinct();

            Console.WriteLine("32. ----------------------------------------------");
            Utilities.FormatedPrint(ex32);


            // 33. Obtener el codc de los coches vendidos por algún concesionario
            // de 'Madrid'.
            // Replacing 'IN' with 'Contains'.
            var cifc33em =
                LoadData.GetConcesionarios()
                .Where(r => r.ciudad == "Madrid")
                .Select(r => new { r.cifc });

            var ex33em = LoadData.GetVentas()
            .Where(r => cifc33em.Contains(new { r.cifc}))
            .Select(r => new { r.codcoche });

            Console.WriteLine("33. ----------------------------------------------");
            Utilities.FormatedPrint(ex33em);


            // 34. Obtener el nombre y el modelo de los coches vendidos por algún
            // concesionario de 'Barcelona'.
            // Replacing 'IN' with 'Contains'.
            var cifc34em =
                LoadData.GetConcesionarios()
                .Where(r => r.ciudad == "Barcelona")
                .Select(r => new { r.cifc });

            var codcoche34em =
                LoadData.GetVentas()
                .Where(r => cifc34em.Contains(new { r.cifc}))
                .Select(r => new { r.codcoche });

            var ex34em =
                LoadData.GetCoches()
                .Where(r => codcoche34em.Contains(new { r.codcoche }));

            Console.WriteLine("34. ----------------------------------------------");
            Utilities.FormatedPrint(ex34em);


            // 35. Obtener todos los nombres de los clientes que hayan adquirido
            // algún conche del concesionario 'DCAR'.
            // Replacing 'IN' with 'Contains'.
            var cifc35em =
                LoadData.GetConcesionarios()
                .Where(r => r.nombre == "DCAR")
                .Select(r => new { r.cifc });

            var dni35em =
                LoadData.GetVentas()
                .Where(r => cifc35em.Contains(new { r.cifc}))
                .Select(r => new { r.dni });

            var ex35em =
                LoadData.GetClientes()
                .Where(r => dni35em.Contains(new { r.dni }));

            Console.WriteLine("35. ----------------------------------------------");
            Utilities.FormatedPrint(ex35em);


            // 36. Obtener el nombre y el apellido de los clientes que han
            // adquirido un choche modelo 'GTI' de color 'Blanco'.
            // Replacing 'IN' with 'Contains'.
            var codcoche36em =
                LoadData.GetCoches()
                .Where(r => r.modelo == "GTI")
                .Select(r => new { r.codcoche });

            var dni36em =
                LoadData.GetVentas()
                .Where(r => r.color == "Blanco")
                .Where(r => codcoche36em.Contains(new { r.codcoche}))
                .Select(r => new { r.dni });

            var ex36em =
                LoadData.GetClientes()
                .Where(r => dni36em.Contains(new { r.dni }));

            Console.WriteLine("36. ----------------------------------------------");
            Utilities.FormatedPrint(ex36em);


            // 37. Obtener el nombre y el apellido de los clientes que han adquirido
            // un automóvil a un concesionario que posea actualmente coches
            // en stock del modelo 'GTI'.
            // Replacing 'IN' with 'Contains'.
            var codcoche37em =
                LoadData.GetCoches()
                .Where(r => r.modelo == "GTI")
                .Select(r => new { r.codcoche });

            var cifc37em =
                LoadData.GetDistribucion()
                .Where(r => codcoche37em.Contains(new { r.codcoche}))
                .Select(r => new { r.cifc });

            var dni37em =
                LoadData.GetVentas()
                .Where(r => cifc37em.Contains(new { r.cifc}))
                .Select(r => new { r.dni });

            var ex37em =
                LoadData.GetClientes()
                .Where(r => dni37em.Contains(new { r.dni }));

            Console.WriteLine("37. ----------------------------------------------");
            Utilities.FormatedPrint(ex37em);


            // 38. Obtener el nombre y el apellido de los clientes que han adquirido
            // un automóvil a un concesionario de 'Madrid' que posea
            // actualmente coches en stock del modelo 'GTI'.
            // Replacing 'IN' with 'Contains'.
            var codcoche38em =
                LoadData.GetCoches()
                .Where(r => r.modelo == "GTI")
                .Select(r => new { r.codcoche });

            var cifc38em =
                LoadData.GetDistribucion()
                .Where(r => codcoche38em.Contains(new { r.codcoche}))
                .Select(r => new { r.cifc });

            var cifcMadrid38em =
                LoadData.GetConcesionarios()
                .Where(r => r.ciudad == "Madrid")
                .Where(r => cifc38em.Contains(new { r.cifc }))
                .Select(r => new { r.cifc });

            var dni38em =
                LoadData.GetVentas()
                .Where(r => cifcMadrid38em.Contains(new { r.cifc}))
                .Select(r => new { r.dni });

            var clientes38em =
                LoadData.GetClientes()
                .Where(r => dni38em.Contains(new { r.dni }));

            Console.WriteLine("38. ----------------------------------------------");
            Utilities.FormatedPrint(clientes38em);


            // 39. Obtener el nombre y el apellido de los clientes cuyo dni es
            // menor que el del cliente 'Juan Martín'.
            var dniJuanMartin39em =
                LoadData.GetClientes()
                .Where(r => r.nombre == "Juan" && r.apellidos == "Martín")
                .Select(r => new { r.dni });

            var clientes39em =
                LoadData.GetClientes()
                .Where(r => r.dni < dniJuanMartin39em.FirstOrDefault()?.dni);

            Console.WriteLine("39. ----------------------------------------------");
            Utilities.FormatedPrint(clientes39em);


            // 40. Obtener el nombre y el apellido de los clientes cuyo dni es
            // menor que el de los clientes que son de 'Barcelona'.
            var dniBarcelona40em =
                LoadData.GetClientes()
                .Where(r => r.ciudad == "Barcelona")
                .Select(r => new { r.dni });

            var clientes40em =
                LoadData.GetClientes()
                .Where
                (
                    r =>
                    dniBarcelona40em
                    .ToList()
                    .All(s => r.dni < s.dni)
                );

            Console.WriteLine("40. ----------------------------------------------");
            Utilities.FormatedPrint(clientes40em);


            // 41. Obtener el nombre y el apellido de los clientes cuyo nombre
            // empieza por 'A' y cuyo dni es mayor que el de los clientes que
            // son de 'Madrid'.
            var dniMadrid41em =
                LoadData.GetClientes()
                .Where(r => r.ciudad == "Madrid")
                .Select(r => new { r.dni });

            var clientes41em =
                LoadData.GetClientes()
                .Where(r => Regex.Match(r.nombre, @"^A").Success)
                .Where
                (
                    r =>
                    dniMadrid41em
                    .ToList()
                    .All(s => r.dni > s.dni)
                );

            Console.WriteLine("41. ----------------------------------------------");
            Utilities.FormatedPrint(clientes41em);


            // 42. Obtener el nombre y el apellido de los clientes cuyo nombre
            // empieza por 'A' y cuyo dni es mayor que el de ¡ALGUNO! de
            // los clientes que son de 'Madrid'.
            var dniMadrid42em =
                LoadData.GetClientes()
                .Where(r => r.ciudad == "Madrid")
                .Select(r => new { r.dni });

            var clientes42em =
                LoadData.GetClientes()
                .Where(r => Regex.Match(r.nombre, @"^A").Success)
                .Where
                (
                    r =>
                    dniMadrid42em
                    .ToList()
                    .Any(s => r.dni > s.dni)
                );

            Console.WriteLine("42. ----------------------------------------------");
            Utilities.FormatedPrint(clientes42em);


            // 43. Obtener el nombre y el apellido de los clientes cuyo nombre
            // empieza por 'A' y cuyo dni es mayor que el de ¡ALGUNO! de
            // los clientes que son de 'Madrid' o menor que el de todos ls de
            // 'Valencia'.
            var dniMadrid43em =
                LoadData.GetClientes()
                .Where(r => r.ciudad == "Madrid")
                .Select(r => new { r.dni });

            var dniValencia43em =
                LoadData.GetClientes()
                .Where(r => r.ciudad == "Valencia")
                .Select(r => new { r.dni });

            var clientes43em =
                LoadData.GetClientes()
                .Where(r => Regex.Match(r.nombre, @"^A").Success)
                .Where
                (
                    r =>
                    dniMadrid43em
                    .ToList()
                    .Any(s => r.dni > s.dni)
                    ||
                    dniValencia43em
                    .ToList()
                    .All(s => r.dni < s.dni)
                );

            Console.WriteLine("43. ----------------------------------------------");
            Utilities.FormatedPrint(clientes43em);


            // 44. Obtener el nombre y el apellido de los clientes que han
            // comprado como mínimo un coche 'Blanco' y un coche
            // 'Rojo'.
            // Replacing 'IN' with 'Contains'.
            var dniBlanco44em =
                LoadData.GetVentas()
                .Where(r => r.color == "Blanco")
                .Select(r => new { r.dni });

            var dniRojo44em =
                LoadData.GetVentas()
                .Where(r => r.color == "Rojo")
                .Select(r => new { r.dni });

            var clientes44em =
                LoadData.GetClientes()
                .Where
                (
                    r =>
                    dniBlanco44em.Contains(new { r.dni })
                    &&
                    dniRojo44em.Contains(new { r.dni })
                );

            Console.WriteLine("44. ----------------------------------------------");
            Utilities.FormatedPrint(clientes44em);


            // 45. Obtener el dni de los clientes cuya ciudad sea la última de la lista
            // alfabética de las ciudades donde hay concesionarios.
            var lastCiudadesConcesionario45em =
                LoadData.GetConcesionarios()
                .Select(r => r.ciudad)
                .Max();

            var clientes45em =
                LoadData.GetClientes()
                .Where(r => r.ciudad == lastCiudadesConcesionario45em);

            Console.WriteLine("45. ----------------------------------------------");
            Utilities.FormatedPrint(clientes45em);


            // 46. Obtener la media de los automóviles que cada concesionario
            // tiene actualmente en stock
            var media46em =
                LoadData.GetDistribucion()
                .GroupBy(r => r.cifc)
                .Select
                (
                    g => new
                    {
                        cifc = g.Key,
                        Count = g.Average(group => group.cantidad)
                    }
                );

            Console.WriteLine("46. ----------------------------------------------");
            Utilities.FormatedPrint(media46em);


            // 47. Obtener el cifc del concesionario que no sea de 'Madrid' cuya
            // media de vehículos en stock sea la mas alta de todas las medias.
            // Replacing 'IN' with 'Contains'.
            var cifcNoMadrid47em =
                LoadData.GetConcesionarios()
                .Where(r => r.ciudad != "Madrid")
                .Select(r => r.cifc);

            var maxMedia47em =
                LoadData.GetDistribucion()
                .Where(r => cifcNoMadrid47em.Contains(r.cifc))
                .GroupBy(r => r.cifc)
                .Select
                (
                    g => new
                    {
                        cifc = g.Key,
                        Count = g.Average(group => group.cantidad)
                    }
                )
                .OrderByDescending(r => r.Count)
                .FirstOrDefault();

            Console.WriteLine("47. ----------------------------------------------");
            Console.WriteLine($"cifc = {maxMedia47em.cifc}");
            Console.WriteLine();


            // 48. Repetir el ejercicio 33 per utilizando EXISTS en la solución.
            // Using 'Any' in place of EXISTS.
            // 33. Obtener el codc de los coches vendidos por algún concesionario
            // de 'Madrid'.
            var cifc48em =
                LoadData.GetConcesionarios()
                .Where(r => r.ciudad == "Madrid")
                .Select(r => new { r.cifc });

            var ex48em =
                LoadData.GetVentas()
                .Where(r => cifc48em.Any(s => s.cifc == r.cifc))
                .Select(r => new { r.codcoche });

            Console.WriteLine("48. ----------------------------------------------");
            Utilities.FormatedPrint(ex48em);


            // 49. Utilizando EXISTS obtener el dni de los clientes que hayan
            // adquirido por lo menos alguno de los coches que ha sido vendido
            // por el concesionario cuyo cifc es 1.
            // Using 'Any' in place of EXISTS.
            var ex49em =
                LoadData.GetVentas()
                .Where
                (
                    r =>
                    LoadData.GetVentas()
                    .Where(s => s.codcoche == r.codcoche)
                    .Any(t => t.cifc == 1)
                )
                .Select(r => new { r.dni });

            Console.WriteLine("49. ----------------------------------------------");
            Utilities.FormatedPrint(ex49em);


            // 50. Obtener los dni de los clientes que sólo han comprado coches al
            // concesionario 1.
            // Using 'All' in place of EXISTS.
            var ex50em =
                LoadData.GetVentas()
                .Where
                (
                    r =>
                    LoadData.GetVentas()
                    .Where(s => s.dni == r.dni)
                    .All(s => s.cifc == 1)
                )
                .Select(r => new { r.dni });

            Console.WriteLine("50. ----------------------------------------------");
            Utilities.FormatedPrint(ex50em);


            // 51. Obtener los dni de los clientes que no han comprado
            // ningún coche 'Rojo' a ningún concesionario de 'Madrid'.
            // Using 'All' in place of NOT EXISTS.
            var cifc51em =
                LoadData.GetConcesionarios()
                .Where(r => r.ciudad == "Madrid")
                .Select(r => r.cifc);

            var ex51em =
                LoadData.GetVentas()
                .Where
                (
                    r =>
                    LoadData.GetVentas()
                    .Where(s => s.dni == r.dni)
                    .All(r => r.color != "Rojo" && !cifc51em.Contains(r.cifc))
                )
                .Select(r => new { r.dni });

            Console.WriteLine("51. ----------------------------------------------");
            Utilities.FormatedPrint(ex51em);


            // 52. Obtener el nombre de los clientes que sólo han comprado en el
            // concesionario de cifc 1.
            // Using 'All' in place of NOT EXISTS.
            var dni52em =
                LoadData.GetVentas()
                .Where
                (
                    r =>
                    LoadData.GetVentas()
                    .Where(s => s.dni == r.dni)
                    .All(r => r.cifc == 1)
                )
                .Select(r => new { r.dni })
                .ToList();

            var ex52em =
                LoadData.GetClientes()
                .Where(r => dni52em.Contains(new { r.dni }));

            Console.WriteLine("52. ----------------------------------------------");
            Utilities.FormatedPrint(ex52em);


            // 53. Obtener el codcoche de aquellos automóviles que han sido
            // comprados por todos los clientes de 'Madrid'.
            // Using 'All' in place of NOT EXISTS.
            // The problem doesn't make sense.
            var dniMadrid53em =
                LoadData.GetClientes()
                .Where(r => r.ciudad == "Madrid")
                .Select(r => r.dni)
                .ToList();

            var ex53em =
                LoadData.GetVentas()
                .Where
                (
                    r =>
                    LoadData.GetVentas()
                    .Where(s => s.codcoche == r.codcoche)
                    .All(r => dniMadrid53em.All(s => s == r.dni))
                );

            Console.WriteLine("53. ----------------------------------------------");
            Utilities.FormatedPrint(ex53em);


            // 54. Obtener el codcoche de aquellos automóviles de color "Rojo" y
            // de modelo "GTI" que han sido comprados por todos los clientes
            // cuyo apellido comienza por "G".
            // Using 'Any' in place of NOT EXISTS.
            // The problem doesn't make sense.
            var name54em =
                LoadData.GetClientes()
                .Where(r => Regex.Match(r.apellidos, @"^G").Success)
                .Select(r => r.dni)
                .ToList();

            var GTI54em =
                LoadData.GetCoches()
                .Where(r => r.modelo == "GTI")
                .Select(r => r.codcoche)
                .ToList();

            var ex54em =
                LoadData.GetVentas()
                .Where
                (
                    r =>
                    LoadData.GetVentas()
                    .Where(s => s.codcoche == r.codcoche)
                    .Where(r => r.color == "Rojo" && GTI54em.Contains(r.codcoche))
                    .Any(r => name54em.Contains(r.dni))
                );

            Console.WriteLine("54. ----------------------------------------------");
            Utilities.FormatedPrint(ex54em);


            // 55. Obtener el dni de los clientes que han adquirido por lo menos los
            // mismos automóviles quel el cliente "Luis García".
            // Using 'Any' in place of NOT EXISTS.
            // The problem doesn't make sense.
            var luisGarcia55em =
                LoadData.GetClientes()
                .Where(r => r.nombre == "Luis" && r.apellidos == "García")
                .Select(r => r.dni)
                .ToList();

            var ex55em =
                LoadData.GetVentas()
                .Where
                (
                    r =>
                    LoadData.GetVentas()
                    .Where(s => s.codcoche == r.codcoche)
                    .Any(r => luisGarcia55em.Contains(r.dni))
                );

            Console.WriteLine("55. ----------------------------------------------");
            Utilities.FormatedPrint(ex55em);


            // 56. Doesn't make sense.
            // 57. Convertir la siguiente proposición de SQL a su equivalente en
            // Castellano (the query is already given).
        }
    }
}
