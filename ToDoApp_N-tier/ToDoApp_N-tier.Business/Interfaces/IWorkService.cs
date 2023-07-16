using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp_N_tier.Common.ResponseObjects;
using ToDoApp_N_tier.Dtos.Interfaces;
using ToDoApp_N_tier.Dtos.WorkDtos;

namespace ToDoApp_N_tier.Business.Interfaces
{
    public interface IWorkService
    {
        Task<IResponse<List<WorkListDto>>> GetAllAsync();
        Task<IResponse<IDto>> GetByIdAsync<IDto>(int id);
        Task<IResponse<WorkCreateDto>> CreateAsync(WorkCreateDto workCreateDto);
        Task<IResponse<WorkUpdateDto>> UpdateAsync(WorkUpdateDto workUpdateDto);
        Task<IResponse> RemoveAsync(int id);
    }
}
