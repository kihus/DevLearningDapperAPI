using System;
using static System.Net.Mime.MediaTypeNames;

namespace DevLearningAPI.Models.Dtos.Author;

public class AuthorResponseDto
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string Name { get; init; } = string.Empty;
    public string Title { get; init; } = string.Empty;
    public string Image { get; init; } = string.Empty;
    public string Bio { get; init; } = string.Empty;
    public string Url { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;
    public byte Type { get; init; } = 1;
}
