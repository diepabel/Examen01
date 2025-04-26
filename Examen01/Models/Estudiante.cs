using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Examen01.Models
{
    public class Estudiante
    {
        [Key]
        public int EstudianteId { get; set; }

        [Required]
        [MaxLength(40)]
        [DisplayName("Nombre")]
        public string Nombre { get; set; }

        [Required]
        [MaxLength(40)]
        [DisplayName("Apellido")]
        public string Apellido { get; set; }

        public int CarreraId { get; set; }

        [ForeignKey("CarreraId")]
        public Carrera Carrera { get; set; }

    }
}
