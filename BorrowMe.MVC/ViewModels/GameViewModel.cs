using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BorrowMe.MVC.ViewModels
{
    public class GameViewModel
    {
        [Key]
        public long Id { get; set; }

        [Required(ErrorMessage = "Preencha o campo Titulo.")]
        [MaxLength(100, ErrorMessage = "Tamanho máximo {0} caracteres.")]
        [MinLength(2, ErrorMessage = "Tamanho mínimo {0} caracteres.")]
        [Display(Name = "Titulo")]
        public string Title { get; set; }

        [Display(Name = "Ativo")]
        public bool IsActive { get; set; }

        [Display(Name = "Emprestado?")]
        public bool IsBorrowed { get; set; }

        [Required(ErrorMessage = "Selecione o proprietário do jogo.")]
        [Display(Name = "Proprietário")]
        public long UserId { get; set; }

        public virtual UserViewModel User { get; set; }
    }
}