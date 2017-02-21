using Reporter.Core.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporter.Service.ClientManagement.DeleteClient
{
    public partial class DeleteClientCommand : IValidate
    {
        public Guid ClientId { get; set; }
    }
}
