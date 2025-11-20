using System.ComponentModel.DataAnnotations;

namespace GestionReservas_LaboratoriosDeComputo.Models
{
    public class Reserva
    {
        [Required(ErrorMessage = "El código de reserva es obligatorio.")]
        [RegularExpression(@"^RES-\d{3}$", ErrorMessage = "El código debe tener el formato RES-### (ej. RES-001).")]
        [Display(Name = "Código de Reserva")]
        public string Codigo { get; set; } = string.Empty;

        [Required(ErrorMessage = "El nombre del profesor es obligatorio.")]
        [MinLength(3, ErrorMessage = "El nombre debe tener al menos 3 caracteres.")]
        [Display(Name = "Nombre del Profesor")]
        public string NombreProfesor { get; set; } = string.Empty;

        [Required(ErrorMessage = "El correo institucional es obligatorio.")]
        [EmailAddress(ErrorMessage = "Ingrese un correo válido.")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@uca\.cr$", ErrorMessage = "El correo debe pertenecer al dominio @uca.cr.")]
        [Display(Name = "Correo Institucional")]
        public string CorreoInstitucional { get; set; } = string.Empty;

        [Required(ErrorMessage = "Debe seleccionar un laboratorio.")]
        public string Laboratorio { get; set; } = string.Empty;

        [Required(ErrorMessage = "La fecha de reserva es obligatoria.")]
        [Display(Name = "Fecha de la Reserva")]
        public DateTime FechaReserva { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "La hora de inicio es obligatoria.")]
        [Display(Name = "Hora de Inicio")]
        public TimeSpan HoraInicio { get; set; }

        [Required(ErrorMessage = "La hora de fin es obligatoria.")]
        [Display(Name = "Hora de Fin")]
        public TimeSpan HoraFin { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria.")]
        [StringLength(200, MinimumLength = 5, ErrorMessage = "La descripción debe tener entre 5 y 200 caracteres.")]
        [Display(Name = "Motivo / Descripción")]
        public string Descripcion { get; set; } = string.Empty;


    } //class
} //end
