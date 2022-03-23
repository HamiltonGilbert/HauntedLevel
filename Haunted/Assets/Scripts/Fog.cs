using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fog : MonoBehaviour
{

    public float rotateSpeed;
    public float fallSpeed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //transform.Rotate(Vector3.back * rotateSpeed * Time.deltaTime);
        //transform.position -= Vector3.down * fallSpeed * Time.deltaTime;
        transform.position += Vector3.right * .5f * Time.deltaTime;
    }
}
