using AutoMapper;
using Repository.Repositories.Interfaces;
using Service.DTOs.Expert;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class ExpertService : IExpertService
    {

        private readonly IExpertRepository _expertRepo;
        private readonly IMapper _mapper;
        public ExpertService(IExpertRepository expertRepo, IMapper mapper)
        {
            _expertRepo = expertRepo;
            _mapper = mapper;


        }

        public async Task DeleteAsync(int? id) => await _expertRepo.DeleteAsync(await _expertRepo.GetByIdAsync(id));


        public async Task<IEnumerable<ExpertDto>> GetAllAsync() => _mapper.Map<IEnumerable<ExpertDto>>(await _expertRepo.FindAllAsync());
    }
}
