﻿using dotNetLabs.Server.Models;
using dotNetLabs.Server.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace dotNetLabs.Repositories
{
    public interface IPlaylistsRepository
    {

        Task CreateAsync(Playlist playlist);
        void Remove(Playlist playlist);
        IEnumerable<Playlist> GetAll();

        Task<Playlist> GetByIdAsync(string id);

    }

    public class PlaylistsRepository : IPlaylistsRepository
    {

        private readonly ApplicationDbContext _db;

        public PlaylistsRepository(ApplicationDbContext db)
        {
            _db = db; 
        }

        public async Task CreateAsync(Playlist playlist)
        {
            await _db.Playlists.AddAsync(playlist);
        }

        public IEnumerable<Playlist> GetAll()
        {
            return _db.Playlists;
        }

        public async Task<Playlist> GetByIdAsync(string id)
        {
            return await _db.Playlists.FindAsync(id);
        }

        public void Remove(Playlist playlist)
        {
            _db.Playlists.Remove(playlist);
        }
    }
}
