using AutoMapper;
using Repository.Repositories.Interfaces;
using Service.DTOs.Say;
using Service.Services.Interfaces;

namespace Service.Services
{
    public class SayService : ISayService
    {

        private readonly ISayRepository _sayRepo;
        private readonly IMapper _mapper;
        public SayService(ISayRepository sayRepo, IMapper mapper)
        {
            _sayRepo = sayRepo;
            _mapper = mapper;


        }

        public async Task DeleteAsync(int? id) => await _sayRepo.DeleteAsync(await _sayRepo.GetByIdAsync(id));


        public async Task<IEnumerable<SayDto>> GetAllAsync() => _mapper.Map<IEnumerable<SayDto>>(await _sayRepo.FindAllAsync());
    }
}
