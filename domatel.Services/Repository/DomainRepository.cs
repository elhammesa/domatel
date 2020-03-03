using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.ModelBinding;
using domatel.DataLayer.Data;
using domatel.Interface.Interfaces.Repository;
using domatel.Models.Core;
using domatel.Models.Criteria.Domain;
using domatel.Models.Criteria.SimCart;
using domatel.Models.Pagination;
using domatel.Models.Products;
using domatel.Services.Utility;
using Microsoft.EntityFrameworkCore;

using Newtonsoft.Json;


namespace domatel.Services.Repository
{
   public class DomainRepository: IDomainRepository

    {
        private DomatelContext _domatelContext;

        public DomainRepository(DomatelContext domatelContext)

        {
            _domatelContext = domatelContext;
        }

        public async Task<ServiceResult> AddDomain(DomainAdd model)
        {
            try
            {
                Domain domain = new Domain()
                {
                  
                    BasePrice = model.BasePrice,
                    FinalPrice = model.FinalPrice,
                    StartDate = model.StartDate,
                    EndDate = model.EndDate,
                    sAvailable = model.isAvailable,
                    RemainTime = model.RemainTime,
                    UserId = model.UserId

                };
                await _domatelContext.Domains.AddAsync(domain);
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

        public  async Task<ServiceResult> EditDomain(int id, Domain model)
        {
            try
            {

                var domainToUpdate = await _domatelContext.Domains.FirstOrDefaultAsync(s => s.Id == id);
                domainToUpdate.Url = model.Url;
                domainToUpdate.BasePrice = model.BasePrice;
                domainToUpdate.FinalPrice = model.FinalPrice;
                domainToUpdate.RemainTime = model.RemainTime;

                _domatelContext.Domains.Update(domainToUpdate);
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

        public async Task<ServiceResult<Domain>> GetDomainById(int id)
        {
            try
            {

                var domainToUpdate = await _domatelContext.Domains.FirstOrDefaultAsync(s => s.Id == id);
                return new ServiceResult<Domain>
                {
                    Data = domainToUpdate,
                    Message = String.Empty,
                    Status = (int)Configuration.ServiceResultStatus.Success
                };
            }
            catch (Exception e)
            {
                return new ServiceResult<Domain>
                {
                    Data = null,
                    Message = e.Message,
                    Status = (int)Configuration.ServiceResultStatus.Error
                };
            }
        }

        public async Task<ServiceResult<string>> GetAllDomain(PagingParameterModel pagingParameter)
        {
            try
            {
                var allDomains =  _domatelContext.Domains.OrderByDescending(s=>s.StartDate)
                    .Skip((pagingParameter.PageNumber - 1) * pagingParameter.PageSize)
                    .Take(pagingParameter.PageSize)
                    .ToList();

                List<DomainCriteria> domainlist = new List<DomainCriteria>();
               
                foreach (var domain in allDomains)
                {
                    DomainCriteria domaincriteria = new DomainCriteria();
                    domaincriteria.Id = domain.Id;
                    domaincriteria.Url = domain.Url;
                    domaincriteria.HaveContent = domain.HaveContent;
                    domaincriteria.BasePrice = domain.BasePrice;
                    domainlist.Add(domaincriteria);

                }
                
                return new ServiceResult<string>
                {
                    Data = JsonConvert.SerializeObject(domainlist),
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

        public async Task<ServiceResult<string>> GetDomainInfoById(int id)
        {
            try
            {
                var domain =   _domatelContext.Domains.FirstOrDefault(s => s.Id == id);
                var owner = _domatelContext.users.FirstOrDefault(s => s.Id == domain.UserId);

                DomainInfo domainInfo = new DomainInfo();

                if (domain != null && owner != null)
                {
                    domainInfo.Id = domain.Id;
                    domainInfo.Url = domain.Url;
                    domainInfo.BasePrice = domain.BasePrice;
                    domainInfo.HaveContent= domain.HaveContent;
                    domainInfo.Province = owner.Province;
                    
                }

               
                return new ServiceResult<string>
                {
                    Data = JsonConvert.SerializeObject(domainInfo),
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

        public async Task<ServiceResult<string>> GetOwnerDomainById(int id)
        {
            try
            {
                var domain = _domatelContext.Domains.FirstOrDefault(s => s.Id == id);
                var owner = _domatelContext.users.FirstOrDefault(s => s.Id == domain.UserId);

                DomainOwnerInfo domainInfo = new DomainOwnerInfo();

               
                    if (owner != null && domain!= null)
                    { 
                        domainInfo.FullName = owner.FullName;
                        domainInfo.Url = domain.Url;
                        domainInfo.Id = domain.Id;
                    domainInfo.Province = owner.Province;
                    }
                return new ServiceResult<string>
                {
                    Data = JsonConvert.SerializeObject(domainInfo),
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

        public async Task<ServiceResult<string>> GetAllDomainById(int id)
        {
            try
            {
                var domain = _domatelContext.Domains.FirstOrDefault(s => s.Id == id);
                var owner = _domatelContext.users.FirstOrDefault(s => s.Id == domain.UserId);
                var bid = _domatelContext.Bids.FirstOrDefault(s => s.UserId == domain.UserId);

                DomainAllInfo domainInfo = new DomainAllInfo();

                if (owner != null && domain != null && bid != null)
                {
                    domainInfo.FullName = owner.FullName;
                    domainInfo.Id = domain.Id;
                    domainInfo.BasePrice = domain.BasePrice;
                    domainInfo.StartDate = domain.StartDate;
                    domainInfo.Url = domain.Url;
                    domainInfo.HaveContent = domain.HaveContent;
                    domainInfo.NumberOfParticipant = bid.NumberOfParticipant;
                    domainInfo.Province = owner.Province;
                }

                return new ServiceResult<string>
                {
                    Data = JsonConvert.SerializeObject(domainInfo),
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
