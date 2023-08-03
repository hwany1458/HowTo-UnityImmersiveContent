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
        // carMats 배열을 자동차 바디 오브젝트의 수만큼 초기화한다.
        carMats = new Material[bodyObject.Length];

        // 자동차 바디 오브젝트의 매터리얼 각각을 carMats 배열에 지정한다.
        for (int i = 0; i < carMats.Length; i++)
        {
            carMats[i] = bodyObject[i].GetComponent<MeshRenderer>().material;
        }

        // 색상 배열 0번에는 매터리얼의 초기 색상을 저장한다.
        colors[0] = carMats[0].color;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeColor(int num)
    {
        // 각 LOD 매터리얼의 색상을 버튼에 지정된 색상으로 변경한다.
        for (int i = 0; i < carMats.Length; i++)
        {
            carMats[i].color = colors[num];
        }
    }

}
