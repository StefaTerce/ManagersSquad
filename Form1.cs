using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace ManagerSquad
{
    public partial class Form1 : Form
    {
        private const string apiUrl = "https://api.football-data.org/v2/competitions";
        private const string apiKey = "94fadb6ba04543abb2d445fdca9684df"; // Sostituisci con la tua chiave API
        public string SelectedLeague { get; private set; }
        public string SelectedTeam { get; private set; }
        public bool CampionatoSelezionato;
        public string selectedLeague;

        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
            GetAvailableLeagues();
        }

        private async Task GetTeamsForSelectedLeague(string league)
        {
            // Effettua una richiesta all'API per ottenere le squadre della lega selezionata
            string teamsUrl = $"https://api.football-data.org/v2/competitions/{GetLeagueCode(league)}/teams";

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("X-Auth-Token", apiKey);

                HttpResponseMessage response = await client.GetAsync(teamsUrl);

                if (response.IsSuccessStatusCode)
                {
                    string responseData = await response.Content.ReadAsStringAsync();

                    dynamic data = Newtonsoft.Json.JsonConvert.DeserializeObject(responseData);

                    // Pulisci la ComboBox delle squadre
                    ItemCombo.Items.Clear();

                    // Aggiungi le squadre ottenute dalla risposta API alla ComboBox
                    foreach (var team in data.teams)
                    {
                        ItemCombo.Items.Add(team.name);
                    }
                    MessageBox.Show("Campionato Selezionato");
                    SelezionaBtn.Text = "Seleziona Squadra";
                    ItemCombo.Text = "";
                    CampionatoSelezionato = true;
                }
                else
                {
                    MessageBox.Show("Errore nella richiesta: " + response.StatusCode);
                }
            }
        }

        private string GetSelectedTeam()
        {
            return ItemCombo.SelectedItem?.ToString();
        }

        private async Task GetAvailableLeagues()
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("X-Auth-Token", apiKey);

                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string responseData = await response.Content.ReadAsStringAsync();

                    dynamic data = Newtonsoft.Json.JsonConvert.DeserializeObject(responseData);
                    foreach (var competition in data.competitions)
                    {
                        string leagueName = competition.name.ToString();
                        if (GetLeagueCode(leagueName) != "")
                        {
                            ItemCombo.Items.Add(leagueName);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Errore nella richiesta: " + response.StatusCode);
                }
            }
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            // Leggi i dati salvati se esistono
            string filePath = "DatiSelezione.txt";
            if (File.Exists(filePath))
            {
                try
                {
                    // Leggi i dati dal file
                    string[] lines = File.ReadAllLines(filePath);
                    string campionato = lines[0].Split(':')[1].Trim();
                    string squadra = lines[1].Split(':')[1].Trim();

                    // Verifica se i dati sono validi
                    if (!string.IsNullOrEmpty(campionato) && !string.IsNullOrEmpty(squadra))
                    {
                        // Crea un'istanza del Menu passando i dati della squadra e del campionato
                        Menu menuForm = new Menu(squadra, campionato);

                        // Mostra il Menu
                        menuForm.Shown += (s, args) =>
                        {
                            // Nasconde la Form corrente quando la nuova form è stata mostrata
                            this.Hide();
                        };

                        menuForm.Show();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Si è verificato un errore durante la lettura dei dati salvati: {ex.Message}");
                }
            }
        }



        private void SelezionaBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ItemCombo.Text))
            {
                MessageBox.Show("Selezionare un item");
                return;
            }
                if (CampionatoSelezionato == false)
            {
                // Salva la lega selezionata globalmente
                selectedLeague = ItemCombo.SelectedItem.ToString();

                // Effettua una richiesta all'API per ottenere le squadre di quella lega
                GetTeamsForSelectedLeague(selectedLeague);
            }
            else if (CampionatoSelezionato == true)
            {
 
                    string Squadra = GetSelectedTeam();

                    // Crea un'istanza del Menu passando i dati della squadra e del campionato
                    Menu menuForm = new Menu(Squadra, selectedLeague);
                    SalvaDati(selectedLeague, Squadra);
                    // Mostra il Menu
                    menuForm.Show();

                    this.Hide();
                
            }
        }
        public string GetLeagueCode(string leagueName)
        {
            switch (leagueName)
            {
                //case "FIFA World Cup":
                //    return "WC";
                //case "UEFA Champions League":
                //    return "CL";
                case "Bundesliga":
                    return "BL1";
                case "Eredivisie":
                    return "DED";
                case "Campeonato Brasileiro Série A":
                    return "BSA";
                case "Primera Division":
                    return "PD";
                case "Ligue 1":
                    return "FL1";
                //case "Championship":
                //    return "ELC";
                case "Primeira Liga":
                    return "PPL";
                //case "European Championship":
                //    return "EC";
                case "Serie A":
                    return "SA";
                case "Premier League":
                    return "PL";
                //case "Copa Libertadores":
                //    return "CLI";
                default:
                    return "";
            }
        }
        private void SalvaDati(string campionato, string squadra)
        {
            try
            {
                // Imposta il percorso del file
                string filePath = "DatiSelezione.txt";

                // Apre o crea il file per la scrittura
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    // Scrive i dati nel file
                    writer.WriteLine($"Campionato: {campionato}");
                    writer.WriteLine($"Squadra: {squadra}");
                }

                MessageBox.Show("Dati salvati correttamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Si è verificato un errore durante il salvataggio dei dati: {ex.Message}");
            }
        }

        private void SelezionaForm_Click(object sender, EventArgs e)
        {

        }
    }
}
