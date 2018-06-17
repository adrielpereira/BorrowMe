using AutoMapper;
using BorrowMe.Domain.Entities;
using BorrowMe.MVC.ViewModels;
using System.Collections.Generic;

namespace BorrowMe.MVC.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public void NewMapperProfile()
        {
            Mapper.Initialize(x => {
                x.CreateMap<User, UserViewModel>();
                x.CreateMap<Game, GameViewModel>();
                x.CreateMap<Borrow, BorrowViewModel>();

                //x.CreateMap<IEnumerable<User>, IEnumerable<UserViewModel>>();
                //x.CreateMap<IEnumerable<Game>, IEnumerable<GameViewModel>>();
                //x.CreateMap<IEnumerable<Borrow>, IEnumerable<BorrowViewModel>>();

            });
        }
    }
}