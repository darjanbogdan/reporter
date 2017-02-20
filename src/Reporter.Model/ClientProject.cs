using System;
using System.Collections.Generic;

namespace Reporter.Model
{
    public class ClientProject
    {
        public Guid Id { get; set; }

        public Guid ClientId { get; set; }

        public Guid ProjectId { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }

        public Client Client { get; set; }

        //public Project Project { get; set; }
    }
}
