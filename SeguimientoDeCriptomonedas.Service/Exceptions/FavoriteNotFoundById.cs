using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SeguimientoDeCriptomonedas.Service.Exceptions
{
    public class FavoriteNotFoundById : Exception
    {
        public FavoriteNotFoundById(int id)
            : base($"Favorite with ID: {id} was not found.")
        {
        }
    }
}
