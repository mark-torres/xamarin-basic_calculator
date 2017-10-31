using System.Text.RegularExpressions;

namespace BasicCalculator
{
	public class SimpleExpressionEvaluator
	{
		string originalExpression;

		string[] basicExpression; // 

		string errorMessage;

		readonly Regex reBasicMathExpression = new Regex(@"^(?:\d+(?:\.\d+)?)(?:[-+*/](?:\d+(?:\.\d+)?))*$");

		public SimpleExpressionEvaluator(string expression)
		{
			errorMessage = "";
			// remove spaces
			originalExpression = expression.Replace(" ", string.Empty);
			// add operators padding for splitting
			var expr = originalExpression.Replace("+", " + ");
			expr = expr.Replace("-", " - ");
			expr = expr.Replace("*", " * ");
			expr = expr.Replace("/", " / ");
			basicExpression = expr.Split(' ');
		}

		// public methods - - - - - - - - - - - - - - - - - - - - - - - - - - - -

		public string GetLastError()
		{
			return errorMessage;
		}

		public double Evaluate()
		{
			double result = 0;
			if(!reBasicMathExpression.IsMatch(originalExpression)) {
				errorMessage = "The given expression is not valid";
			} else {
				// simplify * and /
				string[] simple = new string[ basicExpression.Length ];
				int i = 0, j = 0;
				while(i < basicExpression.Length) {
					if (basicExpression[i] == "*" || basicExpression[i] == "/") {
						// make operation
						double operand1 = double.Parse(simple[j - 1]);
						double operand2 = double.Parse(basicExpression[i + 1]);
						double res = (basicExpression[i] == "*") ? (operand1 * operand2) : (operand1 / operand2);
						simple[j - 1] = string.Format("{0}", res);
						i = i + 2;
					} else {
						simple[j] = basicExpression[i];
						i++;
						j++;
					}
				}
				// evaluate simple array
				i = 1;
				result = double.Parse(simple[0]);
				double operand = 0;
				while(i < simple.Length && simple[i] != null) {
					if (simple[i] == "+" || simple[i] == "-") {
						operand = double.Parse(simple[i + 1]);
						result = (simple[i] == "+") ? (result + operand) : (result - operand);
						i++;
					}
					i++;
				}
			}
			return result;
		}
	}
}
