using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservices.Infrastructure.Http
{
    public class UrlService : IUrlService
    {
        private readonly Dictionary<string, string> _urls;

        public UrlService(IOptions<Dictionary<string, string>> options)
        {
            _urls = new Dictionary<string, string>(options.Value, StringComparer.OrdinalIgnoreCase);
        }

        public string GetUrl(string key)
        {
            return _urls.TryGetValue(key, out var value)
                ? value
                : throw new KeyNotFoundException($"URL for '{key}' not found.");
        }
    }
}
