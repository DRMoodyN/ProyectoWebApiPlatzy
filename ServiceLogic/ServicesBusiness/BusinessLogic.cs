using System;
using ServiceLogic.IServicesLogic;
using Models.Entities;
using Repository.IRepository;
using AutoMapper;
using Repository.DTO;

namespace ServiceLogic.BusinessLogic
{
    public class BusinessLogic : ICrud<BusinessDTO>, IUpdate<BusinessUpdateDTO>
    {
        private readonly IUnitOfWord _unitOfWord;
        private readonly IMapper _mapper;
        private Business? business;
        public BusinessLogic(IUnitOfWord unitOfWord, IMapper mapper)
        {
            _unitOfWord = unitOfWord;
            _mapper = mapper;
        }

        public async Task<BusinessDTO> AddAsync(BusinessDTO entity)
        {
            business = _mapper.Map<Business>(entity);
            business.BusinessId = Guid.NewGuid();
            await _unitOfWord.Businnes.AddAsync(business);
            await _unitOfWord.SaveAsync();
            return _mapper.Map<BusinessDTO>(business);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            business = await _unitOfWord.Businnes.GetIdAsync(
                x => x.BusinessId == id);
            business.IsActive = false;
            _unitOfWord.Businnes.Update(business);
            await _unitOfWord.SaveAsync();
            return true;
        }

        public async Task<List<BusinessDTO>> GetAllAsync()
        {
            List<Business> list = await _unitOfWord.Businnes.GetAllAsync(
                x => x.IsActive == true, x => x.BusinessName);
            return _mapper.Map<List<BusinessDTO>>(list);
        }

        public async Task<BusinessDTO> GetIdAsync(Guid id)
        {
            business = await _unitOfWord.Businnes.GetIdAsync(
                x => x.BusinessId == id && x.IsActive == true);
            return _mapper.Map<BusinessDTO>(business);
        }

        public async Task<bool> UpdateAsync(Guid id, BusinessUpdateDTO entity)
        {
            try
            {
                business = await _unitOfWord.Businnes.GetIdAsync(
                  x => x.BusinessId == id && x.IsActive == true);
                business.BusinessName = entity.BusinessName;
                _unitOfWord.Businnes.Update(business);
                await _unitOfWord.SaveAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
