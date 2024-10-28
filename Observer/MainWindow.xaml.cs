using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Observer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Category> _categories = new List<Category>();
        private List<User> _subscribedUsers = new List<User>();
        private List<Category> SubscribedCategories = new List<Category>();

        private ObservableCollection<Ad> AllAds = new ObservableCollection<Ad>();
        private ObservableCollection<Ad> DisplayedAds = new ObservableCollection<Ad>();

        public MainWindow()
        {
            InitializeComponent();
            LoadCategories();

            this.DataContext = this;

            AdListView.ItemsSource = DisplayedAds;
        }

        private void LoadCategories()
        {
            _categories.Add(new Category { CategoryName = "Электроника" });
            _categories.Add(new Category { CategoryName = "Недвижимость" });
            _categories.Add(new Category { CategoryName = "Работа" });
            CategoryListBox.ItemsSource = _categories;
        }

        private void SubscribeToCategory(Category category)
        {
            if (!SubscribedCategories.Contains(category))
            {
                SubscribedCategories.Add(category);
                UpdateDisplayedAds();
            }
        }

        private void CategoryListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CategoryListBox.SelectedItem is Category selectedCategory)
            {
                UpdateDisplayedAds();
            }
        }

        private void SubscribeButton_Click(object sender, RoutedEventArgs e)
        {
            if (CategoryListBox.SelectedItem is Category selectedCategory)
            {
                var user = new User { Name = "Пользователь" };
                selectedCategory.Subscribe(user);
                _subscribedUsers.Add(user);
                MessageBox.Show($"Вы подписались на категорию: {selectedCategory.CategoryName}");
            }
        }

        private void AddAdButton_Click(object sender, RoutedEventArgs e)
        {
            bool isValid = true;

            if (string.IsNullOrWhiteSpace(TitleTextBox.Text) || TitleTextBox.Text == "Заголовок")
            {
                TitleTextBox.BorderBrush = Brushes.Red;
                MessageBox.Show("Поле 'Заголовок' не может быть пустым.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                isValid = false;
            }
            else
            {
                TitleTextBox.ClearValue(BorderBrushProperty);
            }

            if (string.IsNullOrWhiteSpace(DescriptionTextBox.Text) || DescriptionTextBox.Text == "Описание")
            {
                DescriptionTextBox.BorderBrush = Brushes.Red;
                MessageBox.Show("Поле 'Описание' не может быть пустым.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                isValid = false;
            }
            else
            {
                DescriptionTextBox.ClearValue(BorderBrushProperty);
            }

            if (isValid && CategoryListBox.SelectedItem is Category selectedCategory)
            {
                var ad = new Ad
                {
                    Title = TitleTextBox.Text,
                    Description = DescriptionTextBox.Text,
                    Category = selectedCategory.CategoryName
                };

                selectedCategory.AddAd(ad);
                AllAds.Add(ad);
                UpdateDisplayedAds();

                TitleTextBox.Text = "Заголовок";
                TitleTextBox.Foreground = Brushes.Gray;
                DescriptionTextBox.Text = "Описание";
                DescriptionTextBox.Foreground = Brushes.Gray;
            }
        }

        private void UpdateDisplayedAds()
        {
            DisplayedAds.Clear();

            foreach (var ad in AllAds.Where(ad => SubscribedCategories.Any(category => category.CategoryName == ad.Category)))
            {
                DisplayedAds.Add(ad);
            }

            foreach (var ad in AllAds.Where(ad => !SubscribedCategories.Any(category => category.CategoryName == ad.Category)))
            {
                DisplayedAds.Add(ad);
            }
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox.Text == "Заголовок" || textBox.Text == "Описание")
            {
                textBox.Text = string.Empty;
                textBox.Foreground = Brushes.Black;
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = textBox.Name == "TitleTextBox" ? "Заголовок" : "Описание";
                textBox.Foreground = Brushes.Gray;
            }
        }
    }
}