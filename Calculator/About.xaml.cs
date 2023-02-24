using Calculator.Resources;

namespace Calculator
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class About : ContentPage
    {
        public About()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(About), typeof(About));
        }
        public void OnBackToCalculator(object sender,EventArgs args)
        {
           Application.Current.MainPage.Navigation.PopAsync();
        }
        public void ExitApp(object sender, EventArgs e)
        {
            Application.Current.Quit();
        }
       
        public void OnSetThemes(object sender, EventArgs args)
        {

            MenuFlyoutItem menu = (MenuFlyoutItem)sender;
            ICollection<ResourceDictionary> mergedDictionaries = Application.Current.Resources.MergedDictionaries;
            if (mergedDictionaries != null)
            {
                switch (menu.CommandParameter)
                {
                    case "1":
                        mergedDictionaries.Clear();
                        mergedDictionaries.Add(new LightTheme());
                        break;
                    case "2":
                        mergedDictionaries.Clear();
                        mergedDictionaries.Add(new PinkTheme());
                        break;
                    case "3":
                        mergedDictionaries.Clear();
                        mergedDictionaries.Add(new RedTheme());
                        break;
                    default:
                        mergedDictionaries.Clear();
                        mergedDictionaries.Add(new LightTheme());
                        break;
                }
            }
        }
    }
    
}