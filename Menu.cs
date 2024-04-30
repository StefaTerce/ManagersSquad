using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassSquad;
using Newtonsoft.Json;
using ReaLTaiizor.Controls;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ManagerSquad
{
    public partial class Menu : Form
    {
        public string SelectedLeague { get; set; }
        public string SelectedTeam { get; set; }
        private const string apiKey = "94fadb6ba04543abb2d445fdca9684df";
        MatchManager matches = new MatchManager();

        public Menu(string team, string league)
        {
            InitializeComponent();
            listBox2.ForeColor = System.Drawing.Color.White;

            SelectedLeague = league;
            SelectedTeam = team;

            // Definisci le colonne della DataGridView
            dataGridView1.Columns.Add("DateColumn", "Date");
            dataGridView1.Columns.Add("HomeTeamColumn", "Home Team");
            dataGridView1.Columns.Add("AwayTeamColumn", "Away Team");
            dataGridView1.Columns.Add("StatusColumn", "Status");

            // Aggiungi la colonna "Result"
            DataGridViewTextBoxColumn resultColumn = new DataGridViewTextBoxColumn();
            resultColumn.HeaderText = "Result";
            resultColumn.Name = "ResultColumn";
            dataGridView1.Columns.Add(resultColumn);

            dataGridView1.Columns.Add("MatchIdColumn", "Match ID");
            dataGridView1.Columns.Add("InfoColumn", "More Info");

            // Imposta larghezza delle colonne
            dataGridView1.Columns["DateColumn"].Width = 100; // Larghezza in pixel
            dataGridView1.Columns["HomeTeamColumn"].Width = 200; // Larghezza in pixel
            dataGridView1.Columns["AwayTeamColumn"].Width = 200; // Larghezza in pixel
            dataGridView1.Columns["StatusColumn"].Width = 120; // Larghezza in pixel
            dataGridView1.Columns["ResultColumn"].Width = 60; // Larghezza in pixel
            dataGridView1.Columns["MatchIdColumn"].Width = 60;

            // Imposta il colore di sfondo delle colonne
            dataGridView1.Columns["DateColumn"].DefaultCellStyle.BackColor = Color.LightGray;
            dataGridView1.Columns["HomeTeamColumn"].DefaultCellStyle.BackColor = Color.LightGray;
            dataGridView1.Columns["AwayTeamColumn"].DefaultCellStyle.BackColor = Color.LightGray;
            dataGridView1.Columns["StatusColumn"].DefaultCellStyle.BackColor = Color.LightGray;
            dataGridView1.Columns["ResultColumn"].DefaultCellStyle.BackColor = Color.LightGray;
            dataGridView1.Columns["MatchIdColumn"].DefaultCellStyle.BackColor = Color.LightGray;

            // Definisci le colonne della DataGridView
            dataGridView2.Columns.Add("DateColumn", "Date");
            dataGridView2.Columns.Add("HomeTeamColumn", "Home Team");
            dataGridView2.Columns.Add("AwayTeamColumn", "Away Team");
            dataGridView2.Columns.Add("StatusColumn", "Status");

            // Aggiungi la colonna "Result"
            DataGridViewTextBoxColumn resultColumn2 = new DataGridViewTextBoxColumn();
            resultColumn2.HeaderText = "Result";
            resultColumn2.Name = "ResultColumn";
            dataGridView2.Columns.Add(resultColumn2);

            dataGridView2.Columns.Add("MatchIdColumn", "Match ID");
            dataGridView2.Columns.Add("InfoColumn", "More Info");

            // Imposta larghezza delle colonne
            dataGridView2.Columns["DateColumn"].Width = 100; // Larghezza in pixel
            dataGridView2.Columns["HomeTeamColumn"].Width = 200; // Larghezza in pixel
            dataGridView2.Columns["AwayTeamColumn"].Width = 200; // Larghezza in pixel
            dataGridView2.Columns["StatusColumn"].Width = 120; // Larghezza in pixel
            dataGridView2.Columns["ResultColumn"].Width = 60; // Larghezza in pixel
            dataGridView2.Columns["MatchIdColumn"].Width = 60;

            // Imposta il colore di sfondo delle colonne
            dataGridView2.Columns["DateColumn"].DefaultCellStyle.BackColor = Color.LightGray;
            dataGridView2.Columns["HomeTeamColumn"].DefaultCellStyle.BackColor = Color.LightGray;
            dataGridView2.Columns["AwayTeamColumn"].DefaultCellStyle.BackColor = Color.LightGray;
            dataGridView2.Columns["StatusColumn"].DefaultCellStyle.BackColor = Color.LightGray;
            dataGridView2.Columns["ResultColumn"].DefaultCellStyle.BackColor = Color.LightGray;
            dataGridView2.Columns["MatchIdColumn"].DefaultCellStyle.BackColor = Color.LightGray;

            dataGridView3.Columns.Add("DateColumn", "Date");
            dataGridView3.Columns.Add("HomeTeamColumn", "Home Team");
            dataGridView3.Columns.Add("AwayTeamColumn", "Away Team");
            dataGridView3.Columns.Add("StatusColumn", "Status");

            // Aggiungi la colonna "Result"
            DataGridViewTextBoxColumn resultColumn3 = new DataGridViewTextBoxColumn();
            resultColumn3.HeaderText = "Result";
            resultColumn3.Name = "ResultColumn";
            dataGridView3.Columns.Add(resultColumn3);

            dataGridView3.Columns.Add("MatchIdColumn", "Match ID");
            dataGridView3.Columns.Add("InfoColumn", "More Info");

            // Imposta larghezza delle colonne
            dataGridView3.Columns["DateColumn"].Width = 100; // Larghezza in pixel
            dataGridView3.Columns["HomeTeamColumn"].Width = 200; // Larghezza in pixel
            dataGridView3.Columns["AwayTeamColumn"].Width = 200; // Larghezza in pixel
            dataGridView3.Columns["StatusColumn"].Width = 120; // Larghezza in pixel
            dataGridView3.Columns["ResultColumn"].Width = 60; // Larghezza in pixel
            dataGridView3.Columns["MatchIdColumn"].Width = 60;

            // Imposta il colore di sfondo delle colonne
            dataGridView3.Columns["DateColumn"].DefaultCellStyle.BackColor = Color.LightGray;
            dataGridView3.Columns["HomeTeamColumn"].DefaultCellStyle.BackColor = Color.LightGray;
            dataGridView3.Columns["AwayTeamColumn"].DefaultCellStyle.BackColor = Color.LightGray;
            dataGridView3.Columns["StatusColumn"].DefaultCellStyle.BackColor = Color.LightGray;
            dataGridView3.Columns["ResultColumn"].DefaultCellStyle.BackColor = Color.LightGray;
            dataGridView3.Columns["MatchIdColumn"].DefaultCellStyle.BackColor = Color.LightGray;



            ClassCampioData.Columns.Add("NameMem", "Name");
            ClassCampioData.Columns.Add("PositionMem", "Position");
            ClassCampioData.Columns.Add("NationalityMem", "Nationality");

            ClassCampioData.Columns["NameMem"].Width = 140;

            LoadMatches();
            LoadTeamMatches();
            LoadTable(SelectedLeague);
            LoadBestStrikerDa(SelectedLeague);
            LoadChampionLeague();
        }
        private async void LoadChampionLeague()
        {
            string apiUrl = $"https://api.football-data.org/v4/competitions/CL/matches";
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("X-Auth-Token", apiKey);
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string responseData = await response.Content.ReadAsStringAsync();
                    dynamic data = JsonConvert.DeserializeObject(responseData);

                    foreach (var match in data.matches)
                    {
                        string homeTeam = match.homeTeam.name.ToString();
                        string awayTeam = match.awayTeam.name.ToString();
                        int matchId = int.Parse(match.id.ToString());


                            DateTime matchDate = DateTime.Parse(match.utcDate.ToString());
                            string status = match.status.ToString();
                            string result = match.score.fullTime.home.ToString() + " - " + match.score.fullTime.away.ToString();
                            int rowIndex = dataGridView3.Rows.Add(
                                matchDate.ToShortDateString(),
                                homeTeam,
                                awayTeam,
                                status,
                                result,
                                matchId
                            );

                            DataGridViewButtonCell buttonCell = new DataGridViewButtonCell();
                            buttonCell.Value = "SHOW MORE";
                            buttonCell.Tag = matchId; // Corretto qui
                            dataGridView3.Rows[rowIndex].Cells["InfoColumn"] = buttonCell;
                        
                    }
                    dataGridView3.CellContentClick += (sender, e) =>
                    {
                        if (e.RowIndex >= 0 && e.ColumnIndex == dataGridView3.Columns["InfoColumn"].Index)
                        {
                            DataGridViewButtonCell cell = dataGridView3.Rows[e.RowIndex].Cells["InfoColumn"] as DataGridViewButtonCell;
                            if (cell != null)
                            {
                                int id = (int)cell.Tag; // Ottieni l'ID dalla proprietà Tag del pulsante
                                ApriHtmlChampion(id);
                            }
                        }
                    };
                }
                else
                {
                    MessageBox.Show("Errore nella richiesta: " + response.StatusCode);
                }
            }
        }
        public async void ApriHtmlChampion(int matchId)
        {
            string apiUrl = $"https://api.football-data.org/v4/competitions/CL/matches";
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("X-Auth-Token", apiKey);
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string responseData = await response.Content.ReadAsStringAsync();
                    dynamic data = JsonConvert.DeserializeObject(responseData);
                    foreach (var match in data.matches)
                    {
                        if (match.id == matchId)
                        {
                            string homeTeamImageLink = "";
                            string awayTeamImageLink = "";
                            homeTeamImageLink = match.homeTeam.crest;
                            awayTeamImageLink = match.awayTeam.crest;
                            string result = match.score.fullTime.home.ToString() + " - " + match.score.fullTime.away.ToString();

                            // Crea il contenuto HTML
                            string htmlContent = $@"
<!DOCTYPE html>
<html lang='it'>
<head>
    <meta charset='UTF-8'>
    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
    <title>Dettagli Partita</title>
    <link href='https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css' rel='stylesheet'>
</head>
<body>
    <div class='container my-3'>
        <div class='card mb-3'>
            <div class='row g-0'>
                <!-- Immagine Home Team -->
                <div class='col-md-2'>
                    <img src='{homeTeamImageLink}' class='img-fluid rounded-start' alt='Home Team Symbol'>
                </div>
                <!-- Scritta VS gigante -->
                <div class='col-md-8 d-flex justify-content-center align-items-center'>
                    <h1 class='text-center'>VS</h1>
                </div>
                <!-- Immagine Away Team -->
                <div class='col-md-2'>
                    <img src='{awayTeamImageLink}' class='img-fluid rounded-start' alt='Away Team Symbol'>
                </div>
                <div class='col-md-8'>
                    <div class='card-body'>
                        <h5 class='card-title' id='match-title'>{match.homeTeam.name} vs {match.awayTeam.name}</h5>
                        <p class='card-text' id='match-date'>Date: {match.utcDate.ToString("yyyy-MM-dd")}</p>
                        <p class='card-text'><small class='text-muted' id='match-status'>Status: {match.Status}</small></p>
                        <p class='card-text' id='match-result'>Result: {result}</p>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script src='https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js'></script>
</body>
</html>";
                            // Percorso del file HTML nella directory base del progetto
                            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "MatchDetails.html");

                            // Scrivere il contenuto nel file
                            File.WriteAllText(filePath, htmlContent);

                            // Aprire il file nel browser predefinito
                            Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true });
                        }
                    }
                }
            }
        }
        private async void LoadBestStrikerDa(string leagueName)
        {
            try
            {
                string leagueCode = await GetLeagueCode(leagueName);
                string apiUrl = $"https://api.football-data.org/v4/competitions/{leagueCode}/scorers";

                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("X-Auth-Token", apiKey); // Aggiungi il tuo token API

                    HttpResponseMessage response = await client.GetAsync(apiUrl);
                    response.EnsureSuccessStatusCode();

                    string responseBody = await response.Content.ReadAsStringAsync();

                    // Deserializza la risposta JSON utilizzando Newtonsoft.Json
                    dynamic scorers = JsonConvert.DeserializeObject(responseBody);

                    // Assicurati che la risposta contenga i dati degli scorer
                    if (scorers != null && scorers.scorers != null)
                    {
                        // Aggiungi i dati alla ListBox
                        foreach (var scorer in scorers.scorers)
                        {
                            string playerName = scorer.player.name;
                            string teamName = scorer.team.name;
                            int goals = scorer.goals;
                            int? assists = scorer.assists != null ? (int)scorer.assists : 0;
                            int? penalties = scorer.penalties != null ? (int)scorer.penalties : 0;
                            listBox2.Items.Add($"{playerName} - {teamName}: Goals - {goals}, Assists - {assists}, Penalties - {penalties}");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Nessun dato sugli scorer trovato.");
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Errore durante la richiesta HTTP: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Errore: {ex.Message}");
            }
        }
        private async Task<string> LoadTable(string leagueName)
         {
            string leagueCode = await GetLeagueCode(leagueName);
            string leagueStandingJson = await GetLeagueStanding(leagueCode);

            // Effettua il parsing del JSON e estrai le informazioni necessarie
            dynamic data = JsonConvert.DeserializeObject(leagueStandingJson);

            // Assicurati che la ListBox sia vuota prima di aggiungere i nuovi elementi
            listBox1.Items.Clear();
            foreach (var standing in data.standings[0].table)
            {
                string teamName = standing.team.name.ToString();
                int position = int.Parse(standing.position.ToString());
                int points = int.Parse(standing.points.ToString());
                int teamId = int.Parse(standing.team.id.ToString());

                string teamInfo = $"{position}. {teamName} (ID: {teamId}) - {points} punti";

                listBox1.Items.Add(teamInfo);
            }

            return leagueStandingJson; // Ritorna il JSON delle classifiche
        }



        private async Task<string> GetLeagueCode(string leagueName)
        {
            string campionato = "";
            switch (SelectedLeague)
            {
                //case "FIFA World Cup":
                //    return "WC";
                //case "UEFA Champions League":
                //    return "CL";
                case "Bundesliga":
                    campionato = "BL1";
                    break;
                case "Eredivisie":
                    campionato = "DED";
                    break;
                case "Campeonato Brasileiro Série A":
                    campionato = "BSA";
                    break;
                case "Primera Division":
                    campionato = "PD";
                    break;
                case "Ligue 1":
                    campionato = "FL1";
                    break;
                //case "Championship":
                //    return "ELC";
                case "Primeira Liga":
                    campionato = "PPL";
                    break;
                //case "European Championship":
                //    return "EC";
                case "Serie A":
                    campionato = "SA";
                    break;
                case "Premier League":
                    campionato = "PL";
                    break;
                //case "Copa Libertadores":
                //    return "CLI";
                default:
                    break;
            }
            return campionato;
        }

        private async Task<string> GetLeagueStanding(string leagueCode)
        {
            string apiUrl = $"https://api.football-data.org/v4/competitions/{leagueCode}/standings";
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("X-Auth-Token", apiKey);

                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                return null; // In caso di errore nella richiesta
            }
        }


        private async void LoadMatches()
            {
                // Effettua una richiesta all'API per ottenere le partite del campionato
                string campionato = "";
                switch (SelectedLeague)
                {
                    //case "FIFA World Cup":
                    //    return "WC";
                    //case "UEFA Champions League":
                    //    return "CL";
                    case "Bundesliga":
                        campionato = "BL1";
                        break;
                    case "Eredivisie":
                        campionato = "DED";
                        break;
                    case "Campeonato Brasileiro Série A":
                        campionato = "BSA";
                        break;
                    case "Primera Division":
                        campionato = "PD";
                        break;
                    case "Ligue 1":
                        campionato = "FL1";
                        break;
                    //case "Championship":
                    //    return "ELC";
                    case "Primeira Liga":
                        campionato = "PPL";
                        break;
                    //case "European Championship":
                    //    return "EC";
                    case "Serie A":
                        campionato = "SA";
                        break;
                    case "Premier League":
                        campionato = "PL";
                        break;
                    //case "Copa Libertadores":
                    //    return "CLI";
                    default:
                        break;
                }
                string apiUrl = $"https://api.football-data.org/v2/competitions/{campionato}/matches";
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("X-Auth-Token", apiKey);

                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseData = await response.Content.ReadAsStringAsync();
                        dynamic data = JsonConvert.DeserializeObject(responseData);

   
                    foreach (var match in data.matches)
                    {
                        int matchId = int.Parse(match.id.ToString());
                        DateTime matchDate = DateTime.Parse(match.utcDate.ToString());
                        string homeTeam = match.homeTeam.name.ToString();
                        string awayTeam = match.awayTeam.name.ToString();
                        string status = match.status.ToString();
                        string result = match.score.fullTime.homeTeam.ToString() + " - " + match.score.fullTime.awayTeam.ToString();
                        string venue = match.venue != null ? match.venue.ToString() : "Unknown";  // Verifica se il dato è disponibile

                        if (status == "FINISHED")
                        {
                            matches.AddMatch(matchId, matchDate, homeTeam, awayTeam, status, result, venue);
                        }
                        else
                        {
                            matches.AddMatch(matchId, matchDate, homeTeam, awayTeam, status, "", venue);
                        }
                    }

                    // Popola la DataGridView con i match dalla lista di MatchManager
                    foreach (var match in matches.GetMatches())
                        {
                            DataGridViewButtonCell buttonCell = new DataGridViewButtonCell();
                            buttonCell.Value = "SHOW MORE";
                            buttonCell.Tag = match.MatchId;

                            string result = match.Status == "FINISHED" ? ((MatchEnded)match).Result : "";

                            int rowIndex = dataGridView1.Rows.Add(
                                match.MatchDate.ToShortDateString(),
                                match.HomeTeam,
                                match.AwayTeam,
                                match.Status,
                                result,
                                match.MatchId
                            );
                            dataGridView1.Rows[rowIndex].Cells["InfoColumn"] = buttonCell;
                        }
                        dataGridView1.CellContentClick += (sender, e) =>
                        {
                            if (e.RowIndex >= 0 && e.ColumnIndex == dataGridView2.Columns["InfoColumn"].Index)
                            {
                                DataGridViewButtonCell cell = dataGridView2.Rows[e.RowIndex].Cells["InfoColumn"] as DataGridViewButtonCell;
                                if (cell != null)
                                {
                                    int id = (int)cell.Tag; // Ottieni l'ID dalla proprietà Tag del pulsante
                                    ApriHtml(id);
                                }
                            }
                        };
                    }
                    else
                    {
                        MessageBox.Show("Errore nella richiesta: " + response.StatusCode);
                    }
                }
            }
        private async Task LoadTeamMatches()
        {
            // Effettua una richiesta all'API per ottenere le partite del campionato
            string campionato = "";
            switch (SelectedLeague)
            {
                //case "FIFA World Cup":
                //    return "WC";
                //case "UEFA Champions League":
                //    return "CL";
                case "Bundesliga":
                    campionato = "BL1";
                    break;
                case "Eredivisie":
                    campionato = "DED";
                    break;
                case "Campeonato Brasileiro Série A":
                    campionato = "BSA";
                    break;
                case "Primera Division":
                    campionato = "PD";
                    break;
                case "Ligue 1":
                    campionato = "FL1";
                    break;
                //case "Championship":
                //    return "ELC";
                case "Primeira Liga":
                    campionato = "PPL";
                    break;
                //case "European Championship":
                //    return "EC";
                case "Serie A":
                    campionato = "SA";
                    break;
                case "Premier League":
                    campionato = "PL";
                    break;
                //case "Copa Libertadores":
                //    return "CLI";
                default:
                    break;
            }
            string apiUrl = $"https://api.football-data.org/v2/competitions/{campionato}/matches";
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("X-Auth-Token", apiKey);
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string responseData = await response.Content.ReadAsStringAsync();
                    dynamic data = JsonConvert.DeserializeObject(responseData);

                    foreach (var match in data.matches)
                    {
                        string homeTeam = match.homeTeam.name.ToString();
                        string awayTeam = match.awayTeam.name.ToString();
                        int matchId = int.Parse(match.id.ToString());

                        if (SelectedTeam == homeTeam || SelectedTeam == awayTeam)
                        {
                            DateTime matchDate = DateTime.Parse(match.utcDate.ToString());
                            string status = match.status.ToString();
                            string result = match.score.fullTime.homeTeam.ToString() + " - " + match.score.fullTime.awayTeam.ToString();

                            int rowIndex = dataGridView2.Rows.Add(
                                matchDate.ToShortDateString(),
                                homeTeam,
                                awayTeam,
                                status,
                                result,
                                matchId
                            );

                            DataGridViewButtonCell buttonCell = new DataGridViewButtonCell();
                            buttonCell.Value = "SHOW MORE";
                            buttonCell.Tag = matchId; // Corretto qui
                            dataGridView2.Rows[rowIndex].Cells["InfoColumn"] = buttonCell;
                        }
                    }
                    dataGridView2.CellContentClick += (sender, e) =>
                    {
                        if (e.RowIndex >= 0 && e.ColumnIndex == dataGridView2.Columns["InfoColumn"].Index)
                        {
                            DataGridViewButtonCell cell = dataGridView2.Rows[e.RowIndex].Cells["InfoColumn"] as DataGridViewButtonCell;
                            if (cell != null)
                            {
                                int id = (int)cell.Tag; // Ottieni l'ID dalla proprietà Tag del pulsante
                                ApriHtml(id);
                            }
                        }
                    };
                }
                else
                {
                    MessageBox.Show("Errore nella richiesta: " + response.StatusCode);
                }
            }
        }

        public async void ApriHtml(int matchId)
        {
            // Supponiamo che 'matches' sia un'istanza di 'MatchManager'
            var match = matches.ricercaPerId(matchId); // Assumi che questo metodo restituisca l'oggetto Match corretto
            string id = match.MatchId.ToString();
            string apiUrl = $"https://api.football-data.org/v4/matches/{matchId}";
            string homeTeamImageLink = "";
            string awayTeamImageLink = "";
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("X-Auth-Token", apiKey);
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string responseData = await response.Content.ReadAsStringAsync();
                    dynamic data = JsonConvert.DeserializeObject(responseData);
                    homeTeamImageLink = data.homeTeam.crest;
                    awayTeamImageLink = data.awayTeam.crest;
                }
            }
                        // Verifica se match è di tipo MatchEnded e ottiene il vincitore, altrimenti imposta un valore di default
                        string winner = match is MatchEnded endedMatch ? endedMatch.Winner : "N/A";

            // Crea il contenuto HTML
            string htmlContent = $@"
<!DOCTYPE html>
<html lang='it'>
<head>
    <meta charset='UTF-8'>
    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
    <title>Dettagli Partita</title>
    <link href='https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css' rel='stylesheet'>
</head>
<body>
    <div class='container my-3'>
        <div class='card mb-3'>
            <div class='row g-0'>
                <!-- Immagine Home Team -->
                <div class='col-md-2'>
                    <img src='{homeTeamImageLink}' class='img-fluid rounded-start' alt='Home Team Symbol'>
                </div>
                <!-- Scritta VS gigante -->
                <div class='col-md-8 d-flex justify-content-center align-items-center'>
                    <h1 class='text-center'>VS</h1>
                </div>
                <!-- Immagine Away Team -->
                <div class='col-md-2'>
                    <img src='{awayTeamImageLink}' class='img-fluid rounded-start' alt='Away Team Symbol'>
                </div>
                <div class='col-md-8'>
                    <div class='card-body'>
                        <h5 class='card-title' id='match-title'>{match.HomeTeam} vs {match.AwayTeam}</h5>
                        <p class='card-text' id='match-date'>Date: {match.MatchDate.ToString("yyyy-MM-dd")}</p>
                        <p class='card-text' id='venue'>Venue: {match.Venue}</p>
                        <p class='card-text'><small class='text-muted' id='match-status'>Status: {match.Status}</small></p>
                        <p class='card-text' id='match-result'>Result: {match.Result}</p>
                        <p class='card-text' id='match-winner'>Winner: {winner}</p>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script src='https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js'></script>
</body>
</html>";

            // Percorso del file HTML nella directory base del progetto
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "MatchDetails.html");

            // Scrivere il contenuto nel file
            File.WriteAllText(filePath, htmlContent);

            // Aprire il file nel browser predefinito
            Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true });
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void hopePictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                // Ottieni l'elemento selezionato
                string selectedTeamInfo = listBox1.SelectedItem.ToString();

                // Esegui l'azione desiderata, ad esempio ottenere l'ID del team
                int startIndex = selectedTeamInfo.IndexOf("(ID:") + "(ID:".Length;
                int endIndex = selectedTeamInfo.IndexOf(")", startIndex);
                string teamIdString = selectedTeamInfo.Substring(startIndex, endIndex - startIndex);
                int teamId = int.Parse(teamIdString);

                LoadTeamMembers(teamId);
            }
        }

        private async Task LoadTeamMembers(int teamId)
        {
            string teamMembersJson = await GetTeamMembersJson(teamId);

            // Effettua il parsing del JSON e estrai le informazioni necessarie
            dynamic data = JsonConvert.DeserializeObject(teamMembersJson);

            // Assicurati che la DataGridView sia vuota prima di aggiungere i nuovi elementi
            ClassCampioData.Rows.Clear();

            foreach (var member in data.squad)
            {
                string name = member.name.ToString();
                string position = member.position.ToString();
                string nationality = member.nationality.ToString();

                ClassCampioData.Rows.Add(name, position, nationality);
            }
        }

        private async Task<string> GetTeamMembersJson(int teamId)
        {
            string apiUrl = $"https://api.football-data.org/v4/teams/{teamId}";
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("X-Auth-Token", apiKey);

                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                return null; // In caso di errore nella richiesta
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void resetBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Cancella il file di salvataggio delle informazioni
                string filePath = "DatiSelezione.txt";
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }

                // Riapre la Form1
                Form1 form1 = new Form1();
                form1.Show();

                // Chiude la Form corrente
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Si è verificato un errore durante il reset: {ex.Message}");
            }
        }

        private void cyberButton1_Click(object sender, EventArgs e)
        {

        }
    }
}
