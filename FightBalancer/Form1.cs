using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace FightBalancer
{
    public partial class Form1 : Form
    {
        private bool AddToAttackers { get; set; }
        private Team Attackers { get; set; }
        private Team Defenders { get; set; }

        public Form1()
        {
            Randomizer.Init();
            Attackers = new Team();
            Defenders = new Team();
            InitializeComponent();
            SwitchTeamForm();
            InitAttackers(1);
        }

        private void InitAttackers(int level)
        {
            var mage = new Fighter(2, 0, 11, 13, level) { Name = "Mage" };
            var knight = new Fighter(1, 1, 13, 11, level) { Name = "Knight" };
            var bard = new Fighter(1, 0, 12, 12, level) { Name = "Bard" };
            var hunter = new Fighter(2, 0, 12, 13, level) { Name = "Hunter" };
            AddFighter(mage);
            AddFighter(knight);
            AddFighter(hunter);
            AddFighter(bard);
            SwitchTeamForm();
        }

        private void SwitchTeamForm()
        {
            AddToAttackers = !AddToAttackers;
            SwitchLabel.BackColor = AddToAttackers ? Color.LightGreen : Color.PaleVioletRed;
            SwitchLabel.Text = AddToAttackers ? "Атакующие" : "Защитники";
        }

        private void TeamSwitch_Click(object sender, EventArgs e)
        {
            SwitchTeamForm();
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            var fighter = new Fighter((int)DamageInput.Value, (int)ArmorInput.Value,
                (int)EnduranceInput.Value, (int)AgilityInput.Value, 1, (int)SpeedInput.Value)
            { Name = NameInput.Text };
            AddFighter(fighter);

        }

        private void AddFighter(Fighter f)
        {
            if (AddToAttackers)
            {
                Attackers.Add(f);
                AttackersList.Items.Add(f.ToString());
            }
            else
            {
                Defenders.Add(f);
                DefendersList.Items.Add(f.ToString());
            }
        }

        private void ClearDefenders_Click(object sender, EventArgs e)
        {
            DefendersList.Items.Clear();
            Defenders.Members.Clear();
        }

        private void ClearAttackers_Click(object sender, EventArgs e)
        {
            AttackersList.Items.Clear();
            Attackers.Members.Clear();
        }

        private void Swap(object sender, EventArgs e)
        {
            var temp = Attackers;
            Attackers = Defenders;
            Defenders = temp;

            var tempList = new ListBox();
            tempList.Items.AddRange(AttackersList.Items);
            AttackersList.Items.Clear();
            AttackersList.Items.AddRange(DefendersList.Items);
            DefendersList.Items.Clear();
            DefendersList.Items.AddRange(tempList.Items);
        }

        private void FightBtn_Click(object sender, EventArgs e)
        {
            FightBtn.Enabled = false;
            for (var i = 0; i < 10000; i++)
            {
                var attackersCopy = Attackers.Clone();
                var defendersCopy = Defenders.Clone();
                if (i % 2 == 0)
                    attackersCopy.FightWith(defendersCopy);
                else
                    defendersCopy.FightWith(attackersCopy);
                for (var j = 0; j < Attackers.Members.Count; j++)
                    Attackers.Members[j].Logs.UpdateLogs(attackersCopy.Members[j]);
                for (var j = 0; j < Defenders.Members.Count; j++)
                    Defenders.Members[j].Logs.UpdateLogs(defendersCopy.Members[j]);
            }
            SaveLogs();
            FightBtn.Enabled = true;
        }

        private void SaveLogs()
        {
            var list = Attackers.Members.ToList();
            list.AddRange(Defenders.Members);
            var datetime = DateTime.UtcNow.Ticks;
            var result = JsonConvert.SerializeObject(list.Select(x => new FightResult(x)));
            var path = $"Logs{datetime}.json";

            File.WriteAllText(path, result);
            Process.Start(path);

            foreach (var t in Attackers.Members)
                t.ResetLogs();
            foreach (var t in Defenders.Members)
                t.ResetLogs();
        }
    }
}
