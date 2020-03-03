using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using domatel.DataLayer.Data;
using domatel.Interface.Interfaces.Repository;
using domatel.Models.Core;
using domatel.Models.Criteria.Phone;
using domatel.Models.Criteria.SimCart;
using domatel.Models.Pagination;
using domatel.Models.Products;
using domatel.Services.Utility;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace domatel.Services.Repository
{
  public  class PhoneRepository:IPhoneRepository

    {
        private DomatelContext _domatelContext;

        public PhoneRepository(DomatelContext domatelContext)
        {
            _domatelContext = domatelContext;
        }
        public async Task<ServiceResult> AddPhone(PhoneAdd model)
        {
            try
            {
                Phone phone = new Phone()
                {

                    BasePrice = model.BasePrice,
                    FinalPrice = model.FinalPrice,
                    StartDate = model.StartDate,
                    EndDate = model.EndDate,
                    sAvailable = model.IsAvailable,
                    KindOfUses = model.KindOfUse,
                    PermanentNumber = model.PermanentNumber,
                    RemainTime = model.RemainTime,
                    UserId = model.UserId

                };
                await _domatelContext.Phones.AddAsync(phone);
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

        public Task<ServiceResult> EditPhone(int id, Phone model)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult<Phone>> GetPhoneById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResult<string>> GetAllPhone(PagingParameterModel pagingParameter)
        {
            try
            {
                var allPhone = await _domatelContext.Phones.OrderByDescending(s=>s.StartDate)
                        .Skip((pagingParameter.PageNumber - 1) * pagingParameter.PageSize)
                        .Take(pagingParameter.PageSize)
                        .ToListAsync();
                List<PhoneCriteria> phoneList = new List<PhoneCriteria>();
               
                foreach (var phone in allPhone)
                {
                    PhoneCriteria phoneCriteria = new PhoneCriteria();
                    phoneCriteria.Number = phone.PermanentNumber;
                    phoneCriteria.Id = phone.Id;
                    phoneCriteria.KindOfUse = (int)phone.KindOfUses;
                    phoneCriteria.Price = phone.BasePrice;
                    phoneList.Add(phoneCriteria);

                }
                return new ServiceResult<string>
                {
                    Data = JsonConvert.SerializeObject(phoneList),
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

        public async Task<ServiceResult<string>> GetPhoneInfoById(int id)
        {
            try
            {
                var phones = _domatelContext.Phones.FirstOrDefault(s => s.Id == id);
                var owner = _domatelContext.users.FirstOrDefault(s => s.Id == phones.UserId);

                PhoneInfo phoneInfo = new PhoneInfo();

                if (phones != null && owner != null)
                {
                    phoneInfo.Id = phones.Id;
                    phoneInfo.PermanentNumber = phones.PermanentNumber;
                    phoneInfo.BasePrice = phones.BasePrice;
                    phoneInfo.Province = owner.Province;
                    phoneInfo.KindOfUse = phones.KindOfUses;

                }


                return new ServiceResult<string>
                {
                    Data = JsonConvert.SerializeObject(phoneInfo),
                    Message = string.Empty,
                    Status = (int)Configuration.ServiceResultStatus.Success
                };
            }
            catch (Exception e)
            {
                return new ServiceResult<string>
                {
                    Data = null,
                    Message = e.Message,
                    Status = (int)Configuration.ServiceResultStatus.Error
                };
            }
        }

        public async Task<ServiceResult<string>> GetOwnerPhoneById(int id)
        {
            try
            {
                var phone = _domatelContext.Phones.FirstOrDefault(s => s.Id == id);
                var owner = _domatelContext.users.FirstOrDefault(s => s.Id == phone.UserId);

               PhoneOwnerInfo phoneOwner = new PhoneOwnerInfo();


                if (owner != null && phone != null)
                {
                    phoneOwner.FullName = owner.FullName;
                    phoneOwner.PermanentNumber = phone.PermanentNumber;
                    phoneOwner.Id = phone.Id;
                    phoneOwner.Province = owner.Province;
                }
                return new ServiceResult<string>
                {
                    Data = JsonConvert.SerializeObject(phoneOwner),
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

        public async Task<ServiceResult<string>> GetAllPhoneById(int id)
        {
            try
            {
                var phone = _domatelContext.Phones.FirstOrDefault(s => s.Id == id);
                var owner = _domatelContext.users.FirstOrDefault(s => s.Id == phone.UserId);
                var bid = _domatelContext.Bids.FirstOrDefault(s => s.UserId == phone.UserId);

               PhoneAllInfo phoneAllInfo = new PhoneAllInfo();

                if (owner != null && phone != null && bid != null)
                {
                    phoneAllInfo.FullName = owner.FullName;
                    phoneAllInfo.Id = phone.Id;
                    phoneAllInfo.BasePrice = phone.BasePrice;
                    phoneAllInfo.StartDate = phone.StartDate;
                    phoneAllInfo.PermanentNumber = phone.PermanentNumber;
                    phoneAllInfo.NumberOfParticipant = bid.NumberOfParticipant;
                    phoneAllInfo.Province = owner.Province;
                }

                return new ServiceResult<string>
                {
                    Data = JsonConvert.SerializeObject(phoneAllInfo),
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
