namespace Didact.Models;

public partial class Profile
{
    public Guid AuthorId { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; }
    public string PreferredName { get; set; }
    public string Avatar { get; set; }
    public string AvatarAlt { get; set; }
    public string Bio { get; set; }
    public string Skills { get; set; }
    public string Interests { get; set; }
    public string Aspirations { get; set; }
    public string CollaborationPrefs { get; set; }
    public long WordCount { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime? ModifiedOn { get; set; }
    public DateTime? DeletedOn { get; set; }
}
