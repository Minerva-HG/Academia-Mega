using System.ComponentModel.DataAnnotations;

namespace TiendaMVC.Models
{

    ///<summary>
    /// Modelo de usar para los datos de autenticación
    /// </summary>

    public class User
    {
        [Required(ErrorMessage = "El nombre de usuario es obligatorio")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El nombre de usuario debe de tener entre 3 y 50 caracteres")]
        [Display(Name = "Usuario")]
        public string UserName { get; set; } = string.Empty;


        [Required(ErrorMessage = "El password es obligatorio")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "La contraseña debe de tener entre 6 y 50 caracteres")]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; } = string.Empty;


    }

}