namespace OrderingFoodFinalTerm.Interface
{
    public interface IUserRepository
    {
        User GetUserById(Guid id);
    }
}
