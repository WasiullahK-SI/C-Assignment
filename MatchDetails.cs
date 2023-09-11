using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Match_Details_Management_System
{
    internal class MatchDetails
    {
        public int MatchId { get; set; }
        public string Sport { get; set; }
        public DateTime MatchDateTime { get; set; }
        public string Location { get; set; }
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public int HomeTeamScore { get; set; }
        public int AwayTeamScore { get; set; }

        public MatchDetails(int matchId, string sport, DateTime matchDateTime, string location, string homeTeam, string awayTeam, int homeTeamScore, int awayTeamScore)
        {
            MatchId = matchId;
            Sport = sport;
            MatchDateTime = matchDateTime;
            Location = location;
            HomeTeam = homeTeam;
            AwayTeam = awayTeam;
            HomeTeamScore = homeTeamScore;
            AwayTeamScore = awayTeamScore;
        }

        public override string ToString()
        {
            {
                return $"MatchID: {MatchId}\n Sport: {Sport}\n MatchDateTime: {MatchDateTime}\n Location: {Location}\n HomeTeam: {HomeTeam}\n AwayTeam: {AwayTeam}\n HomeTeamScore: {HomeTeamScore}\n AwayTeamScore: {AwayTeamScore} ";
            }
        }
    }
}
