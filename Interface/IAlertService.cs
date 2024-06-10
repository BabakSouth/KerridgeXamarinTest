using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KerridgeTask.Interface
{
    public interface IAlertService
    {
        Task DisplayAlert(string title, string message, string cancel);
    }

}
