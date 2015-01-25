using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WebAppGitHubView
{
    public class GitHubUrlContext: DbContext
    {
        public DbSet<List> Urls { get; set; }
    }
}