using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("JUMP, Space bar is pressed");
        }

        if (Input.GetButton("Jump"))
        {
            Debug.Log("JUMP, Space bar is pressing ..");
        }

        if (Input.GetButtonUp("Jump"))
        {
            Debug.Log("JUMP, Space bar is pressed .. keyboard releaseed.");
        }

    }
}
