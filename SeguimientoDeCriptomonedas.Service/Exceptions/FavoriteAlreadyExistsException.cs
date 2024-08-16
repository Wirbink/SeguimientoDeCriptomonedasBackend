using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeguimientoDeCriptomonedas.Service.Exceptions
{
    public class FavoriteAlreadyExistsException : Exception
    {
        public FavoriteAlreadyExistsException(string name)
            : base($"A favorite with the name '{name}' already exists.")
        {
        }
    }
}
