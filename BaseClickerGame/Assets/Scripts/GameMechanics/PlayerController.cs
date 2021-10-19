using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GameMechanics
{
    public class PlayerController : MonoBehaviour
    {
        private UI.Stats stats;
        private Camera cam;
        private int score = 0;
        private int misses = 0;
        private int missclicks = 0;
        // Start is called before the first frame update
        void Start()
        {
            cam = Camera.main;
            stats = FindObjectOfType<UI.Stats>();

        }
            void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var position = cam.ScreenToWorldPoint(Input.mousePosition);
                var connect = Physics2D.OverlapPoint(position);
                if (connect != null && connect.GetComponent<Planet>())
                {
                    Destroy(connect.gameObject);
                    score += 1;
                    stats.ScoreText(score);
                }
                else if (connect == null)
                {
                    missclicks += 1;
                    stats.MissclicksText(missclicks);
                }
            } 
        }
        public void PlanetUnClicked()
        {
            misses += 1;
            stats.MissedPlanetsText(misses);
        }
    }
}

