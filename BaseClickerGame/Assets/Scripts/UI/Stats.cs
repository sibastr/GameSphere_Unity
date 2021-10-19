using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
namespace UI
{
        public class Stats : MonoBehaviour
        {
            [SerializeField] private Text scoreText;
            [SerializeField] private Text missedPlanetsText;
            [SerializeField] private Text missclicksText;
            
            private string current_score;
            private string current_missedPlanets;
            private string current_missclicks;

            public void ScoreText(int value)
            {
                current_score = Convert.ToString(value);
                scoreText.text = "Score: " + current_score;
            }

            public void MissedPlanetsText(int value)
            {
                current_missedPlanets = Convert.ToString(value);
                missedPlanetsText.text = "Missed planets: " + current_missedPlanets;
            }
            public void MissclicksText(int value)
            {
                current_missclicks = Convert.ToString(value);
                missclicksText.text = "Missclicks: " + current_missclicks;
                
            }
        }
}



