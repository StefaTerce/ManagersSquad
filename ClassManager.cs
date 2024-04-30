using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ClassSquad
{
    public class Match
    {
        public int MatchId { get; set; }
        public DateTime MatchDate { get; set; }
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public string Status { get; set; }
        public string Result { get; set; }
        public string Venue { get; set; }  // Assuming venue details are available; otherwise, remove this as well

        public Match(int matchId, DateTime matchDate, string homeTeam, string awayTeam, string status, string result, string venue)
        {
            MatchId = matchId;
            MatchDate = matchDate;
            HomeTeam = homeTeam;
            AwayTeam = awayTeam;
            Status = status;
            Result = result;
            Venue = venue;
        }
    }

    public class MatchEnded : Match
    {
        public string Winner { get; set; }

        public MatchEnded(int matchId, DateTime matchDate, string homeTeam, string awayTeam, string result, string venue)
            : base(matchId, matchDate, homeTeam, awayTeam, "FINISHED", result, venue)
        {
            Winner = CalculateWinner(result);
        }

        public string CalculateWinner(string result)
        {
            string[] scores = result.Split('-');
            int homeScore = int.Parse(scores[0].Trim());
            int awayScore = int.Parse(scores[1].Trim());
            return homeScore > awayScore ? HomeTeam : homeScore == awayScore ? "Draw" : AwayTeam;
        }
    }


    public class MatchManager
    {
        private List<Match> matches;

        public MatchManager()
        {
            matches = new List<Match>();
        }
        public string Winner(int id)
        {
            Match match = ricercaPerId(id);
            if (match is MatchEnded endedMatch)
            {
                return endedMatch.Winner;
            }
            else
            {
                return "Match not ended yet";
            }
        }


        public void AddMatch(int matchId, DateTime matchDate, string homeTeam, string awayTeam, string status, string result, string venue)
        {
            Match match;
            if (status == "FINISHED")
            {
                match = new MatchEnded(matchId, matchDate, homeTeam, awayTeam, result, venue);
            }
            else
            {
                match = new Match(matchId, matchDate, homeTeam, awayTeam, status, result, venue);
            }
            matches.Add(match);
        }
        public Match ricercaPerId(int id) 
        {
            return matches.Where(x => x.MatchId == id).FirstOrDefault();
        }


        // Altri metodi utili per la gestione delle partite
        public List<Match> GetMatches()
        {
            return matches;
        }
    }
}
