using MailKit.Security;
using MimeKit.Text;
using MimeKit;

namespace BeanSceneApp.Services
{
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
            public string SendEmailConfirmation(string emailTo, String Lname, string userName, string password)
            {
                try
                {
                    var email = new MimeMessage();
                    email.From.Add(MailboxAddress.Parse("jeremyylshum@gmail.com"));
                    email.To.Add(MailboxAddress.Parse(emailTo));
                    email.Subject = "Registration Confirmation";
                    email.Body = new TextPart(TextFormat.Plain) { Text = "Dear " + Lname + ",\n" + "You have successfully register to the RetailWebApp. \n Your user name: " + userName + " and password: " + password + "\n Kind Regards\n RetailWebApp Service Team" };

                    // send email
                    using var smtp = new MailKit.Net.Smtp.SmtpClient();
                    //using Ethereal smtp
                    //smtp.Connect("smtp.ethereal.email", 587, SecureSocketOptions.StartTls);
                    //smtp.Authenticate("terry53@ethereal.email", "WRSWWnjgUtNntamxA9");

                    //using Gmail smtp
                    smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                    smtp.Authenticate("jeremyylshum@gmail.com", "termvlebmmtyuexh");
                    smtp.Send(email);
                    smtp.Disconnect(true);
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
                return "You will recieved an confirmation email with username and password";
            }
        }
    }
}