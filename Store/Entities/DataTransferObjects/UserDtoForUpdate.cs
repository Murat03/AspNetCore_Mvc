using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
	public record UserDtoForUpdate : UserDto
	{
        public HashSet<string> UserRoles { get; set; } = new HashSet<string>();
    }
}
