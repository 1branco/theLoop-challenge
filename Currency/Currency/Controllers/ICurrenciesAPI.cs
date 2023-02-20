using Currency.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency.Controllers
{
    internal interface ICurrenciesAPI
    {
        Task<APIResponseObject> ConvertCurrency(string userCurrency, float userAmount, string desiredCurrency);

    }
}
