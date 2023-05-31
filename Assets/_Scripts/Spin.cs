using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{

    public float speedRotation = 500f;
    public float translateSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition += Vector3.left * translateSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up * speedRotation * Time.deltaTime);
    }
}
