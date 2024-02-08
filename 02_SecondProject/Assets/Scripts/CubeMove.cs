using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello world.");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, 0, 1);
    }
}
