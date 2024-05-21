using BusinessLayer;
using DataLayer;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeedingLayer
{
    public static class SeedManager
    {

        public static async Task CreateUsersAsync()
        {
            MedicalDbContext dbContext = UserManagerHelper.GetMedicalDbContext();

            UserManager<User> userManager = UserManagerHelper.GetUserManager();
            User u1 = new User
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = "Admin",
                SecondName = "Adminov",
                LastName = "Adminovski",
                Birthdate = new DateTime(2000, 2, 8),
                PhoneNumber = "0886624060",
                UserName = "Admin",
                Email = "adminadminov@abv.bg",
                Role = Role.Administrator,
                NormalizedUserName = "ADMIN",
                NormalizedEmail = "ADMINADMINOV@ABV.BG"
            };

            dbContext.Users.Add(u1);
            dbContext.SaveChanges();

            await userManager.AddPasswordAsync(u1, "Admin123");

            User u2 =
           new Patient
           {
               Id = Guid.NewGuid().ToString(),
               FirstName = "Peter",
               SecondName = "Vulkov",
               LastName = "Zidarov",
               Birthdate = new DateTime(2005, 5, 13),
               PhoneNumber = "088563424",
               UserName = "Patient",
               Email = "patientpatientov@abv.bg",
               Role = Role.Patient,
               NormalizedUserName = "PATIENT",
               NormalizedEmail = "PATIENTPATIENTOV@ABV.BG"
           };

            dbContext.Users.Add(u2);
            dbContext.SaveChanges();

            await userManager.AddPasswordAsync(u2, "654321");


            User u3 =
            new Doctor
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = "Doctor",
                SecondName = "Doctorov",
                LastName = "Doctorovski",
                Birthdate = new DateTime(1996, 1, 24),
                PhoneNumber = "088359223",
                UserName = "Doctor",
                Email = "doctordoctorov@abv.bg",
                Role = Role.Doctor,
                NormalizedUserName = "DOCTOR",
                NormalizedEmail = "DOCTORDOCTOROV@ABV.BG"
            };

            dbContext.Users.Add(u3);
            dbContext.SaveChanges();

            await userManager.AddPasswordAsync(u3, "HelloDoc123");

            User u4 =
           new Doctor
           {
               Id = Guid.NewGuid().ToString(),
               FirstName = "Specialist",
               SecondName = "Specialistov",
               LastName = "Specialistovski",
               Birthdate = new DateTime(2001, 9, 13),
               PhoneNumber = "0886623941",
               UserName = "Specialist",
               Email = "specialistspecialistov@abv.bg",
               Role = Role.LabSpecialist,
               NormalizedUserName = "SPECIALIST",
               NormalizedEmail = "SPECIALISTSPECIALISTOV@ABV.BG"
           };

            dbContext.Users.Add(u4);
            dbContext.SaveChanges();

            await userManager.AddPasswordAsync(u4, "HelloSpec123");

        }


    }
}
