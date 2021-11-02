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
        private float position_z = -5;
        public Coroutine AsteroidCoroutine;
        public int AsteroidDirection;
        private Vector3 currentEulerAngles;
        private Quaternion currentRotation;
        private Rigidbody2D rb;


        // Start is called before the first frame update
        void Start()
        {
            cam = Camera.main;
            height = 2f * cam.orthographicSize;
            width = height * cam.aspect * 0.6f;
            //print(width);
            rb = GetComponent<Rigidbody2D>();
            AsteroidCoroutine = StartCoroutine(Move());
        }

        private IEnumerator Move()
        {   
            while (true)
            {

                //gameObject.transform.position = new Vector3(gameObject.transform.position.x - AsteroidDirection * startSpeed, gameObject.transform.position.y, position_z);
                rb.velocity = new Vector2(-AsteroidDirection * startSpeed, rb.velocity.y);

                currentEulerAngles += new Vector3(gameObject.transform.rotation.x,
                    gameObject.transform.rotation.y, gameObject.transform.rotation.z + AsteroidDirection * rotation) * Time.deltaTime * rotationSpeed;
                currentRotation.eulerAngles = currentEulerAngles;
                transform.rotation = currentRotation;


                if (gameObject.transform.position.x > width && AsteroidDirection == -1)
                {
                    Destroy(gameObject);
                }
                else if (gameObject.transform.position.x < -width && AsteroidDirection == 1)
                {
                    Destroy(gameObject);
                }

                yield return null;
            }
        }
    }
}
