using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.ViewModels
{
    public class ScoreContext:DbContext
    {
        public ScoreContext() : base("UserDB") { }

        public DbSet<Score> Scores { get; set; }
    }
}
