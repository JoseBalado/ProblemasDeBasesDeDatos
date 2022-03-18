using Models;

namespace DataLib
{
    class LoadData
    {
        public static IList<CLIENTES> GetClientes()
        {
            IList<CLIENTES> clientes = new List<CLIENTES>
            {
                new CLIENTES { dni = 1, nombre = "Luis", apellidos = "García", ciudad = "Madrid" },
                new CLIENTES { dni = 2, nombre = "Antonio", apellidos = "López", ciudad = "Valencia" },
                new CLIENTES { dni = 3, nombre = "Juan", apellidos = "Martín", ciudad = "Madrid" },
                new CLIENTES { dni = 4, nombre = "Maria", apellidos = "García", ciudad = "Madrid" },
                new CLIENTES { dni = 5, nombre = "Javier", apellidos = "González", ciudad = "Barcelona" },
                new CLIENTES { dni = 6, nombre = "Ana", apellidos = "López", ciudad = "Barcelona" }
            };

            return clientes;
        }
        public static IList<COCHES> GetCoches()
        {
            IList<COCHES> coches = new List<COCHES>
            {
                new COCHES { codcoche = 1, nombre = "Ibiza", modelo = "GLX" },
                new COCHES { codcoche = 2, nombre = "Ibiza", modelo = "GTI" },
                new COCHES { codcoche = 3, nombre = "Ibiza", modelo = "GTD" },
                new COCHES { codcoche = 4, nombre = "Toledo", modelo = "GTD" },
                new COCHES { codcoche = 5, nombre = "Cordoba", modelo = "GTI" },
                new COCHES { codcoche = 6, nombre = "Megane", modelo = "1.6" },
                new COCHES { codcoche = 7, nombre = "Megane", modelo = "GTI" },
                new COCHES { codcoche = 8, nombre = "Laguna", modelo = "GTD" },
                new COCHES { codcoche = 9, nombre = "Laguna", modelo = "TD" },
                new COCHES { codcoche = 10, nombre = "ZX", modelo = "16v" },
                new COCHES { codcoche = 11, nombre = "ZX", modelo = "TD" },
                new COCHES { codcoche = 12, nombre = "Xantia", modelo = "GTD" },
                new COCHES { codcoche = 13, nombre = "A4", modelo = "1.8" },
                new COCHES { codcoche = 14, nombre = "A4", modelo = "2.8" },
                new COCHES { codcoche = 15, nombre = "Astra", modelo = "Caravan" },
                new COCHES { codcoche = 16, nombre = "Astra", modelo = "GTI" },
                new COCHES { codcoche = 17, nombre = "Corsa", modelo = "1.4" },
                new COCHES { codcoche = 18, nombre = "300", modelo = "316.i" },
                new COCHES { codcoche = 19, nombre = "500", modelo = "525i" },
                new COCHES { codcoche = 20, nombre = "700", modelo = "750i" }
            };

            return coches;
        }
        public static IList<CONCESIONARIO> GetConcesionarios()
        {
            IList<CONCESIONARIO> concesionarios = new List<CONCESIONARIO>
            {
                new CONCESIONARIO { cifc = 1, nombre = "ACAR", ciudad = "Madrid" },
                new CONCESIONARIO { cifc = 2, nombre = "BCAR", ciudad = "Madrid" },
                new CONCESIONARIO { cifc = 3, nombre = "CCAR", ciudad = "Barcelona" },
                new CONCESIONARIO { cifc = 4, nombre = "DCAR", ciudad = "Valencia" },
                new CONCESIONARIO { cifc = 5, nombre = "ECAR", ciudad = "Bilbao" }
            };

            return concesionarios;
        }
        public static IList<DISTRIBUCION> GetDistribucion()
        {
            IList<DISTRIBUCION> distribucion = new List<DISTRIBUCION>
            {
                new DISTRIBUCION { cifc = 1, codcoche = 1, cantidad = 3 },
                new DISTRIBUCION { cifc = 1, codcoche = 5, cantidad = 7 },
                new DISTRIBUCION { cifc = 1, codcoche = 6, cantidad = 7 },
                new DISTRIBUCION { cifc = 2, codcoche = 6, cantidad = 5 },
                new DISTRIBUCION { cifc = 2, codcoche = 8, cantidad = 10 },
                new DISTRIBUCION { cifc = 2, codcoche = 9, cantidad = 10 },
                new DISTRIBUCION { cifc = 3, codcoche = 10, cantidad = 5 },
                new DISTRIBUCION { cifc = 3, codcoche = 11, cantidad = 3 },
                new DISTRIBUCION { cifc = 3, codcoche = 12, cantidad = 5 },
                new DISTRIBUCION { cifc = 4, codcoche = 13, cantidad = 10 },
                new DISTRIBUCION { cifc = 4, codcoche = 14, cantidad = 5 },
                new DISTRIBUCION { cifc = 5, codcoche = 15, cantidad = 10 },
                new DISTRIBUCION { cifc = 5, codcoche = 16, cantidad = 20 },
                new DISTRIBUCION { cifc = 5, codcoche = 17, cantidad = 8 },
                new DISTRIBUCION { cifc = 6, codcoche = 19, cantidad = 3 },
            };

            return distribucion;
        }
        public static IList<MARCAS> GetMarcas()
        {
            IList<MARCAS> marcas = new List<MARCAS>
            {
                new MARCAS { cifm = 1, nombre = "SEAT", ciudad = "Madrid" },
                new MARCAS { cifm = 2, nombre = "Renault", ciudad = "Barcelona" },
                new MARCAS { cifm = 3, nombre = "Citroen", ciudad = "Valencia" },
                new MARCAS { cifm = 4, nombre = "Audi", ciudad = "Madrid" },
                new MARCAS { cifm = 5, nombre = "Opel", ciudad = "Bilbao" },
                new MARCAS { cifm = 6, nombre = "BMW", ciudad = "Barcelona" }
            };

            return marcas;
        }
        public static IList<MARCO> GetMarco()
        {
            IList<MARCO> marco = new List<MARCO>
            {
                new MARCO { cifm = 1, codcoche = 1 },
                new MARCO { cifm = 1, codcoche = 2 },
                new MARCO { cifm = 1, codcoche = 3 },
                new MARCO { cifm = 1, codcoche = 4 },
                new MARCO { cifm = 1, codcoche = 5 },
                new MARCO { cifm = 2, codcoche = 6 },
                new MARCO { cifm = 2, codcoche = 7 },
                new MARCO { cifm = 2, codcoche = 8 },
                new MARCO { cifm = 2, codcoche = 9 },
                new MARCO { cifm = 3, codcoche = 10 },
                new MARCO { cifm = 3, codcoche = 11 },
                new MARCO { cifm = 3, codcoche = 12 },
                new MARCO { cifm = 4, codcoche = 13 },
                new MARCO { cifm = 4, codcoche = 14 },
                new MARCO { cifm = 5, codcoche = 15 },
                new MARCO { cifm = 5, codcoche = 16 },
                new MARCO { cifm = 5, codcoche = 17 },
                new MARCO { cifm = 6, codcoche = 18 },
                new MARCO { cifm = 6, codcoche = 19 },
                new MARCO { cifm = 6, codcoche = 20 }
            };

            return marco;
        }
        public static IList<VENTAS> GetVentas()
        {
            IList<VENTAS> ventas = new List<VENTAS>
            {
                new VENTAS { cifc = 1, dni = 1, codcoche = 1, color = "Blanco" },
                new VENTAS { cifc = 1, dni = 2, codcoche = 5, color = "Rojo" },
                new VENTAS { cifc = 2, dni = 3, codcoche = 8, color = "Blanco" },
                new VENTAS { cifc = 2, dni = 1, codcoche = 6, color = "Rojo" },
                new VENTAS { cifc = 3, dni = 4, codcoche = 11, color = "Rojo" },
                new VENTAS { cifc = 4, dni = 5, codcoche = 14, color = "Verde" }
            };

            return ventas;
        }
    }
}