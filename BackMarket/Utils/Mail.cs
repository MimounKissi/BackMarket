using System.Net.Pop3;

namespace BackMarket.Utils
{
    public class Mail
    {
        public bool IsReceiveMail(string _typeMail)
        {

            int i = 0; 

            var client = new Pop3Client();
            client.Connect("pop.gmail.com", 995, true);
            client.SendAuthUserPass("backmarket.test@gmail.com", "Kissi93190");
            var count = client.GetEmailCount();
            Pop3Message message;

            bool IsReceiveMail = false;

            for (i = 0; i < count; i++)
            {
                message = client.GetEmail(count);

                if (message.From == "Greg de Back Market <test_hi@backmarket.fr>" && message.BodyText.Contains(_typeMail))
                {
                    IsReceiveMail = true;
                    break;
                }
            }

            return IsReceiveMail; 
        }

    }
}
