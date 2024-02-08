using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetObjectCollision : MonoBehaviour
{
    // 오브젝트 제거 파티클
    public Transform explosion;

    // AudioSource를 저장할 변수 선언
    AudioSource objectDestroySound;

    //----------------------------------------
    // Start is called before the first frame update
    void Start()
    {
        // 시작할 때 컴포넌트 열기
        objectDestroySound = GetComponent<AudioSource>();  // 씬이 로딩되면 AudioSource를 변수로 읽어 들임

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DestroySelf(Vector3 pos)
    {
        //Debug.Log("DestroySelf method is called...");

        // 사운드(음향효과), 파티클, 점수 획득 등

        // 사운드(음향효과) -----------
        // AudioSource에 할당된 오디오 클립을 재생
        objectDestroySound.Play();


        // 파티클 -------------
        // 오브젝트 제거 시점에서 파티클 실행
        //Instantiate(explosion, pos, Quaternion.identity);
        // 파티클 오브젝트 생성 후, 삭제되지 않는다면 이렇게
        Transform parti = Instantiate(explosion, pos, Quaternion.identity);
        // Delay(지연)을 줘서 오브젝트 제거(destroy)
        Destroy(parti.gameObject, 2);

        // 객체 제거 --------------
        //Destroy(gameObject);
        // 오브젝트 제거 대신에, 오브젝트가 화면에 안보이게
        gameObject.SetActive(false);

        // 아이템 획득 수(score)를 올려줌
        GameManager.AddResource();

    }
}
