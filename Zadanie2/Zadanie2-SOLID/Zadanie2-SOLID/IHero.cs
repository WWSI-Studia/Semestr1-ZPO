namespace Zadanie2_SOLID
{
    interface IRole: IDescribable
    {
        string NameOfTheRole { get; }
        string ExecuteRoleAction();
    }
}
