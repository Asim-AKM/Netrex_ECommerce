using Application_Service.Common.Mappers.CartMappers;
using Application_Service.DTO_s.CartDtos;
using Application_Service.Services.Cartservices.Interface;
using Domain_Service.Entities.CartAndOrderModule;
using Domain_Service.RepoInterfaces.GenericRepo;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Service.Services.Cartservices.Implemmentation
{
    public class CartManager : ICartManager
    {
        private readonly IRepository<Cart> _repository;
        public CartManager( IRepository<Cart> repository)
        {
            _repository = repository;
        }


        public async Task<AddCartDto> AddCart(AddCartDto addCartDto)
        {
            if(addCartDto == null) 
                throw new ArgumentNullException(nameof(addCartDto));
          var Data= await _repository.Create(addCartDto.Map());
            return Data.MapToDto();
        }

        public async Task<GetCartDto> GetCartById(Guid CartId)
        {
            if(CartId==Guid.Empty)
            {
                throw new ArgumentNullException(nameof(CartId));
            }
          var Data=  await  _repository.GetById(CartId);
          return Data.Map();


        }

        public async Task<bool> RemoveCart(Guid CartId)
        {
            var Domain = await _repository.GetById(CartId);
            if(Domain != null)
            {
                await _repository.Delete(Domain);
                return true;
            }
            return false;
        }

        public async Task<UpdateCartDto> UpdateCart(UpdateCartDto Dto)
        {
             if(Dto == null)
               throw new ArgumentNullException(nameof(Dto));

            var domain = await _repository.Update(Dto.Map());
            return domain.MapToUpdateCartDto();
        }
    }
}
