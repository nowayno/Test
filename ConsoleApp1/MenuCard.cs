using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class MenuCard
    {
        public int MenuCardId { get; set; }
        public string Title { get; set; }
        public List<Menu> Menus { get; } = new List<Menu>();
        public override string ToString() => Title;
    }
}
