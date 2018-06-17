using AutoMapper;
using BorrowMe.Domain.Entities;
using BorrowMe.MVC.ViewModels;
using System.Collections.Generic;

namespace BorrowMe.MVC.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public void NewMapperProfile()
        {
            Mapper.Initialize(x => {
                x.CreateMap<UserViewModel, User>();
                x.CreateMap<GameViewModel, Game>();
                x.CreateMap<BorrowViewModel, Borrow>();

                //x.CreateMap<IEnumerable<GameViewModel>, IEnumerable<Game>>();
                //x.CreateMap<IEnumerable<UserViewModel>, IEnumerable<User>>();
                //x.CreateMap<IEnumerable<BorrowViewModel>, IEnumerable<Borrow>>();
            });
        }
    }
}