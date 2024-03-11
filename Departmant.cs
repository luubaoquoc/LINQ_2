using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_2
{
    class Departmant
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public static List<Departmant> getDepartmants()
        {
            return new List<Departmant>()
            {
                new Departmant{ID=1, Name="IT"},
                new Departmant{ID=2, Name="HR"},
                new Departmant{ID=3, Name="Marketing"}
            };
        }
    }
}
