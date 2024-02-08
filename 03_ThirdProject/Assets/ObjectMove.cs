using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMove : MonoBehaviour
{
    float moveSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 현재 프레임에서 이동할 거리
        float amount = moveSpeed * Time.deltaTime;

        // 전후(Vertical) 좌우(Horizontal) 이동키를 받음
        float vert = Input.GetAxis("Vertical");
        float horz = Input.GetAxis("Horizontal");

        // 오브젝트의 전방으로 이동
        transform.Translate(new Vector3(horz, 0, vert) * amount);   // 상대좌표

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger event is occurred..");
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision evernt is occurred");
        
        if (collision.gameObject.tag == "Item")
        {
            // 파괴(제거)
            //Destroy(collision.gameObject);
            // 안보이게
            //collision.gameObject.SetActive(false);
            collision.gameObject.SendMessage("DestroySelf", transform.position);
        }
    }

}
