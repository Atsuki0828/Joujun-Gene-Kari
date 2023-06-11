using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class KinoBowScript : MonoBehaviour
{


    public GameObject ourhomebase;
    public GameObject enemyhomebase;

    public FactionScript F;


    public Transform target;

    NavMeshAgent agent;

    Transform Targettransform;

    //------------------------------------------味方武器-------------------------
    public string WEquipname;   //武器の名前
    public int WEquipATK;   //攻撃力
    public float WEquipATKspeed;   //攻撃速度
    public int WEquipBulletATK;   //遠隔攻撃力
    public float WEquipBulletATKspeed;   //遠隔攻撃速度
    public float WEquipBulletspeed;   //弾速
    public float WEquipBulletrange;   //弾の飛距離
    public float WEquipBulletAccuracy;   //弾の命中率
    public GameObject WEquipBulletgameobject;   //弾のgameobject
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
    public float EWEquipBulletspeed;   //弾速
    public float EWEquipBulletrange;   //弾の飛距離
    public float EWEquipBulletAccuracy;   //弾の命中率
    public GameObject EWEquipBulletgameobject;   //弾のgameobject
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


    public float KinoBowMxHP
    {
        get
        {

            if (PlayerScript.Hanbetu == Faction.TAKENOKO)
            {
                return 50 + EKinoBowLevel * 5;
            }
            else if (PlayerScript.Hanbetu == Faction.KINOKO)
            {
                return 50 + KinoBowLevel * 5;

            }
            else
            {
                return 0;
            }

        }
    }


    public int KinoBowATK1 //これは近接攻撃
    {
        get
        {
            if (PlayerScript.Hanbetu == Faction.TAKENOKO)
            {
                return EWEquipATK + EAEquipATK + EKinoBowLevel * 2;
            }
            else if (PlayerScript.Hanbetu == Faction.KINOKO)
            {
                return WEquipATK + AEquipATK + EKinoBowLevel * 2;
            }
            else
            {
                return 0;
            }
        }
    }

    public int KinoBowATK2 //これは遠隔攻撃
    {
        get
        {
            if (PlayerScript.Hanbetu == Faction.TAKENOKO)
            {
                return EWEquipBulletATK + EAEquipBulletATK + EKinoBowLevel;
            }
            else if (PlayerScript.Hanbetu == Faction.KINOKO)
            {
                return WEquipBulletATK + AEquipBulletATK + EKinoBowLevel;
            }
            else
            {
                return 0;
            }
        }
    }　

    public int KinoBowGuard
    {
        get
        {
            if (PlayerScript.Hanbetu == Faction.TAKENOKO)
            {
                return EWEquipGuard + EAEquipGuard + EKinoBowLevel;
            }
            else if (PlayerScript.Hanbetu == Faction.KINOKO)
            {
                return WEquipGuard + AEquipGuard + EKinoBowLevel;
            }
            else
            {
                return 0;
            }
        }
    }
    public float KinoBowSpeed
    {
        get
        {
            if (PlayerScript.Hanbetu == Faction.TAKENOKO)
            {
                return 6 - (EWEquipMass + EAEquipMass) / 2;
            }
            else if (PlayerScript.Hanbetu == Faction.KINOKO)
            {
                return 6 - (WEquipMass + AEquipMass) / 2;
            }
            else
            {
                return 0;
            }

        }
    }

    public int KinoBowLevel;
    public static int EKinoBowLevel;
    public float KinoBowNwHP;




    [SerializeField]
    //[Tooltip("弾の速さ")]
    public float speed
    {
        get
        {


            if (PlayerScript.Hanbetu == Faction.TAKENOKO)
            {
                return EWEquipBulletspeed;
            }
            else if (PlayerScript.Hanbetu == Faction.KINOKO)
            {
                return WEquipBulletspeed;
            }
            else
            {
                return 0;
            }
        }
    }




    //敵までの距離比較用の変数、味方用
    float Closedist;
    //敵までの距離比較用の変数、敵用
    float EClosedist;
    // Start is called before the first frame update
    [SerializeField]
    float x;
    void Start()
    {
        Closedist = WEquipBulletrange - 2;
        EClosedist = EWEquipBulletrange - 2;
        if (PlayerScript.Hanbetu == Faction.TAKENOKO)
        {
            agent = GetComponent<NavMeshAgent>();
            KinoBowNwHP = KinoBowMxHP;
            target = ourhomebase.transform;
            agent.SetDestination(target.position);
        }
        else if (PlayerScript.Hanbetu == Faction.KINOKO)
        {
            agent = GetComponent<NavMeshAgent>();
            KinoBowNwHP = KinoBowMxHP;
            target = enemyhomebase.transform;
            agent.SetDestination(target.position);
        }

        if (PlayerScript.Hanbetu == Faction.TAKENOKO)
        {
            EWEquipname = PlayerScript.EnemyHaveLWeapons.GetItemName();
            EWEquipATK = PlayerScript.EnemyHaveLWeapons.GetATK();
            EWEquipATKspeed = PlayerScript.EnemyHaveLWeapons.GetATKSpeed();
            EWEquipBulletATK = PlayerScript.EnemyHaveLWeapons.GetBulletATK();
            EWEquipBulletATKspeed = PlayerScript.EnemyHaveLWeapons.GetBulletATKSpeed();
            EWEquipBulletspeed = PlayerScript.EnemyHaveLWeapons.GetBulletSpeed();
            EWEquipBulletrange = PlayerScript.EnemyHaveLWeapons.GetBulletRange();
            EWEquipBulletAccuracy = PlayerScript.EnemyHaveLWeapons.GetBulletAccuracy();
            EWEquipBulletgameobject = PlayerScript.EnemyHaveLWeapons.Getbulletgameobject();
            EWEquipBulletproofness = PlayerScript.EnemyHaveLWeapons.GetBulletproofness();
            EWEquipGuard = PlayerScript.EnemyHaveLWeapons.GetGuard();
            EWEquipMass = PlayerScript.EnemyHaveLWeapons.GetUnitspeeddown();
            EWEquipUnitcost = PlayerScript.EnemyHaveLWeapons.GetUnitcost();
        }

        if (PlayerScript.Hanbetu == Faction.TAKENOKO)
        {
            EAEquipATK = PlayerScript.EnemyHaveLArmors.GetATK();
            EAEquipATKspeed = PlayerScript.EnemyHaveLArmors.GetATKSpeed();
            EAEquipBulletATK = PlayerScript.EnemyHaveLArmors.GetBulletATK();
            EAEquipBulletATKspeed = PlayerScript.EnemyHaveLArmors.GetBulletATKSpeed();
            EAEquipBulletproofness = PlayerScript.EnemyHaveLArmors.GetBulletproofness();
            EAEquipGuard = PlayerScript.EnemyHaveLArmors.GetGuard();
            EAEquipMass = PlayerScript.EnemyHaveLArmors.GetUnitspeeddown();
            EAEquipUnitcost = PlayerScript.EnemyHaveLArmors.GetUnitcost();
        }

    }

    // Update is called once per frame
    void Update()
    {

        if (KinoBowNwHP <= 0)
        {
            Destroy(this.gameObject);
            F.Kinokolist.Remove(this.transform);
            if (PlayerScript.Hanbetu == Faction.TAKENOKO)
            {
                CountsScript.KC += 1;
                CountsScript.techpoints += 2;
            }
        }


        if (Targettransform != null)
        {
            x += Time.deltaTime;
        }

        if (Targettransform == null)
        {
            this.gameObject.GetComponent<NavMeshAgent>().speed = KinoBowSpeed;
        }

        if (x > (AEquipBulletATKspeed + WEquipBulletATKspeed) / 100)
        {
            x = 0;
            bowshot();
        }

        if (PlayerScript.Hanbetu == Faction.KINOKO)
        {
            if (FrontLineScript.Rangergo == false)
            {
                //Debug.Log(Vector3.Distance(transform.position, i.position));
                foreach (Transform t in F.Takenokolist)
                {
                    float tdist = Vector3.Distance(transform.position, t.transform.position);
                    if (Closedist > tdist)
                    {
                        Closedist = tdist;
                        Targettransform = t;
                        target = t;
                        this.gameObject.GetComponent<NavMeshAgent>().speed = 0;



                    }

                }
                if (Closedist >= WEquipBulletrange - 2)
                {
                    target = enemyhomebase.transform;
                    Targettransform = null;
                    this.gameObject.GetComponent<NavMeshAgent>().speed = KinoBowSpeed;


                }
                else
                {
                    Closedist = WEquipBulletrange - 2;
                }

                agent.SetDestination(target.position);
            }
            else if (FrontLineScript.Rangergo == true)
            {
                //GOPositionSolに移動考える



                //Debug.Log(Vector3.Distance(transform.position, i.position));
                foreach (Transform t in F.Takenokolist)
                {
                    float tdist = Vector3.Distance(transform.position, t.transform.position);
                    if (Closedist > tdist)
                    {
                        Closedist = tdist;
                        Targettransform = t;
                        this.gameObject.GetComponent<NavMeshAgent>().speed = 0;

                    }

                }
                if (Closedist >= WEquipBulletrange - 2)
                {
                    Targettransform = null;
                    this.gameObject.GetComponent<NavMeshAgent>().speed = KinoBowSpeed;


                }
                else
                {
                    Closedist = WEquipBulletrange - 2;
                }

            }

            if (FrontLineScript.Rpointerhantei)

            {
                agent.SetDestination(FrontLineScript.GOPositionRan);
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
                    Targettransform = t;
                    target = t;
                    this.gameObject.GetComponent<NavMeshAgent>().speed = 0;

                }
            }
            if (EClosedist == EWEquipBulletrange - 2)
            {
                target = ourhomebase.transform;
                Targettransform = null;
                this.gameObject.GetComponent<NavMeshAgent>().speed = KinoBowSpeed;

            }
            else
            {
                EClosedist = EWEquipBulletrange - 2;
            }
            agent.SetDestination(target.position);

        }
    }



    void OnTriggerEnter(Collider other)
    {
        

        
        {
            if (other.gameObject.name == "Muskettakenoko(Clone)")
            {
                if ((other.gameObject.GetComponent<TakeMusketScript>().TakeMusATK1 + 8) * 2 - KinoBowGuard * Mathf.Sqrt(12) / 2 >= 0)
                {
                    KinoBowNwHP -= (other.gameObject.GetComponent<TakeMusketScript>().TakeMusATK1 + 8) * 2 - KinoBowGuard * Mathf.Sqrt(Random.Range(8, 12)) / 2;
                }
            }
            if (other.gameObject.name == "Yaritakenoko(Clone)")
            {
                if ((other.gameObject.GetComponent<TakeYariScript>().TakeYariATK + 8) * 2 - KinoBowGuard * Mathf.Sqrt(12) / 2 >= 0)
                {
                    KinoBowNwHP -= (other.gameObject.GetComponent<TakeYariScript>().TakeYariATK + 8) * 2 - KinoBowGuard * Mathf.Sqrt(Random.Range(8, 12)) / 2;
                }
            }
        }
        if (other.gameObject.tag == "TakenokoBall")
        {
            Destroy(other.gameObject);
            KinoBowNwHP -= other.gameObject.GetComponent<BulletScript>().bulletATK;
        }
    }

    void bowshot()
    {
        Vector3 direction;
        if (PlayerScript.Hanbetu == Faction.TAKENOKO)
        {
            // 弾を発射する場所を取得
            Vector3 bulletPosition = this.gameObject.transform.position;
            // 上で取得した場所に、"bullet"のPrefabを出現させる
            GameObject newBall = Instantiate(EWEquipBulletgameobject, bulletPosition, transform.rotation);
            newBall.GetComponent<BulletScript>().bulletATK = KinoBowATK2;
            //newBall.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            newBall.tag = "KinokoBall";

            // 出現させたボールのforward(z軸方向)
            Vector3 RandomTransform = new Vector3(Targettransform.position.x + Random.Range(-EWEquipBulletAccuracy, EWEquipBulletAccuracy) * Vector3.Distance(this.gameObject.transform.position, Targettransform.position) / EWEquipBulletAccuracy,
            Targettransform.position.y, Targettransform.position.z + Random.Range(-EWEquipBulletAccuracy, EWEquipBulletAccuracy) * Vector3.Distance(this.gameObject.transform.position, Targettransform.position) / EWEquipBulletAccuracy);

            direction = (RandomTransform - transform.position) / Vector3.Distance(RandomTransform, transform.position);

            // 弾の発射方向にnewBallのz方向(ローカル座標)を入れ、弾オブジェクトのrigidbodyに衝撃力を加える
            newBall.transform.forward = direction;
            newBall.GetComponent<Rigidbody>().AddForce(direction * speed, ForceMode.Impulse);
            // 出現させたボールの名前を"bullet"に変更
            newBall.name = EWEquipBulletgameobject.name;
            // 出現させたボールをWEquipBulletrange/WEquipBulletspeed　秒後に消す
            Destroy(newBall, EWEquipBulletrange / EWEquipBulletspeed);

        }
        else if (PlayerScript.Hanbetu == Faction.KINOKO)
        {
            // 弾を発射する場所を取得
            Vector3 bulletPosition = this.gameObject.transform.position;
            // 上で取得した場所に、"bullet"のPrefabを出現させる
            GameObject newBall = Instantiate(WEquipBulletgameobject, bulletPosition, transform.rotation);
            newBall.GetComponent<BulletScript>().bulletATK = KinoBowATK2;
            //newBall.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            newBall.tag = "KinokoBall";

            // 出現させたボールのforward(z軸方向)

            Vector3 RandomTransform = new Vector3(Targettransform.position.x + Random.Range(-WEquipBulletAccuracy, WEquipBulletAccuracy) * Vector3.Distance(this.gameObject.transform.position, Targettransform.position) / WEquipBulletAccuracy / 10,
            Targettransform.position.y, Targettransform.position.z + Random.Range(-WEquipBulletAccuracy, WEquipBulletAccuracy) * Vector3.Distance(this.gameObject.transform.position, Targettransform.position) / WEquipBulletAccuracy / 10);



            direction = (RandomTransform - transform.position) / Vector3.Distance(RandomTransform, transform.position);


            // 弾の発射方向にnewBallのz方向(ローカル座標)を入れ、弾オブジェクトのrigidbodyに衝撃力を加える
            newBall.transform.forward = direction;
            newBall.GetComponent<Rigidbody>().AddForce(direction * speed, ForceMode.Impulse);
            // 出現させたボールの名前を"bullet"に変更
            newBall.name = WEquipBulletgameobject.name;
            // 出現させたボールをWEquipBulletrange/WEquipBulletspeed　秒後に消す
            Destroy(newBall, WEquipBulletrange / WEquipBulletspeed);

        }
    }
}


