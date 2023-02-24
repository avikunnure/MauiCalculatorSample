﻿using Calculator.Resources;
using System.Windows.Input;

namespace Calculator;

public partial class MainPage : ContentPage
{
    
    public MainPage()
    {
        InitializeComponent();
        OnClear(this, null);

    }

    string Expressions = string.Empty;
    void OnSelectNumber(object sender, EventArgs e)
    {
    
        Button button = (Button)sender;
        string pressed = button.Text;
        if (this.resultText.Text == "0")
        {
            this.resultText.Text = "";
        }

        Expressions += pressed;
        this.resultText.Text += pressed;
        
    }

    void OnSelectOperator(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        string pressed = button.Text;
        if (this.resultText.Text == "0")
        {
            this.resultText.Text = "";
        }
        Expressions += pressed;
        this.resultText.Text+=pressed;
    }


    void OnClear(object sender, EventArgs e)
    {
        this.resultText.Text = "0";
        Expressions = string.Empty;
    }

    void OnCalculate(object sender, EventArgs e)
    {
        this.CurrentCalculation.Text = Expressions;
        double result = Calculator.Calculate(Expressions);
        this.resultText.Text = result.ToTrimmedString("N0");
        Expressions = this.resultText.Text;
    }    

    void OnNegative(object sender, EventArgs e)
    {   
        Expressions += "*-1";
        OnCalculate(this, null);
    }

    void OnPercentage(object sender, EventArgs e)
    {
        Expressions += "*0.01";
        OnCalculate(this, null);

    }

    void OnSquarRoot(object sender, EventArgs e)
    {
        Expressions += "^";
        OnCalculate(this, null);
    }
    void OnModulus(object sender,EventArgs e)
    {
        Expressions += "%";
        Button button = (Button)sender;
        string pressed = button.Text;
        this.resultText.Text += pressed;
    }
    public void ExitApp(object sender,EventArgs e)
    {
        Application.Current.Quit();
    }
    public void OnBackToAbout(object sender, EventArgs args)
    {
        var name=Application.Current.StyleId;
        Application.Current.MainPage.Navigation.PushModalAsync( new NavigationPage( new About()), true);
    }

}
