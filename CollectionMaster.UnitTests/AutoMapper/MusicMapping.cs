using CollectionMaster.Api.AutoMapper;
using CollectionMaster.Api.Models;
using CollectionMaster.DataAccess.EF.Models;

using AutoMapper;
using FluentAssertions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CollectionMaster.UnitTests.AutoMapper
{
    [TestClass]
    public class MusicMapping
    {
        [TestInitialize]
        public void TestInit()
        {
        }

        [TestMethod]
        public void AutoMapper_Configuration_IsValid()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            config.AssertConfigurationIsValid();
        }

        [TestMethod]
        public void AutoMapper_MusicAlbum_To_Album_Mapping_IsValid()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            
            var mapper = config.CreateMapper();

            var expected = new Album
            {
                AlbumId = 101,
                Description = "Description",
                Logo = "Logo",
                Singer = "Singer",
                Name = "Title",
                Type = DataAccess.EF.Models.Enums.AlbumType.Cassette,
                Year = 2020
            };

            var source = new MusicAlbum
            {
                Id = 101,
                Description = "Description",
                Logo = "Logo",
                Singer = "Singer",
                Title = "Title",
                Type = 1,
                Year = 2020
            };

            var destination = mapper.Map<Album>(source);

            destination.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public void AutoMapper_Album_To_MusicAlbum_Mapping_IsValid()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });

            var mapper = config.CreateMapper();

            var expected = new MusicAlbum
            {
                Id = 101,
                Description = "Description",
                Logo = "Logo",
                Singer = "Singer",
                Title = "Title",
                Type = 1,
                Year = 2020
            };

            var source = new Album
            {
                AlbumId = 101,
                Description = "Description",
                Logo = "Logo",
                Singer = "Singer",
                Name = "Title",
                Type = DataAccess.EF.Models.Enums.AlbumType.Cassette,
                Year = 2020
            };

            var destination = mapper.Map<MusicAlbum>(source);

            destination.Should().BeEquivalentTo(expected);
        }
    }
}
