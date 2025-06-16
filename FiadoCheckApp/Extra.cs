using CommunityToolkit.Maui.Alerts;
using static System.Net.Mime.MediaTypeNames;
using System.Threading;
using CommunityToolkit.Maui.Core;

namespace FiadoCheckApp
{
    public class Extra
    {
        public static void ShowToast(string message)
        {
            string text = message;
            ToastDuration duration = ToastDuration.Long;
            double fontSize = 20;
            var toast = Toast.Make(text, duration, fontSize);
            toast.Show();
        }
    }
}