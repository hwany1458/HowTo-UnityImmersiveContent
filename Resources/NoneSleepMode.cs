using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoneSleepMode : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // �� ���� �߿��� ���� ���� ��ȯ���� �ʵ��� �����Ѵ�.
        Screen.sleepTimeout = SleepTimeout.NeverSleep;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
