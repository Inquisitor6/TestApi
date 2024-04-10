using System.ComponentModel.DataAnnotations;

namespace PruebaEdenred.Model.Dto
{
    /// <summary>
    /// Objeto que define la estructura de Cliente para tareas de Consulta de datos
    /// </summary>
    public class ClientRecordDto
    {
        /// <summary>
        /// Id de Cliente
        /// </summary>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Nombre del Cliente
        /// </summary>
        [Required]
        public string Nombre { get; set; }

        /// <summary>
        /// Apellido del Cliente
        /// </summary>
        [Required]
        public string Apellido { get; set; }

        /// <summary>
        /// Email asociado
        /// </summary>
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// Password de inicio de sesión.
        /// </summary>
        [Required]
        public string Password { get; set; }

        /// <summary>
        /// Fecha de creación del Cliente
        /// </summary>
        [Required]
        public DateTime FechaCreacion { get; set; }

        /// <summary>
        /// Fecha de la última Actualización.
        /// </summary>
        public DateTime ? FechaActualizacion { get; set; }

    }
}
