using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAct : MonoBehaviour
{
    private Camera cam;
    private Vector3 startPos;
    private float MmoveY;
    private float PmoveY;
    [SerializeField]
    private float McamerazoomFoV;//field of view
    [SerializeField]
    private float PcamerazoomFoV;
    // Start is called before the first frame update
    void Start()
    {
        startPos = this.transform.position;

        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (cam == null)
        {
            return;
        }

        float sensitiveMove = 3.0f;
        float sensitiveZoom = 10.0f;
        //float FoVZoom = 1.0f;

        if (Input.GetMouseButton(0))
        {
            // move camera
            float moveX = Input.GetAxis("Mouse X") * sensitiveMove;
            float moveZ = Input.GetAxis("Mouse Y") * sensitiveMove;
            
            cam.transform.localPosition -= new Vector3(moveX, 0.0f, moveZ);

        }
        else if (Input.GetMouseButton(1))
        {

        }

        if (Input.GetKeyDown(KeyCode.H)) //Hを押すとカメラが最初の位置に戻る。
        {
            cam.transform.position = startPos;
        }

        // zoom camera



        //カメラズームスクリプト ボツ<=間違い

        float moveY = Input.GetAxis("Mouse ScrollWheel") * sensitiveZoom;
        if (moveY >= 0)
        {
            MmoveY = moveY;
        }
        else
        {
            PmoveY = moveY;
        }
        if (1 * moveY + cam.transform.position.y > 130)
        {
            cam.transform.position += cam.transform.forward * MmoveY;
        }
        else if (1 * moveY + cam.transform.position.y < 1)
        {
            cam.transform.position += cam.transform.forward * PmoveY;
        }
        else
        {
            cam.transform.position += cam.transform.forward * moveY;
        }

    }
}
