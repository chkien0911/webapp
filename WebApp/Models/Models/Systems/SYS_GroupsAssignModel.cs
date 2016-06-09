using Ivs.Core.Interface;

namespace Ivs.Models.Systems
{
    public class SYS_GroupsAssignModel : IModel
    {
        public int ID { get; set; }

        public int UserID { get; set; }

        public string UserCode { get; set; }

        public int GroupID { get; set; }

        public string GroupCode { get; set; }

        public string DisplayName { get; set; }

        public string Status { get; set; }

        public string SystemData { get; set; }
    }
}