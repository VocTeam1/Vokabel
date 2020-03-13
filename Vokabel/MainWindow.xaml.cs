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

namespace Vokabel
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Dictionary dictionary = new Dictionary();
        public MainWindow()
        {
            InitializeComponent();
          var asd =  dictionary.GetNext();
            
           
        }

        private void Btn_Antwort_1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_Antwort_4_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_Antwort_2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_Antwort_3_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Weiter_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
