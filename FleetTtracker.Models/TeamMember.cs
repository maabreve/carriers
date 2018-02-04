using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;

namespace PowerEvent.Model
{
    public class TeamMember 
    {
        public TeamMember()
        {
            EventTeamMembers = new HashSet<EventTeamMember>();
            InfraPlansTechnical = new HashSet<InfraPlan>();
            TeamTeamMembers = new HashSet<TeamTeamMember>();
            OpenEvents = new HashSet<Event>();
            ApprovedEvents = new HashSet<Event>();
            InfraItemCheck = new HashSet<InfraPlanInfraItem>();
            SpotCoordenator = new HashSet<Spot>();
        }

        public int Id { get; set; }
        public string ApplicationUserId { get; set; }
        public int OfficeId { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public DateTime? DeactivationDate { get; set; }
        

        public virtual Office Office { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual ICollection<EventTeamMember> EventTeamMembers { get; set; }
        public virtual ICollection<InfraPlan> InfraPlansTechnical { get; set; }
        public virtual ICollection<TeamTeamMember> TeamTeamMembers { get; set; }
        public virtual ICollection<Event> OpenEvents { get; set; }
        public virtual ICollection<Event> ApprovedEvents { get; set; }
        public virtual ICollection<InfraPlanInfraItem> InfraItemCheck { get; set; }
        public virtual ICollection<Spot> SpotCoordenator { get; set; }
    }
}