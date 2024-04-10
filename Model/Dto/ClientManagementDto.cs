using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaEdenred.Model.Dto
{
    /// <summary>
    /// Objeto que define la estructura de Cliente para tareas de Gestión de sus Datos
    /// </summary>
    public class ClientManagementDto
    {
        /// <summary>
        /// Nombre del Cliente
        /// </summary>
        [Required(ErrorMessage = "El nombre es un dato Obligatorio y debe contener entre 2 y 50 caracteres")]
        [MaxLength(50, ErrorMessage = "El nombre debe contener como Máximo 50 caracteres")]
        [MinLength(2, ErrorMessage = "El nombre debe tener 2 caracteres, como mínimo")]
        public string Nombre { get; set; }

        /// <summary>
        /// Apellido del Cliente
        /// </summary>
        [Required(ErrorMessage = "El apellido es un dato Obligatorio y debe contener entre 2 y 50 caracteres")]
        [MaxLength(50, ErrorMessage = "El apellido debe contener como Máximo 50 caracteres")]
        [MinLength(2, ErrorMessage = "El apellido debe tener 2 caracteres, como mínimo")]
        public string Apellido { get; set; }

        /// <summary>
        /// Email asociado
        /// </summary>
        [Required(ErrorMessage = "El email es un dato Obligatorio")]
        [MaxLength(100, ErrorMessage = "El email ingresado, no puede contener más de 100 caracteres")]
        [MinLength(7, ErrorMessage = "El email debe contener 7 caracteres, como mínimo")]
        [EmailAddress(ErrorMessage = "El texto ingresado debe contener formato de Email: user@example.com")]
        public string Email { get; set; }

        /// <summary>
        /// Password de inicio de sesión.
        /// </summary>
        [Required(ErrorMessage = "El Password es un dato Obligatorio")]
        [MaxLength(255, ErrorMessage = "El Password ingresado, no puede contener más de 255 caracteres")]
        [MinLength(7, ErrorMessage = "El Password debe contener 7 caracteres, como mínimo")]
        public string Password { get; set; }

    }
}
