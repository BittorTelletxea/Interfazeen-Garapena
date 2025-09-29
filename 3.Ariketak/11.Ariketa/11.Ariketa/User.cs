namespace _11.Ariketa
{
    public class User
    {
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Dni { get; set; }

        public User(string nombre, string apellido1, string apellido2, string dni)
        {
            Nombre = nombre;
            Apellido1 = apellido1;
            Apellido2 = apellido2;
            Dni = dni;
        }

        public string Mostrar()
        {
            return $"{Nombre} {Apellido1} {Apellido2}, DNI: {Dni}";
        }
    }
}
