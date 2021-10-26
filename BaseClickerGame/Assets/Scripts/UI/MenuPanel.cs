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
        public void MenuOff()
        {
            menuPanel.SetActive(false);
        }
        public void ClassicMode()
        {
            menuPanel.SetActive(false);
            StatsPanel.SetActive(true);
            //planetSpawner.PlanetStart();
            //asteroidSpawner.AsteroidStart();
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
