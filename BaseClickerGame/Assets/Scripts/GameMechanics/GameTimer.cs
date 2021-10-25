using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace GameMechanics
{
    public class GameTimer : MonoBehaviour
    {
        [SerializeField] private float timer;

        private UI.Stats stats;

        // Start is called before the first frame update
        void Start()
        {
            stats = FindObjectOfType<UI.Stats>();
            StartCoroutine(Timer());
        }

        // Update is called once per frame
        void Update()
        {

        }
        private IEnumerator Timer()
        {
            double counterTime = timer;
            
            while (counterTime > 0)
            {
                counterTime -= Time.deltaTime;
                stats.TimerText((int)Math.Ceiling(counterTime));
                
                yield return null;
            }

        }

    }
}
