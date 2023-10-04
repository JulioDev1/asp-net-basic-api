using AwesomeDevEvents.API.Entities;

namespace crud_api.persistence
{
    public class DevEventsDbContext
    {
        public List<DevEntities> DevEntities {get; set;}

        public  DevEventsDbContext()
        {
           DevEntities = new List<DevEntities>();
        }
    }
}