using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelectScript : MonoBehaviour
{

    public static int GameDifficultySet; //ゲームでの敵の強さ。この値が大きければ大きいほどより強くなる。



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("mainmenu");
        }
    }


    public void OnclickS1Button()
    {
        GameDifficultySet = 0;
        SceneManager.LoadScene("FactionSelect");
    }
    public void OnclickS2Button()
    {
        GameDifficultySet = 1;
        SceneManager.LoadScene("FactionSelect");

    }
    public void OnclickS3Button()
    {
        GameDifficultySet = 2;
        SceneManager.LoadScene("FactionSelect");

    }
    public void OnclickS4Button()
    {
        GameDifficultySet = 3;
        SceneManager.LoadScene("FactionSelect");

    }
}
