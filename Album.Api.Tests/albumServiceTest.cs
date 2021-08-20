using System;
using Xunit;
using System.Collections.Generic;
using Album.Api.Models;
using Moq;
using Microsoft.EntityFrameworkCore;

namespace Album.Api.Tests
{
    public class AlbumServiceTest
    {
        public AlbumService albumService;

        [Fact]
        public void getAlbum()
        {
            // Arrange
            const int id = 10;
            var optionsBuilder = new DbContextOptionsBuilder<SimpleModelsAndRelationsContext>();
            optionsBuilder.UseInMemoryDatabase(databaseName: "db");
            var inMemory = new SimpleModelsAndRelationsContext(optionsBuilder.Options);

            var albumTest = new Album.Api.Models.Album
            {
                Id = 10,
                Name = "Bob",
                Artist = "Joost",
                ImageUrl = "22312.com"
            };

            inMemory.Albums.Add(albumTest);
            inMemory.SaveChanges();

            albumService = new AlbumService(inMemory);

            // Act
            var album = albumService.getAlbum(id);

            // Assert
            Assert.NotNull(album);
            Assert.Equal(album.Name, "Bob");
            Assert.Equal(album.Artist, "Joost");
            Assert.Equal(album.ImageUrl, "22312.com");
        }

        [Fact]
        public void createAlbum()
        {
            // Arrange
            var optionsBuilder = new DbContextOptionsBuilder<SimpleModelsAndRelationsContext>();
            optionsBuilder.UseInMemoryDatabase(databaseName: "db");
            var inMemory = new SimpleModelsAndRelationsContext(optionsBuilder.Options);

            var albumTest = new Album.Api.Models.Album
            {
                Id = 150,
                Name = "John",
                Artist = "Doe",
                ImageUrl = "2212.com"
            };

            albumService = new AlbumService(inMemory);

            // Act
            var album = albumService.createAlbum(albumTest);

            // Assert
            Assert.NotNull(album);
            Assert.Equal(album, "Created new album succesfully");
        }

        [Fact]
        public void deleteAlbum()
        {
            // Arrange
            const int id = 20;
            var optionsBuilder = new DbContextOptionsBuilder<SimpleModelsAndRelationsContext>();
            optionsBuilder.UseInMemoryDatabase(databaseName: "db");
            var inMemory = new SimpleModelsAndRelationsContext(optionsBuilder.Options);

            var albumTest = new Album.Api.Models.Album
            {
                Id = 20,
                Name = "Bob",
                Artist = "Joost",
                ImageUrl = "22312.com"
            };

            inMemory.Albums.Add(albumTest);
            inMemory.SaveChanges();

            albumService = new AlbumService(inMemory);

            // Act
            var album = albumService.deleteAlbum(id);

            // Assert
            Assert.NotNull(album);
            Assert.Equal(album, "Album deleted succesfully");
        }

        [Fact]
        public void updateAlbum()
        {
            const int id = 30;
            // Arrange
            var optionsBuilder = new DbContextOptionsBuilder<SimpleModelsAndRelationsContext>();
            optionsBuilder.UseInMemoryDatabase(databaseName: "db");
            var inMemory = new SimpleModelsAndRelationsContext(optionsBuilder.Options);

            var albumTest = new Album.Api.Models.Album
            {
                Id = 30,
                Name = "Bob",
                Artist = "Joost",
                ImageUrl = "22312.com"
            };

            var albumTestUpdated = new Album.Api.Models.Album
            {
                Id = 12,
                Name = "John",
                Artist = "Doe",
                ImageUrl = "222.com"
            };

            inMemory.Albums.Add(albumTest);
            inMemory.SaveChanges();

            albumService = new AlbumService(inMemory);

            // Act
            var album = albumService.updateAlbum(id, albumTestUpdated);

            // Assert
            Assert.NotNull(album);
            Assert.Equal(album, "Album updated succesfully");
        }

        [Fact]
        public void getAlbums()
        {
            // Arrange
            var optionsBuilder = new DbContextOptionsBuilder<SimpleModelsAndRelationsContext>();
            optionsBuilder.UseInMemoryDatabase(databaseName: "db");
            var inMemory = new SimpleModelsAndRelationsContext(optionsBuilder.Options);

            var albumTest = new Album.Api.Models.Album
            {
                Id = 100,
                Name = "Bob",
                Artist = "Joost",
                ImageUrl = "22312.com"
            };

            var albumTestTwo = new Album.Api.Models.Album
            {
                Id = 110,
                Name = "John",
                Artist = "Doe",
                ImageUrl = "22312.com"
            };

            var albumTestThree = new Album.Api.Models.Album
            {
                Id = 120,
                Name = "Doe",
                Artist = "Bob",
                ImageUrl = "22312.com"
            };

            inMemory.Albums.Add(albumTest);
            inMemory.Albums.Add(albumTestTwo);
            inMemory.Albums.Add(albumTestThree);
            inMemory.SaveChanges();

            albumService = new AlbumService(inMemory);

            // Act
            var album = albumService.getAll();

            // Assert
            Assert.NotNull(album);
            Assert.Equal(album.Count, 6);
        }
    }
}