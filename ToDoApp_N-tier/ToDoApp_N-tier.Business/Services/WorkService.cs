using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using ToDoApp_N_tier.Business.Extensions;
using ToDoApp_N_tier.Business.Interfaces;
using ToDoApp_N_tier.Common.Enums;
using ToDoApp_N_tier.Common.ResponseObjects;
using ToDoApp_N_tier.DataAccess.UnitOfWork;
using ToDoApp_N_tier.Dtos.WorkDtos;
using ToDoApp_N_tier.Entities.Domains;

namespace ToDoApp_N_tier.Business.Services
{
    public class WorkService : IWorkService
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        private readonly IValidator<WorkCreateDto> _createvalidator;
        private readonly IValidator<WorkUpdateDto> _updatevalidator;

        public WorkService(IUow uow, IMapper mapper, IValidator<WorkCreateDto> createvalidator, IValidator<WorkUpdateDto> updatevalidator)
        {
            _uow = uow;
            _mapper = mapper;
            _createvalidator = createvalidator;
            _updatevalidator = updatevalidator;
        }

        public async Task<IResponse<List<WorkListDto>>> GetAllAsync()
        {
            List<WorkListDto> workListDtos = _mapper.Map<List<WorkListDto>>(await _uow.GetRepository<Work>().GetAllAsync());
            return new Response<List<WorkListDto>>(ResponseType.Success, workListDtos);
        }

        public async Task<IResponse<IDto>> GetByIdAsync<IDto>(int id)
        {
            var dto = _mapper.Map<IDto>(await _uow.GetRepository<Work>().GetByFilter(x => x.Id == id));
            if (dto is null)
            {
                return new Response<IDto>(ResponseType.NotFound, $"No data found matching {id}");
            }
            return new Response<IDto>(ResponseType.Success, dto);
        }

        public async Task<IResponse<WorkCreateDto>> CreateAsync(WorkCreateDto workCreateDto)
        {
            ValidationResult validationResult = _createvalidator.Validate(workCreateDto);
            if (validationResult.IsValid)
            {
                await _uow.GetRepository<Work>().CreateAsync(_mapper.Map<Work>(workCreateDto));
                await _uow.SaveChangesAsync();
                return new Response<WorkCreateDto>(ResponseType.Success, workCreateDto);
            }
            else
                return new Response<WorkCreateDto>(ResponseType.ValidationError, workCreateDto, validationResult.ConvertToCustomValidationError());
        }

        public async Task<IResponse<WorkUpdateDto>> UpdateAsync(WorkUpdateDto workUpdateDto)
        {
            ValidationResult validationResult = _updatevalidator.Validate(workUpdateDto);
            if (validationResult.IsValid)
            {
                Work unchangedWork = await _uow.GetRepository<Work>().GetById(workUpdateDto.Id);
                if (unchangedWork != null)
                {
                    _uow.GetRepository<Work>().Update(_mapper.Map<Work>(workUpdateDto), unchangedWork);
                    await _uow.SaveChangesAsync();
                    return new Response<WorkUpdateDto>(ResponseType.Success, workUpdateDto);
                }
                return new Response<WorkUpdateDto>(ResponseType.NotFound, $"No data found matching {workUpdateDto.Id}");
            }
            else
                return new Response<WorkUpdateDto>(ResponseType.ValidationError, workUpdateDto, validationResult.ConvertToCustomValidationError());
            
        }

        public async Task<IResponse> RemoveAsync(int id)
        {
            Work removedWork = await _uow.GetRepository<Work>().GetByFilter(x => x.Id == id);
            if (removedWork != null)
            {
                _uow.GetRepository<Work>().Remove(removedWork);
                await _uow.SaveChangesAsync();
                return new Response(ResponseType.Success);
            }
            return new Response($"No data found matching {id}", ResponseType.NotFound);
        }
    }
}
