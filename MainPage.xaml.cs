using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace NoBite
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            SetupTimer();

        }
        DispatcherTimer dispatcherTimer;
        DateTimeOffset startTime;



        private void SetupTimer()
        {
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 5);
            dispatcherTimer.Start();
        }

        private ToastContentBuilder builder;

        private void dispatcherTimer_Tick(object sender, object e)
        {
            ShowNotification();
        }

        private void ShowNotification()
        {

            if (builder == null)
            {

                builder = new ToastContentBuilder().AddArgument("action", "viewConversation")
                .AddArgument("conversationId", 9813)
                        .AddText("NICHT NÄGELBEISSEN")
                .AddText("AAAAAAAAAAAAAAAAAAAH!");
            }

            builder.Show();
        }

        private void Start(object sender, RoutedEventArgs e)
        {
            SetupTimer();
        }
        private void Stop(object sender, RoutedEventArgs e)
        {
            StopTimer();
        }

        private void StopTimer()
        {
            if (dispatcherTimer.IsEnabled) //DOESNT WORK
            {
                dispatcherTimer.Stop();  
            }
        }
    }
}
