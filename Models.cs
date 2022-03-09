namespace Models
{
    class MARCAS
    {
        public int cifm { get; set; }
        public string nombre { get; set; }
        public string ciudad { get; set; }
    }

    class COCHES
    {
        public int cifm { get; set; }
        public string nombre { get; set; }
        public string ciudad { get; set; }
    }
    class CONCESIONARIO
    {
        public int cifc { get; set; }
        public string nombre { get; set; }
        public string ciudad { get; set; }
    }
    class CLIENTES
    {
        public int dni { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public string ciudad { get; set; }
    }
    class DISTRIBUCION
    {
        public int cifc { get; set; }
        public int codcoche { get; set; }
        public int cantidad { get; set; }
    }
    class VENTAS
    {
        public int cifc { get; set; }
        public int dni { get; set; }
        public int codcoche { get; set; }
        public string color { get; set; }
    }
    class MARCO
    {
        public int cifm { get; set; }
        public int codcoche { get; set; }
    }
}