using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace GameMechanics
{
    public class PlanetSpawner : MonoBehaviour
    {
        private System.Random rand = new System.Random();
        private Camera cam;
        private float height;
        private float width;
        private float fixedBorder;
        
        

        [SerializeField] GameObject PlanetPrefab;
        [SerializeField] float spawntimer;

        public Coroutine _spawnPlanetCoroutine;

        // Start is called before the first frame update
        /*void Start()
        {
            Vector2 local_sprite_size = PlanetPrefab.GetComponent<SpriteRenderer>().sprite.rect.size / PlanetPrefab.GetComponent<SpriteRenderer>().sprite.pixelsPerUnit;

            fixedBorder = local_sprite_size.y / 2 * PlanetPrefab.transform.localScale.y * PlanetPrefab.GetComponent<Planet>().Scalemultiplier;
            cam = Camera.main;
            height = 2f * (cam.orthographicSize - fixedBorder);
            width = height * cam.aspect;

            StartCoroutine(SpawnPlanets());
        }*/
        public void PlanetStart()
        {
            Vector2 local_sprite_size = PlanetPrefab.GetComponent<SpriteRenderer>().sprite.rect.size / PlanetPrefab.GetComponent<SpriteRenderer>().sprite.pixelsPerUnit;

            fixedBorder = local_sprite_size.y / 2 * PlanetPrefab.transform.localScale.y * PlanetPrefab.GetComponent<Planet>().Scalemultiplier;
            cam = Camera.main;
            height = 2f * (cam.orthographicSize - fixedBorder);
            width = height * cam.aspect;

            _spawnPlanetCoroutine = StartCoroutine(SpawnPlanets());

        }

        // Update is called once per frame
        void Update()
        {

        }
        public IEnumerator SpawnPlanets()
        {

            while (true)
            {
                var PlanetPosition = new Vector2((float)(rand.NextDouble() - 0.5) * width, (float)(rand.NextDouble() - 0.5) * height);
                var Planet = Instantiate(PlanetPrefab, PlanetPosition, Quaternion.identity);

                yield return new WaitForSeconds(spawntimer);
            }
        }
    }
}