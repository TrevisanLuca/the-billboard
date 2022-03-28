namespace TheBillboard.API.Domain
{
    public abstract record DomainBase(int id, DateTime? CreatedAt, DateTime? UpdatedAt);
}
