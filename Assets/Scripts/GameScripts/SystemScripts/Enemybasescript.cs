using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Enemybasescript : MonoBehaviour
{
    


    public int enemyshomeHP;
    public int enemyhomeGuard;

    public Text enemyshomebaseHP;

    // Start is called before the first frame update
    void Start()
    {
        enemyshomeHP = 1000;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyshomeHP <= 0)
        {
            SceneManager.LoadScene("clearscene");
            CountsScript.techpoints = 0;
            CountsScript.ccounts = 0;
            CountsScript.KC = 0;
            CountsScript.CC = 0;
            CountsScript.TECH = 0;
            CountsScript.TECHPOINTS = 0;
        }

        enemyshomebaseHP.text = enemyshomeHP.ToString();
        enemyshomebaseHP.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);

    }
    void OnTriggerEnter(Collider other)
    {


        if (PlayerScript.Hanbetu == Faction.KINOKO)
        {
            if (other.gameObject.name == "Bowkinoko(Clone)")
            {
                enemyshomeHP -= other.gameObject.GetComponent<KinoBowScript>().KinoBowATK1;
            }
            if (other.gameObject.name == "Swordkinoko(Clone)")
            {
                enemyshomeHP -= other.gameObject.GetComponent<KinoSwordScript>().KinoSolATK;
            }
            else if (other.gameObject.name == "bullet" && other.gameObject.tag == "Kinoko")
            {
                enemyshomeHP -= other.gameObject.GetComponent<BulletScript>().bulletATK;
            }

        }
        else if (PlayerScript.Hanbetu == Faction.TAKENOKO)
        {
            if (other.gameObject.name == "Muskettakenoko(Clone)")
            {
                enemyshomeHP -= other.gameObject.GetComponent<TakeMusketScript>().TakeMusATK1;

            }
            else if (other.gameObject.name == "Yaritakenoko(Clone)")
            {
                enemyshomeHP -= other.gameObject.GetComponent<TakeYariScript>().TakeYariATK;
            }
            else if (other.gameObject.name == "bullet" && other.gameObject.tag == "Takenoko")
            {
                enemyshomeHP -= other.gameObject.GetComponent<BulletScript>().bulletATK;
            }
        }
        else
        {

        }
    } 

    
}
