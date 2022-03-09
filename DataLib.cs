using Models;

namespace DataLib
{
    class LoadData
    {
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

        public static IList<CLIENTES> GetClientes()
        {
            IList<CLIENTES> clientes = new List<CLIENTES>
            {
                new CLIENTES { dni = 1, nombre = "Luis", apellidos = "Garcia", ciudad = "Madrid" },
                new CLIENTES { dni = 2, nombre = "Antonio", apellidos = "Lopez", ciudad = "Valencia" },
                new CLIENTES { dni = 3, nombre = "Juan", apellidos = "Martin", ciudad = "Madrid" },
                new CLIENTES { dni = 4, nombre = "Maria", apellidos = "Garcia", ciudad = "Madrid" },
                new CLIENTES { dni = 5, nombre = "Javier", apellidos = "Gonzalez", ciudad = "Barcelona" },
                new CLIENTES { dni = 5, nombre = "Ana", apellidos = "Lopez", ciudad = "Barcelona" }
            };

            return clientes;
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

    }
}