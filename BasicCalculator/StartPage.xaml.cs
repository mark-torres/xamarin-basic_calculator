using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace BasicCalculator
{
	public partial class StartPage : ContentPage
	{
		public StartPage()
		{
			InitializeComponent();
		}

		async void UseCalculator_Clicked(object sender, System.EventArgs e)
		{
			await Navigation.PushModalAsync(new CalculatorPage());
		}
	}
}
