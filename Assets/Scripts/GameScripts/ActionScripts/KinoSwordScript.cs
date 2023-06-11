using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class KinoSwordScript : MonoBehaviour
{


    public GameObject ourhomebase;
    public GameObject enemyhomebase;



    public FactionScript F;

    public Transform target;

    NavMeshAgent agent;

    //------------------------------------------味方武器-------------------------
    public string WEquipname;   //武器の名前
    public int WEquipATK;   //攻撃力
    public float WEquipATKspeed;   //攻撃速度
    public int WEquipBulletATK;   //遠隔攻撃力
    public float WEquipBulletATKspeed;   //遠隔攻撃速度
    public float WEquipBulletproofness;   //遠隔攻撃軽減
    public int WEquipGuard;   //防御力
    public float WEquipMass;   //重さ
    public int WEquipUnitcost;   //必要なユニットのコイン数


    //------------------------------------------味方防具-------------------------
    public string AEquipname;   //防具の名前
    public int AEquipATK;   //攻撃力
    public float AEquipATKspeed;   //攻撃速度
    public int AEquipBulletATK;   //遠隔攻撃力
    public float AEquipBulletATKspeed;   //遠隔攻撃速度
    public float AEquipBulletproofness;   //遠隔攻撃軽減
    public int AEquipGuard;   //防御力
    public float AEquipMass;   //重さ
    public int AEquipUnitcost;   //必要なユニットのコイン数


    //------------------------------------------敵武器---------------------------
    public string EWEquipname;   //武器の名前
    public int EWEquipATK;   //攻撃力
    public float EWEquipATKspeed;   //攻撃速度
    public int EWEquipBulletATK;   //遠隔攻撃力
    public float EWEquipBulletATKspeed;   //遠隔攻撃速度
    public float EWEquipBulletproofness;   //遠隔攻撃軽減
    public int EWEquipGuard;   //防御力
    public float EWEquipMass;   //重さ
    public int EWEquipUnitcost;   //必要なユニットのコイン数

    //------------------------------------------敵防具---------------------------
    public string EAEquipname;   //防具の名前
    public int EAEquipATK;   //攻撃力
    public float EAEquipATKspeed;   //攻撃速度
    public int EAEquipBulletATK;   //遠隔攻撃力
    public float EAEquipBulletATKspeed;   //遠隔攻撃速度
    public float EAEquipBulletproofness;   //遠隔攻撃軽減
    public int EAEquipGuard;   //防御力
    public float EAEquipMass;   //重さ
    public int EAEquipUnitcost;   //必要なユニットのコイン数

    //------------------------------------------場所移動関係---------------------------


    public ItemDataBase armordatabase;
    public ItemDataBase cweaponsdatabase;
    public ItemDataBase lweaponsdatabase;

    public float KinoSolMxHP
    {
        get
        {

            if (PlayerScript.Hanbetu == Faction.TAKENOKO)
            {
                return 50 + EKinoSolLevel * 5;
            }
            else if (PlayerScript.Hanbetu == Faction.KINOKO)
            {
                return 50 + KinoSolLevel * 5;

            }
            else
            {
                return 0;
            }

        }
    }


    public int KinoSolATK
    {
        get
        {
            if (PlayerScript.Hanbetu == Faction.TAKENOKO)
            {
                return EWEquipATK + EAEquipATK + EKinoSolLevel * 2;
            }
            else if (PlayerScript.Hanbetu == Faction.KINOKO)
            {
                return WEquipATK + AEquipATK + EKinoSolLevel * 2;
            }
            else
            {
                return 0;
            }
        }
    }

    public int KinoSolGuard
    {
        get
        {
            if (PlayerScript.Hanbetu == Faction.TAKENOKO)
            {
                return EWEquipGuard + EAEquipGuard + EKinoSolLevel;
            }
            else if (PlayerScript.Hanbetu == Faction.KINOKO)
            {
                return WEquipGuard + AEquipGuard + EKinoSolLevel;
            }
            else
            {
                return 0;
            }
        }
    }
    public float KinoSolSpeed
    {
        get
        {
            if (PlayerScript.Hanbetu == Faction.TAKENOKO)
            {
                return 6 - (WEquipMass + AEquipMass) / 2;
            }
            else if (PlayerScript.Hanbetu == Faction.KINOKO)
            {
                return 6 - (EWEquipMass + EAEquipMass) / 2;
            }
            else
            {
                return 0;
            }

        }
    }

    public int KinoSolLevel;
    public static int EKinoSolLevel;
    public float KinoSolNwHP;

    //敵までの距離比較用の変数、味方用
    float Closedist;
    //敵までの距離比較用の変数、敵用
    float EClosedist;

    //味方が、敵を感知した時に速くなる速度
    float Totugekisol;
    //敵が、敵を感知した時に速くなる速度
    float ETotugekisol;


    //茸 剣攻撃1回 / 1s



    //攻撃頻度書く



    void Start()
    {

        Closedist = 30f;
        EClosedist = 30f;

        Totugekisol = 1.2f;
        ETotugekisol = 1.2f;

        if (PlayerScript.Hanbetu == Faction.TAKENOKO)
        {
            agent = GetComponent<NavMeshAgent>();
            KinoSolNwHP = KinoSolMxHP;
            target = ourhomebase.transform;

            agent.SetDestination(target.position);

        }
        else if (PlayerScript.Hanbetu == Faction.KINOKO)
        {
            agent = GetComponent<NavMeshAgent>();
            KinoSolNwHP = KinoSolMxHP;
            target = enemyhomebase.transform;

            agent.SetDestination(target.position);

        }




        if (PlayerScript.Hanbetu == Faction.TAKENOKO)
        {
            EWEquipname = PlayerScript.EnemyHaveCWeapons.GetItemName();
            EWEquipATK = PlayerScript.EnemyHaveCWeapons.GetATK();
            EWEquipATKspeed = PlayerScript.EnemyHaveCWeapons.GetATKSpeed();
            EWEquipBulletATK = PlayerScript.EnemyHaveCWeapons.GetBulletATK();
            EWEquipBulletATKspeed = PlayerScript.EnemyHaveCWeapons.GetBulletATKSpeed();
            EWEquipBulletproofness = PlayerScript.EnemyHaveCWeapons.GetBulletproofness();
            EWEquipGuard = PlayerScript.EnemyHaveCWeapons.GetGuard();
            EWEquipMass = PlayerScript.EnemyHaveCWeapons.GetUnitspeeddown();
            EWEquipUnitcost = PlayerScript.EnemyHaveCWeapons.GetUnitcost();
        }

        if (PlayerScript.Hanbetu == Faction.TAKENOKO)
        {
            EAEquipname = PlayerScript.EnemyHaveCArmors.GetItemName();
            EAEquipATK = PlayerScript.EnemyHaveCArmors.GetATK();
            EAEquipATKspeed = PlayerScript.EnemyHaveCArmors.GetATKSpeed();
            EAEquipBulletATK = PlayerScript.EnemyHaveCArmors.GetBulletATK();
            EAEquipBulletATKspeed = PlayerScript.EnemyHaveCArmors.GetBulletATKSpeed();
            EAEquipBulletproofness = PlayerScript.EnemyHaveCArmors.GetBulletproofness();
            EAEquipGuard = PlayerScript.EnemyHaveCArmors.GetGuard();
            EAEquipMass = PlayerScript.EnemyHaveCArmors.GetUnitspeeddown();
            EAEquipUnitcost = PlayerScript.EnemyHaveCArmors.GetUnitcost();
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Closedist);

        if (KinoSolNwHP <= 0)
        {
            target = null;
            Destroy(this.gameObject);
            F.Kinokolist.Remove(this.transform);
            if (PlayerScript.Hanbetu == Faction.TAKENOKO)
            {
                CountsScript.KC += 1;
                CountsScript.techpoints += 1;
            }
        }

        if (PlayerScript.Hanbetu == Faction.KINOKO)
        {
            if (FrontLineScript.Soldiergo == false)
            {
                foreach (Transform t in F.Takenokolist)
                {
                    float tdist = Vector3.Distance(transform.position, t.transform.position);

                    if (Closedist > tdist)
                    {
                        Closedist = tdist;
                        target = t;
                        this.gameObject.GetComponent<NavMeshAgent>().speed = KinoSolSpeed * Totugekisol;
                        agent.SetDestination(target.position);


                    }

                }
                if (Closedist == 30f)
                {
                    target = enemyhomebase.transform;
                    agent.SetDestination(target.position);
                    this.gameObject.GetComponent<NavMeshAgent>().speed = KinoSolSpeed;

                }
                else
                {
                    Closedist = 30f;
                }


                //agent.SetDestination(FrontLineScript.GOPositionSol);
                //this.gameObject.GetComponent<NavMeshAgent>().speed = KinoSolSpeed;
            }
            else
            {

                this.gameObject.GetComponent<NavMeshAgent>().speed = KinoSolSpeed;
            }

            if (FrontLineScript.Spointerhantei)
            {
                agent.SetDestination(FrontLineScript.GOPositionSol);

            }
        }
        if (PlayerScript.Hanbetu == Faction.TAKENOKO)
        {
            foreach (Transform t in F.Takenokolist)
            {
                float Etdist = Vector3.Distance(transform.position, t.transform.position);
                if (EClosedist > Etdist)
                {
                    EClosedist = Etdist;
                    target = t;
                    this.gameObject.GetComponent<NavMeshAgent>().speed = KinoSolSpeed * ETotugekisol;
                    agent.SetDestination(target.position);

                }
            }
            if (EClosedist == 30f)
            {
                target = ourhomebase.transform;
                this.gameObject.GetComponent<NavMeshAgent>().speed = KinoSolSpeed;
                agent.SetDestination(target.position);

            }
            else
            {
                EClosedist = 30f;
            }
        }

    }

    void OnTriggerEnter(Collider other)
    {
        
        {
            if (other.gameObject.name == "Muskettakenoko(Clone)")
            {
                if ((other.gameObject.GetComponent<TakeMusketScript>().TakeMusATK1 + 8) * 2 - KinoSolGuard * Mathf.Sqrt(12) / 2 >= 0)
                {


                    KinoSolNwHP -= (other.gameObject.GetComponent<TakeMusketScript>().TakeMusATK1 + 8) * 2 - KinoSolGuard * Mathf.Sqrt(Random.Range(8, 12)) / 2;
                }
            }
            if (other.gameObject.name == "Yaritakenoko(Clone)")
            {
                if ((other.gameObject.GetComponent<TakeYariScript>().TakeYariATK + 8) * 2 - KinoSolGuard * Mathf.Sqrt(12) / 2 >= 0)
                {


                    KinoSolNwHP -= (other.gameObject.GetComponent<TakeYariScript>().TakeYariATK + 8) * 2 - KinoSolGuard * Mathf.Sqrt(Random.Range(8, 12)) / 2;
                }
            }


        }
        if (other.gameObject.tag == "TakenokoBall")
        {
            KinoSolNwHP -= other.gameObject.GetComponent<BulletScript>().bulletATK;
            Destroy(other.gameObject);
        }
    }
}
