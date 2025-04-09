using AutoMapper;
using Repository.Repositories.Interfaces;
using Service.DTOs.Expert;
using Service.DTOs.SectionBackgroundImage;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class SectionBackgroundService : ISectionBackgroundService
    {

        private readonly ISectionBackgroundRepository _sectionRepo;
        private readonly IMapper _mapper;
        public SectionBackgroundService(ISectionBackgroundRepository sectionRepo, IMapper mapper)
        {
            _sectionRepo = sectionRepo;
            _mapper = mapper;


        }

        public async Task DeleteAsync(int? id) => await _sectionRepo.DeleteAsync(await _sectionRepo.GetByIdAsync(id));


        public async Task<IEnumerable<SectionBackgroundDto>> GetAllAsync() => _mapper.Map<IEnumerable<SectionBackgroundDto>>(await _sectionRepo.FindAllAsync());
    }
}
