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

    float x;
    float y;

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
        if (CamLock == false && Input.GetMouseButtonDown(0))
            touchStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (CamLock == false && Input.GetMouseButton(0))
        {
            Vector3 direction = touchStart - Camera.main.ScreenToWorldPoint(Input.mousePosition);

            x += direction.x;
            y += direction.y;
            x = Mathf.Clamp(x, -12f, 17);
            y = Mathf.Clamp(y, -2.5f, 23);

            Vector3 clamp = new Vector3(x, y, -754f);

            Cam.transform.position = clamp;
        }   
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
