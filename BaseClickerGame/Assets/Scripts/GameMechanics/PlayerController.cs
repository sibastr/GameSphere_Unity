using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GameMechanics
{
    public class PlayerController : MonoBehaviour
    {
        private Camera cam;
        // Start is called before the first frame update
        void Start()
        {
            cam = Camera.main;
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var position = cam.ScreenToWorldPoint(Input.mousePosition);
                var connect = Physics2D.OverlapPoint(position);
                if (connect != null && connect.GetComponent<Planet>())
                {
                    Destroy(connect.gameObject);
                }
            } 
        }
    }
}
