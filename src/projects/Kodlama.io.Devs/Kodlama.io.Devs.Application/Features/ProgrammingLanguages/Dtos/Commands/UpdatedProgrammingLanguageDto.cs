﻿namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Dtos.Commands;

public class UpdatedProgrammingLanguageDto {
    public Guid Id { get; set; }
    public String Name { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
}