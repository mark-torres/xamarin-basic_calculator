using System.Diagnostics;
using System.Collections.Generic;
using System.Text.RegularExpressions;

using Xamarin.Forms;


namespace BasicCalculator
{
	public partial class BasicCalculator : ContentView
	{
		private readonly Regex reBasicMath = new Regex(@"^(?:\d+(?:\.\d+)?)(?:[-+*/](?:\d+(?:\.\d+)?))*$");

		private string expressionDisplayed;

		public BasicCalculator()
		{
			InitializeComponent();

			expressionDisplayed = "";
		}

		void BtnValue_Clicked(object sender, System.EventArgs e)
		{
			var button = sender as Button;
			if (button != null) {
				expressionDisplayed = expressionDisplayed + button.Text;
				DisplayExpression();
			}
		}

		void BtnAdd_Clicked(object sender, System.EventArgs e)
		{
			expressionDisplayed = expressionDisplayed + " + ";
			DisplayExpression();
		}

		void BtnSubtract_Clicked(object sender, System.EventArgs e)
		{
			expressionDisplayed = expressionDisplayed + " - ";
			DisplayExpression();
		}

		void BtnMultiply_Clicked(object sender, System.EventArgs e)
		{
			expressionDisplayed = expressionDisplayed + " * ";
			DisplayExpression();
		}

		void BtnDivide_Clicked(object sender, System.EventArgs e)
		{
			expressionDisplayed = expressionDisplayed + " / ";
			DisplayExpression();
		}

		void BtnEquals_Clicked(object sender, System.EventArgs e)
		{
			Debug.WriteLine("Equals");
		}

		void BtnBackspace_Clicked(object sender, System.EventArgs e)
		{
			Debug.WriteLine("Backspace");
		}

		void BtnClear_Clicked(object sender, System.EventArgs e)
		{
			expressionDisplayed = "";
			DisplayExpression();
		}

		void DisplayExpression()
		{
			lblExpression.Text = expressionDisplayed;
		}
	}
}
