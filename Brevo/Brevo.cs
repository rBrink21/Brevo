using System.Diagnostics;
using Newtonsoft.Json.Linq;
using sib_api_v3_sdk.Api;
using sib_api_v3_sdk.Client;
using sib_api_v3_sdk.Model;
using showcase;


namespace showcase;



public class Brevo
{
    // MOCK URL
    const string base_form_url = "forms.google.com/form/form-";
    private const string api_key = "";
    public static void SendEmail(string formId, List<Database.Recipient> recipients)
    {
        Configuration.Default.ApiKey.Add("api-key", api_key);
        var apiInstance = new TransactionalEmailsApi();

        SendSmtpEmail email = createBaseEmail("Reaching out to you about urgent matters!",recipients);
        
        email.HtmlContent = "<html><body><h1>We have something really urgent for you to click on!" +
                            "</h1><a href={{form-link}}>Permission slip</a></body></html>";

        JObject parameters = new JObject();
        parameters.Add("form-link", (base_form_url + formId));
        email.Params = parameters;
        
        CreateSmtpEmail result = apiInstance.SendTransacEmail(email);
    }


    private static SendSmtpEmail createBaseEmail(string subject, List<Database.Recipient> recipients)
    {
        SendSmtpEmail email = new SendSmtpEmail();
        email.Sender = new SendSmtpEmailSender("Roy", "brinkrrr@gmail.com");
        email.Subject = subject;

        List<SendSmtpEmailTo> recievers = new List<SendSmtpEmailTo>();
        foreach (Database.Recipient recipient in recipients)
        {
            recievers.Add(new SendSmtpEmailTo(recipient.email,recipient.firstName + " "+ recipient.lastName));
        }

        email.To = recievers;
        return email;
    }
}