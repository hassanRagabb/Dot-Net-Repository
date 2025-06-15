using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace businessLogicLayer.Entities
{
    public class EntityBase
    {
        public EntityState state { get; set; } = EntityState.Unchanged; //when u first created the state is unchanged 
    }
}
