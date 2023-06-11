using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BaseScript : MonoBehaviour
{
    public int myhomeHP;
    public int myhomeGuard;
    public Text myhomebaseHPText;
    


    
    
    // Start is called before the first frame update
    void Start()
    {
        myhomeHP = 1000;
        //画面
        

        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.tag == "myhomebase" && myhomeHP <= 0 || Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("gameover");
            CountsScript.techpoints = 0;
            CountsScript.ccounts = 0;
            CountsScript.KC = 0;
            CountsScript.CC = 0;
            CountsScript.TECH = 0;
            CountsScript.TECHPOINTS = 0;
            PlayerScript.enemytech = 0;
        }

        myhomebaseHPText.text = myhomeHP.ToString();


        

        

    }
    void OnTriggerEnter(Collider other)
    {
        if (PlayerScript.Hanbetu == Faction.KINOKO)
        {
            if (other.gameObject.name == "Muskettakenoko(Clone)")
            {
                myhomeHP -= other.gameObject.GetComponent<TakeMusketScript>().TakeMusATK1;
            }
            else if (other.gameObject.name == "Yaritakenoko(Clone)")
            {
                myhomeHP -= other.gameObject.GetComponent<TakeYariScript>().TakeYariATK;
            }
            else if (other.gameObject.name == "bullet" && other.gameObject.tag == "Takenoko")
            {
                myhomeHP -= other.gameObject.GetComponent<BulletScript>().bulletATK;
            }
        }
        else if (PlayerScript.Hanbetu == Faction.TAKENOKO)
        {
            if (other.gameObject.name == "Bowkinoko(Clone)")
            {
                myhomeHP -= other.gameObject.GetComponent<KinoBowScript>().KinoBowATK1;

            }
            if (other.gameObject.name == "Swordkinoko(Clone)")
            {

                myhomeHP -= other.gameObject.GetComponent<KinoSwordScript>().KinoSolATK;

            }
            else if (other.gameObject.name == "bullet" && other.gameObject.tag == "Kinoko")
            {
                myhomeHP -= other.gameObject.GetComponent<BulletScript>().bulletATK;
            }
        }
    }
}
