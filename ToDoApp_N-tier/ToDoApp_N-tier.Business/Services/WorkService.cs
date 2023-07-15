using AutoMapper;
using ToDoApp_N_tier.Business.Interfaces;
using ToDoApp_N_tier.DataAccess.UnitOfWork;
using ToDoApp_N_tier.Dtos.Interfaces;
using ToDoApp_N_tier.Dtos.WorkDtos;
using ToDoApp_N_tier.Entities.Domains;

namespace ToDoApp_N_tier.Business.Services
{
    public class WorkService : IWorkService
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;

        public WorkService(IUow uow,IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<List<WorkListDto>> GetAllAsync()
        {
            return _mapper.Map<List<WorkListDto>>(await _uow.GetRepository<Work>().GetAllAsync());
        }

        public async Task<IDto> GetByIdAsync<IDto>(int id)
        {
            return _mapper.Map<IDto>(await _uow.GetRepository<Work>().GetByFilter(x => x.Id == id));
        }

        public async Task CreateAsync(WorkCreateDto workCreateDto)
        {
            await _uow.GetRepository<Work>().CreateAsync(_mapper.Map<Work>(workCreateDto));
            await _uow.SaveChangesAsync();
        }

        public async Task UpdateAsync(WorkUpdateDto workUpdateDto)
        {
            _uow.GetRepository<Work>().Update(_mapper.Map<Work>(workUpdateDto));
            await _uow.SaveChangesAsync();
        }

        public async Task RemoveAsync(int id)
        {
            _uow.GetRepository<Work>().Remove(id);
            await _uow.SaveChangesAsync();
        }
    }
}
