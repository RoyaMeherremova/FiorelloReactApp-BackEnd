using Service.DTOs.Setting;

namespace Service.Services.Interfaces
{
    public interface ISettingService
    {
        Task<IEnumerable<SettingDto>> GetAllAsync();
    }
}
