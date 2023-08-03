using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.EventSystems;


public class ObjectManager : MonoBehaviour
{
    ARRaycastManager arManager;
    public GameObject indicator;  // indicator 객체 활성화 또는 위치조정을 위한 변수

    public GameObject myCar;
    GameObject placedObject;  // 현재 생성된 오브젝트가 있는지 판별하기 위한 변수

    public float relocationDistance = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        // 인디케이터 비활성화
        indicator.SetActive(false);

        // AR Raycase Manager 가져오기
        arManager = GetComponent<ARRaycastManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // 바닥 감지 및 표식 출력 함수
        DetectGround();

        /*
        // 만일, 버튼을 터치했다면, 업데이트를 종료한다.
        if (EventSystem.current.currentSelectedGameObject)
        {
            return;
        }
        */
        // 인디케이터가 활성화 중일 때 화면을 터치하면 자동차 모델링이 생성되게 하고 싶다!

        // 만일, 인디케이터가 활성화 중이면서 화면 터치가 있는 상태라면...
        if (indicator.activeInHierarchy && Input.touchCount > 0)
        {
            // 첫 번째 터치 상태를 가져온다.
            Touch touch = Input.GetTouch(0);

            // 만일, 터치가 시작된 상태라면 자동차를 인디케이터와 동일한 곳에 생성한다.
            if (touch.phase == TouchPhase.Began)
            {
                //--------------
                //Instantiate(myCar, indicator.transform.position, indicator.transform.rotation);
                //-------------- 이렇게 수정
                // 만일 생성된 오브젝트가 없다면 프리팹을 씬에 생성하고, placedObject 변수에 할당한다.
                if (placedObject == null)
                {
                    placedObject = Instantiate(myCar, indicator.transform.position, indicator.transform.rotation);
                }
                // 생성된 오브젝트가 있다면 그 오브젝트의 위치와 회전 값을 변경한다.
                else
                {
                    // 이렇게 변경--------------
                    //placedObject.transform.SetPositionAndRotation(indicator.transform.position, indicator.transform.rotation);
                    // 만일 생성된 오브젝트와 인디케이터 사이의 거리가
                    // 최소 이동 범위 이상이라면...
                    if (Vector3.Distance(placedObject.transform.position, indicator.transform.position) > relocationDistance)
                    {
                        placedObject.transform.SetPositionAndRotation(indicator.transform.position, indicator.transform.rotation);
                    }


                    //---------------
                }
                //--------------

            }

        }

    }

    void DetectGround()
    {
        // 스크린 중앙 지점을 찾는다.
        Vector2 screenSize = new Vector2(Screen.width * 0.5f, Screen.height * 0.5f);

        // 레이에 부딪힌 대상들의 정보를 저장할 리스트 변수를 만든다.
        List<ARRaycastHit> hitInfos = new List<ARRaycastHit>();

        // 만일, 스크린 중앙 지점에서 레이를 발사하였을 때 Plane 타입 추적 대상이 있다면...
        if (arManager.Raycast(screenSize, hitInfos, TrackableType.Planes))
        {
            // 표식 오브젝트를 활성화한다.
            indicator.SetActive(true);

            // 표식 오브젝트의 위치 및 회전 값을 레이가 닿은 지점에 일치시킨다.
            indicator.transform.position = hitInfos[0].pose.position;
            indicator.transform.rotation = hitInfos[0].pose.rotation;

            // 위치를 위쪽 방향으로 0.1미터 올린다.
            indicator.transform.position += indicator.transform.up * 0.1f;

        }
        // 그렇지 않다면 표식 오브젝트를 비활성화한다.
        else
        {
            indicator.SetActive(false);
        }

    }

}
