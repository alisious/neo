using Caliburn.Micro;
using Caliburn.Micro.Extras;

namespace Kseo2.ViewModels
{
    public class ScreenOneViewModel :Screen
    {
        public IResult ShowDialog()
        {
            //MessageService ms = new MessageService();
            //ms.Show("This is dialog");
            return new MessengerResult("This is showed dialog.")
                .Caption("Message box!")
                .Buttons(MessageButton.OKCancel)
                .Image(MessageImage.Information);
        }
    }
}
