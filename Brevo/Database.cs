namespace showcase;

public static class Database
{
    public struct Recipient
    {
        public string firstName;
        public string lastName;
        public int parentId;
        public string email;
    }

    public static List<Recipient> GetAllRecipients()
    {
        List<Recipient> recipients = new List<Recipient>();
        // Put your email adresses here.
        recipients.Add(new Recipient() { firstName = "John", lastName = "Doe", parentId = 1, email = "john.doe@example.com" });
        recipients.Add(new Recipient() { firstName = "Jane", lastName = "Smith", parentId = 2, email = "jane.smith@example.com" });
        recipients.Add(new Recipient() { firstName = "Alice", lastName = "Johnson", parentId = 3, email = "alice.johnson@example.com" });

        return recipients;
    }

}