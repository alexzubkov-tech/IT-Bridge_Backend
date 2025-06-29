using CoreService.Application.Answers.Dtos;
using CoreService.Application.Answers.Mapper;
using CoreService.Domain.Interfaces;
using CoreService.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CoreService.Application.Answers.Commands.UpdateAnswerCommand
{
    public class UpdateAnswerCommandHandler : IRequestHandler<UpdateAnswerCommand, AnswerDto>
    {
        private readonly IAnswerRepository _repository;
        private readonly ILogger<UpdateAnswerCommandHandler> _logger;

        public UpdateAnswerCommandHandler(IAnswerRepository repository, ILogger<UpdateAnswerCommandHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<AnswerDto> Handle(UpdateAnswerCommand request, CancellationToken ct)
        {
            try
            {
                var existing = await _repository.GetByIdAsync(request.Id);
                if (existing == null)
                    throw new KeyNotFoundException("Answer not found");

                existing.UpdateEntityFromDto(request.Dto);
                await _repository.UpdateAsync(existing);

                return existing.ToDto();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating answer.");
                throw;
            }
        }
    }
}