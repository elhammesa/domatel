using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using domatel.DataLayer.Data;
using domatel.Interface.Interfaces.Repository;
using domatel.Models.Core;
using domatel.Models.Criteria.Domain;
using domatel.Models.Criteria.User;
using domatel.Models.Products;
using domatel.Models.Users;
using domatel.Services.Utility;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Newtonsoft.Json;


namespace domatel.Services.Repository
{
    public class UserRepository:IUserRepository
    {
        private DomatelContext _domatelContext;

        public UserRepository(DomatelContext domatelContext)
        {
            _domatelContext = domatelContext;
        }

        public async Task<ServiceResult> AddUser(User model)
        {
            try
            {

                await _domatelContext.users.AddAsync(model);
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

        public async Task<ServiceResult> EditUser(User model)
        {
            try
            {
                
                var userToUpdate = await _domatelContext.users.FirstOrDefaultAsync(s => s.Id == model.Id);
               userToUpdate.Address = model.Address;
               userToUpdate.BirthDayDate = model.BirthDayDate;
               userToUpdate.City = model.City;
               userToUpdate.FirstName = model.FirstName;
               userToUpdate.LastName = model.LastName;
             
               userToUpdate.Jender = model.Jender;
               userToUpdate.Mobile = model.Mobile;
               userToUpdate.Phone = model.Phone;
               userToUpdate.NationalCode = model.NationalCode;
               userToUpdate.Phone = model.Phone;
               userToUpdate.Province = model.Province;
                 _domatelContext.users.Update(userToUpdate);
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

        public async Task<ServiceResult<string>> GetUserById(string userId)
        {
            try
            {
              
                var userToUpdate = await _domatelContext.users.FirstOrDefaultAsync(s => s.Id == userId);
                return new ServiceResult<string>
                {
                    Data = JsonConvert.SerializeObject(userToUpdate),
                    Message = String.Empty,
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

        public async Task<ServiceResult<string>> GetAllUser()
        {
            try
            {
               var allUser=await  _domatelContext.users.ToListAsync();
                await _domatelContext.SaveChangesAsync();
                return new ServiceResult<string>
                {
                    Data= JsonConvert.SerializeObject(allUser),
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

        public async Task<ServiceResult<string>> Domain(string userId)
        {

            try
            {

                var products = _domatelContext.Products.OfType<Domain>().Where(s => s.UserId == userId).ToList();
                List<MyInfo> myInfolist = new List<MyInfo>();
                
                foreach (var product in products)
                {
                    MyInfo myInfo = new MyInfo();

                    myInfo.BasePrice = product.BasePrice;
                        myInfo.FinalPrice = product.FinalPrice;
                        myInfo.Available = product.sAvailable;
                        myInfo.RemainTime = product.RemainTime;
                        myInfo.Url = product.Url;
                        myInfolist.Add(myInfo);

                }

                return new ServiceResult<string>
                {
                    Data = JsonConvert.SerializeObject(myInfolist),
                    Message = String.Empty,
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

        public async Task<ServiceResult<string>> SimCart(string userId)
        {
            try
            {

                var products = _domatelContext.Products.OfType<SimCart>().Where(s => s.UserId == userId).ToList();
                List<MyInfo> myInfolist = new List<MyInfo>();

                foreach (var product in products)
                {
                    MyInfo myInfo = new MyInfo();

                    myInfo.BasePrice = product.BasePrice;
                    myInfo.FinalPrice = product.FinalPrice;
                    myInfo.Available = product.sAvailable;
                    myInfo.RemainTime = product.RemainTime;
                    myInfo.Number = product.Number;
                    myInfolist.Add(myInfo);

                }

                return new ServiceResult<string>
                {
                    Data = JsonConvert.SerializeObject(myInfolist),
                    Message = String.Empty,
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

        public async Task<ServiceResult<string>> Phone(string userId)
        {
            try
            {

                var products = _domatelContext.Products.OfType<Phone>().Where(s => s.UserId == userId).ToList();
                List<MyInfo> myInfolist = new List<MyInfo>();

                foreach (var product in products)
                {
                    MyInfo myInfo = new MyInfo();

                    myInfo.BasePrice = product.BasePrice;
                    myInfo.FinalPrice = product.FinalPrice;
                    myInfo.Available = product.sAvailable;
                    myInfo.RemainTime = product.RemainTime;
                    myInfo.PermanentNumber= product.PermanentNumber;
                    myInfolist.Add(myInfo);

                }

                return new ServiceResult<string>
                {
                    Data = JsonConvert.SerializeObject(myInfolist),
                    Message = String.Empty,
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

        public async Task<ServiceResult<string>> BidSimCart(string userId)
        {
            try
            {


                List<MyInfo> myInfolist = new List<MyInfo>();

                var simCartsList = _domatelContext.Products.OfType<SimCart>().ToList();




                foreach (var simCart in simCartsList)
                {
                    var bids = _domatelContext.Bids.Where(s => s.UserId == userId).FirstOrDefault(s => s.ProductId == simCart.Id);
                    if (bids != null)
                    {
                        MyInfo myInfo = new MyInfo();
                        myInfo.BasePrice = simCart.BasePrice;
                        myInfo.FinalPrice = simCart.FinalPrice;
                        myInfo.Available = simCart.sAvailable;
                        myInfo.RemainTime = simCart.RemainTime;
                        myInfo.Number = simCart.Number;
                        myInfo.OfferPrice = bids.OfferPrice;
                        myInfolist.Add(myInfo);
                    }
                }




                return new ServiceResult<string>
                {
                    Data = JsonConvert.SerializeObject(myInfolist),
                    Message = String.Empty,
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

        public async Task<ServiceResult<string>> BidDomain(string userId)
        {
            try
            {
                
               
                List<MyInfo> myInfolist = new List<MyInfo>();

                var domainsList = _domatelContext.Products.OfType<Domain>().ToList();
              



                foreach (var domain in domainsList)
                {
                    var bids = _domatelContext.Bids.Where(s => s.UserId == userId).FirstOrDefault(s=>s.ProductId==domain.Id);
                    if (bids != null)
                    {
                        MyInfo myInfo = new MyInfo();
                        myInfo.BasePrice = domain.BasePrice;
                        myInfo.FinalPrice = domain.FinalPrice;
                        myInfo.Available = domain.sAvailable;
                        myInfo.RemainTime = domain.RemainTime;
                        myInfo.Url = domain.Url;
                        myInfo.OfferPrice = bids.OfferPrice;
                        myInfolist.Add(myInfo);
                    }
                }
                
                   
                

                return new ServiceResult<string>
                {
                    Data = JsonConvert.SerializeObject(myInfolist),
                    Message = String.Empty,
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

        public async Task<ServiceResult<string>> BidPhone(string userId)
        {
            try
            {


                List<MyInfo> myInfolist = new List<MyInfo>();

                var phonesList = _domatelContext.Products.OfType<Phone>().ToList();




                foreach (var phone in phonesList)
                {
                    var bids = _domatelContext.Bids.Where(s => s.UserId == userId).FirstOrDefault(s => s.ProductId == phone.Id);
                    if (bids != null)
                    {
                        MyInfo myInfo = new MyInfo();
                        myInfo.BasePrice = phone.BasePrice;
                        myInfo.FinalPrice = phone.FinalPrice;
                        myInfo.Available = phone.sAvailable;
                        myInfo.RemainTime = phone.RemainTime;
                        myInfo.PermanentNumber = phone.PermanentNumber;
                        myInfo.OfferPrice = bids.OfferPrice;
                        myInfolist.Add(myInfo);
                    }
                }




                return new ServiceResult<string>
                {
                    Data = JsonConvert.SerializeObject(myInfolist),
                    Message = String.Empty,
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
    }
}