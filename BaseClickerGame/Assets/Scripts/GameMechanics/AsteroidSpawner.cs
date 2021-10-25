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

        [SerializeField] GameObject AsteroidPrefab;
        // Start is called before the first frame update
        void Start()
        {
            Vector2 local_sprite_size = AsteroidPrefab.GetComponent<SpriteRenderer>().sprite.rect.size / AsteroidPrefab.GetComponent<SpriteRenderer>().sprite.pixelsPerUnit;

            fixedBorder = local_sprite_size.y / 2 * AsteroidPrefab.transform.localScale.y;
            cam = Camera.main;
            height = 2f * (cam.orthographicSize - fixedBorder);
            width = height * cam.aspect;

            StartCoroutine(SpawnAsteroids());
            
        }

        // Update is called once per frame
        void Update()
        {

        }
        private IEnumerator SpawnAsteroids()
        {
            while (true)
            {
                yield return new WaitForSeconds(spawnTimerForStart);
                var counterTime = 0f;
                while (counterTime < spawnTimerForStart)
                {
                   
                    var AsteroidPosition = new Vector3(-0.6f * width, (float)(rand.NextDouble() - 0.5) * height, -1);
                    var Asteroid = Instantiate(AsteroidPrefab, AsteroidPosition, Quaternion.identity);
                    counterTime += Time.deltaTime;
                    yield return new WaitForSeconds(spawnTimerBetweenAsteroids);
                }
            }
        }
    }
}
