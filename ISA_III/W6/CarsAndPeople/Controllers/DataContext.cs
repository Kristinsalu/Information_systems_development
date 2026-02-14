using CarsAndPeople.Models;
using Microsoft.EntityFrameworkCore;

namespace CarsAndPeople;

public class DataContext(DbContextOptions options) : DbContext(options) {

    public DbSet<Person> People { get; set; }
    public DbSet<Car> CarList { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Person>().HasData(
        new Person
        {
            Id = 1,                  
            Name = "John Doe",               
            Gender = Gender.Male,    
            DateOfBirth = new DateTime(1990, 12, 12),
            HairColor = HairColor.Blonde,
            Height = 188,
            Weight = 78
        },
        new Person
        {
            Id = 2,
            Name = "Jane Smith",
            Gender = Gender.Female,
            DateOfBirth = new DateTime(1980, 10, 12),
            HairColor = HairColor.Brunette,
            Height = 168,
            Weight = 67
        },
        new Person
        {
            Id = 3,
            Name = "Loe Smith",
            Gender = Gender.Female,
            DateOfBirth = new DateTime(1980, 10, 12),
            HairColor = HairColor.Brunette,
            Height = 168,
            Weight = 67
        });

        modelBuilder.Entity<Car>().HasData(
        new Car{
            Id =1,
            OwnerId = 2,
            Manufacturer = "Toyota",
            ModelName = "Corolla",
            Color= "black",
            ModelYear = 2002

        },
            new Car{
            Id =2,
            OwnerId = 1,
            Manufacturer = "BMW",
            ModelName = "F6",
            Color= "white",
            ModelYear = 2018

        },
           new Car{
            Id =3,
            OwnerId = 3,
            Manufacturer = "Audi",
            ModelName = "A6",
            Color= "red",
            ModelYear = 2019

        });
    }
}
