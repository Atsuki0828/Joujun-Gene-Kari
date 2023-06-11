using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    

    public GameObject O;
    public GameObject E;
    public GameObject levelmanager;

    //キャラクターのスクリプトを取ってきて、その後でキャラクターの目標であるキャラクターのスクリプト内のenemyhomebaseとourhomebaseを設定する。


    public GameObject ty,tg,ks,kb;
    
    public int tas;
    public int tar;
    public int kis;
    public int kir;

    float x;
    float z;
    Vector3 pos;
    public FactionScript F;

    //[System.NonSerialized] < inspector上に表示させないが他のスクリプト上からアクセスできる
    // Start is called before the first frame update
    void Start()
    {
        



    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                SoldierG();
                

            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                RangerG();
                
            }

        tas = this.GetComponent<UnitValueScript>().TSV;
        tar = this.GetComponent<UnitValueScript>().TRV;
        kis = this.GetComponent<UnitValueScript>().KSV;
        kir = this.GetComponent<UnitValueScript>().KRV;


    }
    public void SoldierG()
    {
        if (PlayerScript.Hanbetu == Faction.TAKENOKO)
        {
            if (CountsScript.ccounts >= tas)
            {
                x = Random.Range(-10f, 10f);
                z = Random.Range(-43f, -46f);
                pos = new Vector3(x, 0.7142222f, z);
                GameObject Takesol = Instantiate(ty, pos, Quaternion.identity);
                F.Takenokolist.Add(Takesol.transform);
                Takesol.GetComponent<TakeYariScript>().ourhomebase = O;
                Takesol.GetComponent<TakeYariScript>().enemyhomebase = E;
                Takesol.GetComponent<TakeYariScript>().F = F;
                Takesol.GetComponent<TakeYariScript>().TakeYariLevel += levelmanager.GetComponent<CountsScript>().Takeyariuplevel;
                CountsScript.Coin(tas);
            }else{
                Debug.Log("cannot generate");
            }
        }
        else if (PlayerScript.Hanbetu == Faction.KINOKO)
        {
            if (CountsScript.ccounts >= kis)
            {
                x = Random.Range(-10f, 10f);
                z = Random.Range(-43f, -46f);
                pos = new Vector3(x, 0.7142222f, z);
                GameObject Kinosol = Instantiate(ks, pos, Quaternion.identity);
                F.Kinokolist.Add(Kinosol.transform);
                Kinosol.GetComponent<KinoSwordScript>().ourhomebase = O;
                Kinosol.GetComponent<KinoSwordScript>().enemyhomebase = E;
                Kinosol.GetComponent<KinoSwordScript>().F = F;
                Kinosol.GetComponent<KinoSwordScript>().KinoSolLevel += levelmanager.GetComponent<CountsScript>().Kinosoluplevel;

                CountsScript.Coin(kis);
            }
            else
            {
                Debug.Log("cannot generate");
            }
        }

    }
    public void RangerG()
    {
        if (PlayerScript.Hanbetu == Faction.TAKENOKO)
        {
            if (CountsScript.ccounts >= tar)
            {
                x = Random.Range(-10f, 10f);
                z = Random.Range(-43f, -46f);
                pos = new Vector3(x, 0.7142222f, z);
                GameObject Takemus = Instantiate(tg, pos, Quaternion.identity);
                F.Takenokolist.Add(Takemus.transform);
                Takemus.GetComponent<TakeMusketScript>().ourhomebase = O;
                Takemus.GetComponent<TakeMusketScript>().enemyhomebase = E;
                Takemus.GetComponent<TakeMusketScript>().F = F;
                Takemus.GetComponent<TakeMusketScript>().TakeMusLevel += levelmanager.GetComponent<CountsScript>().Takemusuplevel;
                CountsScript.Coin(tar);
            }
            else
            {
                Debug.Log("cannot generate");
            }
        }
        else if (PlayerScript.Hanbetu == Faction.KINOKO)
        {
            if (CountsScript.ccounts >= kir)
            {
                x = Random.Range(-10f, 10f);
                z = Random.Range(-43f, -46f);
                pos = new Vector3(x, 0.7142222f, z);
                GameObject Kinobow = Instantiate(kb, pos, Quaternion.identity);
                F.Kinokolist.Add(Kinobow.transform);
                Kinobow.GetComponent<KinoBowScript>().ourhomebase = O;
                Kinobow.GetComponent<KinoBowScript>().enemyhomebase = E;
                Kinobow.GetComponent<KinoBowScript>().F = F;
                Kinobow.GetComponent<KinoBowScript>().KinoBowLevel += levelmanager.GetComponent<CountsScript>().Kinobowuplevel;
                CountsScript.Coin(kir);
            }
            else
            {
                Debug.Log("cannot generate");
            }
        }
    }
}
