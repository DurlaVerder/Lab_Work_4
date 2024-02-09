using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
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

namespace WPF_Lab_Work_4
{
    
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            comboBox_color.Visibility = Visibility.Hidden;
            comboBox_font.Visibility = Visibility.Hidden;
            comboBox_family.Visibility = Visibility.Hidden;
            Loaded += MainWindow_Loaded;
            Closed += MainWindow_Closed;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            File_Load();
        }

        private void MainWindow_Closed(object sender, EventArgs e)
        {
            File_Save();
        }

        private void File_Save()
        {
            string text = text_box.Text;

            
            string[] lines = text.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            
            string newText = string.Join(Environment.NewLine, lines);

           
            
            File.WriteAllText(@"WPF_Lab_Work_4", newText);
        }

        private void File_Load()
        {
            text_box.Text = File.ReadAllText(@"WPF_Lab_Work_4");
        }

        private void b_color_Click(object sender, RoutedEventArgs e)
        {
            if (comboBox_color.Visibility == Visibility.Visible) comboBox_color.Visibility= Visibility.Hidden;
            else comboBox_color.Visibility = Visibility.Visible;
        }

        private void b_font_Click(object sender, RoutedEventArgs e)
        {
            if (comboBox_font.Visibility == Visibility.Visible) comboBox_font.Visibility = Visibility.Hidden;
            else comboBox_font.Visibility = Visibility.Visible;
            if (comboBox_family.Visibility == Visibility.Visible) comboBox_family.Visibility = Visibility.Hidden;
            else comboBox_family.Visibility = Visibility.Visible;
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem selectedItem = comboBox_color.SelectedItem as ComboBoxItem;
   
            string colorName = selectedItem.Content.ToString();
            SolidColorBrush brush = new SolidColorBrush((Color)ColorConverter.ConvertFromString(colorName));
            menu.Background = brush;
            
        }

        private void FontSizeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem selectedItem = comboBox_font.SelectedItem as ComboBoxItem;
         
            double fontSize = double.Parse(selectedItem.Content.ToString());
            text_box.FontSize = fontSize;
            
        }

        private void FontFamilyComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem selectedItem = comboBox_family.SelectedItem as ComboBoxItem;
            
            string fontFamily = selectedItem.Content.ToString();
            text_box.FontFamily = new System.Windows.Media.FontFamily(fontFamily);
            
        }
    }
}
