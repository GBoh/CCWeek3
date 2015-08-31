using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ContactManager.Models
{
    public class DatabaseInitializer : DropCreateDatabaseAlways<DataContext>
    {
    }
}