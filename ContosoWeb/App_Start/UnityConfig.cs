using Contoso.Data;
using Contoso.Data.Repositories;
using Contoso.Data.Repositories.IRepositories;
using Contoso.Service;
using System;

using Unity;
using Unity.Injection;

namespace ContosoWeb {
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() => {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container) {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your type's mappings here.
            // container.RegisterType<IProductRepository, ProductRepository>();
            container.RegisterType<ContosoContext>(new InjectionFactory(c => new ContosoContext()));
            container.RegisterType<IPersonRepository, PersonRepository>();
            container.RegisterType<IStudentRepository, StudentRepository>();
            container.RegisterType<IDepartmentRepository, DepartmentRepository>();
            container.RegisterType<ICourseRepository, CourseRepository>();
            container.RegisterType<IEnrollmentRepository, EnrollmentRepository>();
            container.RegisterType<IInstructorRepository, InstructorRepository>();
            container.RegisterType<IRoleRepository, RoleRepository>();


            container.RegisterType<IPersonService, PersonService>();
            container.RegisterType<IStudentService, StudentService>();
            container.RegisterType<IDepartmentService, DepartmentService>();
            container.RegisterType<ICourseService, CourseService>();
            container.RegisterType<IEnrollmentService, EnrollmentService>();
            container.RegisterType<IInstructorService, InstructorService>();
            container.RegisterType<IRoleService, RoleService>();


            //container.RegisterType<IPersonRepository>(new InjectionFactory(c => new PersonRepository()));


        }
    }
}