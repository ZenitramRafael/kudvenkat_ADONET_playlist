using kudvenkat_ADONET_playlist_p15u_WebApp.DataAccess;
using kudvenkat_ADONET_playlist_p15u_WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kudvenkat_ADONET_playlist_p15u_WebApp.Ux
{
    public class UiStudents
    {
        public static IEnumerable<Student> GetStudents()
        {
            return AccessStudents.GetStudents();
        }
    }
}
