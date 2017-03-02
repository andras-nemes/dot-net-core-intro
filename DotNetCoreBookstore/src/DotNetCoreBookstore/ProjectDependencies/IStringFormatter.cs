using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreBookstore.Dependencies
{
    public interface IStringFormatter
    {
		string FormatMe(object input);
    }
}
