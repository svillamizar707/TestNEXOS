using System.Web.Http;
using BooksApi.Services;
using BooksApi.Data;
using BooksApi.DataAcces;
using BooksApi.Entities;
using BooksApi.Interfaces;
using BooksApi.Interfaces.Base;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
using System;
using SimpleInjector.Advanced;

[assembly: WebActivatorEx.PostApplicationStartMethod(typeof(BooksAPI.App_Start.SimpleInjectorWebApiInitializer), "Initialize")]

namespace BooksAPI.App_Start
{   
    public static class SimpleInjectorWebApiInitializer
    {
        /// <summary>Initialize the container and register it as Web API Dependency Resolver.</summary>
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
          

            InitializeContainer(container);

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            container.Register<BooksApiContext>(Lifestyle.Scoped);


            container.Verify();
            
            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);
        }
     
        private static void InitializeContainer(Container container)
        {
            container.Register<IBookRepository, BookRepository>(Lifestyle.Scoped);
            container.Register<IAuthorRepository, AuthorRepository>(Lifestyle.Scoped);
            container.Register<IBookService, BookService>(Lifestyle.Scoped);
            container.Register<IAuthorService, AuthorService>(Lifestyle.Scoped);
        }

        // inside ConfigureServices or Startup ctor
           

        // behavior
        internal class ApiControllersAsScopedBehavior : ILifestyleSelectionBehavior
        {
            public Lifestyle SelectLifestyle(Type implementationType) =>
                typeof(ApiController).IsAssignableFrom(implementationType)
                    ? Lifestyle.Scoped
                    : Lifestyle.Transient;
        }
    }
}