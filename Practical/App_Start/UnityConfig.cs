using Practical.BizRepositories;
using Practical.Controllers;
using Practical.Models;
using System.Web.Mvc;
using Unity;
using Unity.Injection;
using Unity.Mvc5;

namespace Practical
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<AccountController>(new InjectionConstructor());
            container.RegisterType<ManageController>(new InjectionConstructor());
            container.RegisterType<ApplicationDbContext>();
            container.RegisterType<IBizRepositories<Student, int>, StudentRepository>();
            container.RegisterType<IBizRepositories<Course, int>, CourseRepository>();
            container.RegisterType<IBizRepositories<Trainer, int>, TrainerRepository>();


            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}