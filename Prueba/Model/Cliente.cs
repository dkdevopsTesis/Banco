using System.ComponentModel.DataAnnotations;

namespace Prueba.Model
{
    public class Cliente : Persona
    {

        public string Contraseña { get; set; }
        public bool Estado { get; set; }
    }
}
