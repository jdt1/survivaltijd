using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using LumenWorks.Framework.IO.Csv;

namespace Survivaltijd
{
    public partial class Form1 : Form
    {
        int counter = 1;
        Deelnemers deelnemers = new Deelnemers();
        
        public Form1()
        {
            InitializeComponent();
            backgroundWorker2.DoWork += backgroundWorker2_DoWork;
            backgroundWorker2.RunWorkerCompleted += backgroundWorker2_RunWorkerCompleted;
            this.backgroundWorker2.RunWorkerAsync();
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(5000);
            try
            {
                File.WriteAllText("individueel_backup.csv", deelnemers.getFinished("individueel").ToString());
                File.WriteAllText("teams_backup.csv", deelnemers.getFinished("team").ToString());
            }
            catch (IOException ex)
            {
                MessageBox.Show("Er is een fout opgetreden bij het opslaan van de backuptijden: " +
                    ex.Message + " Het bestand is niet opgeslagen!");
            }            
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {            
            backgroundWorker2.RunWorkerAsync();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Huidige waarde: " + counter);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Huidige waarde: " + counter);
        }

        delegate void StartTeamCallback(string text);

        private void StartTeam(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.txtInd1.InvokeRequired)
            {
                StartTeamCallback d = new StartTeamCallback(StartTeam);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                string zeroes = "00000".Substring(0, 5 - text.Length);
                this.lstTeamBezig.Items.Add(zeroes + text);
            }
        }

        delegate void StartIndividueelCallback(string text);

        private void StartIndividueel(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.txtInd1.InvokeRequired)
            {
                StartIndividueelCallback d = new StartIndividueelCallback(StartIndividueel);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                string zeroes = "00000".Substring(0, 5 - text.Length);
                this.lstIndBezig.Items.Add(zeroes + text);                  
            }
        }

        delegate void LeegListsCallBack();

        private void LeegLists()
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.txtInd1.InvokeRequired)
            {
                LeegListsCallBack d = new LeegListsCallBack(LeegLists);
                this.Invoke(d, new object[] {  });
            }
            else
            {
                this.lstIndBezig.Items.Clear();
                this.lstTeamBezig.Items.Clear();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            wisAlles();         
        }

        public void wisAlles()
        {
            txtInd1.Text = "";
            txtInd2.Text = "";
            txtInd3.Text = "";
            txtInd4.Text = "";
            txtInd5.Text = "";
            txtInd6.Text = "";
            txtInd7.Text = "";
            txtInd8.Text = "";
            txtInd9.Text = "";
            txtInd10.Text = "";
            txtInd11.Text = "";
            txtTeam1.Text = "";
            txtTeam2.Text = "";
            txtTeam3.Text = "";
            txtTeam4.Text = "";
            txtTeam5.Text = "";
            txtTeam6.Text = "";
            txtTeam7.Text = "";
            txtTeam8.Text = "";
            txtTeam9.Text = "";
            txtTeam10.Text = "";
            txtTeam11.Text = "";
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            List<String> teams = new List<String>();
            List<String> individueel = new List<String>();

            String ind1 = txtInd1.Text;
            String ind2 = txtInd2.Text;
            String ind3 = txtInd3.Text;
            String ind4 = txtInd4.Text; 
            String ind5 = txtInd5.Text;
            String ind6 = txtInd6.Text;
            String ind7 = txtInd7.Text;
            String ind8 = txtInd8.Text;
            String ind9 = txtInd9.Text;
            String ind10 = txtInd10.Text;
            String ind11 = txtInd11.Text;

            String team1 = txtTeam1.Text;
            String team2 = txtTeam2.Text;
            String team3 = txtTeam3.Text;
            String team4 = txtTeam4.Text;
            String team5 = txtTeam5.Text;
            String team6 = txtTeam6.Text;
            String team7 = txtTeam7.Text;
            String team8 = txtTeam8.Text;
            String team9 = txtTeam9.Text;
            String team10 = txtTeam10.Text;
            String team11 = txtTeam11.Text;

            if (!(ind1 == ""))  { individueel.Add(ind1);  }
            if (!(ind2 == ""))  { individueel.Add(ind2);  }
            if (!(ind3 == ""))  { individueel.Add(ind3);  }
            if (!(ind4 == ""))  { individueel.Add(ind4);  }
            if (!(ind5 == ""))  { individueel.Add(ind5);  }
            if (!(ind6 == ""))  { individueel.Add(ind6);  }
            if (!(ind7 == ""))  { individueel.Add(ind7);  }
            if (!(ind8 == ""))  { individueel.Add(ind8);  }
            if (!(ind9 == ""))  { individueel.Add(ind9);  }
            if (!(ind10 == "")) { individueel.Add(ind10); }
            if (!(ind11 == "")) { individueel.Add(ind11); }

            if (!(team1 == ""))  { teams.Add(team1);  }
            if (!(team2 == ""))  { teams.Add(team2);  }
            if (!(team3 == ""))  { teams.Add(team3);  }
            if (!(team4 == ""))  { teams.Add(team4);  }
            if (!(team5 == ""))  { teams.Add(team5);  }
            if (!(team6 == ""))  { teams.Add(team6);  }
            if (!(team7 == ""))  { teams.Add(team7);  }
            if (!(team8 == ""))  { teams.Add(team8);  }
            if (!(team9 == ""))  { teams.Add(team9);  }
            if (!(team10 == "")) { teams.Add(team10); }
            if (!(team11 == "")) { teams.Add(team11); }

            start(teams, "team");
            start(individueel, "individueel");

            wisAlles();
          } 

        private void start(List<String> lopers, string type){
            int sn;
            lopers = lopers.Distinct().ToList();
            foreach (String l in lopers){
            try
            {
               sn = Convert.ToInt32(l);
               if (deelnemers.start(sn, type))
               {
                   if (type.Equals("team"))
                   {
                       StartTeam(l);
                   }
                   if (type.Equals("individueel"))
                   {
                       StartIndividueel(l);
                   }
               }
               }
               catch (System.FormatException)
               {
                   MessageBox.Show("Vul a.u.b. alleen cijfers in! ");
               }                
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FinishLoper();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (String s in deelnemers.getList("individueel"))
                {
                    MessageBox.Show(s);
                }
            }
            catch (Exception){}
        }

        delegate void GetLoperCallBack();

        private void FinishLoper()
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.txtInd1.InvokeRequired)
            {
                GetLoperCallBack d = new GetLoperCallBack(LeegLists);
                this.Invoke(d, new object[] { });
            }
            else
            {
                try
                {
                    string inList = lstIndBezig.SelectedItem.ToString();
                    deelnemers.stop(Convert.ToInt32(inList), "individueel");
                    lstFinishInd.Items.Add(inList +
                        "    " + deelnemers.getRondeTijd(Convert.ToInt32(inList), "individueel"));
                    lstIndBezig.Items.Remove(lstIndBezig.SelectedItem);
                }
                catch (NullReferenceException)
                {
                    MessageBox.Show("Geen loper geselecteerd!");
                }
            }
        }

        delegate void GetTeamCallBack();

        private void FinishTeam()
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.txtInd1.InvokeRequired)
            {
                GetTeamCallBack d = new GetTeamCallBack(LeegLists);
                this.Invoke(d, new object[] { });
            }
            else
            {
                try
                {
                    string inList = lstTeamBezig.SelectedItem.ToString();
                    deelnemers.stop(Convert.ToInt32(inList), "team");
                    lstFinishTeam.Items.Add(inList +
                        "    " + deelnemers.getRondeTijd(Convert.ToInt32(inList), "team"));

                    lstTeamBezig.Items.Remove(lstTeamBezig.SelectedItem);
                }
                catch (NullReferenceException)
                {
                    MessageBox.Show("Geen team geselecteerd!");                    
                }
            }
        }

        private void btnFinishTeam_Click(object sender, EventArgs e)
        {
            FinishTeam();
        }

        // voor teams
        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            string name = saveFileDialogTeam.FileName;
            File.WriteAllText(name, deelnemers.getFinished("team").ToString());
        }

        private void btnSaveTeam_Click(object sender, EventArgs e)
        {
            saveFileDialogTeam.ShowDialog();
        }

        // voor individuele lopers
        private void saveFileDialogInd_FileOk(object sender, CancelEventArgs e)
        {
            string name = saveFileDialogInd.FileName;
            try
            {
                File.WriteAllText(name, deelnemers.getFinished("individueel").ToString());
            }
            catch (IOException ex)
            {
                MessageBox.Show("Er is een fout opgetreden: " + 
                    ex.Message + " Het bestand is niet opgeslagen!");                
            }
        }

        private void btnSaveInd_Click(object sender, EventArgs e)
        {
            saveFileDialogInd.ShowDialog();
        }

        private void btnVerwijderLoper_Click(object sender, EventArgs e)
        {
             VerwijderLoper();
        }

        delegate void VerwijderLoperCallBack();

        private void VerwijderLoper()
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.txtInd1.InvokeRequired)
            {
                VerwijderLoperCallBack d = new VerwijderLoperCallBack(VerwijderLoper);
                this.Invoke(d, new object[] { });
            }
            else
            {
                try
                {
                    DialogResult d = MessageBox.Show("Loper verwijderen, weet je het zeker? De rondetijd zal verloren gaan.",
                        "Loper verwijderen", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                    if (d == DialogResult.OK)
                    {                        
                        string inList = lstIndBezig.SelectedItem.ToString();
                        deelnemers.verwijder(Convert.ToInt32(inList), "individueel");
                        lstIndBezig.Items.Remove(lstIndBezig.SelectedItem);
                    }
                }
                catch (NullReferenceException)
                {
                    MessageBox.Show("Geen loper geselecteerd!");
                }
            }
        }

        delegate void VerwijderTeamCallBack();

        private void VerwijderTeam()
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.txtInd1.InvokeRequired)
            {
                VerwijderTeamCallBack d = new VerwijderTeamCallBack(VerwijderTeam);
                this.Invoke(d, new object[] { });
            }
            else
            {
                try
                {
                    DialogResult d = MessageBox.Show("Team verwijderen, weet je het zeker? De rondetijd zal verloren gaan.",
                        "Loper verwijderen", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                    if (d == DialogResult.OK)
                    {
                        string inList = lstTeamBezig.SelectedItem.ToString();
                        deelnemers.verwijder(Convert.ToInt32(inList), "team");
                        lstTeamBezig.Items.Remove(lstTeamBezig.SelectedItem);
                    }
                }
                catch (NullReferenceException)
                {
                    MessageBox.Show("Geen team geselecteerd!");
                }
            }
        }

        private void btnVerwijderTeam_Click(object sender, EventArgs e)
        {
            VerwijderTeam();
        }

        private void btnHerstelInd_Click(object sender, EventArgs e)
        {
            HerstelLoper();
        }

        // btnHerstelTeam_Click
        private void button2_Click_1(object sender, EventArgs e)
        {
            HerstelTeam();
        }

        delegate void HerstelLoperCallBack();

        private void HerstelLoper()
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.txtInd1.InvokeRequired)
            {
                HerstelLoperCallBack d = new HerstelLoperCallBack(HerstelLoper);
                this.Invoke(d, new object[] { });
            }
            else
            {
                try
                {
                    DialogResult d = MessageBox.Show("Finish ongedaan maken, weet je het zeker? De rondetijd zal verloren gaan.",
                        "Finish annuleren", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                    if (d == DialogResult.OK)
                    {
                        string inList = lstFinishInd.SelectedItem.ToString().Substring(0, 5);
                        deelnemers.annuleerFinish(Convert.ToInt32(inList), "individueel");
                        lstFinishInd.Items.Remove(lstFinishInd.SelectedItem);
                        StartIndividueel(inList);                        
                    }
                }
                catch (NullReferenceException)
                {
                    MessageBox.Show("Geen loper geselecteerd!");
                }
            }
        }

        delegate void HerstelTeamCallBack();

        private void HerstelTeam()
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.txtInd1.InvokeRequired)
            {
                HerstelTeamCallBack d = new HerstelTeamCallBack(HerstelTeam);
                this.Invoke(d, new object[] { });
            }
            else
            {
                try
                {
                    DialogResult d = MessageBox.Show("Finish ongedaan maken, weet je het zeker? De rondetijd zal verloren gaan.",
                        "Finish annuleren", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                    if (d == DialogResult.OK)
                    {
                        string inList = lstFinishTeam.SelectedItem.ToString().Substring(0,5);
                        deelnemers.annuleerFinish(Convert.ToInt32(inList), "team");
                        lstFinishTeam.Items.Remove(lstFinishTeam.SelectedItem);
                        StartTeam(inList);
                    }
                }
                catch (NullReferenceException)
                {
                    MessageBox.Show("Geen team geselecteerd!");
                }
            }
        }

        private void btnVerwijderFinishedInd_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Loper verwijderen, weet je het zeker? De rondetijd zal verloren gaan!",
                        "Gefinishte loper verwijderen", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            if (d == DialogResult.OK)
            {
            }
        }

        private void btnLoadInd_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            { 
                using (CsvReader csv = new CsvReader(new StreamReader(openFileDialog1.FileName), true))
                {
                 int fieldCount = csv.FieldCount;
                    while (csv.ReadNextRecord())
                    {
                        for (int i = 0; i < fieldCount; i++)
                        {
                            string[] parts = csv[i].Split(';');
                            int sn = Convert.ToInt32(parts[0]);
                            DateTime starttijd = DateTime.Parse(parts[1]);
                            if (deelnemers.start(sn, "individueel", starttijd))
                            {
                                StartIndividueel(parts[0]);
                            }                           
                        }                   
                    }
                }           
            }
        }

        private void btnLoadTeam_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (CsvReader csv = new CsvReader(new StreamReader(openFileDialog1.FileName), true))
                {
                    int fieldCount = csv.FieldCount;
                    while (csv.ReadNextRecord())
                    {
                        for (int i = 0; i < fieldCount; i++)
                        {
                            string[] parts = csv[i].Split(';');
                            int sn = Convert.ToInt32(parts[0]);
                            DateTime starttijd = DateTime.Parse(parts[1]);
                            if (deelnemers.start(sn, "team", starttijd))
                            {
                                StartTeam(parts[0]);
                            }                            
                        }
                    }
                }
            }
        }

        private void lstIndBezig_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                FinishLoper();
            }
        }

        private void lstTeamBezig_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                FinishTeam();
            }
        }
                                 
    }

}
