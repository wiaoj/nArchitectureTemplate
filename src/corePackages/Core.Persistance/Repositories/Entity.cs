namespace Core.Persistence.Repositories;

public abstract class BaseEntity {
    public Guid Id { get; set; }
    public virtual DateTime CreatedDate { get; set; }
    public virtual DateTime UpdatedDate { get; set; }

    public BaseEntity() { }

    public BaseEntity(Guid id) : this() {
        Id = id;
    }
}