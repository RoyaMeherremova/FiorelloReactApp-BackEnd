using Service.DTOs.Category;
using Service.DTOs.SectionBackgroundImage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interfaces
{
    public interface ISectionBackgroundService
    {
        Task<IEnumerable<SectionBackgroundDto>> GetAllAsync();

    }
}
