using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetAcademy.Persistence.Entities
{
	public class ApplicationUser : IdentityUser
	{
		public required string FirstName { get; set; }
		public required string LastName { get; set; }
		public required string Description { get; set; }
		public byte[]? ProfileImage { get; set; } = null!;
	}
}
