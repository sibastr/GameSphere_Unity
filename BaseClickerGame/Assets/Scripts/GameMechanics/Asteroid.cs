using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GameMechanics
{
    public class Asteroid : MonoBehaviour
    {
        [SerializeField] private float rotation;
        [SerializeField] private float startSpeed;
        [SerializeField] private float rotationSpeed;
        private Camera cam;
        private float height;
        private float width;
        public Coroutine AsteroidCoroutine;
        public int AsteroidDirection;
        private Vector3 currentEulerAngles;
        private Quaternion currentRotation;
        private Rigidbody2D rb;


        void Start()
        {
            cam = Camera.main;
            height = 2f * cam.orthographicSize;
            width = height * cam.aspect * 0.6f;
            
            rb = GetComponent<Rigidbody2D>();
            AsteroidCoroutine = StartCoroutine(Move());
        }

        private IEnumerator Move()
        {
            rb.AddForce(new Vector2(-AsteroidDirection * startSpeed, 0));
            while (true)
            {
                currentEulerAngles += new Vector3(gameObject.transform.rotation.x,
                    gameObject.transform.rotation.y, gameObject.transform.rotation.z + AsteroidDirection * rotation) * Time.deltaTime * rotationSpeed;
                currentRotation.eulerAngles = currentEulerAngles;
                transform.rotation = currentRotation;


                if ((gameObject.transform.position.x > width && AsteroidDirection == -1) || (gameObject.transform.position.y > height || gameObject.transform.position.x < -height))
                {
                    Destroy(gameObject);
                }
                else if ((gameObject.transform.position.x < -width && AsteroidDirection == 1) || (gameObject.transform.position.y > height || gameObject.transform.position.x < -height))
                {
                    Destroy(gameObject);
                }

                yield return null;
            }
        }
    }
}
