
namespace EurosPicker
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//List<string> participants = ["Ross", "Kingsley", "Sam", "Jamie", "Calum", "Chris"];

			List<string> participants = ["John", "Amanda", "Jeremy", "Petunia", "Augustus", "Mike"];

			List<string> pot1 = ["Germany", "Portugal", "France", "Spain", "Belgium", "England"];
			List<string> pot2 = ["Hungary", "Turkey", "Romania", "Denmark", "Albania", "Austria"];
			List<string> pot3 = ["Netherlands", "Scotland", "Croatia", "Slovenia", "Slovakia", "Czech Republic"];
			List<string> pot4 = ["Italy", "Serbia", "Switzerland", "Poland", "Ukraine", "Georgia"];

			Dictionary<string, string> resultPot1 = PickPot(participants, pot1);
			Dictionary<string, string> resultPot2 = PickPot(participants, pot2);
			Dictionary<string, string> resultPot3 = PickPot(participants, pot3);
			Dictionary<string, string> resultPot4 = PickPot(participants, pot4);

			Dictionary<string, List<string>> fullResults = [];

			foreach (string participant in participants)
				fullResults.Add(participant, []);

			foreach (var hi in resultPot1)
				fullResults[hi.Key].Add(hi.Value);

			foreach (var hi in resultPot2)
				fullResults[hi.Key].Add(hi.Value);

			foreach (var hi in resultPot3)
				fullResults[hi.Key].Add(hi.Value);

			foreach (var hi in resultPot4)
				fullResults[hi.Key].Add(hi.Value);

			foreach (var person in fullResults)
			{
				Console.WriteLine($"Player: {person.Key}.");

				foreach (var team in person.Value)
				{
					Console.WriteLine($"Team: {team}");
				}

				Console.WriteLine($"---------------");
				Console.WriteLine($"---------------");
			}
		}

		private static Dictionary<string, string> PickPot(List<string> participants, List<string> pot1)
		{
			List<string> participantsLeft = [.. participants];
			List<string> teamsLeft = [.. pot1];

			Dictionary<string, string> results = [];

			Random rnd = new Random();

			// Loop through everyone and pick a team
			foreach (var participant in participants)
			{
				var person = rnd.Next(participantsLeft.Count);
				var team = rnd.Next(teamsLeft.Count);

				results.Add(participantsLeft[person], teamsLeft[team]);

				participantsLeft.Remove(participantsLeft[person]);
				teamsLeft.Remove(teamsLeft[team]);
			}

			return results;
		}
	}
}
