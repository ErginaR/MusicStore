using MusicStore.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.Domain.Entities
{
    public class Cart
    {
        public List<CartLine> lineCollection=new List<CartLine>();
        public IEnumerable<CartLine> LineCollection()
        {
            return lineCollection;
        }

        public void AddToCart(Album album,int quantity)
        {
            CartLine line = lineCollection.Where(l => l.Album.AlbumID== album.AlbumID).FirstOrDefault();
            if(line!=null)
            {
                line.Quantity += quantity;
            }
            else
            {
                lineCollection.Add(new CartLine { Album = album, Quantity = quantity });
            }
        }

        public void RemoveFromCart(Album album)
        {
            lineCollection.RemoveAll(l => l.Album.AlbumID == album.AlbumID);
        }
        public void Clear()
        {
            lineCollection.Clear();
        }


    }
}
