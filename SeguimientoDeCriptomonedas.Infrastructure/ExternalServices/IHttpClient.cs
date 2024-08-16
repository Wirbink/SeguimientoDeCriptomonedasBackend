using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeguimientoDeCriptomonedas.Infrastructure.ExternalServices
{
    public interface IHttpClient
    {
        Task<string> GetAsync(string url);
    }
}
