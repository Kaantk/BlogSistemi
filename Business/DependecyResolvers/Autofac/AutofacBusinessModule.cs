using Autofac;
using Business.Abstract;
using Business.Concrete;
using Core.Utilities.Security.Jwt;

namespace Business.DependecyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // Business katmanı servis kayıtları buraya eklenecek
            builder.RegisterType<AuthManager>().As<IAuthService>();
            //builder.RegisterType<RefreshTokenGenerator>().As<RefreshTokenHelper>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>().SingleInstance();
        }
    }
}
