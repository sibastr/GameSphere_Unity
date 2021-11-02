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
        private float position_z = -1;
        public Coroutine AsteroidCoroutine;
        public int AsteroidDirection;
        private Vector3 currentEulerAngles;
        private Quaternion currentRotation;


        // Start is called before the first frame update
        void Start()
        {
            cam = Camera.main;
            height = 2f * cam.orthographicSize;
            width = height * cam.aspect;

            AsteroidCoroutine = StartCoroutine(Move());
        }

        private IEnumerator Move()
        {   
            while (true)
            {
    
                gameObject.transform.position = new Vector3(gameObject.transform.position.x - AsteroidDirection * startSpeed, gameObject.transform.position.y, position_z);
                    
                currentEulerAngles += new Vector3(gameObject.transform.rotation.x,
                    gameObject.transform.rotation.y, gameObject.transform.rotation.z - AsteroidDirection * rotation) * Time.deltaTime * rotationSpeed;
                currentRotation.eulerAngles = currentEulerAngles;
                transform.rotation = currentRotation;

                    
                if (gameObject.transform.position.x > width)
                { 
                    Destroy(gameObject);
                }
                yield return null;
            }
        }
    }
}
