using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountsScript : MonoBehaviour
{



    public Text playerkillenemycounts;
    public Text playercoincounts;
    public Text tech;
    public Text Techpoints;

    public static float ccounts;
    public static int KC;
    public static int CC;
    public static int TECH;
    public static int TECHPOINTS;
    public static float techpoints;
    //多分内部ではコインの変数を、int型のCCではなくfloat型のccountsでしており、それをint型に直して出力している。 KCについても同じ。

    private float LevelUpCost;  //レベルアップ時に必要なコスト
    public Text LevelUpCostText;
    private float TechUpCost;  //レベルアップ時に必要なコスト
    public Text TechUpCostText0;
    public Text TechUpCostText1;
    public int Kinosoluplevel;
    public int Kinobowuplevel;

    public int Takeyariuplevel;
    public int Takemusuplevel;
    public int NowLevel;


    public TakeMusketScript takeMusketScript;
    public TakeYariScript takeYariScript;
    public KinoBowScript kinobowscript;
    public KinoSwordScript kinoSwordScript;

    
    
        
    
    // Start is called before the first frame update
    void Start()
    {
        techpoints = 50;
        ccounts = 50; //初期所持金
        TECH = 1;
        LevelUpCost = 50;
        NowLevel = 0;
        TechUpCost = 100;
        Kinosoluplevel = 0;
        Takeyariuplevel = 0;
        TechUpCostText0.text = TechUpCost.ToString() + "TP TechUp";
        TechUpCostText1.text = TechUpCost.ToString() + "TP TechUp";


    }
    // Update is called once per frame
    void Update()
    {
        techpoints += Time.deltaTime;
        ccounts += Time.deltaTime * ((TECH * 2 + 9) * (NowLevel + 2) / 3) / 5;

        
        

        //相手を倒したら幾分かコインとkillenemycountを増やすスクリプトを下に書く

        CC = (int)ccounts;
        TECHPOINTS = (int)techpoints;

        playerkillenemycounts.text = "キル数:" + KC.ToString();
        playercoincounts.text = CC.ToString() + "C";
        tech.text = "TL:" + TECH;
        Techpoints.text = "TP:" + TECHPOINTS.ToString();

        
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            levelup();
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            techup();
        }
        
    }

    public static void Coin(int cost)
    {
        ccounts -= cost;
        Debug.Log("CC:"+(int)ccounts); 
    }
    
    public void levelup()
    {
        if (ccounts >= LevelUpCost)
        {
            
            ccounts -= LevelUpCost;
            LevelUpCost += 50f;  //レベル上昇毎に50づつコストアップ
            LevelUpCostText.text = LevelUpCost.ToString() + "C LevelUp";
            if(PlayerScript.Hanbetu == Faction.KINOKO)
            {
                Kinosoluplevel += 1;
                Kinobowuplevel += 1;

            }
            else if (PlayerScript.Hanbetu == Faction.TAKENOKO)
            {
                Takeyariuplevel += 1;
                Takemusuplevel += 1;
            }
            NowLevel += 1;
        }
        else
        {
            Debug.Log("cannnotlevelUP");
        }

    }
    public void techup()
    {
        if (techpoints >= TechUpCost)
        {
            TECH += 1;
            this.gameObject.GetComponent<PlayerScript>().CanUseTech = TECH;
            techpoints -= TechUpCost;
            TechUpCost += 50f;  //技術上昇毎に50づつコストアップ
            TechUpCostText0.text = TechUpCost.ToString() + "TP TechUp";
            TechUpCostText1.text = TechUpCost.ToString() + "TP TechUp";




            if (PlayerScript.Hanbetu == Faction.KINOKO)
            {
                if (TECH == 1)
                {
                    Kinosoluplevel += 1;
                }
                if (TECH == 2)
                {
                    Kinosoluplevel += 1;
                }
                if (TECH == 3)
                {
                    Kinosoluplevel +=1;
                }
                if (TECH == 4)
                {
                    Kinosoluplevel += 1;
                }
                if (TECH == 5)
                {
                    Kinosoluplevel += 1;
                }
                if (TECH == 6)
                {
                    Kinosoluplevel += 1;
                }
                if (TECH == 7)
                {
                    Kinosoluplevel += 1;
                }

                if (TECH == 1)
                {
                    Kinosoluplevel += 1;
                }
                if (TECH == 2)
                {
                    Kinobowuplevel += 1;
                }
                if (TECH == 3)
                {
                    Kinobowuplevel += 1;
                }
                if (TECH == 4)
                {
                    Kinobowuplevel += 1;
                }
                if (TECH == 5)
                {
                    Kinobowuplevel += 1;
                }
                if (TECH == 6)
                {
                    Kinobowuplevel += 1;
                }
                if (TECH == 7)
                {
                    Kinobowuplevel += 1;
                }
            }
            else if (PlayerScript.Hanbetu == Faction.TAKENOKO)
            {
                if (TECH == 1)
                {
                    Kinosoluplevel += 1;
                }
                if (TECH == 2)
                {
                    Takeyariuplevel += 1;
                }
                if (TECH == 3)
                {
                    Takeyariuplevel += 1;
                }
                if (TECH == 4)
                {
                    Takeyariuplevel += 1;
                }
                if (TECH == 5)
                {
                    Takeyariuplevel += 1;
                }
                if (TECH == 6)
                {
                    Takeyariuplevel += 1;
                }
                if (TECH == 7)
                {
                    Takeyariuplevel += 1;
                }

                if (TECH == 1)
                {
                    Kinosoluplevel += 1;
                }
                if (TECH == 2)
                {
                    Takemusuplevel += 1;
                }
                if (TECH == 3)
                {
                    Takemusuplevel += 1;
                }
                if (TECH == 4)
                {
                    Takemusuplevel += 1;
                }
                if (TECH == 5)
                {
                    Takemusuplevel += 1;
                }
                if (TECH == 6)
                {
                    Takemusuplevel += 1;
                }
                if (TECH == 7)
                {
                    Takemusuplevel += 1;
                } //上記のスクリプトが長いのは筍陣営と茸陣営の、それぞれの兵科が書かれているから。間違いではない。


            }
        }
        else
        {
            Debug.Log("cannnottechUP");
        }

    }


}
