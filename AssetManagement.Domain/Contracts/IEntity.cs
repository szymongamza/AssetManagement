using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Domain.Contracts
{
    public interface IEntity<Tid>
    {
        public Tid Id { get; set; }
    }
}
