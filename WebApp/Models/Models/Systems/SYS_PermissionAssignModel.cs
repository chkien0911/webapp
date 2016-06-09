namespace Ivs.Models.Systems
{
    public class SYS_PermissionAssignModel : Ivs.Core.Interface.IModel
    {
        public int Id { get; set; }

        public string GroupCode { get; set; }

        public string GroupName { get; set; }

        public int MappingId { get; set; }

        public string FunctionID { get; set; }

        public string FunctionName { get; set; }

        public string OperID { get; set; }
    }
}