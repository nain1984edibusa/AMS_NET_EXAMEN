using AutoMapper;
using Microservices.Demo.Payments.Service.Application.UseCases.PolicyAccount.Dtos;
using Microservices.Demo.Payments.Service.Domain.Payments.Exceptions;
using Microservices.Demo.Payments.Service.Domain.Payments.Interfaces;
using Microservices.SharedKernel.Application.UseCases.Interfaces;

namespace Microservices.Demo.Payments.Service.Application.UseCases.PolicyAccount.Queries.GetPolicyAccountByNumber
{
    public class GetPolicyAccountByNumberUseCase: IQueryUseCase<GetPolicyAccountByNumberQuery, GetPolicyAccountByNumberResult>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetPolicyAccountByNumberUseCase(IUnitOfWork uow, IMapper mapper)
        {
            _unitOfWork = uow;
            _mapper = mapper;
        }

        public async Task<GetPolicyAccountByNumberResult> ExecuteAsync(GetPolicyAccountByNumberQuery input)
        {
            var policyAccount = await _unitOfWork.PolicyAccounts.FindByNumber(input.PolicyNumber);

            if (policyAccount == null) throw new PolicyAccountNotFound(input.PolicyNumber);

            var result = _mapper.Map<GetPolicyAccountByNumberResult>(policyAccount);

            return result;
        }
    }
}
