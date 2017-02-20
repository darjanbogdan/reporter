using Reporter.Core.Query;
using Reporter.Core.Validation;
using Reporter.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporter.Service.ClientManagement.GetClient
{
    public partial class GetClientQuery : IQuery<Client>, IValidate
    {
        public Guid ClientId { get; set; }
    }
}
