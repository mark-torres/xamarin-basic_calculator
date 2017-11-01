using System.Diagnostics;
using System.Collections.Generic;
using System.Text.RegularExpressions;

using Xamarin.Forms;


namespace BasicCalculator
{
	public partial class BasicCalculator : ContentView
	{
		readonly Regex reBasicMath = new Regex(@"^(?:\d+(?:\.\d+)?)(?:[-+*/](?:\d+(?:\.\d+)?))*$");

		string expressionDisplayed;
		string expression;

		public double Result;

		public BasicCalculator()
		{
			InitializeComponent();

			expressionDisplayed = "";
		}

		double EvaluateExpression()
		{
			return 0;
		}

		void BtnValue_Clicked(object sender, System.EventArgs e)
		{
			var button = sender as Button;
			if (button != null) {
				expression = expression + button.Text;
				DisplayExpression();
			}
		}

		void BtnAdd_Clicked(object sender, System.EventArgs e)
		{
			expression = expression + "+";
			DisplayExpression();
		}

		void BtnSubtract_Clicked(object sender, System.EventArgs e)
		{
			expression = expression + "-";
			DisplayExpression();
		}

		void BtnMultiply_Clicked(object sender, System.EventArgs e)
		{
			expression = expression + "*";
			DisplayExpression();
		}

		void BtnDivide_Clicked(object sender, System.EventArgs e)
		{
			expression = expression + "/";
			DisplayExpression();
		}

		void BtnEquals_Clicked(object sender, System.EventArgs e)
		{
			bool validExpression = reBasicMath.IsMatch(expression);
			// validate expression
			if(!validExpression) {
				lblError.Text = "ERROR";
			} else {
				lblError.Text = " ";
				// evaluate the expression
				SimpleExpressionEvaluator evaluator = new SimpleExpressionEvaluator(expression);
				Result = evaluator.Evaluate();
				lblResult.Text = Result.ToString();
			}
		}

		void BtnBackspace_Clicked(object sender, System.EventArgs e)
		{
			if(expression.Length > 0) {
				expression = expression.Remove(expression.Length - 1);
				DisplayExpression();
			}
		}

		void BtnClear_Clicked(object sender, System.EventArgs e)
		{
			expression = "";
			DisplayExpression();
			lblResult.Text = "";
		}

		void DisplayExpression()
		{
			expressionDisplayed = expression;
			if (expressionDisplayed.Length > 0) {
				// add padding to operators
				expressionDisplayed = expressionDisplayed.Replace("+"," + ");
				expressionDisplayed = expressionDisplayed.Replace("-"," - ");
				expressionDisplayed = expressionDisplayed.Replace("*"," * ");
				expressionDisplayed = expressionDisplayed.Replace("/"," / ");
			}
			lblExpression.Text = expressionDisplayed;
		}
	}
}
