using ConnOutlineMessenger.Entities;
using ConnOutlineMessenger.Validation;
using System.ComponentModel.DataAnnotations;

namespace ConnOutlineMessenger.Models
{
    public class RegistrationModel
    {
        [Required(ErrorMessage = "Укажите имя")]
        [MaxLength(20, ErrorMessage = "Количество символов имени пользователя не должно быть больше 20")]
        [MinLength(4, ErrorMessage = "Количество символов имени пользователя не должно быть меньше 4")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Укажите почту")]
        [EmailAddress]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Укажите пароль")]
        [MinLength(4, ErrorMessage = "Количество символов пароля пользователя не должно быть меньше 4")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Подтвердите пароль")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }

        [Checked(ErrorMessage = "Перед созданием аккаунта вы должны согласиться с политикой коефиденциальности")]
        public bool Agreement { get; set; }
    }
}
