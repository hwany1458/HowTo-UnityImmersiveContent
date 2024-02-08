using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [HideInInspector]
    public static int resource;


    //public Text score;
    // unity version이 올라감에 따라, UI text를 쓰기 보다는 TextMeshPro를 사용하는게 나을 듯
    public TextMeshProUGUI resourceText;

    // Start is called before the first frame update
    void Start()
    {
        // public으로 선언해서 (따로) GetComponent<>()를 할 필요 없음
        //resourceText = GetComponent<TextMeshProUGUI>();
        resource = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Score : " + resource.ToString());
        resourceText.text = "Score : " + resource.ToString();
    }

    public int GetResource()
    {
        return resource;
    }

    public static void AddResource(int addCount)
    {
        resource += addCount;
    }

    public static void AddResource()
    {
        resource++;
    }
}
