namespace Match_Details_Management_System
{
    internal class Program
    {
            static void Main(string[] args)
            {
                MatchManagemnet matchManager = new MatchManagemnet();

                // Create a menu for different functionalities
                bool exit = false;
                while (!exit)
                {
                    Console.WriteLine("Menu:");
                    Console.WriteLine("1. Display All matches");
                    Console.WriteLine("2. Display Match By Id");
                    Console.WriteLine("3. Update Match Scores");
                    Console.WriteLine("4. Remove Match");
                    Console.WriteLine("5. Sort Matches");
                    Console.WriteLine("6. Filter Matches");
                    Console.WriteLine("7. View Statistics");
                    Console.WriteLine("8. Search Matches");
                    Console.WriteLine("9. Exit");
                    Console.Write("Enter your choice: ");

                    int choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                        
                        matchManager.DisplayMatches();
                        break;
                        case 2:
                                Console.WriteLine("enter Id ");
                                int id = int.Parse(Console.ReadLine());
                        matchManager.DisplayMatchesById(id);
                            break;
                        case 3:
                            // Update Match Score
                            matchManager.UpdateScores();
                            break;
                        case 4:
                            // Remove Match
                            matchManager.RemoveMatchById();
                            break;
                        case 5:
                        // Sort Matches
                        matchManager.SortMatches();
                        matchManager.DisplayMatches();
                        break;
                        case 6:
                        // Filter Matches
                        List<MatchDetails> filteredMatches = matchManager.FilterMatches();
                        Console.WriteLine("\nFiltered Matches:");
                        foreach (var match in filteredMatches)
                        {
                            Console.WriteLine($"Match ID: {match.MatchId}, Sport: {match.Sport}, Date: {match.MatchDateTime}, Location: {match.Location}, Teams: {match.HomeTeam} vs {match.AwayTeam}, Scores: {match.HomeTeamScore} - {match.AwayTeamScore}");
                        }
                        break;
                        case 7:
                        // View Statistics
                        Console.WriteLine("Calculate statistics for: (averagescore/highestscore/lowestscore)");
                        string statistic = Console.ReadLine();
                        matchManager.CalculateStatistics(statistic);
                        break;
                        case 8:
                        // Search Matches

                        List<MatchDetails> searchedMatches = matchManager.SearchMatches();
                        Console.WriteLine("\nSearched Matches:");
                        foreach (var match in searchedMatches)
                        {
                            Console.WriteLine($"Match ID: {match.MatchId}, Sport: {match.Sport}, Date: {match.MatchDateTime}, Location: {match.Location}, Teams: {match.HomeTeam} vs {match.AwayTeam}, Scores: {match.HomeTeamScore} - {match.AwayTeamScore}");
                        }
                        break;
                        case 9:
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
            }
        }
    }
