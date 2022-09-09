using Core.Persistence.Repositories;
using Core.Security.Enums;

namespace Kodlama.io.Devs.Domain.Entities;
public class ProgrammingLanguage : BaseEntity {
    public String Name { get; set; }

    public virtual ICollection<ProgrammingFramework> ProgrammingFrameworks { get; set; }
    public ProgrammingLanguage() { }
    public ProgrammingLanguage(Guid id, String name) : this() {
        Id = id;
        Name = name;
    }
}