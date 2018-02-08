using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web
{
    public class ConstantsHelper
    {
        public static int ParseIntegerParameter(string parameter)
        {
            int resultParameter;
            if (!Int32.TryParse(parameter, out resultParameter))
            {
                resultParameter = 0;
            }
            return resultParameter;
        }
    }
}