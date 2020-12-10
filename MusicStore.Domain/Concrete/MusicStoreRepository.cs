using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicStore.Domain.Abstract;
using MusicStore.Domain.Entities;

namespace MusicStore.Domain.Concrete
{
    public class MusicStoreRepository:IMusicStoreRepository
    {
        private MusicStoreDbContext context = new MusicStoreDbContext();
        public IEnumerable<Album> Albums 
        {
            get
            {
                return context.Albums;
            }
        }

        public void SaveAlbum(Album album)
        {
            if(album.AlbumID==0)
            {
                context.Albums.Add(album);
            }
            else
            {
                Album alb = context.Albums.Find(album.AlbumID);
                alb.Title = album.Title;
                alb.Artist = album.Artist;
                alb.Genre = album.Genre;
                alb.Price = album.Price;
            }
            context.SaveChanges();

        }
        public Album DeleteAlbum(int albumId)
        {
            Album album = context.Albums.Find(albumId);
            if(album!=null)
            {
                context.Albums.Remove(album);
                context.SaveChanges();
            }
            return album;
        }

    }
}
