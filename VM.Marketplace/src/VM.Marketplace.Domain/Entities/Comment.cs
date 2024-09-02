namespace VM.Marketplace.Domain.Entities;

public class Comment : Entity
{

    public string Text { get; private set; }
    public Guid ProductId { get; private set; }
    public string UserName { get; private set; }
    public string UserEmail { get; private set; }
    public string UserPhoneNumber { get; private set; }
    public DateTime Date { get; private set; }


    public Comment(string text, Guid productId, string userName, string userEmail, string userPhoneNumber)
    {
        Text = text;
        ProductId = productId;
        UserName = userName;
        UserEmail = userEmail;
        UserPhoneNumber = userPhoneNumber;
        Date = DateTime.UtcNow;
    }

    //For MongoDb Rel.
    public Comment() { }
}