using System.Collections.Generic;

namespace MVCWebDemo.Models
{
    public class RolesViewModel
    {
        public IEnumerable<string> RoleNames { get; set; }
        public string UserName { get; set; }
    }
}
