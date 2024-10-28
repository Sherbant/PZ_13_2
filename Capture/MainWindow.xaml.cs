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

namespace Capture
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TextHistory _history = new TextHistory();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnEncrypt_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtInput.Text))
            {
                MessageBox.Show("Поле пустое. Введите текст для шифрования.", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            _history.SaveState(new TextMemento(txtInput.Text));
            Console.WriteLine("Сохранено состояние: " + txtInput.Text);

            txtEncrypted.Text = Encrypt(txtInput.Text, 3);
        }

        private void btnDecrypt_Click(object sender, RoutedEventArgs e)
        {
            txtEncrypted.Text = Decrypt(txtEncrypted.Text, 3);
        }

        private void btnUndo_Click(object sender, RoutedEventArgs e)
        {
            var memento = _history.Undo();
            if (memento != null)
            {
                txtInput.Text = memento.TextState;
                Console.WriteLine("Отменено состояние: " + memento.TextState);
            }
            else
            {
                MessageBox.Show("Нет сохраненных состояний для отмены.", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnCompare_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtInput.Text) || string.IsNullOrWhiteSpace(txtEncrypted.Text))
            {
                MessageBox.Show("Одно из полей пустое. Введите текст и выполните шифрование перед сравнением.", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            MessageBox.Show(txtInput.Text == txtEncrypted.Text ? "Тексты совпадают" : "Тексты различаются");
        }

        private string Encrypt(string input, int shift)
        {
            return new string(input.Select(c => (char)(c + shift)).ToArray());
        }

        private string Decrypt(string input, int shift)
        {
            return new string(input.Select(c => (char)(c - shift)).ToArray());
        }
    }



}