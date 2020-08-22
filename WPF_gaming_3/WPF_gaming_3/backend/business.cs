﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;
using WPF_gaming_3.CharCreation;

namespace WPF_gaming_3.backend
{
    public class business
    {
        public List<dungoen> dungoens = new List<dungoen>() 
        { 
            new dungoen("Chambers of the Unknown Forest", 
                1, 
                120, 
                0, 
                "C:/Users/chris/source/repos/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/images/area1Loading.png", 
                "C:/Users/chris/source/repos/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/images/area1bg.jpg"),
            new dungoen("Vault of the Nameless Widow", 
                2, 
                250, 
                0, 
                "C:/Users/chris/source/repos/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/images/area2Loading.png", 
                "C:/Users/chris/source/repos/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/images/area2bg.jpg"),
            new dungoen("Tunnels of the Mystic Horsemen", 
                3, 
                600, 
                1, 
                "C:/Users/chris/source/repos/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/images/area3.png", 
                "C:/Users/chris/source/repos/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/images/area3bg.jpg")
        };



        public playerClass pClass;
        public player playerObject;
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
            playerObject = new player(playerName, pClass, 1, 0, 100, stregthP, agilityP, luckP);
        
        }


        public void selcectSound()
        {
            MediaPlayer selcect = new MediaPlayer();
            Uri selectPath = new Uri(@"C:/Users/chris/source/repos/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/sounds/select.wav");
            selcect.Open(selectPath);
            selcect.Play();
        }

        public void createDungoen()
        {
            
        }
        
    }
}
