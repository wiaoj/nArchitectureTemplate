namespace Core.Persistence.Repositories;

public abstract class BaseEntity {
    public Guid Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }

    public BaseEntity() { }

    public BaseEntity(Guid id) : this() {
        Id = id;
    }
}