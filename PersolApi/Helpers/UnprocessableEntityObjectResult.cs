using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersolApi.Helpers
{
    public class UnprocessableEntityObjectResultTunsBad : ObjectResult
    {
        public UnprocessableEntityObjectResultTunsBad(ModelStateDictionary modelState): base(new SerializableError(modelState))
        {
            if (modelState == null)
            {
                throw new ArgumentNullException(nameof(modelState));
            }
            StatusCode = 422;
        }
    }
}
