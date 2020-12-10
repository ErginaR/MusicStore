using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.Domain.Entities
{
    public class CartLine
    {
        public Album Album { get; set; }
        public int Quantity { get; set; }
    }
}
