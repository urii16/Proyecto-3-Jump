using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]

public class RepeatBackground : MonoBehaviour
{

    private Vector3 startPos;
    private float witdh;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        witdh = GetComponent<BoxCollider>().size.x/2;
    }

    // Update is called once per frame
    void Update()
    {
        if(startPos.x - transform.position.x > witdh)
        {
            transform.position = startPos;
        }
    }
}
