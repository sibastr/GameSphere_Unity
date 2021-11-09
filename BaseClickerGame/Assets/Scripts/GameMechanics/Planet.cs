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
        [SerializeField] private ParticleSystem particle;
        [SerializeField] private GameObject planetExplosion;
        private Coroutine colorandDestroy;




        private PlayerController playercontroller;
        private System.Random rand = new System.Random();

        // Start is called before the first frame update
        void Start()
        {
            playercontroller = FindObjectOfType<PlayerController>();
            colorandDestroy = StartCoroutine(ColorandDestroy());
        }

        public void PlanetClicked()
        {
            StartCoroutine(PlanetClickedDestroy());
        }


        public IEnumerator PlanetClickedDestroy()
        {
            //particle.Play();
            StopCoroutine(colorandDestroy);
            Instantiate(particle, gameObject.transform.position, Quaternion.identity);
            
            
            var a = Instantiate(planetExplosion, gameObject.transform.position, Quaternion.identity);
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;

            yield return new WaitForSeconds(0.5f);
            if (gameObject != null)
            {
                
                Destroy(gameObject);
            }
            Destroy(a.gameObject);
        }

        private IEnumerator ColorandDestroy()
        {
            var counterTime = 0f;
            Color planetColor = new Color((float)rand.NextDouble(), (float)rand.NextDouble(), (float)rand.NextDouble());
            
            planetSprite.color = planetColor;
            var deltaColor = Color.red - planetColor;
            var deltaScale = new Vector3(Scalemultiplier * transform.lossyScale.x, Scalemultiplier * transform.lossyScale.y, 1) - transform.localScale;

            while (counterTime < destroyTime)
            {
                counterTime += Time.deltaTime;

                planetSprite.color += deltaColor * Time.deltaTime / destroyTime;
                transform.localScale += deltaScale * Time.deltaTime / destroyTime;

                

                yield return null;
                
            }
            playercontroller.PlanetUnClicked();
            Destroy(gameObject);

        }
    }
}
