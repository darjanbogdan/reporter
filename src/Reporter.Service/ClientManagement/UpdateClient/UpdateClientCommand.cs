using Reporter.Core.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporter.Service.ClientManagement.UpdateClient
{
    public partial class UpdateClientCommand : IValidate
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid ManagerId { get; set; }
    }
}
