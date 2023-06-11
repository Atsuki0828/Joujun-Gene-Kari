using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpownScript : MonoBehaviour
{

    //キャラクターのスクリプトを取ってきて、その後でキャラクターの目標であるキャラクターのスクリプト内のenemyhomebaseとourhomebaseを設定する。

    public GameObject O;
    public GameObject E;
    public GameObject levelmanager;


    public GameObject Ety, Etg, Eks, Ekb;
    public FactionScript F;

    int S;
    int R;
    float r;

    float wavetime;






    public int EnemyCC;
    public float Enemyccounts;
    public float ESGenerateCosts;//ES:EnemySoldier, ER:EnemyRanger
    public float ERGenerateCosts;


    public int enemydifficulty;






    // Start is called before the first frame update
    void Start()
    {
        wavetime = Random.Range(60f - (enemydifficulty * 2), 100f - (enemydifficulty * 4));
        

        Enemyccounts = 50;
        EnemyCC = 50;

        enemydifficulty = StageSelectScript.GameDifficultySet;




    }

    // Update is called once per frame
    void Update()
    {

        r += Time.deltaTime;


        if (wavetime <= r)
        {

            Wave();
            r = 0;
        }
        if (r <= 0.2f)
        {
            Waveterm();
        }



        Enemyccounts += Time.deltaTime * ((PlayerScript.enemytech * 2 + 9) / 5 * (enemydifficulty / 4 + 1));
        EnemyCC = (int)Enemyccounts;

        EnemyActPatern();





    }

    //敵の生成行動のパターン化
    public void EnemyActPatern()
    {
        float x = this.GetComponent<Managers>().GetCWeaponsItem(PlayerScript.FirstW).GetUnitcost() + this.GetComponent<Managers>().GetArmorsItem(PlayerScript.ThirdW).GetUnitcost();
        float y = this.GetComponent<Managers>().GetLWeaponsItem(PlayerScript.SecondW).GetUnitcost() + this.GetComponent<Managers>().GetArmorsItem(PlayerScript.FourthW).GetUnitcost();

        if (Enemyccounts >= (x + y) * 4)
        {
            for (int i = 0; i < 10; i++)
            {
                float a = 5.5f;
                float b = 4.5f;

                if (Enemyccounts >= x + y)
                {
                    float z = Random.Range(1, a + b);//敵の生成比率の決定
                    if (z <= a)
                    {
                        ESoldierG();
                        Enemyccounts -= x;
                    }
                    else if (a < z && z <= a + b)
                    {
                        ERangerG();
                        Enemyccounts -= y;
                    }
                }
            }
        }
    }

    //敵が生成されるのに必要なenemyccounts及びそれを設定するenemytech






    void Waveterm()
    {
        wavetime = Random.Range(40f - (enemydifficulty * 5), 80f - (enemydifficulty * 10));
    }
    public void ESoldierG()
    {
        if (PlayerScript.Hanbetu == Faction.KINOKO)
        {
            float x = Random.Range(-10f, 10f);
            float z = Random.Range(43f, 46f);
            Vector3 pos = new Vector3(x, 0.7142222f, z);
            GameObject Takesol = Instantiate(Ety, pos, Quaternion.identity);
            Takesol.GetComponent<TakeYariScript>().ourhomebase = O;
            Takesol.GetComponent<TakeYariScript>().enemyhomebase = E;
            Takesol.GetComponent<TakeYariScript>().F = F;
            Takesol.GetComponent<TakeYariScript>().TakeYariLevel += levelmanager.GetComponent<CountsScript>().Takeyariuplevel;
            F.Takenokolist.Add(Takesol.transform);
        }
        else if (PlayerScript.Hanbetu == Faction.TAKENOKO)
        {
            float x = Random.Range(-10f, 10f);
            float z = Random.Range(43f, 46f);
            Vector3 pos = new Vector3(x, 0.7142222f, z);
            GameObject Kinosol = Instantiate(Eks, pos, Quaternion.identity);
            F.Kinokolist.Add(Kinosol.transform);
            Kinosol.GetComponent<KinoSwordScript>().ourhomebase = O;
            Kinosol.GetComponent<KinoSwordScript>().enemyhomebase = E;
            Kinosol.GetComponent<KinoSwordScript>().F = F;
            Kinosol.GetComponent<KinoSwordScript>().KinoSolLevel += levelmanager.GetComponent<CountsScript>().Kinosoluplevel;
        }

    }
    public void ERangerG()
    {
        if (PlayerScript.Hanbetu == Faction.KINOKO)
        {
            float x = Random.Range(-10f, 10f);
            float z = Random.Range(47f, 49f);
            Vector3 pos = new Vector3(x, 0.7142222f, z);
            GameObject Takemus = Instantiate(Etg, pos, Quaternion.identity);
            F.Takenokolist.Add(Takemus.transform);
            Takemus.GetComponent<TakeMusketScript>().ourhomebase = O;
            Takemus.GetComponent<TakeMusketScript>().enemyhomebase = E;
            Takemus.GetComponent<TakeMusketScript>().F = F;
            Takemus.GetComponent<TakeMusketScript>().TakeMusLevel += levelmanager.GetComponent<CountsScript>().Takemusuplevel;
        }
        else if (PlayerScript.Hanbetu == Faction.TAKENOKO)
        {
            float x = Random.Range(-10f, 10f);
            float z = Random.Range(47f, 49f);
            Vector3 pos = new Vector3(x, 0.7142222f, z);
            GameObject Kinobow = Instantiate(Ekb, pos, Quaternion.identity);
            F.Kinokolist.Add(Kinobow.transform);
            Kinobow.GetComponent<KinoBowScript>().ourhomebase = O;
            Kinobow.GetComponent<KinoBowScript>().enemyhomebase = E;
            Kinobow.GetComponent<KinoBowScript>().F = F;
            Kinobow.GetComponent<KinoBowScript>().KinoBowLevel += levelmanager.GetComponent<CountsScript>().Kinobowuplevel;
        }
    }

    public void Wave()
    {

        S = Random.Range(4 + enemydifficulty, 6 + enemydifficulty * 2);
        R = Random.Range(3 + enemydifficulty, 5 + enemydifficulty * 2);

        for (int i = 0; i < S; i++)
        {
            ESoldierG();
        }
        for (int i = 0; i < R; i++)
        {
            ERangerG();
        }


    }
}
