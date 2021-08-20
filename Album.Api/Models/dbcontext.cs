using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Album.Api.Models
{
    public partial class SimpleModelsAndRelationsContext : DbContext
    {
        // TODO 1: complete the implementation below (1 pt) 
        public DbSet<Album> Albums {get;set;}

        public SimpleModelsAndRelationsContext(DbContextOptions<SimpleModelsAndRelationsContext> options) : base(options) { }
    }
}
