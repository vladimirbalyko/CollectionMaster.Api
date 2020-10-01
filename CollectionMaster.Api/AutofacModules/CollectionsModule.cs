using Autofac;

using CollectionMaster.Api.Services;

namespace CollectionMaster.Api.AutofacModules
{
    public class CollectionsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MusicService>().As<IMusicService>();
        }
    }
}
