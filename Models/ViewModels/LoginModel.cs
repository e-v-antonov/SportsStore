using System.ComponentModel.DataAnnotations;

namespace SportsStore.Models.ViewModels
{
    /// <summary>
    /// Класс модели представления для учетных данных пользователя
    /// </summary>
    public class LoginModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [UIHint("password")]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }
    }
}
