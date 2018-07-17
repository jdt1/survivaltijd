using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Survivaltijd
{
    class Deelnemer
    {
        String type;
        public int startnummer;
        DateTime starttijd;
        DateTime eindtijd;
        Boolean finished = false;

     public Deelnemer(int sn, String typ){         
         starttijd = DateTime.Now;
         startnummer = sn;
         type = typ;
     }

     public Deelnemer(int sn, String typ, DateTime start)
     {
         starttijd = start;
         startnummer = sn;
         type = typ;
     }

     public Boolean isFinished()
     {
         return finished;
     }

     public void stop()
     {
         eindtijd = DateTime.Now;
         finished = true;
     }

     public void annuleerFinish()
     {
         finished = false;
     }

     public int getStartnummer()
     {
         return startnummer;
     }

     public TimeSpan getRondetijd()
     {
         return (eindtijd - starttijd);
     }

     public override String ToString()
     {
         if (!finished){
             return "#" + startnummer + " Gestart: " + starttijd.ToShortTimeString();
         }
         else
         {
             return "#" + startnummer + " Rondetijd: " + getRondetijd().TotalHours.ToString();
         }
     }

     public void resetTijd()
     {
         starttijd = DateTime.Now;
     }

     public DateTime getStartTijd()
     {
         return starttijd;
     }

    }
}
