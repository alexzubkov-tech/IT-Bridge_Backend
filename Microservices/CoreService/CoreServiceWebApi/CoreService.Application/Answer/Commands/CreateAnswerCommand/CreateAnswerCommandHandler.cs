using CoreService.Application.Answers.Dtos;
using CoreService.Application.Answers.Mapper;
using CoreService.Domain.Interfaces;
using CoreService.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CoreService.Application.Answers.Commands.CreateAnswerCommand
{
    public class CreateAnswerCommandHandler : IRequestHandler<CreateAnswerCommand, AnswerDto>
    {
        private readonly IAnswerRepository _repository;
        private readonly ILogger<CreateAnswerCommandHandler> _logger;

        public CreateAnswerCommandHandler(IAnswerRepository repository, ILogger<CreateAnswerCommandHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<AnswerDto> Handle(CreateAnswerCommand request, CancellationToken ct)
        {
            try
            {
                var entity = request.Dto.ToEntity();
                await _repository.CreateAsync(entity);
                return entity.ToDto();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating answer.");
                throw;
            }
        }
    }
}