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
           Application.Current.MainPage.Navigation.PopModalAsync();
        }
        public void ExitApp(object sender, EventArgs e)
        {
            Application.Current.Quit();
        }
        public void OnBackToAbout(object sender, EventArgs args)
        {
            var name = Application.Current.StyleId;
            Application.Current.MainPage.Navigation.PushModalAsync(new NavigationPage(new About()), true);
        }
    }
    
}