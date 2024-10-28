using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ChainOfResponsibility
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ProcessApplication_Click(object sender, RoutedEventArgs e)
        {
            var application = new LoanApplication
            {
                Creditworthy = ((ComboBoxItem)CreditworthyComboBox.SelectedItem).Content.ToString() == "True",
                DocumentsValid = ((ComboBoxItem)DocumentsValidComboBox.SelectedItem).Content.ToString() == "True"
            };

            var creditworthinessHandler = new CreditworthinessCheckHandler();
            var documentHandler = new DocumentVerificationHandler();

            creditworthinessHandler.SetNext(documentHandler);

            creditworthinessHandler.Handle(application);

            ResultTextBlock.Text = string.Join(Environment.NewLine, application.Results);
        }


    }
}