using Autofac;
using Business.Abstract;
using Business.Concrete;
using Core.Utilities.Security.Jwt;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

namespace Business.DependecyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // Business katmanı servis kayıtları buraya eklenecek

            builder.RegisterType<AdminManager>().As<IAdminService>();
            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<AccountManager>().As<IAccountService>();
            builder.RegisterType<HomeManager>().As<IHomeService>();

            builder.RegisterType<EfUserDal>().As<IUserDal>();

            builder.RegisterType<JwtHelper>().As<ITokenHelper>().SingleInstance();
        }
    }
}
