using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollision : MonoBehaviour
{
    // AudioSource를 저장할 변수 선언
    AudioSource ballAudio;

    // Start is called before the first frame update
    void Start()
    {
        // 시작할 때 컴포넌트 열기
        ballAudio = GetComponent<AudioSource>();  // 씬이 로딩되면 AudioSource를 변수로 읽어 들임

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 충돌 처리 함수
    void OnCollisionEnter(Collision other)
    {
        Debug.Log("공과 충돌한 객체 =" + other.gameObject.name);
        // 오브젝트 충돌이 발생하면 호출되는 이벤트 함수
        // 충돌의 상대편 정보가 매개변수 other로 전달됨
        ballAudio.Play();   // AudioSource에 할당된 오디오 클립을 재생
    }

}
