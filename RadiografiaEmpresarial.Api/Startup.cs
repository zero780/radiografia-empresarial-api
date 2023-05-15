using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using RadiografiaEmpresarial.Core.Email;
using RadiografiaEmpresarial.Core.Interfaces;
using RadiografiaEmpresarial.Core.Services;
using RadiografiaEmpresarial.Infrastructure.Data;
using RadiografiaEmpresarial.Infrastructure.Filters;
using RadiografiaEmpresarial.Infrastructure.Interfaces;
using RadiografiaEmpresarial.Infrastructure.Repositories;
using RadiografiaEmpresarial.Infrastructure.Services;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace RadiografiaEmpresarial.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(c =>
            {
                //c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin());
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()); //con esto se arregla el problema de cors

            });

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //Exceptions
            services.AddControllers(op => {
                op.Filters.Add<GlobalExceptionFilter>();
            }).AddNewtonsoftJson(op => {
                op.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                op.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
            }).
            ConfigureApiBehaviorOptions(op => {
                op.SuppressModelStateInvalidFilter = true;
            });

            //ConexionDB
            services.AddDbContext<RadiografiaContext>(options =>
            {
                if (Configuration.GetValue<string>("DefaultConnection") == "SqlServer")
                    options.UseSqlServer(Configuration.GetConnectionString("ConexionSqlServer"));
                else
                    options.UseMySql(Configuration.GetConnectionString("ConexionMySQL"));
            });

            //Dependencias
            services.AddTransient<ISendMail, SendMail>();
            services.AddTransient<IRadiografiaService, RadiografiaService>();
            services.AddTransient<IGruposTrabajoService, GruposTrabajoService>();
            services.AddTransient<IOrganizacionService, OrganizacionService>();
            services.AddTransient<IUsuarioService, UsuarioService>();
            services.AddTransient<IOrganizacionService, OrganizacionService>();
            services.AddTransient<IExcelService, ExcelService>();
            services.AddTransient<ITokenService, TokenService>();
            services.AddTransient<IReportesService, ReportesService>();
            services.AddTransient<ISeccionRadiografia, SeccionRadiografia>();

            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddSingleton<IUriService>(prov =>
            {
                var accesor = prov.GetRequiredService<IHttpContextAccessor>();
                var request = accesor.HttpContext.Request;
                var absUri = string.Concat(request.Scheme, "://", request.Host.ToUriComponent());
                return new UriService(absUri);
            });

            services.AddSwaggerGen(doc => 
            {
                doc.SwaggerDoc("v1", new OpenApiInfo { Title = "Radiografía Empresarial Api", Version = "v1" });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                doc.IncludeXmlComments(xmlPath);

                doc.AddSecurityDefinition("bearer", new OpenApiSecurityScheme
                {
                    Description = "Standard Authorization header using the Bearer scheme. Example: \"bearer {token}\"",
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    BearerFormat = "JWT",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "bearer"
                });

                doc.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "bearer"
                            }

                        },
                        new string[] { }
                    }
                });
            });
            

            services.AddAuthentication(op =>
            {
                op.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                op.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer( op =>
            {
                op.TokenValidationParameters = new TokenValidationParameters {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["Authentication:Issuer"],
                    ValidAudience = Configuration["Authentication:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Authentication:SecretKey"]))
                };
            });

            //Filter y Validaciones
            services.AddMvc(op =>
            {
                op.Filters.Add<ValidationFilter>();
            }).AddFluentValidation(op => {
                op.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(options => options.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()); //con esto se arregla el problema de cors

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(op =>
            {
                op.SwaggerEndpoint("/swagger/v1/swagger.json", "Radiografía Empresarial Api");
                op.RoutePrefix = string.Empty;
            });

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
