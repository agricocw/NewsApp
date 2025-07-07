using NewsApp.Models;

namespace NewsApp.Pages
{
    public partial class NewsDetailPage : ContentPage
    {
        public NewsDetailPage(NewsArticle article)
        {
            InitializeComponent();

            ArticleImage.Source = article.Image;
            ArticleTitle.Text = article.Title;
            ArticleContent.Text = article.Content;
        }
    }
}
