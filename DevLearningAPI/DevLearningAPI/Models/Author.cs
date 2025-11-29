namespace DevLearningAPI.Models;

public class Author(string name, string title, string image, string bio, string url, string email, byte type)
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Name { get; private set; } = name;
    public string Title { get; private set; } = title;
    public string Image { get; private set; } = image;
    public string Bio { get; private set; } = bio;
    public string Url { get; private set; } = url;
    public string Email { get; private set; } = email;
    public byte Type { get; private set; } = type;

}
