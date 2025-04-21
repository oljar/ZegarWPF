using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ZegarWPF
{

    public enum Wskazówka{Godzinowa, Minutowa, Sekundowa }
    class KonwerteryKątaWskazówki : IValueConverter
    {
        public Wskazówka Wskazówka { get; set; } = Wskazówka.Godzinowa;
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime dt = (DateTime)value;
            double wartość = 0;
            switch(Wskazówka)
            { 
                case Wskazówka.Godzinowa:
                    wartość = dt.Hour;
                    if (wartość > 12) wartość -= 12;
                    wartość += dt.Minute / 60.0;
                    wartość /= 12.0;
                    break;
                case Wskazówka.Minutowa:
                    wartość = dt.Minute;
                    wartość += dt.Second / 60.0;
                    wartość /= 60.0;
                    break;
                case Wskazówka.Sekundowa:
                    wartość = dt.Second;
                    wartość += dt.Millisecond / 1000.0;
                    wartość /= 60.0;
                    break;
            }
            wartość *= 360.0;
            return wartość;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
