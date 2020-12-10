using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicStore.Domain.Entities;

namespace MusicStore.Domain.Abstract
{
    public interface IMusicStoreRepository
    {
        IEnumerable<Album> Albums { get; }
        void SaveAlbum(Album album);
        Album DeleteAlbum(int albumId);
    }
}
