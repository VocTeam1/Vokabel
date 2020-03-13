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
        Werte asd;
        public MainWindow()
        {
            InitializeComponent();
            fillWindow();



        }

        private void Btn_Antwort_1_Click(object sender, RoutedEventArgs e)
        {
            check( dictionary.IsCorrectAnswer(txbl_Fragewort.Text, ((Button)sender).Content.ToString()), (Button) sender);
        }

        private void Btn_Antwort_4_Click(object sender, RoutedEventArgs e)
        {
            check(dictionary.IsCorrectAnswer(txbl_Fragewort.Text, ((Button)sender).Content.ToString()), (Button)sender);
        }

        private void Btn_Antwort_2_Click(object sender, RoutedEventArgs e)
        {
            check(dictionary.IsCorrectAnswer(txbl_Fragewort.Text, ((Button)sender).Content.ToString()), (Button)sender);
        }

        private void Btn_Antwort_3_Click(object sender, RoutedEventArgs e)
        {
            check(dictionary.IsCorrectAnswer(txbl_Fragewort.Text, ((Button)sender).Content.ToString()), (Button)sender);
        }

        private void Button_Weiter_Click(object sender, RoutedEventArgs e)
        {
            fillWindow();
            btn_Antwort_1.Click += Btn_Antwort_1_Click;
            btn_Antwort_2.Click += Btn_Antwort_2_Click;
            btn_Antwort_3.Click += Btn_Antwort_3_Click;
            btn_Antwort_4.Click += Btn_Antwort_4_Click;
            btn_Weiter.Visibility = Visibility.Hidden;

        }
        private void fillLabels(Button button)
        {
            lbl_Richtige_Antwort.Content = asd.antworten[asd.correctI];
            lbl_User_Antwort.Content = button.Content;
        }
        private void fillWindow()
        {
            asd = dictionary.GetNext();
            btn_Antwort_1.Content = asd.antworten[0];
            btn_Antwort_2.Content = asd.antworten[1];
            btn_Antwort_3.Content = asd.antworten[2];
            btn_Antwort_4.Content = asd.antworten[3];
            txbl_Fragewort.Text = asd.frage;
        }
        private void check( bool check, Button sender) {
            if (check)
            {
                sender.Background = Brushes.Green;
            }
            else
            {
                sender.Background = Brushes.Red;
            }
            fillLabels(sender);

            btn_Weiter.Visibility = Visibility.Visible;
            btn_Antwort_1.Click -= Btn_Antwort_1_Click;
            btn_Antwort_2.Click -= Btn_Antwort_2_Click;
            btn_Antwort_3.Click -= Btn_Antwort_3_Click;
            btn_Antwort_4.Click -= Btn_Antwort_4_Click;

        }

    }
}
