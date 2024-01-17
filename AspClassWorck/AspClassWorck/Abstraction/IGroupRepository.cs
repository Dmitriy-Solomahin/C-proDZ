using AspClassWorck.Models.DTO;

namespace AspClassWorck.Abstraction
{
    public interface IGroupRepository
    {
        public int AddGroup(GroupDTO group);
        public IEnumerable<GroupDTO> GetGroups();
        public int DeleteGroup(GroupDTO group);
    }
}
