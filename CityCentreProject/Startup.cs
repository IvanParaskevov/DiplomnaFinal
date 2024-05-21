﻿using BusinessLayer;
using CityCentreProject.Components;
using CityCentreProject.Components.Services;
using DataLayer;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Identity;
using MudBlazor;
using MudBlazor.Services;
using ServiceLayer;

namespace CityCentreProject
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddRazorComponents().AddInteractiveServerComponents();
            services.AddMudServices();

            services.AddMudServices(config =>
            {
                config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomLeft;

                config.SnackbarConfiguration.PreventDuplicates = false;
                config.SnackbarConfiguration.NewestOnTop = false;
                config.SnackbarConfiguration.ShowCloseIcon = true;
                config.SnackbarConfiguration.VisibleStateDuration = 10000;
                config.SnackbarConfiguration.HideTransitionDuration = 500;
                config.SnackbarConfiguration.ShowTransitionDuration = 500;
                config.SnackbarConfiguration.SnackbarVariant = Variant.Filled;
            });



            services.AddScoped<ProtectedSessionStorage>();
            services.AddScoped<AuthorizeView, AuthorizeView>();
            services.AddAuthenticationCore();

            services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
            services.AddScoped<StartLogin, StartLogin>();






            services.AddScoped<StateContainer<User>, StateContainer<User>>();
            services.AddScoped<StateContainer<DoctorAvailableHours>, StateContainer<DoctorAvailableHours>>();

            services.AddScoped<StateContainer<Doctor>, StateContainer<Doctor>>();
            services.AddScoped<StateContainer<Patient>, StateContainer<Patient>>();
            services.AddScoped<StateContainer<Appointment>, StateContainer<Appointment>>();
            services.AddScoped<StateContainer<PatientExamination>, StateContainer<PatientExamination>>();
            services.AddScoped<StateContainer<LabExamination>, StateContainer<LabExamination>>();



            services.AddScoped<IdentityManager, IdentityManager>();
            services.AddScoped<IdentityContext, IdentityContext>();

            services.AddScoped<AppointmentManager, AppointmentManager>();
            services.AddScoped<AppointmentContext, AppointmentContext>();

            services.AddScoped<LabExaminationManager, LabExaminationManager>();
            services.AddScoped<LabExaminationContext, LabExaminationContext>();

            services.AddScoped<PatientExaminationManager, PatientExaminationManager>();
            services.AddScoped<PatientExaminationContext, PatientExaminationContext>();

            services.AddScoped<DoctorManager, DoctorManager>();
            services.AddScoped<DoctorContext, DoctorContext>();

            services.AddScoped<PatientManager, PatientManager>();
            services.AddScoped<PatientContext, PatientContext>();

            services.AddScoped<DoctorAvailableHoursManager, DoctorAvailableHoursManager>();
            services.AddScoped<DoctorAvailableHoursContext, DoctorAvailableHoursContext>();

            services.AddScoped<MedicalDbContext, MedicalDbContext>();

            services.AddIdentity<User, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
            .AddEntityFrameworkStores<MedicalDbContext>()
            .AddSignInManager()
            .AddDefaultTokenProviders();



            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;


                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
                options.Lockout.MaxFailedAccessAttempts = 3;
                options.Lockout.AllowedForNewUsers = true;


                // User settings.
                options.User.AllowedUserNameCharacters =
                "абвгдежзийклмнопрстуфхцчшщьюяАБВГДЕЖЗИЙКЛМНОПРСТУФХЦЧШЩЬЮЯabcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = true;


                // Log in required.
                options.SignIn.RequireConfirmedAccount = false; // default
                options.SignIn.RequireConfirmedEmail = false; // default

            });

            services.ConfigureApplicationCookie(options =>
            {

                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(15);


                options.LoginPath = "/login";
                options.LogoutPath = "/logout";
                options.AccessDeniedPath = "/access-denied";
                options.SlidingExpiration = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }



            app.UseHttpsRedirection();
            app.UseStaticFiles();


            app.UseRouting();
            app.UseAntiforgery();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorComponents<App>()
                        .AddInteractiveServerRenderMode();
            });


        }
    }
}
