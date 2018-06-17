using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BorrowMe.MVC.ViewModels
{
    public class UserEditViewModel
    {
        [Key]
        public long Id { get; set; }

        [Required(ErrorMessage = "Preencha o campo Nome.")]
        [MaxLength(100, ErrorMessage = "Tamanho máximo {0} caracteres.")]
        [MinLength(6, ErrorMessage = "Tamanho mínimo {0} caracteres.")]
        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Preencha o campo Usuário.")]
        [MaxLength(50, ErrorMessage = "Tamanho máximo {0} caracteres.")]
        [MinLength(5, ErrorMessage = "Tamanho mínimo {0} caracteres.")]
        [Display(Name = "Usuário")]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Tamanho mínimo {0} caracteres.")]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [Display(Name = "Ativo")]
        public bool IsActive { get; set; }
    }
}