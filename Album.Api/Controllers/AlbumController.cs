using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Album.Api.Models;
using Microsoft.AspNetCore.Http;

namespace Album.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlbumController : ControllerBase
    {
        public IAlbumService album;

        public AlbumController(IAlbumService _album)
        {
            album = _album;
        }

        /// <summary>
        /// Get an album
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET /Album/id
        ///     
        /// </remarks>
        /// <returns>Album</returns>
        /// <response code="201">Album</response>
        /// <response code="400">Invalid input</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult albumGet(int id)
        {
            var albumGet = album.getAlbum(id);
            return Ok(albumGet);
        }

        /// <summary>
        /// Get all albums
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET /Album
        ///     
        /// </remarks>
        /// <returns>Albums</returns>
        /// <response code="201">Albums</response>
        /// <response code="400">Invalid input</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult albumsGet()
        {
            var albumGet = album.getAll();
            return Ok(albumGet);
        }

        /// <summary>
        /// Create a new album
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST /Album
        ///     {
        ///         "id": 1,
        ///         "name": "Album 1",
        ///         "artist": "Artist 1",
        ///         "image-url": "myimageurl.com"
        ///     }
        ///     
        /// </remarks>
        /// <returns>Created new album succesfully</returns>
        /// <response code="201">Created new album succesfully</response>
        /// <response code="400">Invalid input</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult albumCreate([FromBody] Album.Api.Models.Album Album)
        {
            var albumGet = album.createAlbum(Album);
            return Ok(albumGet);
        }

        /// <summary>
        /// Delete an album
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     DELETE /Album/id
        ///     
        /// </remarks>
        /// <returns>Album deleted succesfully</returns>
        /// <response code="201">Album deleted succesfully</response>
        /// <response code="400">Invalid input</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult albumDelete(int id)
        {
            var albumGet = album.deleteAlbum(id);
            return Ok(albumGet);
        }

        /// <summary>
        /// Update an album
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     PUT /Album/id
        ///     {
        ///         "id": 1,
        ///         "name": "Album 1",
        ///         "artist": "Artist 1",
        ///         "image-url": "myimageurl.com"
        ///     }
        ///     
        /// </remarks>
        /// <returns>Album updated succesfully</returns>
        /// <response code="201">Album updated succesfully</response>
        /// <response code="400">Invalid input</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult albumUpdate(int id, [FromBody] Album.Api.Models.Album Album)
        {
            var albumGet = album.updateAlbum(id, Album);
            return Ok(albumGet);
        }
    }
}
