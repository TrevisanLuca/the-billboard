namespace TheBillboard.API.Domain
{
    public abstract record DomainBase(int Id, DateTime? CreatedAt, DateTime? UpdatedAt);
}