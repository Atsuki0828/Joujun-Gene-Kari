using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FrontLineScript : MonoBehaviour
{
    public GameObject Spointer;
    public GameObject Rpointer;

    public static bool Spointerhantei = false;
    public static bool Rpointerhantei = false;

    public static bool Soldiergo;
    public Image SoldiergoShape;
    public static bool Rangergo;
    public Image RangergoShape;

    public static Vector3 GOPositionSol;
    public static Vector3 GOPositionRan;
    void Start()
    {
        SoldiergoShape.enabled = false;
        RangergoShape.enabled = false;
    }
    void Update()
    {
        if (Soldiergo == true　&& Input.GetMouseButtonDown(1))
        {
            GameObject[] Sobjects = GameObject.FindGameObjectsWithTag("Soldierspointer");
            foreach (GameObject p in Sobjects)
            {
                Destroy(p);
            }

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                GOPositionSol = hit.point;
            }
            else
            {
            }

            Instantiate(Spointer, GOPositionSol, Quaternion.identity);
            Spointerhantei = true;
        }
        if (Rangergo == true && Input.GetMouseButtonDown(1))
        {
            GameObject[] Robjects = GameObject.FindGameObjectsWithTag("Rangerspointer");
            foreach (GameObject p in Robjects)
            {
                Destroy(p);
            }


            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                GOPositionRan = hit.point;
            }
            else
            {    
            }
            Instantiate(Rpointer, GOPositionRan, Quaternion.identity);
            Rpointerhantei = true;
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Solclick();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            Ranclick();
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            Clearclick();
        }

    }
    public void Solclick()
    {
        
        if (Soldiergo == true)
        {
            Soldiergo = false;
            SoldiergoShape.enabled = false;
        }
        else
        {
            if (Rangergo == true)
            {
                Rangergo = false;
                RangergoShape.enabled = false;
            }
            Soldiergo = true;
            SoldiergoShape.enabled = true;
        }

        
    }
    public void Ranclick()
    {
        
        if (Rangergo == true)
        {
            Rangergo = false;
            RangergoShape.enabled = false;
        }
        else
        {
            if (Soldiergo == true)
            {
                Soldiergo = false;
                SoldiergoShape.enabled = false;
            }
            Rangergo = true;
            RangergoShape.enabled = true;
        }
        
    }
    public void Clearclick()
    {
        Soldiergo = false;
        Rangergo = false;
        SoldiergoShape.enabled = false;
        RangergoShape.enabled = false;
        Spointerhantei = false;
        Rpointerhantei = false;
        GameObject[] Sobjects = GameObject.FindGameObjectsWithTag("Soldierspointer");
        foreach (GameObject p in Sobjects)
        {
            Destroy(p);
        }
        GameObject[] Robjects = GameObject.FindGameObjectsWithTag("Rangerspointer");
        foreach (GameObject p in Robjects)
        {
            Destroy(p);
        }
    }
}



