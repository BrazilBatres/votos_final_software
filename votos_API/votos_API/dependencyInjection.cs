using Autofac;
using System.Data;
using votos_API.Business.impl;
using votos_API.Business.interfaces;
using votos_API.DataAccess.common;
using votos_API.DataAccess.interfaces;
using votos_API.DataAccess.repositories;

namespace votos_API
{
    public sealed class dependencyInjection : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            ////Relational datastore
            //builder.Register(c => new NpgsqlConnection(c.Resolve<IOptions<connectionStrings>>().Value.relationalDBConn))
            //    .InstancePerLifetimeScope()
            //    .As<IDbConnection>();
            ////Non-relational datastore
            //builder.Register(c => new MongoClient(c.Resolve<IOptions<connectionStrings>>().Value.mongoDbConn))
            //    .SingleInstance()
            //    .As<IMongoClient>();

            //builder.Register(c => c.Resolve<IMongoClient>().GetDatabase("chess"))
            //    .SingleInstance()
            //    .As<IMongoDatabase>();

            //#region "Low level relational DAL Infrastructure"
            //builder.Register(c => new clsConcurrency<TC>())
            //    .SingleInstance()
            //    .As<IDBConcurrencyHandler<TC>>();
            //builder.Register(c => new clsRelationalContext<TC>(c.Resolve<IDbConnection>(),
            //                                                   c.Resolve<ILogger<clsRelationalContext<TC>>>(),
            //                                                   c.Resolve<IDBConcurrencyHandler<TC>>()))
            //        .InstancePerLifetimeScope()
            //        .As<IRelationalContext<TC>>();
            //#endregion

            //#region "MongoDb Collections"
            //builder.Register(c => c.Resolve<IMongoClient>().GetDatabase("chess").GetCollection<clsGameEntityModel>("games"))
            //    .InstancePerDependency()
            //    .As<IMongoCollection<clsGameEntityModel>>();
            //#endregion

            //#region "Queries"
            //builder.Register(c => new qPlayer())
            //  .SingleInstance()
            //  .As<IQPlayer>();
            //#endregion

            #region "Relational Repositories"
            builder.Register(c => new clsVotoRepository(new EleccionesContext()))
            .InstancePerDependency()
          .As<IVotoRepository>();
            builder.Register(c => new clsCandidatoRepository(new EleccionesContext()))
            .InstancePerDependency()
          .As<ICandidatoRepository>();
            #endregion

            //#region "Non-Relational Repositories"
            //builder.Register(c => new clsGameRepository(c.Resolve<IMongoCollection<clsGameEntityModel>>()))
            //    .InstancePerDependency()
            //    .As<IGameRepository>();
            //#endregion

            //#region "Kaizen Entity Factories"
            //builder.Register<Func<IPlayerRepository<TI, TC>>>(delegate (IComponentContext context)
            //{
            //    IComponentContext cc = context.Resolve<IComponentContext>();
            //    return cc.Resolve<IPlayerRepository<TI, TC>>;
            //});
            //#endregion

            #region "Business classes"
            builder.Register(c => new clsVotoBusiness(c.Resolve<IVotoRepository>()))
                   .InstancePerDependency()
                   .As<IVotoBusiness>();
            builder.Register(c => new clsCandidatoBusiness(c.Resolve<ICandidatoRepository>()))
                   .InstancePerDependency()
                   .As<ICandidatoBusiness>();
            #endregion
        }
    }

}
