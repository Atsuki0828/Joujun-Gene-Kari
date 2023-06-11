using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class TakeYariScript : MonoBehaviour
{

    public GameObject ourhomebase;
    public GameObject enemyhomebase;

    //[SerializeField]
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

    public float TakeYariMxHP
    {
        get
        {

            if (PlayerScript.Hanbetu == Faction.TAKENOKO)
            {
                return 50 + TakeYariLevel * 5;
            }
            else if (PlayerScript.Hanbetu == Faction.KINOKO)
            {
                return 50 + ETakeYariLevel * 5;

            }
            else
            {
                return 0;
            }

        }
    }


    public int TakeYariATK
    {
        get
        {
            if (PlayerScript.Hanbetu == Faction.TAKENOKO)
            {
                return WEquipATK + AEquipATK + TakeYariLevel * 2;
            }
            else if (PlayerScript.Hanbetu == Faction.KINOKO)
            {
                return EWEquipATK + EAEquipATK + ETakeYariLevel * 2;
            }
            else
            {
                return 0;
            }
        }
    }

    public int TakeYariGuard
    {
        get
        {
            if (PlayerScript.Hanbetu == Faction.TAKENOKO)
            {
                return WEquipGuard + AEquipGuard + TakeYariLevel;
            }
            else if (PlayerScript.Hanbetu == Faction.KINOKO)
            {
                return EWEquipGuard + EAEquipGuard + ETakeYariLevel;
            }
            else
            {
                return 0;
            }
        }
    }
    public float TakeYariSpeed
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


    public float TakeYariNwHP;
    public int TakeYariLevel;
    public static int ETakeYariLevel;



    //敵までの距離比較用の変数、味方用
    float Closedist;
    //敵までの距離比較用の変数、敵用
    float EClosedist;

    //味方が、敵を感知した時に速くなる速度
    float Totugekisol;
    //敵が、敵を感知した時に速くなる速度
    float ETotugekisol;


    // Start is called before the first frame update
    void Start()
    {
        Closedist = 30f;
        EClosedist = 30f;

        Totugekisol = 1.2f;
        ETotugekisol = 1.2f;

        if (PlayerScript.Hanbetu == Faction.KINOKO)
        {
            agent = GetComponent<NavMeshAgent>();
            TakeYariNwHP = TakeYariMxHP;
            target = ourhomebase.transform;
            agent.SetDestination(target.position);

        }
        else if (PlayerScript.Hanbetu == Faction.TAKENOKO)
        {
            agent = GetComponent<NavMeshAgent>();
            TakeYariNwHP = TakeYariMxHP;
            target = enemyhomebase.transform;
            agent.SetDestination(target.position);

        }



        if (PlayerScript.Hanbetu == Faction.KINOKO)
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

        if (PlayerScript.Hanbetu == Faction.KINOKO)
        {
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

        if (TakeYariNwHP <= 0)
        {
            Destroy(this.gameObject);
            F.Takenokolist.Remove(this.transform);
            if (PlayerScript.Hanbetu == Faction.KINOKO)
            {
                CountsScript.KC += 1;
                CountsScript.techpoints += 1;
            }
        }



        if (PlayerScript.Hanbetu == Faction.KINOKO)
        {
            foreach (Transform t in F.Kinokolist)
            {
                float tdist = Vector3.Distance(transform.position, t.transform.position);
                if (EClosedist > tdist)
                {
                    EClosedist = tdist;
                    target = t;
                    agent.SetDestination(target.position);

                    this.gameObject.GetComponent<NavMeshAgent>().speed = TakeYariSpeed * ETotugekisol;

                }
            }
            if (EClosedist == 30f)
            {
                target = ourhomebase.transform;
                this.gameObject.GetComponent<NavMeshAgent>().speed = TakeYariSpeed;
                agent.SetDestination(target.position);


            }
            else
            {
                EClosedist = 30f;
            }



        }
        else if (PlayerScript.Hanbetu == Faction.TAKENOKO)
        {
            if (FrontLineScript.Soldiergo == false)
            {
                foreach (Transform t in F.Kinokolist)
                {
                    float tdist = Vector3.Distance(transform.position, t.transform.position);
                    if (Closedist > tdist)
                    {
                        Closedist = tdist;
                        target = t;
                        this.gameObject.GetComponent<NavMeshAgent>().speed = TakeYariSpeed * Totugekisol;
                        agent.SetDestination(target.position);
                    }

                }
                if (Closedist == 30f)
                {
                    target = enemyhomebase.transform;
                    this.gameObject.GetComponent<NavMeshAgent>().speed = TakeYariSpeed;

                    agent.SetDestination(target.position);


                }
                else
                {
                    Closedist = 30f;
                }

            }
            else
            {

                this.gameObject.GetComponent<NavMeshAgent>().speed = TakeYariSpeed;

            }

            if (FrontLineScript.Spointerhantei)
            {
                agent.SetDestination(FrontLineScript.GOPositionSol);

            }
        }

    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.name == "Bowkinoko(Clone)")
        {
            if ((other.gameObject.GetComponent<KinoBowScript>().KinoBowATK1　+ 8) * 2 - TakeYariGuard * Mathf.Sqrt(12) / 2 >= 0)
            {
                TakeYariNwHP -= (other.gameObject.GetComponent<KinoBowScript>().KinoBowATK1 + 8) * 2 - TakeYariGuard * Mathf.Sqrt(Random.Range(8, 12)) / 2;
            }


        }
        if (other.gameObject.name == "Swordkinoko(Clone)")
            
        {
            if ((other.gameObject.GetComponent<KinoSwordScript>().KinoSolATK + 8) * 2 - TakeYariGuard * Mathf.Sqrt(12) / 2 >= 0)
            {
                TakeYariNwHP -= (other.gameObject.GetComponent<KinoSwordScript>().KinoSolATK + 8) * 2 - TakeYariGuard * Mathf.Sqrt(Random.Range(8, 12)) / 2;

            }
        }

        if (other.gameObject.tag == "KinokoBall")
        {
            TakeYariNwHP -= other.gameObject.GetComponent<BulletScript>().bulletATK;

            Destroy(other.gameObject);

        }
    }
}
