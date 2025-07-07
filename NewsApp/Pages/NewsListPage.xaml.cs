using NewsApp.Models;
using NewsApp.Services;

namespace NewsApp.Pages
{
    public partial class NewsListPage : ContentPage
    {
        private readonly string _category;
        private readonly NewsService _newsService = new NewsService();

        public string PageTitle { get; set; }

        public NewsListPage(string category)
        {
            InitializeComponent();
            _category = category;
            PageTitle = category;
            Title = category;
            LoadNews();
        }

        private async void LoadNews()
        {
            var articles = await _newsService.GetNewsByCategoryAsync(_category);
            ArticlesCollectionView.ItemsSource = articles;
        }

        private async void OnArticleSelected(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.FirstOrDefault() is NewsArticle selectedArticle)
            {
                await Navigation.PushAsync(new NewsDetailPage(selectedArticle));
                ArticlesCollectionView.SelectedItem = null; // Deselect
            }
        }
    }
}
