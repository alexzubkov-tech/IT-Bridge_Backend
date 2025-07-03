using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildingBlocks.EventBus.Abstractions;

namespace BuildingBlock.Events
{
    public class TestEvent: IEvent
    {
       public  string message;

        public TestEvent(string message)
        {
            this.message = message;
        }
    }
}
