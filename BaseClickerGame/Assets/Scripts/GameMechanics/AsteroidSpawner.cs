using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace GameMechanics
{
    public class AsteroidSpawner : MonoBehaviour
    {
        [SerializeField] float spawnTimerForStart;
        [SerializeField] float spawnTimerBetweenAsteroids;
        private System.Random rand = new System.Random();
        private Camera cam;
        private float height;
        private float width;
        private float fixedBorder;
        public Coroutine _spawnAsteroidCoroutine;


        [SerializeField] GameObject AsteroidPrefab;
       
        public void AsteroidStart()
        {
            Vector2 local_sprite_size = AsteroidPrefab.GetComponent<SpriteRenderer>().sprite.rect.size / AsteroidPrefab.GetComponent<SpriteRenderer>().sprite.pixelsPerUnit;

            fixedBorder = local_sprite_size.y / 2 * AsteroidPrefab.transform.localScale.y;
            cam = Camera.main;
            height = 2f * (cam.orthographicSize - fixedBorder);
            width = height * cam.aspect;


            _spawnAsteroidCoroutine = StartCoroutine(SpawnAsteroids());
            
        }


        public void StopSpawn()
        {
            StopCoroutine(_spawnAsteroidCoroutine);

        }

        public IEnumerator SpawnAsteroids()
        {
            while (true)
            {
                yield return new WaitForSeconds(spawnTimerForStart);
                var counterTime = 0f;
                while (counterTime < spawnTimerForStart)
                {
                    var pos = rand.Next(2);
                    var poscoef = 0;
                    if (pos == 0)
                    {
                        poscoef = -1;
                    }
                    else
                    {
                        poscoef = 1;
                    }
                    var AsteroidPosition = new Vector3(poscoef *0.6f * width, (float)(rand.NextDouble() - 0.5) * height, -1);
                    var asteroid = Instantiate(AsteroidPrefab, AsteroidPosition, Quaternion.identity);
                    asteroid.GetComponent<Asteroid>().AsteroidDirection = poscoef;
                    counterTime += Time.deltaTime;
                    yield return new WaitForSeconds(spawnTimerBetweenAsteroids);
                }
            }
        }
    }
}
