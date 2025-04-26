using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Examen01.Models
{
    public class Carrera
    {
        [Key]
        public int CarreraId { get; set; }

        [Required]
        [MaxLength(40)]
        [DisplayName("Nombre de Carrera")]
        public string Nombre { get; set; }

        public List<Estudiante> Estudiante { get; set; }
    }
}
