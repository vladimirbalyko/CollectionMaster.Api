using Autofac;

using CollectionMaster.Api.Services;
using CollectionMaster.DataAccess.EF.Context;
using CollectionMaster.DataAccess.EF.Repository;

namespace CollectionMaster.Api.AutofacModules
{
    public class CollectionsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MusicService>().As<IMusicService>();
            builder.Register(c => new CollectionMasterRepository(new CollectionMasterContext()))
                .As<ICollectionMasterRepository>();
        }
    }
}
