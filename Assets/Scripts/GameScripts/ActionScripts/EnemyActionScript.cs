using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyActionScript : MonoBehaviour
{

    //NavMeshAgent agent;
    //public GameObject target1;//近接キャラ
    //public GameObject target2;//遠隔キャラ

    //public GameObject yaritakenoko;
    //public GameObject maskettakenko;
    //public GameObject swordkinoko;
    //public GameObject bowkinoko;
    //bool inarea = false;
    //public float chasespeed = 0.5f;


    // Start is called before the first frame update
    //void Start()
    //{
    //yaritakenoko.name = "Yaritakenoko(Clone)";
    //maskettakenko.name = "Muskettakenoko(Clone)";
    //swordkinoko.name = "Swordkinoko(Clone)";
    //bowkinoko.name = "Yaritakenoko(Clone)";

    //agent = GetComponent<NavMeshAgent>();
    //if (PlayerScript.Hanbetu == Faction.KINOKO)
    //{
    //    target1 = yaritakenoko;
    //    target2 = maskettakenko;
    //}
    //else if (PlayerScript.Hanbetu == Faction.TAKENOKO)
    //{
    //    target1 = swordkinoko;
    //    target2 = bowkinoko;
    //}
    //}

    // Update is called once per frame
    //void Update()
    //{



    //    if (target1.activeInHierarchy == false && target2.activeInHierarchy == false)
    //    {
    //        //自陣営の者が消えた時
    //        //
    //        //相手陣営の者が消えた時
    //        CountsScript.ccounts += 1;
    //    }

    //    if (inarea == true && target1.activeInHierarchy == true)
    //    {

    //        agent.destination = target1.transform.position;
    //        EnemyChasing();
    //    } else if (inarea == true && target2.activeInHierarchy == true)
    //    {

    //        agent.destination = target2.transform.position;
    //        EnemyChasing();
    //    }
    //}
    //void OnTriggerEnter(Collider other)
    //{
    //    if (PlayerScript.Hanbetu == Faction.KINOKO) 
    //    {
    //        if (other.gameObject.tag == "Takenoko")
    //        {
    //            inarea = true;
    //            //target = other.gameObject;
    //            EnemyChasing();
    //        }
    //    }
    //    else if (PlayerScript.Hanbetu == Faction.TAKENOKO)
    //    {
    //        if (other.gameObject.tag == "Kinoko")
    //        {
    //            inarea = true;
    //            //target = other.gameObject;
    //            EnemyChasing();
    //        }
    //    }
    //}
    //void OnTriggerExit(Collider other)
    //{
    //    if (PlayerScript.Hanbetu == Faction.KINOKO)
    //    {
    //        if (other.gameObject.tag == "Takenoko")
    //        {
    //            inarea = false;
    //        }
    //    }
    //    else if (PlayerScript.Hanbetu == Faction.TAKENOKO)
    //    {
    //        if (other.gameObject.tag == "Kinoko")
    //        {
    //            inarea = false;
    //        }
    //    }
    //}
    //void EnemyChasing()
    //{
    //    transform.position += transform.forward * chasespeed;
    //}

    NavMeshAgent agent;
    public GameObject target;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        if (PlayerScript.Hanbetu == Faction.KINOKO && this.gameObject.tag == "Takenoko")
        {
            target = GameObject.FindWithTag("myhomebase");
            agent.destination = target.transform.position;
        }
        else if (PlayerScript.Hanbetu == Faction.KINOKO && this.gameObject.tag == "Kinoko")
        {
            target = GameObject.FindWithTag("myhomebase");
            agent.destination = target.transform.position;
        }
        else if (PlayerScript.Hanbetu == Faction.TAKENOKO && this.gameObject.tag == "Kinoko")
        {
            target = GameObject.FindWithTag("enemyshomebase");
            agent.destination = target.transform.position;
        }
        else if (PlayerScript.Hanbetu == Faction.TAKENOKO && this.gameObject.tag == "Takenoko")
        {
            target = GameObject.FindWithTag("enemyshomebase");
            agent.destination = target.transform.position;
        }
    }
}
