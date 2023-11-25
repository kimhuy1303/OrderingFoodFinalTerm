namespace OrderingFoodFinalTerm.Interface
{
    public interface IUserRepository
    {
        User GetUserById(int id);

        User GetUserByName(string name);

        bool CreateUser(UserDTO request);

        bool ValidatePassword(User user, string password);

        string CreateToken(User user);

    }
}
