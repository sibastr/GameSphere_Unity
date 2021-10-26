using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace GameMechanics
{
    public class PlayerController : MonoBehaviour
    {
        private UI.Stats stats;
        private Camera cam;
        private int score = 0;
        private int misses = 0;
        private int missclicks = 0;
        [SerializeField] private float timer;

        private AsteroidSpawner asteroidSpawner;
        private PlanetSpawner planetSpawner;
        //private Coroutine _spawnAsteroidCoroutine;
        //private Coroutine _spawnPlanetsCoroutine;
        private Coroutine _clicksCoroutine;
        private Coroutine _timerCoroutine;
        private string mode;
        // Start is called before the first frame update
        /*void Start()
        {
            cam = Camera.main;
            stats = FindObjectOfType<UI.Stats>();

        }*/
        /*void Update()
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
        }*/
        public void ClassicStart()
        {
            cam = Camera.main;
            mode = "classic";
            stats = FindObjectOfType<UI.Stats>();
            asteroidSpawner = FindObjectOfType<AsteroidSpawner>();
            planetSpawner = FindObjectOfType<PlanetSpawner>();
            asteroidSpawner.AsteroidStart();
            planetSpawner.PlanetStart();
            
            StartCoroutine(Clicks(mode));
            
        }
        public void TimeModeStart()
        {
            cam = Camera.main;
            mode = "time";
            stats = FindObjectOfType<UI.Stats>();
            asteroidSpawner = FindObjectOfType<AsteroidSpawner>();
            planetSpawner = FindObjectOfType<PlanetSpawner>();
            asteroidSpawner.AsteroidStart();
            planetSpawner.PlanetStart();

            _clicksCoroutine = StartCoroutine(Clicks(mode));
            _timerCoroutine = StartCoroutine(Timer());

        }

        private IEnumerator Clicks(string mode)
        {

            while (true)
            {
                    if (Input.GetMouseButtonDown(0))
                {
                    var position = cam.ScreenToWorldPoint(Input.mousePosition);
                    var connect = Physics2D.OverlapPoint(position);
                    if (connect != null && connect.GetComponent<Planet>())
                    {
                        Destroy(connect.gameObject);
                        score += 1;
                        stats.ScoreText(score, mode);
                    }
                    else if (connect == null)
                    {
                        missclicks += 1;
                        stats.MissclicksText(missclicks, mode);
                    }
                }
                yield return null;
            }
        }
        private IEnumerator Timer()
        {
            var counterTime = timer;

            while (counterTime > 0)
            {
                counterTime -= Time.deltaTime;
                stats.TimerText((int)Math.Ceiling(counterTime));

                yield return null;
            }
            GameEnd();
            StopCoroutine(_timerCoroutine);


        }
        private void GameEnd()
        {
            StopCoroutine(planetSpawner._spawnPlanetCoroutine);
            StopCoroutine(asteroidSpawner._spawnAsteroidCoroutine);
            StopCoroutine(_clicksCoroutine);
            var asteroidobjects = FindObjectsOfType<Asteroid>();
            var planetobjects = FindObjectsOfType<Planet>();
            foreach (var a in asteroidobjects)
            {
                Destroy(a.gameObject);
            }
            foreach (var b in planetobjects)
            {
                Destroy(b.gameObject);
            }

        }
        public void PlanetUnClicked()
        {
            misses += 1;
            stats.MissedPlanetsText(misses, mode);
        }
    }
}

