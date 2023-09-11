using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Match_Details_Management_System
{
    internal class MatchManagemnet
    {
        private List<MatchDetails> matches = new List<MatchDetails>()
        {
            new MatchDetails(1,"cricket",new DateTime(2001,01,03,09,23,12),"Mumbai","Mumbai Indians","GT",190,140),
            new MatchDetails(2,"cricket",new DateTime(2001,01,02,09,23,12),"Chennai","Csk","RCB",170,172),
            new MatchDetails(3,"Kabbaddi",new DateTime(2002,01,05,09,23,12),"Pune","Puneri Paltans","UMumba",40,45),
            new MatchDetails(4,"Baseball",new DateTime(2023,01,06,09,23,12),"New York","NYY","Astros",9,7),
            new MatchDetails(5,"TableTennis",new DateTime(2003,09,01,09,23,12),"China","chini","Indian",9,11),
            new MatchDetails(6,"Football",new DateTime(2004,01,12,09,23,12),"Spain","Real Madrid","Barcelona",3,3),

        };
        public void DisplayMatches()
        {
            foreach (MatchDetails match in matches)
            {
                Console.WriteLine(match);
            }
        }

        public void DisplayMatchesById(int id)
        {
            //Console.WriteLine("Enter the Match Id:");
           // id = Convert.ToInt32(Console.ReadLine());
            foreach (MatchDetails match in matches)
                if (id.Equals(match.MatchId))
                {
                    Console.WriteLine(match);
                }
        }

        public void UpdateScores()
        {
            Console.WriteLine("Enter the Match Id to Update");
           int id = Convert.ToInt32(Console.ReadLine());
            DisplayMatchesById(id);
            Console.WriteLine("Enter the new score of Home Team");
            int newHomeTeamScore = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the new score of Away Team");
            int newAwayTeamScore = Convert.ToInt32(Console.ReadLine());
            MatchDetails matchDetails = matches.FirstOrDefault(m => m.MatchId == id);
            if (matchDetails != null)
            {
                matchDetails.HomeTeamScore = newHomeTeamScore;
                matchDetails.AwayTeamScore = newAwayTeamScore;
            }
            else
            {
                Console.WriteLine("Match not found");
            }
            DisplayMatchesById(id);

        }

        public void RemoveMatchById()
        {
            Console.WriteLine("Enter the Match Id to Remove");
            int id = Convert.ToInt32(Console.ReadLine());
            MatchDetails matchDetails = matches.FirstOrDefault(m => m.MatchId == id);
            if (matchDetails != null)
            {
                matches.Remove(matchDetails);
            }
            else
            {
                Console.WriteLine("Match not found");
            }
        }

        public void SortMatches() { 
           Console.WriteLine("Sort by: (date/sport/location)");
            string sorty = Console.ReadLine();
           Console.WriteLine("Ascending? (true/false)");
            bool ascending = bool.Parse(Console.ReadLine());
        
            switch (sorty.ToLower())
            {
                case "date":
                    matches = ascending ? matches.OrderBy(m => m.MatchDateTime).ToList() : matches.OrderByDescending(m => m.MatchDateTime).ToList();
                    break;
                case "sport":
                    matches = ascending ? matches.OrderBy(m => m.Sport).ToList() : matches.OrderByDescending(m => m.Sport).ToList();
                    break;
                case "location":
                    matches = ascending ? matches.OrderBy(m => m.Location).ToList() : matches.OrderByDescending(m => m.Location).ToList();
                    break;
                default:
                    Console.WriteLine("Invalid sorting criteria.");
                    break;
            }
        }

       
        

        public List<MatchDetails> FilterMatches()
        {
            Console.WriteLine("Filter by: (sport/location/daterange)");
            string filterCriteria = Console.ReadLine();
            Console.WriteLine("Enter value: ");
            string value = Console.ReadLine();

            switch (filterCriteria.ToLower())
            {
                case "sport":
                    return matches.Where(m => m.Sport.Equals(value, StringComparison.OrdinalIgnoreCase)).ToList();
                case "location":
                    return matches.Where(m => m.Location.Equals(value, StringComparison.OrdinalIgnoreCase)).ToList();
                case "daterange":
                    DateTime startDate;
                    DateTime endDate;
                    if (DateTime.TryParse(value.Split('-')[0], out startDate) && DateTime.TryParse(value.Split('-')[1], out endDate))
                    {
                        return matches.Where(m => m.MatchDateTime >= startDate && m.MatchDateTime <= endDate).ToList();
                    }
                    else
                    {
                        Console.WriteLine("Invalid date range format. Use format 'yyyy-mm-dd - yyyy-mm-dd'.");
                    }
                    break;
                default:
                    Console.WriteLine("Invalid filtering criteria.");
                    break;
            }

            return new List<MatchDetails>();
        }

        public void CalculateStatistics(string criteria)
        {
            switch (criteria.ToLower())
            {
                case "averagescore":
                    double homeAvg = matches.Average(m => m.HomeTeamScore);
                    double awayAvg = matches.Average(m => m.AwayTeamScore);
                    Console.WriteLine($"Average Score - Home: {homeAvg}, Away: {awayAvg}");
                    break;
                case "highestscore":
                    int highestHomeScore = matches.Max(m => m.HomeTeamScore);
                    int highestAwayScore = matches.Max(m => m.AwayTeamScore);
                    Console.WriteLine($"Highest Score - Home: {highestHomeScore}, Away: {highestAwayScore}");
                    break;
                case "lowestscore":
                    int lowestHomeScore = matches.Min(m => m.HomeTeamScore);
                    int lowestAwayScore = matches.Min(m => m.AwayTeamScore);
                    Console.WriteLine($"Lowest Score - Home: {lowestHomeScore}, Away: {lowestAwayScore}");
                    break;
                default:
                    Console.WriteLine("Invalid statistics criteria.");
                    break;
            }
        }

        public List<MatchDetails> SearchMatches()
        {
            Console.WriteLine("Search for: ");
            string keyword = Console.ReadLine();
            return matches.Where(m =>
                m.Sport.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                m.HomeTeam.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                m.AwayTeam.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                m.Location.Contains(keyword, StringComparison.OrdinalIgnoreCase)
            ).ToList();
        }
        private bool IsValidMatch(MatchDetails match)
        {
            if (match.MatchId <= 0 || matches.Any(m => m.MatchId == match.MatchId))
                return false;

            if (string.IsNullOrWhiteSpace(match.Sports))
                return false;

            if (match.MatchDateTime <= DateTime.Now)
                return false;

            if (string.IsNullOrWhiteSpace(match.Location))
                return false;

            if (string.IsNullOrWhiteSpace(match.HomeTeam) || string.IsNullOrWhiteSpace(match.AwayTeam) || match.HomeTeam == match.AwayTeam)
                return false;

            if (match.HomeTeamScore < 0 || match.AwayTeamScore < 0)
                return false;

            return true;
        }
    }
}
