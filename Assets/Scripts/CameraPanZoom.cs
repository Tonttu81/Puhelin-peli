 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraPanZoom : MonoBehaviour
{
    public float MaxZoom = 1;
    public float MinZoom = 8;
    public bool CamLock;
    public GameObject CamButton1;
    public GameObject CamButton2;

    CinemachineVirtualCamera Cam;

    Vector3 touchStart;
    // Start is called before the first frame update
    void Start()
    {
        Cam = GetComponent<CinemachineVirtualCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CamLock == false && Input.touchCount == 2)
        {
            Touch Zero = Input.GetTouch(0);
            Touch One = Input.GetTouch(1);

            Vector2 TouchZeroPrevPos = Zero.position - Zero.deltaPosition;
            Vector2 TouchOnePrevPos = One.position - One.deltaPosition;

            float PrevMagnitute = (TouchZeroPrevPos = TouchOnePrevPos).magnitude;
            float CurrentMagnitute = (Zero.position - One.position).magnitude;

            float difference = CurrentMagnitute - PrevMagnitute;


            Zoom(difference * 0.01f);
        }
        if (CamLock == false && Input.GetMouseButtonDown(0))
            touchStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (CamLock == false && Input.GetMouseButton(0))
        {
            Vector3 direction = touchStart - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Cam.transform.position += direction;
        }   
    }

    public void Zoom(float increment)
    {
        Cam.m_Lens.OrthographicSize = Mathf.Clamp(Camera.main.orthographicSize - increment, MinZoom, MaxZoom);
    }

    public void CamLocker()
    {       
        CamLock = !CamLock;

        if (CamLock == true)
        {
            CamButton1.SetActive(true);
            CamButton2.SetActive(false);
        }
        else if (CamLock == false)
        {
            CamButton1.SetActive(false);
            CamButton2.SetActive(true);
        }
    }
}
