﻿using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
	public interface IAuthService
	{
		IEnumerable<IdentityRole> Roles { get; }
		IEnumerable<IdentityUser> Users { get; }
		Task<UserDtoForUpdate> GetOneUserForUpdate(string userName);
		Task<IdentityUser> GetOneUser(string userName);
		Task<IdentityResult> CreateUser(UserDtoForCreation userDto);
		Task Update(UserDtoForUpdate userDto);
		Task<IdentityResult> ResetPassword(ResetPasswordDto model);
		Task<IdentityResult> DeleteOneUser(string userName);
	}
}
