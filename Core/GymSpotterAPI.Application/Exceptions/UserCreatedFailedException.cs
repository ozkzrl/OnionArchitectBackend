using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GymSpotterAPI.Application.Exceptions
{

    public class UserCreatedFailedException : Exception
    {
        public UserCreatedFailedException():base("Kullanıcı oluşturulurken beklenmeyen bir hata ile karşılaşıldı!")
        {
        }

        public UserCreatedFailedException(string? message) : base(message)
        {
        }

        public UserCreatedFailedException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
