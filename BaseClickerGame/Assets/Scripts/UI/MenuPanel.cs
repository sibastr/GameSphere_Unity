using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UI
{
    public class MenuPanel : MonoBehaviour
    {
        [SerializeField] private GameObject menuPanel;
        [SerializeField] private GameObject StatsPanel;
        [SerializeField] private GameObject TimeModePanel;
        //private GameMechanics.PlanetSpawner planetSpawner;
       //private GameMechanics.AsteroidSpawner asteroidSpawner;
        private GameMechanics.PlayerController playerController;
        // Start is called before the first frame update
        void Start()
        {
            //planetSpawner = FindObjectOfType<GameMechanics.PlanetSpawner>();
           // asteroidSpawner = FindObjectOfType<GameMechanics.AsteroidSpawner>();
            playerController = FindObjectOfType<GameMechanics.PlayerController>();
        }

        // Update is called once per frame
        void Update()
        {

        }
        public void MenuOn()
        {
            if (TimeModePanel.activeSelf)
            {
                TimeModePanel.SetActive(false);
            }
            else if(StatsPanel.activeSelf)
            {
                StatsPanel.SetActive(false);
            }
            menuPanel.SetActive(true);
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

        //public void ShowMenu()
        //{
        //    livesEndedPanel.SetActive(true);
        //}
    }
}
