using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace GameMechanics
{
    public class Planet : MonoBehaviour
    {
        
        [SerializeField] private SpriteRenderer planetSprite;
        [SerializeField] private float destroyTime;
        [SerializeField] private float planetScaleIncrease;
        [SerializeField] public float Scalemultiplier = 1.5f;

        private PlayerController playercontroller;
        private System.Random rand = new System.Random();
        // Start is called before the first frame update
        void Start()
        {
            playercontroller = FindObjectOfType<PlayerController>();
            StartCoroutine(ColorandDestroy());
        }

        // Update is called once per frame
        void Update()
        {

        }
        private IEnumerator ColorandDestroy()
        {
            var counterTime = 0f;
            Color planetColor = new Color((float)rand.NextDouble(), (float)rand.NextDouble(), (float)rand.NextDouble());
            //var deltaColor = Color.red - planetSprite.color;
            planetSprite.color = planetColor;
            var deltaColor = Color.red - planetColor;
            var deltaScale = new Vector3(Scalemultiplier * transform.lossyScale.x, Scalemultiplier * transform.lossyScale.y, 1) - transform.localScale;

            while (counterTime < destroyTime)
            {
                counterTime += Time.deltaTime;

                planetSprite.color += deltaColor * Time.deltaTime / destroyTime;
                transform.localScale += deltaScale * Time.deltaTime / destroyTime;

                //Vector2 Increase = new Vector2(transform.localScale.x + planetScaleIncrease, transform.localScale.x + planetScaleIncrease);
                //transform.localScale = Increase;

                yield return null;
                
            }
            playercontroller.PlanetUnClicked();
            Destroy(gameObject);

        }
    }
}
