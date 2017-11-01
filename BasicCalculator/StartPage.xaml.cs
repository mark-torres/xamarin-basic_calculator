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

			double padding = 10;
			double topPadding = (Device.RuntimePlatform == Device.iOS) ? (padding + 15) : padding;
			Padding = new Thickness(padding, topPadding, padding, padding);
		}

		async void UseCalculator_Clicked(object sender, System.EventArgs e)
		{
			CalculatorPage calcPage = new CalculatorPage();
			await Navigation.PushModalAsync(calcPage);

			// set event handler
			calcPage.UseResult += OnUseResult;
		}

		// event handler

		private async void OnUseResult(object sender, Double result)
		{
			entryNumber.Text = result.ToString();
			// close calculator page
			await Navigation.PopModalAsync();
		}
	}
}
