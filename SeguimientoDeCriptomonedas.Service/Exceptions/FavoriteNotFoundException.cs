using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeguimientoDeCriptomonedas.Service.Exceptions
{
    public class FavoriteNotFoundException : Exception
    {
        public FavoriteNotFoundException(string name)
            : base($"Favorite with Name {name} was not found.")
        { 
        }
    }
}
