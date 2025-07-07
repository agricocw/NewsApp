using NewsApp.Models;

namespace NewsApp.Pages;

public partial class NewsHomePage : ContentPage
{
    public List<Category> CategoryList = new List<Category>()
    {
        new Category(){Name="World", ImageUrl = "world.png"},
        new Category(){Name = "Nation" , ImageUrl="nation.png"},
        new Category(){Name = "Business" , ImageUrl="business.png"},
        new Category(){Name = "Technology" , ImageUrl="technology.png"},
        new Category(){Name = "Entertainment", ImageUrl = "entertainment.png"},
        new Category(){Name = "Sports" , ImageUrl="sports.png"},
        new Category(){Name = "Science", ImageUrl= "science.png"},
        new Category(){Name = "Health", ImageUrl="health.png"},
    };

    public NewsHomePage()
    {
        InitializeComponent();
        CvCategories.ItemsSource = CategoryList;
    }

    private async void OnCategorySelected(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Category selectedCategory)
        {
            await Navigation.PushAsync(new NewsListPage(selectedCategory.Name.ToLower()));
            CvCategories.SelectedItem = null;
        }
    }
}
