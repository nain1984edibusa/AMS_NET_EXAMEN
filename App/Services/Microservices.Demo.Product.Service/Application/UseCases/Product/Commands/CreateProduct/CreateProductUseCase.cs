using AutoMapper;
using Azure.Core;
using Microservices.Demo.Products.Service.Application.UseCases.Product.Dtos;
using Microservices.Demo.Products.Service.Domain.Products.Entities;
using Microservices.Demo.Products.Service.Domain.Products.Interfaces;
using Microservices.Demo.Products.Service.Framework.DI;
using Microservices.Infrastructure.Trace;
using Microservices.SharedKernel.Application.UseCases.Interfaces;
using System.Diagnostics;

namespace Microservices.Demo.Products.Service.Application.UseCases.Product.Commands.CreateProduct
{
    public class CreateProductUseCase : ICommandUseCase<CreateProductCommand, CreateProductResult>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ActivitySource _activitySource;

        public CreateProductUseCase(IUnitOfWork unitOfWork, IMapper mapper, ActivitySource activitySource)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _activitySource = activitySource;
        }

        public async Task<CreateProductResult> ExecuteAsync(CreateProductCommand input)
        {
            using var activity = _activitySource.StartActivity("CreateProductUseCase.ExecuteAsync", ActivityKind.Internal);

            var draft = Domain.Products.Entities.Product.CreateDraft
            (
                input.Code,
                input.Name,
                input.Image,
                input.Description,
                input.MaxNumberOfInsured,
                input.Icon
            );

            foreach (var cover in input.Covers)
                draft.AddCover(cover.Code, cover.Name, cover.Description, cover.Optional, cover.SumInsured);

            var questions = new List<Question>();
            foreach (var question in input.Questions)
                switch (question)
                {
                    case NumericQuestionDto numericQuestion:
                        questions.Add(new NumericQuestion(numericQuestion.QuestionCode, numericQuestion.Index,
                            numericQuestion.Text));
                        break;
                    case DateQuestionDto dateQuestion:
                        questions.Add(new DateQuestion(dateQuestion.QuestionCode, dateQuestion.Index,
                            dateQuestion.Text));
                        break;
                    case ChoiceQuestionDto choiceQuestion:
                        questions.Add(new ChoiceQuestion(choiceQuestion.QuestionCode, choiceQuestion.Index,
                            choiceQuestion.Text, choiceQuestion.Choices.Select(c => new Choice(c.Code, c.Label)).ToList()));
                        break;
                }

            draft.AddQuestions(questions);

            await _unitOfWork.Products.AddAsync(draft);
            await _unitOfWork.CompleteAsync();

            var result = _mapper.Map<CreateProductResult>(draft);

            activity.SetTagsFromObject(result, "Product");
            activity.SetStatus(ActivityStatusCode.Ok);

            return result;
        }
    }

}
