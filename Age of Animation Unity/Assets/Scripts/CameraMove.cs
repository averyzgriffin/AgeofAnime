﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

    public KeyCode left_key;
    public KeyCode right_key;

    public float speed = 5f;

    public int bound;

    public GameObject L;
    public GameObject R;


    // Use this for initialization
    void Awake ()
    {
        transform.position = new Vector3(0, -2.4f, -5);
		
	}

    void Update()
    {
        float edgeSize = 30f;
        //Right bound
        if (gameObject.transform.position.x < R.transform.position.x + bound) 
        {
            if (Input.GetKey(right_key))
            {
                transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
            }


            if (Input.mousePosition.x > Screen.width - edgeSize)
            {
                transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
            }
        }

        //Left bound
        if (gameObject.transform.position.x > L.transform.position.x - bound)
        {
            if (Input.GetKey(left_key))
            {
                transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
            }
            
            if (Input.mousePosition.x < edgeSize)
            {
                transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
            }
        }  
    }
}
