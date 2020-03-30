using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Vokabel
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Dictionary dictionary = new Dictionary();
        CurrentQuestions currentQuestions;
        Button[] buttons = new Button[4];
        LinearGradientBrush defaultButtonBrush = new LinearGradientBrush();
        public MainWindow()
        {
            InitializeComponent();
            fillWindow();
            defaultButtonBrush = (LinearGradientBrush) btn_Answer_1.Background;
            buttons[0] = btn_Answer_1;
            buttons[1] = btn_Answer_2;
            buttons[2] = btn_Answer_3;
            buttons[3] = btn_Answer_4;
        }

        private void Btn_Answer_1_Click(object sender, RoutedEventArgs e)
        {
            check(dictionary.IsCorrectAnswer(txbl_Question.Text, ((Button)sender).Content.ToString()), (Button) sender);
        }

        private void Btn_Answer_4_Click(object sender, RoutedEventArgs e)
        {
            check(dictionary.IsCorrectAnswer(txbl_Question.Text, ((Button)sender).Content.ToString()), (Button)sender);
        }

        private void Btn_Answer_2_Click(object sender, RoutedEventArgs e)
        {
            check(dictionary.IsCorrectAnswer(txbl_Question.Text, ((Button)sender).Content.ToString()), (Button)sender);
        }

        private void Btn_Answer_3_Click(object sender, RoutedEventArgs e)
        {
            check(dictionary.IsCorrectAnswer(txbl_Question.Text, ((Button)sender).Content.ToString()), (Button)sender);
        }

        private void Button_Next_Click(object sender, RoutedEventArgs e)
        {
            fillWindow();
            btn_Answer_1.Click += Btn_Answer_1_Click;
            btn_Answer_2.Click += Btn_Answer_2_Click;
            btn_Answer_3.Click += Btn_Answer_3_Click;
            btn_Answer_4.Click += Btn_Answer_4_Click;

            btn_Answer_1.Background = defaultButtonBrush;
            btn_Answer_2.Background = defaultButtonBrush;
            btn_Answer_3.Background = defaultButtonBrush;
            btn_Answer_4.Background = defaultButtonBrush;

            btn_Answer_1.Cursor = System.Windows.Input.Cursors.Hand;
            btn_Answer_2.Cursor = System.Windows.Input.Cursors.Hand;
            btn_Answer_3.Cursor = System.Windows.Input.Cursors.Hand;
            btn_Answer_4.Cursor = System.Windows.Input.Cursors.Hand;

            lbl_Richtige_Antwort.Content = "";
            lbl_User_Antwort.Content = "";
            btn_Weiter.Visibility = Visibility.Hidden;

        }
        private void fillLabels(Button button)
        {
            lbl_Richtige_Antwort.Content = currentQuestions.answers[currentQuestions.correctID];
            lbl_User_Antwort.Content = button.Content;
        }
        private void fillWindow()
        {
            currentQuestions = dictionary.GetNext();
            btn_Answer_1.Content = currentQuestions.answers[0];
            btn_Answer_2.Content = currentQuestions.answers[1];
            btn_Answer_3.Content = currentQuestions.answers[2];
            btn_Answer_4.Content = currentQuestions.answers[3];
            txbl_Question.Text = currentQuestions.question;
        }
        private void check( bool check, Button sender) {

            if (!check)
            {
                sender.Background = Brushes.Red;
            }
            fillLabels(sender);
            buttons[currentQuestions.correctID].Background = Brushes.Green;
            btn_Weiter.Visibility = Visibility.Visible;
            btn_Answer_1.Click -= Btn_Answer_1_Click;
            btn_Answer_2.Click -= Btn_Answer_2_Click;
            btn_Answer_3.Click -= Btn_Answer_3_Click;
            btn_Answer_4.Click -= Btn_Answer_4_Click;

            btn_Answer_1.Cursor = System.Windows.Input.Cursors.Arrow;
            btn_Answer_2.Cursor = System.Windows.Input.Cursors.Arrow;
            btn_Answer_3.Cursor = System.Windows.Input.Cursors.Arrow;
            btn_Answer_4.Cursor = System.Windows.Input.Cursors.Arrow;

        }

    }
}
