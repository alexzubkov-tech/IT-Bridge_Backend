using CoreService.Application.Common.Interfaces;
using CoreService.Application.Questions.Dtos;
using CoreService.Application.Questions.Mapper;
using CoreService.Domain.Entities;
using CoreService.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CoreService.Application.Questions.Queries.GetQuestionDetailsQuery
{
    public class GetQuestionDetailsQueryHandler : IRequestHandler<GetQuestionDetailsQuery, QuestionDetailsDto>
    {
        private readonly ICoreServiceDbContext _context;
        private readonly IQuestionRepository _questionRepository;

        public GetQuestionDetailsQueryHandler(ICoreServiceDbContext context, IQuestionRepository questionRepository)
        {
            _context = context;
            _questionRepository = questionRepository;
        }

        public async Task<QuestionDetailsDto> Handle(GetQuestionDetailsQuery request, CancellationToken ct)
        {

            var question = await _questionRepository.GetByIdWithDetailsAsync(request.Id, ct);
            if (question == null)
                throw new KeyNotFoundException($"Question with ID {request.Id} not found.");

            return question.ToDetailsDto();
        }
    }
}