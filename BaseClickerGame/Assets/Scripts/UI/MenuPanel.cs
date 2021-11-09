using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
namespace UI
{
    public class MenuPanel : MonoBehaviour
    {
        [SerializeField] private GameObject menuPanel;
        [SerializeField] private GameObject StatsPanel;
        [SerializeField] private GameObject TimeModePanel;
        [SerializeField] private Text timeModeScore;
        private GameMechanics.PlayerController playerController;
        [SerializeField] private GameObject menuSound;
        private GameObject _menuSound;
       
        void Start()
        {
            playerController = FindObjectOfType<GameMechanics.PlayerController>();
        }
        private void OnEnable()
        {
            _menuSound = Instantiate(menuSound, gameObject.transform.position, Quaternion.identity);
        }
        private void OnDisable()
        {
            Destroy(_menuSound);
        }

        public void MenuOn(int score, string mode)
        {
            if (mode == "time")
            {
                
                TimeModePanel.SetActive(false);
                menuPanel.SetActive(true);
                timeModeScore.text = "Last score:" + Convert.ToString(score); ;
            }
            else if(mode == "classic")
            {
                StatsPanel.SetActive(false);
                menuPanel.SetActive(true);
            }
        
        }
        public void ClassicMode()
        {
            menuPanel.SetActive(false);
            StatsPanel.SetActive(true);
            playerController.ClassicStart();
        }
        public void TimeMode()
        {
            menuPanel.SetActive(false);
            TimeModePanel.SetActive(true);
            playerController.TimeModeStart();
        }
    }
}
