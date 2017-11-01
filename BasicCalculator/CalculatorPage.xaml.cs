using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace BasicCalculator
{
	public partial class CalculatorPage : ContentPage
	{
		// Event handler
		public EventHandler<Double> UseResult;

		public CalculatorPage()
		{
			InitializeComponent();
		}

		async void Close_Clicked(object sender, System.EventArgs e)
		{
			await Navigation.PopModalAsync();
		}

		void UseResult_Clicked(object sender, System.EventArgs e)
		{
			SetUseResult(calculator.Result);
		}

		// event trigger

		private void SetUseResult(Double result)
		{
			if(UseResult != null) {
				UseResult(this, result);
			}
		}
	}
}
