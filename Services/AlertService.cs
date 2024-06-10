using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KerridgeTask.Interface;
namespace KerridgeTask.Services
{
    public class AlertService : IAlertService
    {
        private readonly Page _page;

        public AlertService()
        {
            _page = Application.Current.MainPage; ;
        }

        public Task DisplayAlert(string title, string message, string cancel)
        {
            return _page.DisplayAlert(title, message, cancel);
        }
    }
}
