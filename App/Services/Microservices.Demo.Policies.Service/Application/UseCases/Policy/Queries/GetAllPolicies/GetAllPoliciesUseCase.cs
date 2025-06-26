using AutoMapper;
using Microservices.Demo.Policies.Service.Application.UseCases.Policy.Dtos;
using Microservices.Demo.Policies.Service.Domain.Policies.Interfaces;
using Microservices.SharedKernel.Application.UseCases.Interfaces;
using Microsoft.Diagnostics.Tracing.StackSources;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Microservices.Demo.Policies.Service.Application.UseCases.Policy.Queries.GetAllPolicies
{
    public class GetAllPoliciesUseCase : IQueryUseCase<GetAllPoliciesQuery, GetAllPoliciesResult>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ActivitySource _activitySource;

        public GetAllPoliciesUseCase(IUnitOfWork unitOfWork, IMapper mapper, ActivitySource activitySource)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _activitySource = activitySource;
        }
        //public async Task<GetAllPoliciesResult> ExecuteAsync(GetAllPoliciesQuery input)
        //{
        //    using var activity = _activitySource.StartActivity("GetAllProductsUseCase.ExecuteAsync", ActivityKind.Internal);

        //    var policies = await _unitOfWork.Policies.FindAllPolicies();
        //    var result = _mapper.Map<GetAllPoliciesResult>(policies);

        //    Console.WriteLine($"[Telemetry] Found {result.Policies.Count()} policies.");

        //    activity.SetTag("Products.Count", result.Policies.Count());
        //    activity.SetStatus(ActivityStatusCode.Ok);

        //    Console.WriteLine($"[Telemetry] Activity '{activity.DisplayName}' completed with status: {activity.Status}");


        //    return result;
        //}

        public async Task<GetAllPoliciesResult> ExecuteAsync(GetAllPoliciesQuery input)
        {
            using var activity = _activitySource.StartActivity("GetAllPoliciesUseCase.ExecuteAsync", ActivityKind.Internal);

            var policies = await _unitOfWork.Policies.FindAllPolicies();

            var result = new GetAllPoliciesResult
            {
                //Policies = _mapper.Map<IEnumerable<PolicyDto>>(policies)
                Policies = policies.Select(policy =>
                {
                    var firstVersion = policy.Versions.FirstOrDefault(v => v.VersionNumber == 1);

                    return new PolicyDto
                    {
                        Id = policy.Id.ToString(),
                        Number = policy.Number,
                        ProductCode = policy.ProductCode,
                        PolicyHolder = firstVersion != null
                            ? $"{firstVersion.PolicyHolder.FirstName} {firstVersion.PolicyHolder.LastName}"
                            : "N/A",
                        DateFrom = firstVersion?.CoverPeriod.ValidFrom ?? default,
                        DateTo = firstVersion?.CoverPeriod.ValidTo ?? default,
                        TotalPremium = firstVersion?.TotalPremiumAmount ?? 0,
                        Covers = firstVersion?.Covers.Select(c => c.Code).ToList() ?? new List<string>()
                    };
                }).ToList()

            };

            Console.WriteLine($"[Telemetry] Found {result.Policies.Count()} policies.");

            activity?.SetTag("Products.Count", result.Policies.Count());
            activity?.SetStatus(ActivityStatusCode.Ok);

            Console.WriteLine($"[Telemetry] Activity '{activity?.DisplayName}' completed with status: {activity?.Status}");

            return result;
        }
    }
}
