[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(ContosoAPI.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(ContosoAPI.App_Start.NinjectWebCommon), "Stop")]

namespace ContosoAPI.App_Start {
    using System;
    using System.Web;
    using System.Web.Http;
    using Contoso.Data.Repositories;
    using Contoso.Data.Repositories.IRepositories;
    using Contoso.Service;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Web.Common.WebHost;
    using Ninject.Web.WebApi;

    public static class NinjectWebCommon {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop() {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel() {
            var kernel = new StandardKernel();
            try {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(kernel);
                return kernel;


            }
            catch {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel) {

            // Repositories

            kernel.Bind<IStudentRepository>().To<StudentRepository>();
            kernel.Bind<IPersonRepository>().To<PersonRepository>();
            kernel.Bind<IDepartmentRepository>().To<DepartmentRepository>();
            kernel.Bind<IInstructorRepository>().To<InstructorRepository>();
            kernel.Bind<ICourseRepository>().To<CourseRepository>();
            kernel.Bind<IRoleRepository>().To<RoleRepository>();
            kernel.Bind<IEnrollmentRepository>().To<EnrollmentRepository>();

            // Services

            kernel.Bind<IStudentService>().To<StudentService>();
            kernel.Bind<IPersonService>().To<PersonService>();
            kernel.Bind<IDepartmentService>().To<DepartmentService>();
            kernel.Bind<IInstructorService>().To<InstructorService>();
            kernel.Bind<ICourseService>().To<CourseService>();
            kernel.Bind<IRoleService>().To<RoleService>();
            kernel.Bind<IEnrollmentService>().To<EnrollmentService>();



        }
    }
}
