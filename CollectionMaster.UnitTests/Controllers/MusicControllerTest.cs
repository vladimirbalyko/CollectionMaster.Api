using CollectionMaster.Api.Controllers;
using CollectionMaster.Api.Models;
using CollectionMaster.Api.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

namespace CollectionMaster.UnitTests.Controllers
{
    [TestClass]
    public class MusicControllerTest
    {
        private int _id;

        [TestInitialize]
        public void Initialize()
        {
            _id = 101;
        }

        [TestMethod]
        public void GetAlbums_Method_IsValid()
        {
            var mock = new Mock<IMusicService>();
            var musicAlbumsMock = new List<MusicAlbum>
            {
                new MusicAlbum
                {
                    Id = _id,
                    Description = "Description",
                    Logo = "Logo",
                    Singer = "Singer",
                    Title = "Title",
                    Type = 1,
                    Year = 2020
                }
            };

            mock.Setup(repo => repo.GetAlbums()).Returns(musicAlbumsMock);
            var controller = new MusicController(mock.Object);

            var expected = new List<MusicAlbum>
            {
                new MusicAlbum
                {
                    Id = _id,
                    Description = "Description",
                    Logo = "Logo",
                    Singer = "Singer",
                    Title = "Title",
                    Type = 1,
                    Year = 2020
                }
            };
            var result = controller.GetAlbums();
            result.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public void GetAlbum_Method_IsValid()
        {
            var mock = new Mock<IMusicService>();

            var musicAlbumMock = new MusicAlbum
            {
                Id = _id,
                Description = "Description",
                Logo = "Logo",
                Singer = "Singer",
                Title = "Title",
                Type = 1,
                Year = 2020
            };

            mock.Setup(repo => repo.GetAlbum(_id)).Returns(musicAlbumMock);
            var controller = new MusicController(mock.Object);

            var expected = new MusicAlbum
            {
                Id = _id,
                Description = "Description",
                Logo = "Logo",
                Singer = "Singer",
                Title = "Title",
                Type = 1,
                Year = 2020
            };

            var result = controller.GetAlbum(_id);
            result.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public void GetAlbums_Search_By_Template_Method_IsValid()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void Add_Method_Return_BadRequest()
        {
            var mock = new Mock<IMusicService>();
            var controller = new MusicController(mock.Object);

            MusicAlbum album = null;
            var result = controller.Add(album);
            Assert.IsInstanceOfType(result.Result, typeof(BadRequestResult));
        }

        [TestMethod]
        public void Add_Method_IsValid()
        {
            var mock = new Mock<IMusicService>();
            var controller = new MusicController(mock.Object);

            var musicAlbumMock = new MusicAlbum
            {
                Id = _id,
                Description = "Description",
                Logo = "Logo",
                Singer = "Singer",
                Title = "Title",
                Type = 1,
                Year = 2020
            };

            var expected = new MusicAlbum
            {
                Id = _id,
                Description = "Description",
                Logo = "Logo",
                Singer = "Singer",
                Title = "Title",
                Type = 1,
                Year = 2020
            };

            mock.Setup(repo => repo.Add(musicAlbumMock));
            var result = controller.Add(musicAlbumMock);
            Assert.IsInstanceOfType(result.Result, typeof(CreatedAtActionResult));
            
            var actual = (result.Result as CreatedAtActionResult).Value;
            actual.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public void Delete_Method_Return_NotFound()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void Delete_Method_IsValid()
        {
            throw new NotImplementedException();
        }
    }
}
