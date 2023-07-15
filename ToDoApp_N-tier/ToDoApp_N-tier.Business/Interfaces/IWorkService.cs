using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp_N_tier.Dtos.Interfaces;
using ToDoApp_N_tier.Dtos.WorkDtos;

namespace ToDoApp_N_tier.Business.Interfaces
{
    public interface IWorkService
    {
        Task<List<WorkListDto>> GetAllAsync();
        Task<IDto> GetByIdAsync<IDto>(int id);
        Task CreateAsync(WorkCreateDto workCreateDto);
        Task UpdateAsync(WorkUpdateDto workUpdateDto);
        Task RemoveAsync(int id);
    }
}
