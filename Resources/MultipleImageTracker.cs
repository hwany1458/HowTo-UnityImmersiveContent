using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;

public class MultipleImageTracker : MonoBehaviour
{
    ARTrackedImageManager imageManager;
    public Text logText;


    // Start is called before the first frame update
    void Start()
    {
        imageManager = GetComponent<ARTrackedImageManager>();

        // �̹��� �ν� ��������Ʈ�� ����� �Լ��� �����Ѵ�. 
        imageManager.trackedImagesChanged += OnTrackedImage;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    string test = "�̹���=";

    public void OnTrackedImage(ARTrackedImagesChangedEventArgs args)
    {
        //logText.text = "OnTrackedImage ";

        // ���� �ν��� �̹������� ��� ��ȸ�Ѵ�.
        foreach (ARTrackedImage trackedImage in args.added)
        {
            // �̹��� ���̺귯������ �ν��� �̹����� �̸��� �о�´�.
            string imageName = trackedImage.referenceImage.name;

            test += imageName;

            // Resources �������� �ν��� �̹����� �̸��� ������ �̸��� �������� ã�´�.
            GameObject imagePrefab = Resources.Load<GameObject>(imageName);

            // ����, �˻��� �������� �����Ѵٸ�... 
            if (imagePrefab != null)
            {
                //---- �̳���
                // �̹����� ��ġ�� �������� �����Ѵ�.
                //GameObject go = Instantiate(imagePrefab, trackedImage.transform.position, trackedImage.transform.rotation);
                //----- �̷���
                // �̹����� ��ϵ� �ڽ� ������Ʈ�� ���ٸ�...
                if (trackedImage.transform.childCount < 1)
                {
                    // �̹����� ��ġ�� �������� �����ϰ� �̹����� �ڽ� ������Ʈ�� ����Ѵ�.
                    GameObject go = Instantiate(imagePrefab, trackedImage.transform.position, trackedImage.transform.rotation);
                    go.transform.SetParent(trackedImage.transform);
                }
                //------
            }

            
        }

        logText.text = test;

        // �ν� ���� �̹������� ��� ��ȸ�Ѵ�.
        foreach (ARTrackedImage trackedImage in args.updated)
        {
            // �̹����� ��ϵ� �ڽ� ������Ʈ�� �ִٸ�...
            if (trackedImage.transform.childCount > 0)
            {
                //�ڽ� ������Ʈ�� ��ġ�� �̹����� ��ġ�� ����ȭ�Ѵ�.
                trackedImage.transform.GetChild(0).position = trackedImage.transform.position;
                trackedImage.transform.GetChild(0).rotation = trackedImage.transform.rotation;
            }
        }


    }

}
