using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorMaker.MODELS
{
    public class RGBProp
    {
        //Declaratie

        //ROOD
        public int Rood { get; set; }
        //GROEN
        public int Groen { get; set; }
        //BLAUW
        public int Blauw { get; set; }

        //Constructor
        public RGBProp()
        {
            Rood = 0;
            Groen = 0;
            Blauw = 0;
        }
    }
}
