using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
namespace UI
{
        public class Stats : MonoBehaviour
        {
            [SerializeField] private Text classicscoreText;
            [SerializeField] private Text classicmissedPlanetsText;
            [SerializeField] private Text classicmissclicksText;

            [SerializeField] private Text timescoreText;
            [SerializeField] private Text timemissedPlanetsText;
            [SerializeField] private Text timemissclicksText;
            [SerializeField] private Text timerText;
            
            private string current_score;
            private string current_missedPlanets;
            private string current_missclicks;
            private string current_time;

        public void ScoreText(int value,string mode)
            {
                if (mode == "classic")
            {
                current_score = Convert.ToString(value);
                classicscoreText.text = "Score: " + current_score;
            }
                else if (mode == "time")
            {
                current_score = Convert.ToString(value);
                timescoreText.text = "Score: " + current_score;
            }
            }

            public void MissedPlanetsText(int value, string mode)
            {
                if (mode == "classic")
                {
                    current_missedPlanets = Convert.ToString(value);
                    classicmissedPlanetsText.text = "Missed planets: " + current_missedPlanets;
                }
                else if (mode == "time")
            {
                current_missedPlanets = Convert.ToString(value);
                timemissedPlanetsText.text = "Missed planets: " + current_missedPlanets;
            }
            }
            public void MissclicksText(int value, string mode)
            {
                if (mode == "classic")
                {
                    current_missclicks = Convert.ToString(value);
                    classicmissclicksText.text = "Missclicks: " + current_missclicks;
                }
                else if (mode == "time")
            {
                current_missclicks = Convert.ToString(value);
                timemissclicksText.text = "Missclicks: " + current_missclicks;
            }
            }
            public void TimerText(int value)
            {
                current_time = Convert.ToString(value);
                timerText.text = "Timer: " + current_time;
                

            }

    }
}



