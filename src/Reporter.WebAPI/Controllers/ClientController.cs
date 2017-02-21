using AutoMapper;
using Reporter.Core.Command;
using Reporter.Core.Context;
using Reporter.Core.Query;
using Reporter.Model;
using Reporter.Service.ClientManagement.CreateClient;
using Reporter.Service.ClientManagement.DeleteClient;
using Reporter.Service.ClientManagement.GetClient;
using Reporter.Service.ClientManagement.UpdateClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Reporter.WebAPI.Controllers
{
    [RoutePrefix("api/clients")]
    public class ClientController : ApiController
    {
        //TODO: Facade
        private readonly ICommandHandler<CreateClientCommand> createClientCommandHandler;
        private readonly IQueryHandler<GetClientQuery, Client> getClientQueryHandler;
        private readonly ICommandHandler<UpdateClientCommand> updateClientCommandHandler;
        private readonly ICommandHandler<DeleteClientCommand> deleteClientCommandHandler;

        private readonly IApplicationContext applicationContext;
        private readonly IMapper mapper;

        public ClientController(
            ICommandHandler<CreateClientCommand> createClientCommandHandler, 
            IQueryHandler<GetClientQuery, Client> getClientQueryHandler,
            ICommandHandler<UpdateClientCommand> updateClientCommandHandler,
            ICommandHandler<DeleteClientCommand> deleteClientCommandHandler,
            IApplicationContext applicationContext,
            IMapper mapper)
        {
            this.createClientCommandHandler = createClientCommandHandler;
            this.getClientQueryHandler = getClientQueryHandler;
            this.updateClientCommandHandler = updateClientCommandHandler;
            this.deleteClientCommandHandler = deleteClientCommandHandler;
            this.applicationContext = applicationContext;
            this.mapper = mapper;
        }

        [Route("{clientId}")]
        [HttpDelete]
        public async Task<HttpResponseMessage> DeleteAsync(Guid clientId)
        {
            var command = new DeleteClientCommand()
            {
                ClientId = clientId
            };

            await this.deleteClientCommandHandler.ExecuteAsync(command);

            return Request.CreateResponse(HttpStatusCode.NoContent);
        }

        [Route("{clientId}")]
        [HttpGet]
        public async Task<HttpResponseMessage> GetAsync(Guid clientId)
        {
            var query = new GetClientQuery()
            {
                ClientId = clientId
            };

            var result = await this.getClientQueryHandler.RunAsync(query);

            return Request.CreateResponse(HttpStatusCode.OK, this.mapper.Map<ClientRest>(result));
        }

        [Route("")]
        [HttpPost]
        public async Task<HttpResponseMessage> PostAsync(ClientRest client)
        {
            var command = this.mapper.Map<CreateClientCommand>(client);

            await this.createClientCommandHandler.ExecuteAsync(command);

            return Request.CreateResponse(HttpStatusCode.Created);
        }

        [Route("{clientId}")]
        [HttpPut]
        public async Task<HttpResponseMessage> UpdateAsync(Guid clientId, ClientRest client)
        {
            var command = new UpdateClientCommand();
            this.mapper.Map(client, command);
            command.Id = clientId;

            await this.updateClientCommandHandler.ExecuteAsync(command);

            return Request.CreateResponse(HttpStatusCode.NoContent);
        }

        public class ClientRest
        {
            //SGuid
            public Guid Id { get; set; }

            public string Name { get; set; }

            public Guid ManagerId { get; set; }
        }
    }
}