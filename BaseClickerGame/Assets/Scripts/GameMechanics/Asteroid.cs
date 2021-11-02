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

        // Update is called once per frame
        void Update()
        {

        }
        private IEnumerator Move()
        {   
            while (true)
            {
                if (true)
                {
                    gameObject.transform.position = new Vector3(gameObject.transform.position.x + startSpeed, gameObject.transform.position.y, position_z);
                    /*
                    Vector3 to = new Vector3(0, 0, rotation);
                    transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, to, Time.deltaTime);
                    transform.Rotate(gameObject.transform.rotation.x,
                        gameObject.transform.rotation.y, gameObject.transform.rotation.z - rotation);
                    */
                    currentEulerAngles += new Vector3(gameObject.transform.rotation.x,
                        gameObject.transform.rotation.y, gameObject.transform.rotation.z - rotation) * Time.deltaTime * rotationSpeed;
                    currentRotation.eulerAngles = currentEulerAngles;
                    transform.rotation = currentRotation;

                    //print(gameObject.transform.position.x);
                    if (gameObject.transform.position.x > width)
                    {
                        //print(gameObject.transform.position.x);
                        Destroy(gameObject);
                    }
                }
                else
                {

                }
                yield return null;
            }
        }
    }
}
