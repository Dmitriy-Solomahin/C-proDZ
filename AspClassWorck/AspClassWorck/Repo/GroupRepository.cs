using AspClassWorck.Abstraction;
using AspClassWorck.Models;
using AspClassWorck.Models.DTO;
using AutoMapper;
using Microsoft.Extensions.Caching.Memory;

namespace AspClassWorck.Repo
{
    public class GroupRepository : IGroupRepository
    {
        private readonly ProductContext _context;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _memoryCache;

        public GroupRepository(IMapper mapper, IMemoryCache memoryCache, ProductContext context)
        {
            _mapper = mapper;
            _memoryCache = memoryCache;
            _context = context;
        }
        public int AddGroup(GroupDTO group)
        {
            using (_context)
            {
                var entityGroup = _context.ProductGroups.FirstOrDefault(x => x.Name.ToLower().Equals(group.Name.ToLower()));
                if (entityGroup == null)
                {
                    entityGroup = _mapper.Map<Group>(group);
                    _context.ProductGroups.Add(entityGroup);
                    _context.SaveChanges();
                    _memoryCache.Remove("groups");
                }
                return entityGroup.Id;
            }
        }

        public int DeleteGroup(GroupDTO group)
        {
            using (_context)
            {
                var entityGroup = _context.ProductGroups.FirstOrDefault(x => x.Name.ToLower().Equals(group.Name.ToLower()));
                if (entityGroup != null)
                {
                    entityGroup = _mapper.Map<Group>(entityGroup);
                    _context.ProductGroups.Remove(entityGroup);
                    _context.SaveChanges();
                    _memoryCache.Remove("groups");
                }
                return entityGroup.Id;
            }
        }

        public IEnumerable<GroupDTO> GetGroups()
        {
            if (_memoryCache.TryGetValue("groups", out List<GroupDTO> groups))
                return groups;
            using (_context)
            {
                var groupsList = _context.ProductGroups.Select(x => _mapper.Map<GroupDTO>(x)).ToList();
                _memoryCache.Set("groups", groupsList, TimeSpan.FromMinutes(30));
                return groupsList;
            }
        }
    }
}
