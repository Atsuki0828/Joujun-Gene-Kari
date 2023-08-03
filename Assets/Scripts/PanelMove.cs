using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelMove : MonoBehaviour
{
    public Camera mainCamera;

    private void Update()
    {
        var origin = mainCamera.transform.position;
        //var hits = Physics2D.RaycastAll(origin, mainCamera.transform.forward);
        var clickPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        var hits = Physics2D.RaycastAll(clickPos, mainCamera.transform.forward);
        //Debug.Log(Input.mousePosition);
        Debug.Log(clickPos);
        foreach (var hit in hits)
        {
            Debug.Log($"Hit: {hit}");
        }
    }
}
