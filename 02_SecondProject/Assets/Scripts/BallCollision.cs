using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollision : MonoBehaviour
{
    // AudioSource�� ������ ���� ����
    AudioSource ballAudio;

    // Start is called before the first frame update
    void Start()
    {
        // ������ �� ������Ʈ ����
        ballAudio = GetComponent<AudioSource>();  // ���� �ε��Ǹ� AudioSource�� ������ �о� ����

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // �浹 ó�� �Լ�
    void OnCollisionEnter(Collision other)
    {
        Debug.Log("���� �浹�� ��ü =" + other.gameObject.name);
        // ������Ʈ �浹�� �߻��ϸ� ȣ��Ǵ� �̺�Ʈ �Լ�
        // �浹�� ����� ������ �Ű����� other�� ���޵�
        ballAudio.Play();   // AudioSource�� �Ҵ�� ����� Ŭ���� ���
    }

}
