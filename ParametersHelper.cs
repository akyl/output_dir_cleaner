using Utility.CommandLine;

namespace cleaner
{
	public static class ParametersHelper
	{
		public static bool? ParseStringToNullableBool(string input)
		{
			return input == null ? null : bool.Parse(input);
		}

		public static void ShowHelpAttributes(IEnumerable<ArgumentInfo> arguments)
		{
			Console.WriteLine("Long name | Description");
			Console.WriteLine("---------------------------------------------");
			foreach (var argument in arguments)
			{
				Console.WriteLine($"{argument.LongName} | {argument.HelpText}");
			}
		}
	}

}
