using AutoMapper;
using Repository.Repositories.Interfaces;
using Service.DTOs.Expert;
using Service.DTOs.Setting;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class SettingService : ISettingService
    {
        private readonly ISettingRepository _settingRepo;
        private readonly IMapper _mapper;
        public SettingService(ISettingRepository settingRepo, IMapper mapper)
        {
            _settingRepo = settingRepo;
            _mapper = mapper;


        }

        public async Task DeleteAsync(int? id) => await _settingRepo.DeleteAsync(await _settingRepo.GetByIdAsync(id));


        public async Task<IEnumerable<SettingDto>> GetAllAsync() => _mapper.Map<IEnumerable<SettingDto>>(await _settingRepo.FindAllAsync());
    }
}
