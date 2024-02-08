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
        // ���� �����ӿ��� �̵��� �Ÿ�
        float amount = moveSpeed * Time.deltaTime;

        // ����(Vertical) �¿�(Horizontal) �̵�Ű�� ����
        float vert = Input.GetAxis("Vertical");
        float horz = Input.GetAxis("Horizontal");

        // ������Ʈ�� �������� �̵�
        transform.Translate(new Vector3(horz, 0, vert) * amount);   // �����ǥ

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
            // �ı�(����)
            //Destroy(collision.gameObject);
            // �Ⱥ��̰�
            //collision.gameObject.SetActive(false);
            collision.gameObject.SendMessage("DestroySelf", transform.position);
        }
    }

}
