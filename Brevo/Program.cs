using showcase;

string form_id = "12345";
Brevo.SendEmail(form_id, Database.GetAllRecipients());