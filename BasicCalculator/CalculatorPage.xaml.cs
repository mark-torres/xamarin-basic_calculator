using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace BasicCalculator
{
	public partial class CalculatorPage : ContentPage
	{
		public CalculatorPage()
		{
			InitializeComponent();
		}

		async void Close_Clicked(object sender, System.EventArgs e)
		{
			await Navigation.PopModalAsync();
		}
	}
}
