using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ChoosingFactionScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //public void OnclickTake()
    //{
    //    Debug.Log("筍");
    //    SceneManager.LoadScene("game");
    //    PlayerScript.Hanbetu = Faction.TAKENOKO;
        

    //}
    public void OnclickKino()
    {
        Debug.Log("茸");
        SceneManager.LoadScene("game");
        PlayerScript.Hanbetu = Faction.KINOKO;
    }
    public void OnclickTake()
    {
        Debug.Log("筍");
        SceneManager.LoadScene("game");
        PlayerScript.Hanbetu = Faction.TAKENOKO;
    }
}
