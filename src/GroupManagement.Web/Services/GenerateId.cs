using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupManagement.Web.Services
{
    public class GenerateId : IGenerateId
    {
        private int currentId = 2;
        public int Next() =>
            ++currentId;
    }
}
