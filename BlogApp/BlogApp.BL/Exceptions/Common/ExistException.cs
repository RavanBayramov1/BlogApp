using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.BL.Exceptions.Common;

public class ExistException<T> : Exception, IBaseException
{
    public int Code => StatusCodes.Status409Conflict;

    public string ErrorMessage { get; }
    public ExistException() : base(typeof(T).Name + " is exist!")
    {
        ErrorMessage = typeof(T).Name + " is exist!";
    }
    public ExistException(string msg) : base(msg)
    {
        ErrorMessage = msg;
    }
}
