using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using domatel.DataLayer.Data;
using domatel.Interface.Interfaces.Repository;
using domatel.Models.Core;
using domatel.Models.Criteria.SimCart;
using domatel.Models.Pagination;
using domatel.Models.Products;
using domatel.Models.Products.Enums;
using domatel.Models.Users;
using domatel.Services.Utility;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Newtonsoft.Json;

namespace domatel.Services.Repository

{
  public  class SimcartRepository:ISimcartRepository
    {
        private readonly DomatelContext _domatelContext;

        public SimcartRepository(DomatelContext domatelContext)
        {
            _domatelContext = domatelContext;
        }


        public async Task<ServiceResult> AddSimcart(SimCartAdd model)
        {
            try
            {
                SimCart simCart = new SimCart()
                {

                    BasePrice = model.BasePrice,
                    FinalPrice = model.FinalPrice,
                    StartDate = model.StartDate,
                    EndDate = model.EndDate,
                    sAvailable = model.IsAvailable,
                    RemainTime = model.RemainTime,
                    UserId = model.UserId,
                    Number = model.Number,
                    KindOfUse = model.KindOfUse,
                    OperatorType = model.OperatorType,
                    SimcartType = model.SimcartType,
                    RoundType = model.RoundType

                };
                await _domatelContext.SimCarts.AddAsync(simCart);
              
                await _domatelContext.SaveChangesAsync();
                return new ServiceResult
                {

                    Message = string.Empty,
                    Status = (int)Configuration.ServiceResultStatus.Success
                };
            }
            catch (Exception e)
            {
                return new ServiceResult
                {
                    Message = e.Message,
                    Status = (int)Configuration.ServiceResultStatus.Error
                };
            }
        }

        public async Task<ServiceResult> EditSimcart(int id, SimCart model)
        {
            try
            {
               
                var simCartToUpdate = await _domatelContext.SimCarts.FirstOrDefaultAsync(s => s.Id == id);
                simCartToUpdate.Number = model.Number;
                simCartToUpdate.OperatorType = model.OperatorType;
                simCartToUpdate.KindOfUse = model.KindOfUse;
                simCartToUpdate.SimcartType = model.SimcartType;
                simCartToUpdate.BasePrice = model.BasePrice;
                simCartToUpdate.FinalPrice = model.FinalPrice;
                simCartToUpdate.RemainTime = model.RemainTime;

                _domatelContext.SimCarts.Update(simCartToUpdate);
                await _domatelContext.SaveChangesAsync();

                return new ServiceResult
                {
                    Message = string.Empty,
                    Status = (int)Configuration.ServiceResultStatus.Success
                };
            }
            catch (Exception e)
            {
                return new ServiceResult
                {
                    Message = e.Message,
                    Status = (int)Configuration.ServiceResultStatus.Error
                };
            }
        }

        public async Task<ServiceResult<SimCart>> GetSimcartById(int id)
        {
            try
            {
               
                var userToUpdate = await _domatelContext.SimCarts.FirstOrDefaultAsync(s => s.Id == id);
                return new ServiceResult<SimCart>
                {
                    Data = userToUpdate,
                    Message = String.Empty,
                    Status = (int)Configuration.ServiceResultStatus.Success
                };
            }
            catch (Exception e)
            {
                return new ServiceResult<SimCart>
                {
                    Data = null,
                    Message = e.Message,
                    Status = (int)Configuration.ServiceResultStatus.Error
                };
            }
        }

        public async Task<ServiceResult<string>> GetAllSimcart(PagingParameterModel pagingParameter)
        {
            try
            {
                var allsimcarts = await _domatelContext.SimCarts.OrderByDescending(s=>s.StartDate)
                        .Skip((pagingParameter.PageNumber - 1) * pagingParameter.PageSize)
                        .Take(pagingParameter.PageSize)
                        .ToListAsync();
                List<SimcartCriteria> simcartlist=new List<SimcartCriteria>();
              
                foreach (var simcart in allsimcarts)
                {
                    SimcartCriteria simcartcriteria = new SimcartCriteria();
                    simcartcriteria.Id = simcart.Id;
                    simcartcriteria.Number = simcart.Number;
                    simcartcriteria.SimcartOperatorType = (int)simcart.OperatorType;
                    simcartcriteria.KindOfUse = (int)simcart.KindOfUse;
                    simcartcriteria.Price= simcart.BasePrice;
                    simcartlist.Add(simcartcriteria);

                }
                return new ServiceResult<string>
                {
                    Data = JsonConvert.SerializeObject(simcartlist),
                    Message = string.Empty,
                    Status = (int)Configuration.ServiceResultStatus.Success
                };
            }
            catch (Exception e)
            {
                return new ServiceResult<string>
                {
                    Message = e.Message,
                    Status = (int)Configuration.ServiceResultStatus.Error
                };
            }
        }

        public async Task<ServiceResult<string>> GetSimCartInfoById(int id)

        {
            
           
            try
            {
                var simcart =  _domatelContext.SimCarts.FirstOrDefault(s => s.Id == id);
                var owner = _domatelContext.users.FirstOrDefault(s => s.Id == simcart.UserId);

                SimCartInfo simCartInfo = new SimCartInfo();

                if (simcart != null)
                {
                    simCartInfo.Id = simcart.Id;
                    simCartInfo.SimcartType = simcart.SimcartType;
                    simCartInfo.Number = simcart.Number;
                    simCartInfo.BasePrice = simcart.BasePrice;
                    simCartInfo.KindOfUse = simcart.KindOfUse;
                    simCartInfo.SimcartType = simcart.SimcartType;
                    simCartInfo.RoundType = simcart.RoundType;
                }

                if (owner != null) simCartInfo.Province = owner.Province;

                return new ServiceResult<string>
                {
                    Data = JsonConvert.SerializeObject(simCartInfo),
                    Message = string.Empty,
                    Status = (int)Configuration.ServiceResultStatus.Success
                };
            }
            catch (Exception e)
            {
                return new ServiceResult<string>
                { Data = null,
                    Message = e.Message,
                    Status = (int)Configuration.ServiceResultStatus.Error
                };
            }

        }

        public async Task<ServiceResult<string>> GetOwnerInfoById(int id)

        {
            try
            {
                var simCart = _domatelContext.SimCarts.FirstOrDefault(s => s.Id == id);
                var owner = _domatelContext.users.FirstOrDefault(s => s.Id == simCart.UserId);

                SimcartOwnerInfo simCartInfo = new SimcartOwnerInfo();

                if (owner != null && simCart != null)
                {
                    simCartInfo.FullName = owner.FullName;
                    simCartInfo.Number = simCart.Number;
                    simCartInfo.Id = simCart.Id;
                    simCartInfo.Province = owner.Province;
                }

                return new ServiceResult<string>
                {
                    Data = JsonConvert.SerializeObject(simCartInfo),
                    Message = string.Empty,
                    Status = (int)Configuration.ServiceResultStatus.Success
                };
            }
            catch (Exception e)
            {
                return new ServiceResult<string>
                {
                    Message = e.Message,
                    Status = (int)Configuration.ServiceResultStatus.Error
                };
            }
        }

        public async Task<ServiceResult<string>> 	GetAllSimInfoById(int id)
        {
            try
            {
                var simcart = _domatelContext.SimCarts.FirstOrDefault(s => s.Id == id);
                var owner = _domatelContext.users.FirstOrDefault(s => s.Id == simcart.UserId);
                var bid=_domatelContext.Bids.FirstOrDefault(s => s.UserId == simcart.UserId);

                SimcartAllInfo simCartInfo = new SimcartAllInfo();

                if (owner != null && simcart!=null && bid!=null)
                {
                    simCartInfo.Id = simcart.Id;
                    simCartInfo.FullName = owner.FullName;
                    simCartInfo.Number = simcart.Number;
                    simCartInfo.BasePrice = simcart.BasePrice;
                    simCartInfo.StartDate = simcart.StartDate;
                    simCartInfo.KindOfUse = (int)simcart.KindOfUse;
                    simCartInfo.OperatorType = (int)simcart.OperatorType;
                    simCartInfo.SimcartType = (int)simcart.SimcartType;
                    simCartInfo.RoundType = (int)simcart.RoundType;
                    simCartInfo.NumberOfParticipant = bid.NumberOfParticipant;
                    simCartInfo.Province = owner.Province;
                }

                return new ServiceResult<string>
                {
                    Data = JsonConvert.SerializeObject(simCartInfo),
                    Message = string.Empty,
                    Status = (int)Configuration.ServiceResultStatus.Success
                };
            }
            catch (Exception e)
            {
                return new ServiceResult<string>
                {
                    Message = e.Message,
                    Status = (int)Configuration.ServiceResultStatus.Error
                };
            }
        }
    }
}
