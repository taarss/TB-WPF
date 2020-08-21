using System;
using System.Collections.Generic;
using System.Text;
using WPF_gaming_3.CharCreation;

namespace WPF_gaming_3.backend
{
    public class business
    {
        


        public playerClass pClass;
        public player player;
        public void createClass(string className, int stregthP, int agilityP, int luckP, string playerName)
        {
            playerClass p1Class = new playerClass(className);
            if (p1Class.ClassName == "warrior")
            {
                p1Class.Def = 11;
                p1Class.MaxHP = 212;
                p1Class.MaxStamina = 71;
            }
            else
            {
                p1Class.Def = 6;
                p1Class.MaxHP = 186;
                p1Class.MaxStamina = 163;
            }
            pClass = p1Class;
            player = new player(playerName, pClass, 1, 0, 100, stregthP, agilityP, luckP);
        
        }

        
    }
}
