using MailKit.Security;
using MimeKit.Text;
using MimeKit;

namespace BeanSceneApp.Services
{
    //("jeremyylshum@gmail.com", "termvlebmmtyuexh");
    public class EmailOuterService
    {
        public EmailInnerService Inner { get; set; }

        // Constructor to establish link between
        // instance of Outer_class to its
        // instance of the Inner_class
        public EmailOuterService()
        {
            this.Inner = new EmailInnerService(this);
        }
        public class EmailInnerService
        {
            private EmailOuterService obj;
            public EmailInnerService()
            {

            }
            public EmailInnerService(EmailOuterService outer)
            {
                this.obj = outer;
            }
            public string SendEmailConfirmation(string emailTo, String name, string userName, string password)
            {
                try
                {
                    var email = new MimeMessage();
                    email.From.Add(MailboxAddress.Parse("jeremyylshum@gmail.com"));
                    email.To.Add(MailboxAddress.Parse(emailTo));
                    email.Subject = "Registration Confirmation - Bean Scene App";
                    email.Body = new TextPart(TextFormat.Plain)
                    {
                        Text = $"Dear {name},\n\n" +
                               "Thank you for registering with Bean Scene App!\n\n" +
                              $"Your account details:\n" +
                              $"Username: {userName}\n" +
                              $"Password: {password}\n\n" +
                              "You can now log in to our system using these credentials.\n\n" +
                              "Kind Regards,\n" +
                              "The Bean Scene Team"
                    };

                    // send email
                    using var smtp = new MailKit.Net.Smtp.SmtpClient();
                    smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                    smtp.Authenticate("jeremyylshum@gmail.com", "termvlebmmtyuexh");
                    smtp.Send(email);
                    smtp.Disconnect(true);
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
                return "Email sent successfully";
            }
        }
    }
}