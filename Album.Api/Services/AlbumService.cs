using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Album.Api.Models;

namespace Album.Api
{
    public interface IAlbumService
    {
        public string createAlbum(Album.Api.Models.Album album);
        public string deleteAlbum(int Id);
        public string updateAlbum(int Id, Album.Api.Models.Album album);
        public Album.Api.Models.Album getAlbum(int Id);
        public List<Album.Api.Models.Album> getAll();
    }
    public class AlbumService : IAlbumService
    {
        private readonly SimpleModelsAndRelationsContext _context;
        public AlbumService(SimpleModelsAndRelationsContext context) 
        {
            _context = context;
        }
        public string createAlbum(Album.Api.Models.Album album) {
            var newAlbum = _context.Albums.FirstOrDefault(s => s.Id == album.Id || s.Name == album.Name);
            if(newAlbum == null) {
                _context.Albums.Add(album);
                _context.SaveChanges();
                return "Created new album succesfully";
            }
            return "Album already exists";
        }

        public string deleteAlbum(int Id) {
            var albumDelete =_context.Albums.FirstOrDefault(s => s.Id == Id);
            if(albumDelete != null) {
                _context.Albums.Remove(albumDelete);
                _context.SaveChanges();
                return "Album deleted succesfully";
            }
            return "No such album in database";
        }

        public string updateAlbum(int Id, Album.Api.Models.Album album) {
            var albumUpdate =_context.Albums.FirstOrDefault(s => s.Id == Id);
            if(albumUpdate != null) {
                albumUpdate.Artist = album.Artist;
                albumUpdate.Name = album.Name;
                albumUpdate.ImageUrl = album.ImageUrl;
                _context.Albums.Update(albumUpdate);
                _context.SaveChanges();
                return "Album updated succesfully";
            }
            return "No such album in database";
        }

        public Album.Api.Models.Album getAlbum(int Id) {
            return _context.Albums.FirstOrDefault(s => s.Id == Id);
        }

        public List<Album.Api.Models.Album> getAll() {
            return _context.Albums.ToList();
        }
    }
}
