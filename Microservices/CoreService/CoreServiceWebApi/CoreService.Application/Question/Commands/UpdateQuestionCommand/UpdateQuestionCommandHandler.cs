using CoreService.Application.Questions.Dtos;
using CoreService.Application.Questions.Mapper;
using CoreService.Domain.Entities;
using CoreService.Domain.Interfaces;
using MediatR;

namespace CoreService.Application.Questions.Commands.UpdateQuestionCommand
{
    public class UpdateQuestionCommandHandler : IRequestHandler<UpdateQuestionCommand, QuestionDto>
    {
        private readonly IQuestionRepository _questionRepository;

        public UpdateQuestionCommandHandler(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public async Task<QuestionDto> Handle(UpdateQuestionCommand request, CancellationToken ct)
        {
            var existing = await _questionRepository.GetByIdAsync(request.Id, ct);
            if (existing == null)
                throw new KeyNotFoundException($"Question with ID {request.Id} not found.");

            existing.UpdateEntityFromDto(request.Dto);
            await _questionRepository.UpdateAsync(existing, ct);

            return existing.ToDto();
        }
    }
}