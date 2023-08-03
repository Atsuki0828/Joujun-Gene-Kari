using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCameraAct : MonoBehaviour
{
    private Camera cam;
    private Vector3 startPos;
    private float fmoveZ;
    private float bmoveZ;
    private float fmoveX;
    private float bmoveX;
    private float fmoveY;
    private float bmoveY;
    private float sensitiveMove = 30.0f;
    private float sensitiveZoom = 100.0f;

    bool isClicked;

    // Start is called before the first frame update
    void Start()
    {
        startPos = this.transform.position;

        cam = GetComponent<Camera>();

        isClicked = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (WindowScript.isDragging) return;

        if (cam == null)
        {
            return;
        }

        if (isClicked)
        {
            if (Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                bmoveZ = Input.GetAxis("Mouse ScrollWheel") * sensitiveZoom;
                fmoveZ = 0;
            }
            else
            {
                bmoveZ = 0;
                fmoveZ = Input.GetAxis("Mouse ScrollWheel") * sensitiveZoom;
            }

            if (Input.GetMouseButton(0))
            {
                if (Input.GetAxis("Mouse X") < 0)
                {
                    fmoveX = Input.GetAxis("Mouse X") * sensitiveMove;
                    bmoveX = 0;
                }
                else
                {
                    fmoveX = 0;
                    bmoveX = Input.GetAxis("Mouse X") * sensitiveMove;
                }

                if (Input.GetAxis("Mouse Y") < 0)
                {
                    fmoveY = Input.GetAxis("Mouse Y") * sensitiveMove;
                    bmoveY = 0;
                }
                else
                {
                    fmoveY = 0;
                    bmoveY = Input.GetAxis("Mouse Y") * sensitiveMove;
                }
                if (cam.transform.position.x > 395)
                {
                    cam.transform.localPosition -= new Vector3(bmoveX, 0.0f, 0.0f);
                }
                else if (cam.transform.position.x < -400)
                {
                    cam.transform.localPosition -= new Vector3(fmoveX, 0.0f, 0.0f);
                }
                else if (cam.transform.position.y > 227)
                {
                    cam.transform.localPosition -= new Vector3(0.0f, bmoveY, 0.0f);
                }
                else if (cam.transform.position.y < -223)
                {
                    cam.transform.localPosition -= new Vector3(0.0f, fmoveY, 0.0f);
                }
                else
                {
                    cam.transform.localPosition -= new Vector3(fmoveX + bmoveX, fmoveY + bmoveY, 0.0f);
                }


                // move camera
                //float moveX = Input.GetAxis("Mouse X") * sensitiveMove;
                //float moveY = Input.GetAxis("Mouse Y") * sensitiveMove;
                //cam.transform.localPosition -= new Vector3(moveX, moveY, 0.0f);
            }
            else if (Input.GetMouseButton(1))
            {

            }

            if (Input.GetKeyDown(KeyCode.H)) //Hを押すとカメラが最初の位置に戻る。
            {
                cam.transform.position = startPos;
            }

            // zoom camera

            //Vector3 a;
            //a.x = cam.transform.position.x;
            //a.z = cam.transform.position.z;

            //a = cam.transform.position;

            //cam.transform.position = a;
            if (cam.transform.position.z > 370)
            {
                cam.transform.position += cam.transform.forward * bmoveZ;
            }
            else if (cam.transform.position.z < 30)
            {
                cam.transform.position += cam.transform.forward * fmoveZ;
            }
            else
            {
                cam.transform.position += cam.transform.forward * fmoveZ;
                cam.transform.position += cam.transform.forward * bmoveZ;

            }
        }





        //cam.transform.position += cam.transform.forward * moveY;
    }


    public void Onwindow()
    {
        isClicked = false;
    }
    public void Exitwindow()
    {
        isClicked = true;
    }

    
}