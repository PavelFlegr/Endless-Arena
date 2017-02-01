using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EndlessArena.Views
{
    /// <summary>
    /// Pro použití tohoto vlastního ovládacího prvku v souboru XAML postupujte podle kroků 1a nebo 1b a pak 2.
    ///
    /// Krok 1a) Použití tohoto vlastního ovládacího prvku v XAML souboru, který už je v aktuálním projektu.
    /// Přidejte tento XmlNamespace atribut do kořenového elementu označovacího souboru, kde 
    /// bude použit:
    ///
    ///     xmlns:MyNamespace="clr-namespace:EndlessArena.Views"
    ///
    ///
    /// Krok 1b) Použití tohoto vlastního ovládacího prvku v souboru XAML, který je v jiném projektu.
    /// Přidejte tento XmlNamespace atribut do kořenového elementu označovacího souboru, kde 
    /// bude použit:
    ///
    ///     xmlns:MyNamespace="clr-namespace:EndlessArena.Views;assembly=EndlessArena.Views"
    ///
    /// Budete taky muset přidat odkaz na projekt z projektu, kde se nachází XAML soubor,
    /// ve kterém se soubor XAML nachází, a pro vyloučení chyb kompilace projekt znovu sestavit:
    ///
    ///     V Průzkumníku řešení klikněte pravým tlačítkem na cílový projekt a
    ///     v nabídce "Přidat odkaz"->"Projekty"->[Najděte a vyberte tento projekt]
    ///
    ///
    /// Krok 2)
    /// Pokračujte dále a použijte svůj ovládací prvek v souboru XAML.
    ///
    ///     <MyNamespace:CartesianCanvas/>
    ///
    /// </summary>
    public class CartesianCanvas : Panel
    {
        public static readonly DependencyProperty XProperty = DependencyProperty.RegisterAttached("X", typeof(double), typeof(CartesianCanvas), new FrameworkPropertyMetadata(0d, new PropertyChangedCallback(OnPositioningChanged)));

        private static void OnPositioningChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is UIElement)
            {
                var uie = (UIElement)d;
                if (VisualTreeHelper.GetParent(uie) is CartesianCanvas)
                {
                    var p = (CartesianCanvas)VisualTreeHelper.GetParent(uie);
                    p.InvalidateArrange();
                }
            }
        }

        public static void SetX(UIElement element, double value)
        {
            element.SetValue(XProperty, value);
            
        }
        public static double GetX(UIElement element)
        {
            return (double)element.GetValue(XProperty);
        }

        public static readonly DependencyProperty YProperty = DependencyProperty.RegisterAttached("Y", typeof(double), typeof(CartesianCanvas), new FrameworkPropertyMetadata(0d, new PropertyChangedCallback(OnPositioningChanged)));
        public static void SetY(UIElement element, double value)
        {
            element.SetValue(YProperty, value);
        }
        public static double GetY(UIElement element)
        {
            return (double)element.GetValue(YProperty);
        }

        static CartesianCanvas()
        {
            var metadata = new FrameworkPropertyMetadata(typeof(CartesianCanvas))
            {
                AffectsArrange = true,
                AffectsMeasure = true,
                AffectsRender = true,
            };
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CartesianCanvas), metadata);
        }

        protected override Size MeasureOverride(Size availableSize)
        {
            var panelSize = new Size();
            foreach(UIElement element in InternalChildren)
            {
                element.Measure(availableSize);
                panelSize.Height += element.DesiredSize.Height;
                panelSize.Width += element.DesiredSize.Width;
            }
            return availableSize;
        }

        protected override Size ArrangeOverride(Size arrangeSize)
        {
            Point middle = new Point(arrangeSize.Width / 2, arrangeSize.Height / 2);

            foreach (UIElement element in InternalChildren)
            {
                if (element == null)
                {
                    continue;
                }
                double x = GetX(element);
                double y = GetY(element);
                element.Arrange(new Rect(new Point(middle.X + x - element.DesiredSize.Width/2, middle.Y + y - element.DesiredSize.Height/2), element.DesiredSize));
            }
            return arrangeSize;
        }
    }
}
