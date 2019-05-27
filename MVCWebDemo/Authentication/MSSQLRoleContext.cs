﻿using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using MVCWebDemo.Core.DAL.Model;
using System;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace MVCWebDemo.Authentication
{
    public class MSSQLRoleContext : IRoleStore<Role>
    {
        private readonly string _connectionString;
        public MSSQLRoleContext(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public Task<IdentityResult> CreateAsync(Role role, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> DeleteAsync(Role role, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {

        }

        public Task<Role> FindByIdAsync(string roleId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Role> FindByNameAsync(string normalizedRoleName, CancellationToken cancellationToken)
        {
            try
            {
                cancellationToken.ThrowIfCancellationRequested();

                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Role", connection);
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        Role role = default;
                        if (sqlDataReader.Read())
                        {
                            role = new Role();
                        }
                        return Task.FromResult<Role>(role);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<string> GetNormalizedRoleNameAsync(Role role, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetRoleIdAsync(Role role, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetRoleNameAsync(Role role, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetNormalizedRoleNameAsync(Role role, string normalizedName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetRoleNameAsync(Role role, string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> UpdateAsync(Role role, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}