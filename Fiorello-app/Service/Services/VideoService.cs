using AutoMapper;
using Repository.Repositories.Interfaces;
using Service.DTOs.Slider;
using Service.DTOs.Video;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class VideoService : IVideoService
    {

        private readonly IVideoRepository _videoRepo;
        private readonly IMapper _mapper;

        public VideoService(IVideoRepository videoRepo, IMapper mapper)
        {
            _videoRepo = videoRepo;
            _mapper = mapper;


        }

        public async Task<IEnumerable<VideoDto>> GetAllAsync() => _mapper.Map<IEnumerable<VideoDto>>(await _videoRepo.FindAllAsync());
    }
}
