using FitnessApp.Data.DBContext;
using FitnessApp.Data.Exceptions;
using FitnessApp.Domain.Contracts;
using FitnessApp.Domain.Entities;
using FitnessApp.Domain.Entitities;
using Microsoft.EntityFrameworkCore;

namespace FitnessApp.Data.Repository;

public class UserRepository : IUserRepository
{
    FitnessAppContext _context = new FitnessAppContext();

    public User GetUser(string userName)
    {
        // Task 9: Implement the method to load a user by his userName including his SportActivities
        // I suggess we load the user without activities first
        // method to be extended in the next branch to include sportactivities
        var user = _context.Users.FirstOrDefault(u => u.UserName == userName);
        if (user != null) return user;
        throw new UserNotFoundException($"User with Username: {userName} does not exist");
    }

    public User AddUser(User user)
    {
        // Task 4: Implement the method to add a user 
        _context.Users.Add(user);
        _context.SaveChanges();
        return user;
    }

    public void SaveOrUpdate()
    {
        _context.SaveChanges();
    }

    public User? GetUserById(int userId)
    {
        // Task 8: Implement the method to load a user by his is including his SportActivities
        // i suggest we implement retrieving a user first without including his sportactivities
        // we can extend this after successful login
        var user = _context.Users.FirstOrDefault(u => u.Id == userId);
        if (user != null) return user;
        return null;
    }
}