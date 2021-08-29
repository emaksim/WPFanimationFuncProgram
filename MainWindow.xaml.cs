using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WPFanimationFuncProgram
{
    public partial class MainWindow : Window
    {
        private readonly LambdaCollection<Ellipse> Circles;
        private const int Count = 1000;

        public MainWindow()
        {
            InitializeComponent();

            Circles = new LambdaCollection<Ellipse>(Count)
                .WithProperty(WidthProperty, i => i * 1.1)
                .WithProperty(HeightProperty, i => i * 1.2)
                .WithProperty(Shape.FillProperty, i => new SolidColorBrush(GetColor()))
                .WithXy(
                    i => 100 + Math.Pow(i, 1.1) * Math.Sin(i / 4.0 * Math.PI),
                    i => 100 + Math.Pow(i, 1.1) * Math.Cos(i / 4.0 * Math.PI)
                );

            foreach (var circle in Circles)
            {
                MyCanvas.Children.Add(circle);
            }
        }

        private Color GetColor()
        {
            Random rnd = new Random();
            return Color.FromArgb((byte)rnd.Next(256), (byte)rnd.Next(256), (byte)rnd.Next(256), (byte)rnd.Next(256));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var lambdaDoubleAnimationCollection = new LambdaDoubleAnimationCollection(Circles.Count,
                i => 100 + Math.Pow(i, 1.1) * Math.Sin(i / 4.0 * Math.PI),
                i => 10.0 * i,
                i => new Duration(TimeSpan.FromSeconds(1)), i => j => 100.0 / j);

            lambdaDoubleAnimationCollection.BeginApplyAnimation(Circles.Cast<UIElement>().ToArray(), Canvas.LeftProperty);
        }
    }
}