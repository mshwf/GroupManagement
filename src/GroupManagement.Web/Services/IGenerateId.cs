using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupManagement.Web.Services
{
    public interface IGenerateId
    {
        int Next();
    }
}
