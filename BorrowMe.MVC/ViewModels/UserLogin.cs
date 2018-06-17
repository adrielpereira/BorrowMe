using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BorrowMe.MVC.ViewModels
{
    public class UserLogin
    {
        [Required(ErrorMessage = "Preencha o campo Usuário.")]
        [MaxLength(50, ErrorMessage = "Tamanho máximo {0} caracteres.")]
        [MinLength(5, ErrorMessage = "Tamanho mínimo {0} caracteres.")]
        [Display(Name = "Usuário")]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Preencha o campo Senha")]
        [MinLength(6, ErrorMessage = "Tamanho mínimo {0} caracteres.")]
        [Display(Name = "Senha")]
        public string Password { get; set; }
    }
}