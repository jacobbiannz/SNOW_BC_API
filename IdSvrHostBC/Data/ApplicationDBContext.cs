using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.EntityFramework.Options;
using IdSvrHostBC.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdSvrHostBC.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
	    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
	    {
		    
	    }
	    protected override void OnModelCreating(ModelBuilder builder)
	    {
		    base.OnModelCreating(builder);
	    }
    }

	//public class ConfigurationDbContext : IdentityServer4.EntityFramework.DbContexts.ConfigurationDbContext
	//{
	//	public ConfigurationDbContext(DbContextOptions<IdentityServer4.EntityFramework.DbContexts.ConfigurationDbContext> options, ConfigurationStoreOptions storeOptions) : base(options, storeOptions)
	//	{
	//	}

	//	protected override void OnModelCreating(ModelBuilder builder)
	//	{
	//		base.OnModelCreating(builder);
	//	}
	//}

	//public class PersistedGrantDbContext : IdentityServer4.EntityFramework.DbContexts.PersistedGrantDbContext
	//{
	//	public PersistedGrantDbContext(DbContextOptions<IdentityServer4.EntityFramework.DbContexts.PersistedGrantDbContext> options, OperationalStoreOptions storeOptions) : base(options, storeOptions)
	//	{
	//	}

	//	protected override void OnModelCreating(ModelBuilder builder)
	//	{
	//		base.OnModelCreating(builder);
	//	}
	//}
}
