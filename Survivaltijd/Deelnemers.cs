using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Survivaltijd
{
    class Deelnemers
    {
        List<Deelnemer> individueel;
        List<Deelnemer> team;

        StringBuilder sbTeam = new StringBuilder();
        StringBuilder sbInd  = new StringBuilder();
        
        public Deelnemers()
        {
            string delimiter = ",";
            individueel = new List<Deelnemer>();
            team = new List<Deelnemer>();
            sbTeam.AppendLine("Startnummer" + delimiter + "Tijd");
            sbInd.AppendLine("Startnummer" + delimiter + "Tijd");
        }

        // laat een nieuw team of een nieuwe loper starten
        public Boolean start(int sn, string typ){
            try
            {
                Deelnemer nieuweDeelnemer = new Deelnemer(sn, typ);
                if (typ.Equals("individueel"))
                {
                    if (individueel.Exists(x => x.getStartnummer() == sn)) // is de loper al gestart?
                    {
                        MessageBox.Show("Er is al een loper gestart met nummer " + sn + ", verwijder deze loper voordat je een nieuwe " +
                            "loper toevoegt met dit nummer.");
                       return false;
                    }
                    else
                    {
                        individueel.Add(nieuweDeelnemer);
                        return true;
                    }
                }
                else // er moet een team worden toegevoegd
                {
                    if (team.Exists(x => x.getStartnummer() == sn) && typ.Equals("team")) // is het team al gestart?
                    {
                        MessageBox.Show("Er is al een team gestart met nummer " + sn + ", verwijder dit team voordat je een nieuw " +
                            "team toevoegt met dit nummer.");
                        return false;
                    }
                    else
                    {
                        team.Add(nieuweDeelnemer);
                        return true;
                    }
                }
            }
            catch (Exception e){
                MessageBox.Show(e.Message);
                return false;
            }
        }

        // laat een nieuw team of een nieuwe loper starten op een voorgeschreven tijd
        public Boolean start(int sn, string typ, DateTime start)
        {
            try
            {
                Deelnemer nieuweDeelnemer = new Deelnemer(sn, typ, start);
                if (typ.Equals("individueel"))
                {
                    if (individueel.Exists(x => x.getStartnummer() == sn)) // is de loper al gestart?
                    {
                        MessageBox.Show("Er is al een loper gestart met nummer " + sn + ", verwijder deze loper voordat je een nieuwe " +
                            "loper toevoegt met dit nummer.");
                        return false;
                    }
                    else
                    {
                        individueel.Add(nieuweDeelnemer);
                        return true;
                    }
                }
                else // er moet een team worden toegevoegd
                {
                    if (team.Exists(x => x.getStartnummer() == sn) && typ.Equals("team")) // is het team al gestart?
                    {
                        MessageBox.Show("Er is al een team gestart met nummer " + sn + ", verwijder dit team voordat je een nieuw " +
                            "team toevoegt met dit nummer.");
                        return false;
                    }
                    else
                    {
                        team.Add(nieuweDeelnemer);
                        return true;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }

        public void stop(int sn, string typ)
        {
            Deelnemer result = null;
            if (typ.Equals("individueel")){                                  
                result = individueel.Find(x => x.getStartnummer() == sn);                
            }
            if (typ.Equals("team")){
                result = team.Find(x => x.getStartnummer() == sn);                 
            }
            result.stop(); 
            voegToeFinished(sn.ToString(), result.getRondetijd().ToString(), typ);
        }

        public void reset(int sn, string typ)
        {
            Deelnemer result = null;
            if (typ.Equals("individueel"))
            {
                result = individueel.Find(x => x.getStartnummer() == sn);
            }
            else
            {
                result = team.Find(x => x.getStartnummer() == sn);    
            }
            result.resetTijd();
        }
     
        public List<String> getList(string typ){
            List<String> returnList = null;
            if (typ.Equals("individueel"))
            {
                try
                {
                    foreach (Deelnemer d in individueel)
                    {
                        returnList.Add(d.ToString());
                    }
                }
                catch (Exception)
                {}
            }
            if (typ.Equals("team"))
            {
                try
                {
                    foreach (Deelnemer d in team)
                    {
                        returnList.Add(d.ToString());
                    }
                }
                catch (Exception)
                {}
            }
            return returnList;
        }

        public TimeSpan getRondeTijd(int sn, string typ)
        {
            TimeSpan result = DateTime.Now - DateTime.Now;
            if (typ.Equals("individueel"))
            {
                if (individueel.Exists(x => x.getStartnummer() == sn))
                {
                    result = individueel.Find(x => x.getStartnummer() == sn).getRondetijd();
                }
                else
                { // de deelnemer is niet gestart
                    MessageBox.Show("Deze deelnemer is niet gestart!");
                }
            }

            if (typ.Equals("team"))
            {
                if (team.Exists(x => x.getStartnummer() == sn))
                {
                    result = team.Find(x => x.getStartnummer() == sn).getRondetijd();
                }
                else
                { // het team is niet gestart
                    MessageBox.Show("Dit team is niet gestart!");
                }
            }
            return result;
        }

        public void voegToeFinished(string sn, string tijd, string typ)
        {
            string delimiter = ",";
            if (typ.Equals("team"))
            {                
                sbTeam.AppendLine(sn + delimiter + tijd);
            }
            if (typ.Equals("individueel"))
            {
                sbInd.AppendLine(sn + delimiter + tijd);
            }
        }

        public StringBuilder getFinished(string typ)
        {
            if (typ.Equals("team"))
            {
                return sbTeam;
            } 
            else // het gaat om een individu
            {
                return sbInd;
            }
        }

        public void verwijder(int sn, string typ)
        {
            if(typ.Equals("team")){
                var itemToRemove = team.Single(r => r.startnummer == sn);
                team.Remove(itemToRemove);
            }
            else // het gaat om een individu
            {
                var itemToRemove = individueel.Single(r => r.startnummer == sn);
                individueel.Remove(itemToRemove);
            }            
        }

        public void annuleerFinish(int sn, string typ)
        {
            if (typ.Equals("team"))
            {
                Deelnemer itemToCancel = team.Single(r => r.startnummer == sn);
                itemToCancel.annuleerFinish();
            }
            else // het gaat om een individu
            {
                Deelnemer itemToCancel = individueel.Single(r => r.startnummer == sn);
                itemToCancel.annuleerFinish();
            }
        }

        public Boolean getIsFinished(int sn, string typ)
        {
            Deelnemer result = null;
            if (typ.Equals("team"))
            {
                Deelnemer itemToCheck = team.Single(r => r.startnummer == sn);
            }
            else // het gaat om een individu
            {
                Deelnemer itemToCheck = individueel.Single(r => r.startnummer == sn);
            }
            return result.isFinished();
        }



    }
}