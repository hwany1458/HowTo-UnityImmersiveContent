using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    public GameObject[] bodyObject;
    public Color32[] colors;

    Material[] carMats;


    // Start is called before the first frame update
    void Start()
    {
        // carMats �迭�� �ڵ��� �ٵ� ������Ʈ�� ����ŭ �ʱ�ȭ�Ѵ�.
        carMats = new Material[bodyObject.Length];

        // �ڵ��� �ٵ� ������Ʈ�� ���͸��� ������ carMats �迭�� �����Ѵ�.
        for (int i = 0; i < carMats.Length; i++)
        {
            carMats[i] = bodyObject[i].GetComponent<MeshRenderer>().material;
        }

        // ���� �迭 0������ ���͸����� �ʱ� ������ �����Ѵ�.
        colors[0] = carMats[0].color;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeColor(int num)
    {
        // �� LOD ���͸����� ������ ��ư�� ������ �������� �����Ѵ�.
        for (int i = 0; i < carMats.Length; i++)
        {
            carMats[i].color = colors[num];
        }
    }

}
