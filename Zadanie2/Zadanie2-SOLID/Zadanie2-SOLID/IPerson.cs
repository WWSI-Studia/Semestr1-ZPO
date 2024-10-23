namespace Zadanie2_SOLID
{
    interface IPerson: IDescribable
    {
        string Name { get; }
        string Gender { get; }
        string FatherName { get; }
        string MotherName { get; }
        IRole Role { get; set; }
        string Play();
        void ChangeRole(IRole role);
    }
}
