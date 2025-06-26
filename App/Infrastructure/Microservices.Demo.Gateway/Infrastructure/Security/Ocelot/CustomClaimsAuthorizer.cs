using Ocelot.Authorization;
using Ocelot.DownstreamRouteFinder.UrlMatcher;
using Ocelot.Infrastructure.Claims.Parser;
using Ocelot.Responses;
using System.Security.Claims;
using System.Text.RegularExpressions;

namespace Microservices.Demo.Gateway.Infrastructure.Security.Ocelot
{
    public partial class CustomClaimsAuthorizer : IClaimsAuthorizer
    {
        private readonly IClaimsParser _claimsParser;

        public CustomClaimsAuthorizer(IClaimsParser claimsParser)
        {
            _claimsParser = claimsParser;
        }

        private static readonly Regex _regexAuthorize = new Regex(@"^{(?<variable>.+)}$", RegexOptions.None);

        public Response<bool> Authorize(
            ClaimsPrincipal claimsPrincipal,
            Dictionary<string, string> routeClaimsRequirement,
            List<PlaceholderNameAndValue> urlPathPlaceholderNameAndValues
        )
        {
            foreach (var required in routeClaimsRequirement)
            {
                var values = _claimsParser.GetValuesByClaimType(claimsPrincipal.Claims, required.Key);

                if (values.IsError)
                {
                    return new ErrorResponse<bool>(values.Errors);
                }

                if (values.Data != null)
                {
                    // 🔁 SOPORTE PARA MÚLTIPLES ROLES EN LA CONFIG
                    var expectedValues = required.Value
                        .Split(",", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

                    var match = _regexAuthorize.Match(required.Value);
                    if (match.Success)
                    {
                        var variableName = match.Groups["variable"].Value;

                        var matchingPlaceholders = urlPathPlaceholderNameAndValues
                            .Where(p => p.Name.Equals(variableName))
                            .Take(2)
                            .ToArray();

                        if (matchingPlaceholders.Length == 1)
                        {
                            var actualValue = matchingPlaceholders[0].Value;
                            var authorized = values.Data.Contains(actualValue);
                            if (!authorized)
                            {
                                return new ErrorResponse<bool>(new ClaimValueNotAuthorizedError(
                                    $"dynamic claim value for {variableName} of {string.Join(", ", values.Data)} is not the same as required value: {actualValue}"));
                            }
                        }
                        else
                        {
                            return new ErrorResponse<bool>(new ClaimValueNotAuthorizedError(
                                matchingPlaceholders.Length == 0
                                    ? $"config error: requires variable claim value: {variableName} placeholders does not contain that variable: {string.Join(", ", urlPathPlaceholderNameAndValues.Select(p => p.Name))}"
                                    : $"config error: requires variable claim value: {required.Value} but placeholders are ambiguous: {string.Join(", ", matchingPlaceholders.Select(p => p.Value))}"));
                        }
                    }
                    else
                    {
                        // ✅ VERIFICAR SI ALGÚN VALOR DEL USUARIO ESTÁ ENTRE LOS REQUERIDOS
                        var authorized = values.Data.Any(userClaim =>
                            expectedValues.Contains(userClaim, StringComparer.OrdinalIgnoreCase));

                        if (!authorized)
                        {
                            return new ErrorResponse<bool>(new ClaimValueNotAuthorizedError(
                                $"claim value: {string.Join(", ", values.Data)} is not among expected values: {string.Join(", ", expectedValues)} for type: {required.Key}"));
                        }
                    }
                }
                else
                {
                    return new ErrorResponse<bool>(new UserDoesNotHaveClaimError($"user does not have claim {required.Key}"));
                }
            }

            return new OkResponse<bool>(true);
        }
    }

}
