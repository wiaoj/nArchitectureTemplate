using Core.Persistence.Repositories;

namespace Kodlama.io.Devs.Domain.Entities;

public class ProgrammingFramework : BaseEntity {
    public String Name { get; set; }
    public Double Version { get; set; }
    public String Tag { get; set; }

    public Guid ProgrammingLanguageId { get; set; }
    public virtual ProgrammingLanguage? ProgrammingLanguage { get; set; }

    public ProgrammingFramework() { }
    public ProgrammingFramework(Guid id, String name, Double version, String tag,Guid programmingLanguageId) : this() {
        Id = id;
        Name = name;
        Version = version;
        Tag = tag;
        ProgrammingLanguageId = programmingLanguageId;
    }
}