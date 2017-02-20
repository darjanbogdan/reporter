using Reporter.Core.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporter.Service.ClientManagement.CreateClient
{
    public partial class CreateClientCommand : IValidate
    {
        public string Name { get; set; }

        public Guid ManagerId { get; set; }
    }
}
