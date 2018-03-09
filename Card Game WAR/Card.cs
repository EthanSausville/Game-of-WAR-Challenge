using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Card_Game_WAR
{
    [Serializable()]
    public class Card
    {
        public string Suite { get; set; }
        public string FaceValue { get; set; }
        public int Rank { get; set; }

        public string PrintCardName()
        { return string.Format("{0} of {1}", this.FaceValue, this.Suite); }
    }
}