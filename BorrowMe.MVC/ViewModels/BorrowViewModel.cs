using BorrowMe.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace BorrowMe.MVC.ViewModels
{
    public class BorrowViewModel
    {
        [Key]
        public long Id { get; set; }

        [Display(Name = "Data do Empréstimo")]
        [ScaffoldColumn(false)]
        public DateTime BorrowedAt { get; set; }

        [Display(Name = "Data da Devolução")]
        [ScaffoldColumn(false)]
        public DateTime? ReturnDate { get; set; }

        [Display(Name = "Usuário")]
        public long UserId { get; set; }

        [Display(Name = "Jogo")]
        public long GameId { get; set; }

        [Display(Name = "Usuário")]
        public virtual User User { get; set; }

        [Display(Name = "Jogo")]
        public virtual Game Game { get; set; }
    }
}