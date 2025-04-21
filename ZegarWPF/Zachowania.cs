using Microsoft.Xaml.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ZegarWPF
{
    public class PrzesuwanieOkna : Behavior<Window>
    {
        protected override void OnAttached()
        {
            Window window = this.AssociatedObject;
            if (window != null)
            {
                window.MouseDown += window_MouseDown;
                window.MouseMove += window_MouseMove;
                window.MouseUp += window_MouseUp;
            }
        }

        private bool trwaPrzesuwanie = false;
        Point początkawaPozycjaKursora;

        private void window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Window window = (Window)sender;
            if (!trwaPrzesuwanie && e.LeftButton == MouseButtonState.Pressed)
            {
                trwaPrzesuwanie = true;
                początkawaPozycjaKursora = e.GetPosition(window);
            }
        }

        private void window_MouseMove(object sender, MouseEventArgs e)
        {
            Window window = (Window)sender;
            if (trwaPrzesuwanie)
            { 
                Point pozycjaKursora = e.GetPosition(window);
                Vector przesunięcie =  pozycjaKursora-początkawaPozycjaKursora;
                window.Left += przesunięcie.X;
                window.Top += przesunięcie.Y;
            }

        }

        private void window_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (trwaPrzesuwanie && e.LeftButton == System.Windows.Input.MouseButtonState.Released)
            {
                trwaPrzesuwanie = false;
            }
        }
    }
   

    
}
