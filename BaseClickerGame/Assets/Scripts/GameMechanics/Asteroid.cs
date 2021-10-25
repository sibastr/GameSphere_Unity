using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GameMechanics
{
    public class Asteroid : MonoBehaviour
    {
        [SerializeField] private float rotation;
        [SerializeField] private float startSpeed;
        private Camera cam;
        private float height;
        private float width;
        private float position_z = -1;

        // Start is called before the first frame update
        void Start()
        {
            cam = Camera.main;
            height = 2f * cam.orthographicSize;
            width = height * cam.aspect;

            StartCoroutine(Move());
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
                    
                    Vector3 to = new Vector3(0, 0, rotation);

                    transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, to, Time.deltaTime);

                    transform.Rotate(gameObject.transform.rotation.x,
                        gameObject.transform.rotation.y, gameObject.transform.rotation.z - rotation);

                    if (gameObject.transform.position.x > width)
                    {
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
