using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShojihinButtonSet : MonoBehaviour
{
    public Button[] shojihinButtons;

    [ContextMenu("Setup")]
    private void Setup()
    {
        shojihinButtons = GetComponentsInChildren<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
