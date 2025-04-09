using Service.DTOs.HeaderBackgroundDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interfaces
{
    public interface IHeaderBackgroundService
    {
        Task<IEnumerable<HeaderBackgroundDto>> GetAllAsync();
    }
}
