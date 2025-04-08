using AutoMapper;
using Repository.Repositories.Interfaces;
using Service.DTOs.Expert;
using Service.DTOs.Instagram;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class InstagramService : IInstagramService
    {
        private readonly IInstagramRepository _instagramRepo;
        private readonly IMapper _mapper;
        public InstagramService(IInstagramRepository instagramRepo, IMapper mapper)
        {
            _instagramRepo = instagramRepo;
            _mapper = mapper;


        }

        public async Task DeleteAsync(int? id) => await _instagramRepo.DeleteAsync(await _instagramRepo.GetByIdAsync(id));


        public async Task<IEnumerable<InstagramDto>> GetAllAsync() => _mapper.Map<IEnumerable<InstagramDto>>(await _instagramRepo.FindAllAsync());
    }
}
