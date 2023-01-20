//using AutoMapper;
//using E_Learn.Entity;
//using E_Learn.Entity.DTO;
//using E_Learn.Entity.Models;
//using E_Learn.Infrastructure.IRepo;
//using ELearning.Service.IService;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ELearning.Service.Service
//{
//    public class Basket1Service: IBasket1Service
//    {
       
//        private readonly IMapper _mapper;
//        private readonly IBasketRepo _basketRepo;

//        public Basket1Service( IMapper mapper, IBasketRepo basketRepo)
//        {
//            _mapper = mapper;   
//            _basketRepo = basketRepo; 
//        }
//        public async Task<IEnumerable<BasketDTO>> GetBasket()
//        {
//            //var result = await _basketRepo.GetBasket();  
//            var result1 = _mapper.Map<IEnumerable<Basket>, IEnumerable<BasketDTO>>(result);
//            try
//            {
//                if (result1 == null)
//                    return result1;
//                return result1;
//            }
//            catch (Exception ex)
//            { 
//                var message = ex.Message;    
//            }
//            return result1;

            

            
//        }
//    }
//}
