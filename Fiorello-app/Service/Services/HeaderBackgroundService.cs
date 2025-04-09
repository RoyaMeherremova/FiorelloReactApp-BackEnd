using AutoMapper;
using Repository.Repositories.Interfaces;
using Service.DTOs.Expert;
using Service.DTOs.HeaderBackgroundDto;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class HeaderBackgroundService : IHeaderBackgroundService
    {
        private readonly IHeaderBackgroundRepository _headerBackRepo;
        private readonly IMapper _mapper;
        public HeaderBackgroundService(IHeaderBackgroundRepository headerBackRepo, IMapper mapper)
        {
            _headerBackRepo = headerBackRepo;
            _mapper = mapper;


        }

        public async Task DeleteAsync(int? id) => await _headerBackRepo.DeleteAsync(await _headerBackRepo.GetByIdAsync(id));


        public async Task<IEnumerable<HeaderBackgroundDto>> GetAllAsync() => _mapper.Map<IEnumerable<HeaderBackgroundDto>>(await _headerBackRepo.FindAllAsync());
    }
}
