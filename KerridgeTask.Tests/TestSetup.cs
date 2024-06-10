using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KerridgeTask.Interface;
using KerridgeTask.Services;
using Microsoft.Maui;
using Microsoft.Maui.Hosting;

using Moq;
using Windows.Services.Maps;
namespace KerridgeTask.Tests
{
 
    public class TestSetup
    {
        static TestSetup()
        {
            var mauiApp = MauiProgram.CreateMauiApp();
            Application.Current = new Application();
            // Access services from MauiApp instance
         
           // MauiWinUIApplication.Current.Services = mauiApp.Services;

            MauiApp.ReferenceEquals(mauiApp, Application.Current);
           
        }


    
     /*   public static void Initialize(TestContext testContext)
        {
            var mauiApp = MauiProgram.CreateMauiApp();
            MauiWinUIApplication.Current = new MauiWinUIApplication.Current { Services = mauiApp.Services };
        }*/

    }
}
