using Autofac;
using Autofac.Integration.Mvc;
using QA.Data.Infrastructure;
using QA.Data.Repositories;
using QA.Service;
using QA.Web.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace QA.Web.App_Start
{
    public class BootStrapper
    {
        public static void Run()
        {
            SetAutofacContainer();
            //Configure AutoMapper
            AutoMapperConfiguration.Configure();
        }

        private static void SetAutofacContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterType<DbFactory>().As<IDbFactory>().InstancePerRequest();

            // Repositories
            builder.RegisterAssemblyTypes(typeof(CityRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(ProfessorRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(QuestionRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(StudentRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(SubjectRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();
            // Services
            builder.RegisterAssemblyTypes(typeof(CityService).Assembly)
               .Where(t => t.Name.EndsWith("Service"))
               .AsImplementedInterfaces().InstancePerRequest();
            //builder.RegisterAssemblyTypes(typeof(ProfessorService).Assembly)
            //   .Where(t => t.Name.EndsWith("Service"))
            //   .AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(QuestionService).Assembly)
               .Where(t => t.Name.EndsWith("Service"))
               .AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(StudentService).Assembly)
               .Where(t => t.Name.EndsWith("Service"))
               .AsImplementedInterfaces().InstancePerRequest();
            //builder.RegisterAssemblyTypes(typeof(SubjectService).Assembly)
            //   .Where(t => t.Name.EndsWith("Service"))
            //   .AsImplementedInterfaces().InstancePerRequest();


            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
