using CoreService.Application.Questions.Dtos;
using CoreService.Application.Questions.Mapper;
using CoreService.Domain.Entities;
using CoreService.Domain.Interfaces;
using MediatR;

namespace CoreService.Application.Questions.Commands.CreateQuestionCommand
{
    public class CreateQuestionCommandHandler : IRequestHandler<CreateQuestionCommand, QuestionDto>
    {
        private readonly IQuestionRepository _questionRepository;

        public CreateQuestionCommandHandler(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public async Task<QuestionDto> Handle(CreateQuestionCommand request, CancellationToken ct)
        {
            var entity = request.Dto.ToEntity(request.UserProfileId);
            await _questionRepository.CreateAsync(entity, ct);
            return entity.ToDto();
        }
    }
}