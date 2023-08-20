using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSceneManager : MonoBehaviour
{
    public string SeiryokuName { get; private set; }
    // Start is called before the first frame update
    void Start()
    {

        SeiryokuName = NoBrokenScript.MySeiryokuName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
