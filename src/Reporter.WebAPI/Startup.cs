using AutoMapper;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataHandler.Encoder;
using Microsoft.Owin.Security.Jwt;
using Microsoft.Owin.Security.OAuth;
using Owin;
using Reporter.Core;
using Reporter.Repository.Infrastructure.Mapper;
using Reporter.Service.Infrastructure.Mapper;
using Reporter.Service.Membership.Login;
using Reporter.WebAPI.Infrastructure.DependencyInjection;
using Reporter.WebAPI.Infrastructure.Mapper;
using Reporter.WebAPI.Infrastructure.Owin;
using Reporter.WebAPI.Infrastructure.Owin.IdentityModel;
using Reporter.WebAPI.Infrastructure.Owin.Providers;
using Reporter.WebAPI.Infrastructure.Security.OAuth;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Http;

[assembly: OwinStartup(typeof(Reporter.WebAPI.Startup))]

namespace Reporter.WebAPI
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var container = SimpleInjectorContainerFactory.Create();

            #region Container Setup

            container.RegisterPackages();

            container.RegisterSingleton<IOwinContextProvider>(new CallContextOwinContextProvider());

            #region Mapper

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<RepositoryProfile>();
                cfg.AddProfile<ServiceProfile>();
                cfg.AddProfile<WebAPIProfile>();
            });

            container.Register<IMapper>(() => config.CreateMapper(container.GetInstance));

            #endregion Mapper

            #region Web Api

            HttpConfiguration httpConfig = new HttpConfiguration();

            WebApiConfig.Register(httpConfig);

            container.RegisterWebApiControllers(httpConfig);

            httpConfig.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);

            #endregion Web Api

            container.Verify();

            #endregion Container Setup

            app.UseOwinContextExecutionScope(container);

            #region OAuth2

            ConfigureOAuthTokenGeneration(app, container);

            ConfigureOAuthTokenConsumption(app);

            #endregion OAuth2

            app.UseOwinContextProvider();

            app.UseCors(CorsOptions.AllowAll);

            app.UseWebApi(httpConfig);
        }

        private void ConfigureOAuthTokenGeneration(IAppBuilder app, Container container)
        {
            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                //For Dev enviroment only (on production should be AllowInsecureHttp = false)
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/login"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = new ReporterOAuthProvider(() => container.GetInstance<IQueryHandler<GetUserIdentityQuery, GetUserIdentityResult>>()),
                AccessTokenFormat = new ReporterJwtFormat("http://reporter.local", null)
            };

            // OAuth 2.0 Bearer Access Token Generation
            app.UseOAuthAuthorizationServer(OAuthServerOptions);
        }

        private void ConfigureOAuthTokenConsumption(IAppBuilder app)
        {
            var issuer = "http://reporter.local";
            string audienceId = ConfigurationManager.AppSettings["as:AudienceId"];
            byte[] audienceSecret = TextEncodings.Base64Url.Decode(ConfigurationManager.AppSettings["as:AudienceSecret"]);

            // Api controllers with an [Authorize] attribute will be validated with JWT
            app.UseJwtBearerAuthentication(
                new JwtBearerAuthenticationOptions
                {
                    AuthenticationMode = AuthenticationMode.Active,
                    AllowedAudiences = new[] { audienceId },
                    IssuerSecurityTokenProviders = new IIssuerSecurityTokenProvider[]
                    {
                        new SymmetricKeyIssuerSecurityTokenProvider(issuer, audienceSecret)
                    }
                });
        }
    }
}