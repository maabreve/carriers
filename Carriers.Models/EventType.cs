using System.Collections.Generic;

namespace PowerEvent.Model
{
    public class EventType
    {
        public EventType()
        {
            InfraItems = new HashSet<InfraItem>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
       
        public virtual ICollection<InfraItem> InfraItems {get; set;}
    }
}
