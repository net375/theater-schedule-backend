using System;
using System.Collections.Generic;
using System.Text;

namespace TheaterSchedule.BLL.Classes
{
    public class Form
    {
        public List<Multiple_Form> Multiple;
        public List<Single_Form> Single;
        public List<Radio_Form> Radio;

        public Form()
        {
            Multiple = new List<Multiple_Form>();
            Single = new List<Single_Form>();
            Radio = new List<Radio_Form>();
        }
    }
}
