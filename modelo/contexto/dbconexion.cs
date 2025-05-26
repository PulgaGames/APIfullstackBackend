using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace modelo.modelos
{
    public partial class dbconexion : DbContext
    {
        private dbconexion(string stringconexion)
            : base(stringconexion) {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
            this.Database.CommandTimeout = 900;
        }

        public static dbconexion Create()  { 

            return new dbconexion("name=dbconexion");


        }
        public DbSet<medico> medico { get; set; }
        public DbSet<ingreso> ingreso { get; set; }
        public DbSet<egreso> egreso { get; set; }
        public DbSet<paciente> paciente { get; set; }



    }
}
