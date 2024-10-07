using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace abstract_fctory
{
    public partial class MainWindow : Window
    {
        private ShapeFactory factory;
        private Shape currentShape;

        public MainWindow()
        {
            InitializeComponent();
            colorComboBox.IsEnabled = false; 
        }

        private void ShapeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            canvas.Children.Clear();
            currentShape = null;

            if (shapeComboBox.SelectedIndex != -1)
            {
                colorComboBox.IsEnabled = true; 
            }
        }

        private void ColorComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (colorComboBox.SelectedIndex == -1) return; 

            string color = (colorComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();

            factory = color switch
            {
                "Красный" => new RedFactory(),
                "Синий" => new BlueFactory(),
                _ => factory
            };

            CreateShape();
        }

        private void CreateShape()
        {
            if (shapeComboBox.SelectedIndex == -1 || factory == null) return;

            string shapeType = (shapeComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            currentShape = shapeType switch
            {
                "Круг" => factory.CreateCircle(),
                "Квадрат" => factory.CreateSquare(),
                "Треугольник" => factory.CreateTriangle(),
                _ => null
            };

            if (currentShape != null)
            {
                Canvas.SetLeft(currentShape, 10);
                Canvas.SetTop(currentShape, 10);
                canvas.Children.Add(currentShape);
            }
        }

        public abstract class ShapeFactory
        {
            public abstract Shape CreateCircle();
            public abstract Shape CreateSquare();
            public abstract Shape CreateTriangle();
        }

        public class RedFactory : ShapeFactory
        {
            public override Shape CreateCircle() => CreateShape(new Ellipse(), Brushes.Red);
            public override Shape CreateSquare() => CreateShape(new Rectangle(), Brushes.Red);
            public override Shape CreateTriangle() => CreateTriangleShape(Brushes.Red);

            private Shape CreateShape(Shape shape, Brush brush)
            {
                shape.Width = 50;
                shape.Height = 50;
                shape.Fill = brush;
                return shape;
            }

            private Shape CreateTriangleShape(Brush brush)
            {
                var triangle = new Polygon
                {
                    Points = new PointCollection(new[] { new Point(25, 0), new Point(50, 50), new Point(0, 50) }),
                    Fill = brush
                };
                return triangle;
            }
        }

        public class BlueFactory : ShapeFactory
        {
            public override Shape CreateCircle() => CreateShape(new Ellipse(), Brushes.Blue);
            public override Shape CreateSquare() => CreateShape(new Rectangle(), Brushes.Blue);
            public override Shape CreateTriangle() => CreateTriangleShape(Brushes.Blue);

            private Shape CreateShape(Shape shape, Brush brush)
            {
                shape.Width = 50;
                shape.Height = 50;
                shape.Fill = brush;
                return shape;
            }

            private Shape CreateTriangleShape(Brush brush)
            {
                var triangle = new Polygon
                {
                    Points = new PointCollection(new[] { new Point(25, 0), new Point(50, 50), new Point(0, 50) }),
                    Fill = brush
                };
                return triangle;
            }
        }
    }
}
