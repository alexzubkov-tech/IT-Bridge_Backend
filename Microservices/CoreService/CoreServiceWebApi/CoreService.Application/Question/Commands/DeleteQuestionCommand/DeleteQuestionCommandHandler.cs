using MediatR;
using CoreService.Domain.Interfaces;

namespace CoreService.Application.Questions.Commands.DeleteQuestionCommand
{
    public class DeleteQuestionCommandHandler : IRequestHandler<DeleteQuestionCommand, bool>
    {
        private readonly IQuestionRepository _questionRepository;

        public DeleteQuestionCommandHandler(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public async Task<bool> Handle(DeleteQuestionCommand request, CancellationToken ct)
        {
            var result = await _questionRepository.DeleteAsync(request.Id, ct);
            if (!result)
                throw new KeyNotFoundException($"Question with ID {request.Id} not found.");

            return result;
        }
    }
}