using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetObjectCollision : MonoBehaviour
{
    // ������Ʈ ���� ��ƼŬ
    public Transform explosion;

    // AudioSource�� ������ ���� ����
    AudioSource objectDestroySound;

    //----------------------------------------
    // Start is called before the first frame update
    void Start()
    {
        // ������ �� ������Ʈ ����
        objectDestroySound = GetComponent<AudioSource>();  // ���� �ε��Ǹ� AudioSource�� ������ �о� ����

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DestroySelf(Vector3 pos)
    {
        //Debug.Log("DestroySelf method is called...");

        // ����(����ȿ��), ��ƼŬ, ���� ȹ�� ��

        // ����(����ȿ��) -----------
        // AudioSource�� �Ҵ�� ����� Ŭ���� ���
        objectDestroySound.Play();


        // ��ƼŬ -------------
        // ������Ʈ ���� �������� ��ƼŬ ����
        //Instantiate(explosion, pos, Quaternion.identity);
        // ��ƼŬ ������Ʈ ���� ��, �������� �ʴ´ٸ� �̷���
        Transform parti = Instantiate(explosion, pos, Quaternion.identity);
        // Delay(����)�� �༭ ������Ʈ ����(destroy)
        Destroy(parti.gameObject, 2);

        // ��ü ���� --------------
        //Destroy(gameObject);
        // ������Ʈ ���� ��ſ�, ������Ʈ�� ȭ�鿡 �Ⱥ��̰�
        gameObject.SetActive(false);

        // ������ ȹ�� ��(score)�� �÷���
        GameManager.AddResource();

    }
}
