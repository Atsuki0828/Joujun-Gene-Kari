using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum Faction
{
    KINOKO,TAKENOKO
}

public class PlayerScript : MonoBehaviour
{
    //アイテムマネージャー
    [SerializeField]
    private ItemDataBase CWeaponsDatabase;
    [SerializeField]
    private ItemDataBase ArmorsDatabase;
    [SerializeField]
    private ItemDataBase LWeaponsDatabase;

    //選択中のアイテムに関するテキスト等
    public int sentakuCW;
    public Text CWName;
    public Text CWInfo;
    public int sentakuCA;
    public Text CAName;
    public Text CAInfo;
    public int sentakuLW;
    public Text LWName;
    public Text LWInfo;
    public int sentakuLA;
    public Text LAName;
    public Text LAInfo;




    public static Faction Hanbetu;

    //画面遷移gameobject
    public GameObject SoldierManagePanel;
    public GameObject RangerManagePanel;

    public GameObject commonpanel;


    //Manage画面UI
    public Image CWeaponImage;
    public Image CArmorImage;

    public Image LWeaponImage;
    public Image LArmorImage;

    //参照するスクリプト変数
    public KinoSwordScript kinos;
    public KinoBowScript kinob;
    public TakeYariScript takey;
    public TakeMusketScript takem;

    //装備を使用可能か
    public int CanUseTech;

    //敵の装備に関して
    public static Items EnemyHaveCWeapons;
    public static Items EnemyHaveLWeapons;
    public static Items EnemyHaveCArmors;
    public static Items EnemyHaveLArmors;

    public float enemytechuptime;
    public float enemytechuptimeamount;
    public static int enemytech;

    public static string FirstW;
    public static string SecondW;
    public static string ThirdW;
    public static string FourthW;


    // Start is called before the first frame update
    void Start()
    {
        enemytech = 1;
        enemytechuptimeamount = 100;
        enemytechuptime = 50;


        SoldierManagePanel.SetActive(false);
        RangerManagePanel.SetActive(false);
        commonpanel.SetActive(true);
        //近接キャラの武器
        CWeaponImage.sprite = CWeaponsDatabase.GetItemLists()[0].GetIcon();
        CWName.text = CWeaponsDatabase.GetItemLists()[sentakuCW].GetItemName();
        CWInfo.text =
        "近接攻撃力 : " + CWeaponsDatabase.GetItemLists()[sentakuCW].GetATK()
        + "\r\n 近接攻撃速度 : " + CWeaponsDatabase.GetItemLists()[sentakuCW].GetATKSpeed() + "/100秒に1回"
        + "\r\n 防御力 : " + CWeaponsDatabase.GetItemLists()[sentakuCW].GetGuard()
        + "\r\n 追加ユニットコスト : " + CWeaponsDatabase.GetItemLists()[sentakuCW].GetUnitcost() + "コイン"
        + "\r\n 対遠隔攻撃 : " + CWeaponsDatabase.GetItemLists()[sentakuCW].GetBulletproofness() + "%軽減"
        + "\r\n 重量 : " + CWeaponsDatabase.GetItemLists()[sentakuCW].GetUnitspeeddown()
        + "\r\n 情報 : " + CWeaponsDatabase.GetItemLists()[sentakuCW].GetInformation();


        CArmorImage.sprite = ArmorsDatabase.GetItemLists()[0].GetIcon();
        CAName.text = ArmorsDatabase.GetItemLists()[sentakuCA].GetItemName();

        CAInfo.text =
        "近接防御力 : " + ArmorsDatabase.GetItemLists()[sentakuCA].GetGuard()
        + "\r\n 追加ユニットコスト : " + ArmorsDatabase.GetItemLists()[sentakuCA].GetUnitcost() + "コイン"
        + "\r\n 対遠隔攻撃 : " + ArmorsDatabase.GetItemLists()[sentakuCA].GetBulletproofness() + "%軽減"
        + "\r\n 重量 : " + ArmorsDatabase.GetItemLists()[sentakuCA].GetUnitspeeddown()
        + "\r\n 情報 : " + ArmorsDatabase.GetItemLists()[sentakuCA].GetInformation();

        LWeaponImage.sprite = LWeaponsDatabase.GetItemLists()[0].GetIcon();
        LWName.text = LWeaponsDatabase.GetItemLists()[sentakuLW].GetItemName();

        LWInfo.text =
        " 近接攻撃力 : " + LWeaponsDatabase.GetItemLists()[sentakuLW].GetATK()
        + "\r\n 近接防御力 : " + LWeaponsDatabase.GetItemLists()[sentakuLW].GetGuard()
        + "\r\n 遠隔攻撃力 : " + LWeaponsDatabase.GetItemLists()[sentakuLW].GetBulletATK()
        + "\r\n 遠隔攻撃速度 : " + LWeaponsDatabase.GetItemLists()[sentakuLW].GetBulletATKSpeed() + "/100秒に1回"
        + "\r\n 弾速 : " + LWeaponsDatabase.GetItemLists()[sentakuLW].GetBulletSpeed() + "/100秒に1回"
        + "\r\n 弾の飛距離 : " + LWeaponsDatabase.GetItemLists()[sentakuLW].GetBulletRange() + "/100秒に1回"
        + "\r\n 弾の命中率　:　" + LWeaponsDatabase.GetItemLists()[sentakuLW].GetBulletAccuracy() + "/ターゲットから2*Xfだけずらして弾を発射する"
        + "\r\n 使う弾の名前 : " + LWeaponsDatabase.GetItemLists()[sentakuLW].Getbulletgameobject()
        + "\r\n 追加ユニットコスト : " + LWeaponsDatabase.GetItemLists()[sentakuLW].GetUnitcost() + "コイン"
        + "\r\n 重量 : " + LWeaponsDatabase.GetItemLists()[sentakuLW].GetUnitspeeddown()
        + "\r\n 情報 : " + LWeaponsDatabase.GetItemLists()[sentakuLW].GetInformation();

        LArmorImage.sprite = ArmorsDatabase.GetItemLists()[0].GetIcon();
        LAName.text = ArmorsDatabase.GetItemLists()[sentakuLA].GetItemName();

        LAInfo.text =
        "近接防御力 : " + ArmorsDatabase.GetItemLists()[sentakuLA].GetGuard()
        + "\r\n 追加ユニットコスト : " + ArmorsDatabase.GetItemLists()[sentakuLA].GetUnitcost() + "コイン"
        + "\r\n 対遠隔攻撃 : " + ArmorsDatabase.GetItemLists()[sentakuLA].GetBulletproofness() + "%軽減"
        + "\r\n 重量 : " + ArmorsDatabase.GetItemLists()[sentakuLA].GetUnitspeeddown()
        + "\r\n 情報 : " + ArmorsDatabase.GetItemLists()[sentakuLA].GetInformation();

        sentakuCW = 0;
        sentakuCA = 0;
        sentakuLW = 0;
        sentakuLA = 0;




        //敵の初期装備
        ETECH("素手", "スリンガー", "裸", "裸");





        //近距離装備の情報代入
        if (Hanbetu == Faction.KINOKO)
        {
            kinos.WEquipname = CWeaponsDatabase.GetItemLists()[sentakuCW].GetItemName();
            kinos.WEquipATK = CWeaponsDatabase.GetItemLists()[sentakuCW].GetATK();
            kinos.WEquipATKspeed = CWeaponsDatabase.GetItemLists()[sentakuCW].GetATKSpeed();
            kinos.WEquipBulletATK = CWeaponsDatabase.GetItemLists()[sentakuCW].GetBulletATK();
            kinos.WEquipBulletATKspeed = CWeaponsDatabase.GetItemLists()[sentakuCW].GetBulletATKSpeed();
            kinos.WEquipBulletproofness = CWeaponsDatabase.GetItemLists()[sentakuCW].GetBulletproofness();
            kinos.WEquipGuard = CWeaponsDatabase.GetItemLists()[sentakuCW].GetGuard();
            kinos.WEquipMass = CWeaponsDatabase.GetItemLists()[sentakuCW].GetUnitspeeddown();
            kinos.WEquipUnitcost = CWeaponsDatabase.GetItemLists()[sentakuCW].GetUnitcost();
        }
        else if (Hanbetu == Faction.TAKENOKO)
        {
            takey.WEquipname = CWeaponsDatabase.GetItemLists()[sentakuCW].GetItemName();
            takey.WEquipATK = CWeaponsDatabase.GetItemLists()[sentakuCW].GetATK();
            takey.WEquipATKspeed = CWeaponsDatabase.GetItemLists()[sentakuCW].GetATKSpeed();
            takey.WEquipBulletATK = CWeaponsDatabase.GetItemLists()[sentakuCW].GetBulletATK();
            takey.WEquipBulletATKspeed = CWeaponsDatabase.GetItemLists()[sentakuCW].GetBulletATKSpeed();
            takey.WEquipBulletproofness = CWeaponsDatabase.GetItemLists()[sentakuCW].GetBulletproofness();
            takey.WEquipGuard = CWeaponsDatabase.GetItemLists()[sentakuCW].GetGuard();
            takey.WEquipMass = CWeaponsDatabase.GetItemLists()[sentakuCW].GetUnitspeeddown();
            takey.WEquipUnitcost = CWeaponsDatabase.GetItemLists()[sentakuCW].GetUnitcost();

        }
        else
        {

        }

        //防御装備の情報代入

        if (Hanbetu == Faction.KINOKO)
        {
            kinos.AEquipname = ArmorsDatabase.GetItemLists()[sentakuCA].GetItemName();
            kinos.AEquipATK = ArmorsDatabase.GetItemLists()[sentakuCA].GetATK();
            kinos.AEquipATKspeed = ArmorsDatabase.GetItemLists()[sentakuCA].GetATKSpeed();
            kinos.AEquipBulletATK = ArmorsDatabase.GetItemLists()[sentakuCA].GetBulletATK();
            kinos.AEquipBulletATKspeed = ArmorsDatabase.GetItemLists()[sentakuCA].GetBulletATKSpeed();
            kinos.AEquipBulletproofness = ArmorsDatabase.GetItemLists()[sentakuCA].GetBulletproofness();
            kinos.AEquipGuard = ArmorsDatabase.GetItemLists()[sentakuCA].GetGuard();
            kinos.AEquipMass = ArmorsDatabase.GetItemLists()[sentakuCA].GetUnitspeeddown();
            kinos.AEquipUnitcost = ArmorsDatabase.GetItemLists()[sentakuCA].GetUnitcost();
        }
        else if (Hanbetu == Faction.TAKENOKO)
        {
            takey.AEquipname = ArmorsDatabase.GetItemLists()[sentakuCA].GetItemName();
            takey.AEquipATK = ArmorsDatabase.GetItemLists()[sentakuCA].GetATK();
            takey.AEquipATKspeed = ArmorsDatabase.GetItemLists()[sentakuCA].GetATKSpeed();
            takey.AEquipBulletATK = ArmorsDatabase.GetItemLists()[sentakuCA].GetBulletATK();
            takey.AEquipBulletATKspeed = ArmorsDatabase.GetItemLists()[sentakuCA].GetBulletATKSpeed();
            takey.AEquipBulletproofness = ArmorsDatabase.GetItemLists()[sentakuCA].GetBulletproofness();
            takey.AEquipGuard = ArmorsDatabase.GetItemLists()[sentakuCA].GetGuard();
            takey.AEquipMass = ArmorsDatabase.GetItemLists()[sentakuCA].GetUnitspeeddown();
            takey.AEquipUnitcost = ArmorsDatabase.GetItemLists()[sentakuCA].GetUnitcost();
        }
        else
        {

        }

        //遠距離装備の情報代入
        if (Hanbetu == Faction.KINOKO)
        {
 
            kinob.WEquipname = LWeaponsDatabase.GetItemLists()[sentakuLW].GetItemName();
            kinob.WEquipATK = LWeaponsDatabase.GetItemLists()[sentakuLW].GetATK();
            kinob.WEquipATKspeed = LWeaponsDatabase.GetItemLists()[sentakuLW].GetATKSpeed();
            kinob.WEquipBulletATK = LWeaponsDatabase.GetItemLists()[sentakuLW].GetBulletATK();
            kinob.WEquipBulletATKspeed = LWeaponsDatabase.GetItemLists()[sentakuLW].GetBulletATKSpeed();
            kinob.WEquipBulletspeed = LWeaponsDatabase.GetItemLists()[sentakuLW].GetBulletSpeed();
            kinob.WEquipBulletrange = LWeaponsDatabase.GetItemLists()[sentakuLW].GetBulletRange();
            kinob.WEquipBulletAccuracy = LWeaponsDatabase.GetItemLists()[sentakuLW].GetBulletAccuracy();
            kinob.WEquipBulletgameobject = LWeaponsDatabase.GetItemLists()[sentakuLW].Getbulletgameobject();
            kinob.WEquipBulletproofness = LWeaponsDatabase.GetItemLists()[sentakuLW].GetBulletproofness();
            kinob.WEquipGuard = LWeaponsDatabase.GetItemLists()[sentakuLW].GetGuard();
            kinob.WEquipMass = LWeaponsDatabase.GetItemLists()[sentakuLW].GetUnitspeeddown();
            kinob.WEquipUnitcost = LWeaponsDatabase.GetItemLists()[sentakuLW].GetUnitcost();
        }
        else if (Hanbetu == Faction.TAKENOKO)
        {
            takem.WEquipname = LWeaponsDatabase.GetItemLists()[sentakuLW].GetItemName();
            takem.WEquipATK = LWeaponsDatabase.GetItemLists()[sentakuLW].GetATK();
            takem.WEquipATKspeed = LWeaponsDatabase.GetItemLists()[sentakuLW].GetATKSpeed();
            takem.WEquipBulletATK = LWeaponsDatabase.GetItemLists()[sentakuLW].GetBulletATK();
            takem.WEquipBulletATKspeed = LWeaponsDatabase.GetItemLists()[sentakuLW].GetBulletATKSpeed();
            takem.WEquipBulletspeed = LWeaponsDatabase.GetItemLists()[sentakuLW].GetBulletSpeed();
            takem.WEquipBulletrange = LWeaponsDatabase.GetItemLists()[sentakuLW].GetBulletRange();
            takem.WEquipBulletAccuracy = LWeaponsDatabase.GetItemLists()[sentakuLW].GetBulletAccuracy();
            takem.WEquipBulletgameobject = LWeaponsDatabase.GetItemLists()[sentakuLW].Getbulletgameobject();
            takem.WEquipBulletproofness = LWeaponsDatabase.GetItemLists()[sentakuLW].GetBulletproofness();
            takem.WEquipGuard = LWeaponsDatabase.GetItemLists()[sentakuLW].GetGuard();
            takem.WEquipMass = LWeaponsDatabase.GetItemLists()[sentakuLW].GetUnitspeeddown();
            takem.WEquipUnitcost = LWeaponsDatabase.GetItemLists()[sentakuLW].GetUnitcost();
        }
        else
        {

        }

        
        


        //EnemyHaveCWeapons = this.gameObject.GetComponent<Managers>().GetCWeaponsItem("素手");
        //EnemyHaveLWeapons = this.gameObject.GetComponent<Managers>().GetLWeaponsItem("スリンガー");
        //EnemyHaveCArmors = this.gameObject.GetComponent<Managers>().GetArmorsItem("裸");
        //EnemyHaveLArmors = this.gameObject.GetComponent<Managers>().GetArmorsItem("裸");

        //EnemyCWeaponsIn(EnemyHaveCWeapons);
        //EnemyCArmorsIn(EnemyHaveCArmors);
        //EnemyLWeaponsIn(EnemyHaveLWeapons);
        //EnemyLArmorsIn(EnemyHaveLArmors);

        //味方の装備品のセットアップ
        CWEquipClick();
        CAEquipClick();
        LWEquipClick();
        LAEquipClick();
    }

    // Update is called once per frame

    public void OnClickSolEquipPanel()
    {
        if (SoldierManagePanel.activeSelf == false)
        {
            SoldierManagePanel.SetActive(true);
            RangerManagePanel.SetActive(false);
            commonpanel.SetActive(false);
        }
        else if (SoldierManagePanel.activeSelf == true)
        {
            SoldierManagePanel.SetActive(false);
            RangerManagePanel.SetActive(false);
            commonpanel.SetActive(true);
        }
    }
    public void OnClickRanEquipPanel()
    {
        if (RangerManagePanel.activeSelf == false)
        {
            SoldierManagePanel.SetActive(false);
            RangerManagePanel.SetActive(true);
            commonpanel.SetActive(false);
        }
        else if (RangerManagePanel.activeSelf == true)
        {
            SoldierManagePanel.SetActive(false);
            RangerManagePanel.SetActive(false);
            commonpanel.SetActive(true);
        }
    }
    public void OnClickBackToGamePanel()
    {
        if (commonpanel == false)
        {
            SoldierManagePanel.SetActive(false);
            RangerManagePanel.SetActive(false);
            commonpanel.SetActive(true);
        }
        else if (commonpanel == true)
        {
            SoldierManagePanel.SetActive(false);
            RangerManagePanel.SetActive(false);
            commonpanel.SetActive(true);
        }
    }
    void Update()
    {
        //画面遷移
        if (Input.GetKeyDown(KeyCode.C))
        {
            OnClickSolEquipPanel();

        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            OnClickRanEquipPanel();
            
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            OnClickBackToGamePanel();
            
        }

        

        //敵の装備に関して
        enemytechuptime += Time.deltaTime * (StageSelectScript.GameDifficultySet + 1) / 2;
        if(enemytechuptime > enemytechuptimeamount)
        {
            enemytech += 1;
            enemytechuptime -= enemytechuptimeamount;
            enemytechuptimeamount += 50;
            if (Hanbetu == Faction.KINOKO)
            {
                TakeYariScript.ETakeYariLevel += 1;
                TakeMusketScript.ETakeMusLevel += 1;

                if (enemytech == 1)
                {
                    ETECH("素手", "スリンガー", "裸", "裸");
                    //レベルアップに伴う敵のユニットのレベルの上昇を書く。
                    
                }
                else if (enemytech == 2)
                {
                    ETECH("木の棒", "スリンガー", "ボロ着", "ボロ着");
                }
                else if (enemytech == 3)
                {
                    ETECH("剣", "スリンガー", "レザーアーマー", "レザーアーマー");
                }
                else if (enemytech == 4)
                {
                    ETECH("槍", "弓", "鎖帷子", "鎖帷子");
                }
                else if (enemytech == 5)
                {
                    ETECH("刀", "長弓", "甲冑", "甲冑");
                }
                else if (enemytech == 6)
                {
                    ETECH("刀", "マスケット", "甲冑", "甲冑");
                }
                else if (enemytech == 7)
                {
                    ETECH("刀", "マスケット", "胸甲", "胸甲");
                }
                else if (enemytech == 8)
                {
                    ETECH("刀", "マスケット", "胸甲", "胸甲");
                }
                else
                {

                }
                BasicLevelupAmounts();
                
            }
            else
            {

                KinoSwordScript.EKinoSolLevel += 1;
                KinoBowScript.EKinoBowLevel += 1;
               
                if (enemytech == 1)
                {
                    ETECH("素手", "スリンガー", "裸", "裸");
                    //レベルアップに伴う敵のユニットのレベルの上昇を書く。
                }
                else if (enemytech == 2)
                {
                    ETECH("木の棒", "スリンガー", "ボロ着", "ボロ着");
                }
                else if (enemytech == 3)
                {
                    ETECH("剣", "スリンガー", "レザーアーマー", "レザーアーマー");
                }
                else if (enemytech == 4)
                {
                    ETECH("槍", "弓", "鎖帷子", "鎖帷子");
                }
                else if (enemytech == 5)
                {
                    ETECH("刀", "長弓", "甲冑", "甲冑");
                }
                else if (enemytech == 6)
                {
                    ETECH("刀", "マスケット", "甲冑", "甲冑");
                }
                else if (enemytech == 7)
                {
                    ETECH("刀", "マスケット", "胸甲", "胸甲");
                }
                else if (enemytech == 8)
                {
                    ETECH("刀", "マスケット", "胸甲", "胸甲");
                }
                else
                {

                }
                BasicLevelupAmounts();

            }
        }


    }

    public void BasicLevelupAmounts()
    {
        if(Hanbetu == Faction.KINOKO)
        {
            this.GetComponent<CountsScript>().Takeyariuplevel += 1;
            this.GetComponent<CountsScript>().Takemusuplevel += 1;
        } else if (Hanbetu == Faction.TAKENOKO)
        {
            this.GetComponent<CountsScript>().Kinosoluplevel += 1;
            this.GetComponent<CountsScript>().Kinobowuplevel += 1;
        }
        else
        {

        }
    }


    public void ETECH (string firstW, string secondW,string thirdW,string fourthW)
    {
        FirstW = firstW;
        SecondW = secondW;
        ThirdW = thirdW;
        FourthW = fourthW;
        EnemyHaveCWeapons = this.gameObject.GetComponent<Managers>().GetCWeaponsItem(firstW);
        EnemyHaveLWeapons = this.gameObject.GetComponent<Managers>().GetLWeaponsItem(secondW);
        EnemyHaveCArmors = this.gameObject.GetComponent<Managers>().GetArmorsItem(thirdW);
        EnemyHaveLArmors = this.gameObject.GetComponent<Managers>().GetArmorsItem(fourthW);

        EnemyCWeaponsIn(EnemyHaveCWeapons);
        EnemyCArmorsIn(EnemyHaveCArmors);
        EnemyLWeaponsIn(EnemyHaveLWeapons);
        EnemyLArmorsIn(EnemyHaveLArmors);
    }



    //武器、防具の選択ボタン-------------------------------------------------------------
    //テンプレ
    //public void CWRightArrow()//近接キャラの武器
    //{

    //    sentakuCW += 1;
    //    CWeaponImage.sprite = CWeaponsDatabase.GetItemLists()[sentakuCW].GetIcon();
    //    if (CWeaponImage.sprite == null)
    //    {
    //        sentakuCW = 0;
    //        CWeaponImage.sprite = CWeaponsDatabase.GetItemLists()[sentakuCW].GetIcon();
    //    }
    //    //武器及び防具の情報表示
    //    CWName.text = CWeaponsDatabase.GetItemLists()[sentakuCW].GetItemName();

    //    CWInfo.text = " 近接攻撃力 : " + CWeaponsDatabase.GetItemLists()[sentakuCW].GetATK()
    //    + "\r\n 近接攻撃速度 : " + CWeaponsDatabase.GetItemLists()[sentakuCW].GetATKSpeed() + "/100秒に1回"
    //    + "\r\n 防御力 : " + CWeaponsDatabase.GetItemLists()[sentakuCW].GetGuard()
    //    + "\r\n 追加ユニットコスト : " + CWeaponsDatabase.GetItemLists()[sentakuCW].GetUnitcost() + "コイン"
    //    + "\r\n 対遠隔攻撃 : " + CWeaponsDatabase.GetItemLists()[sentakuCW].GetBulletproofness() + "%軽減"
    //    + "\r\n 遠隔攻撃力 : " + CWeaponsDatabase.GetItemLists()[sentakuCW].GetBulletATK()
    //    + "\r\n 遠隔攻撃速度 : " + CWeaponsDatabase.GetItemLists()[sentakuCW].GetBulletATKSpeed() + "/100秒に1回"
    //    + "\r\n 弾速 : " + LWeaponsDatabase.GetItemLists()[sentakuLW].GetBulletSpeed() + "/100秒に1回"
    //    + "\r\n 弾の飛距離 : " + LWeaponsDatabase.GetItemLists()[sentakuLW].GetBulletRange() + "/100秒に1回"
    //    + "\r\n 重量 : " + CWeaponsDatabase.GetItemLists()[sentakuCW].GetUnitspeeddown()
    //    + "\r\n 情報 : " + CWeaponsDatabase.GetItemLists()[sentakuCW].GetInformation();
    //      　因みに、近距離攻撃によって与らるる式は右記　敵近接攻撃力 - 防御力
    //      　遠距離攻撃によって与らるる式は右記　敵遠隔攻撃力*(100 - 対遠隔攻撃%)-防御力
    //        
    //}
    //----------------------------------------------------------------
    public void CWRightArrow()//近接キャラの武器
    {
        if (CanUseTech >= CWeaponsDatabase.GetItemLists()[sentakuCW + 1].GetKindOfTech())
        {
            sentakuCW += 1;
        }
        else
        {
        }
        CWeaponImage.sprite = CWeaponsDatabase.GetItemLists()[sentakuCW].GetIcon();
        if (CWeaponImage.sprite == null)
        {
            sentakuCW = 0;
            CWeaponImage.sprite = CWeaponsDatabase.GetItemLists()[sentakuCW].GetIcon();
        }
        //武器及び防具の情報表示
        CWName.text = CWeaponsDatabase.GetItemLists()[sentakuCW].GetItemName();

        CWInfo.text =
        " 近接攻撃力 : " + CWeaponsDatabase.GetItemLists()[sentakuCW].GetATK()
        + "\r\n 近接攻撃速度 : " + CWeaponsDatabase.GetItemLists()[sentakuCW].GetATKSpeed() + "/100秒に1回"
        + "\r\n 防御力 : " + CWeaponsDatabase.GetItemLists()[sentakuCW].GetGuard()
        + "\r\n 追加ユニットコスト : " + CWeaponsDatabase.GetItemLists()[sentakuCW].GetUnitcost() + "コイン"
        + "\r\n 対遠隔攻撃 : " + CWeaponsDatabase.GetItemLists()[sentakuCW].GetBulletproofness() + "%軽減"
        + "\r\n 重量 : " + CWeaponsDatabase.GetItemLists()[sentakuCW].GetUnitspeeddown()
        + "\r\n 情報 : " + CWeaponsDatabase.GetItemLists()[sentakuCW].GetInformation();
    }

    public void CWLeftArrow()
    {

        sentakuCW -= 1;



        if (sentakuCW < 0)
        {
            sentakuCW = 0;
            CWeaponImage.sprite = CWeaponsDatabase.GetItemLists()[sentakuCW].GetIcon();
        }
        CWeaponImage.sprite = CWeaponsDatabase.GetItemLists()[sentakuCW].GetIcon();
        //武器及び防具の情報表示
        CWName.text = CWeaponsDatabase.GetItemLists()[sentakuCW].GetItemName();

        CWInfo.text =
        " 近接攻撃力 : " + CWeaponsDatabase.GetItemLists()[sentakuCW].GetATK()
        + "\r\n 近接攻撃速度 : " + CWeaponsDatabase.GetItemLists()[sentakuCW].GetATKSpeed() + "/100秒に1回"
        + "\r\n 防御力 : " + CWeaponsDatabase.GetItemLists()[sentakuCW].GetGuard()
        + "\r\n 追加ユニットコスト : " + CWeaponsDatabase.GetItemLists()[sentakuCW].GetUnitcost() + "コイン"
        + "\r\n 対遠隔攻撃 : " + CWeaponsDatabase.GetItemLists()[sentakuCW].GetBulletproofness() + "%軽減"
        + "\r\n 重量 : " + CWeaponsDatabase.GetItemLists()[sentakuCW].GetUnitspeeddown()
        + "\r\n 情報 : " + CWeaponsDatabase.GetItemLists()[sentakuCW].GetInformation();

    }

    public void CARightArrow()//近接キャラの防具
    {
        if (CanUseTech >= ArmorsDatabase.GetItemLists()[sentakuCA + 1].GetKindOfTech())
        {
            sentakuCA += 1;
        } else
        {
        }

        CArmorImage.sprite = ArmorsDatabase.GetItemLists()[sentakuCA].GetIcon();

        if (CArmorImage.sprite == null)
        {
            sentakuCA = 0;
            CArmorImage.sprite = ArmorsDatabase.GetItemLists()[sentakuCA].GetIcon();

        }
        //武器及び防具の情報表示
        CAName.text = ArmorsDatabase.GetItemLists()[sentakuCA].GetItemName();

        CAInfo.text =
        " 近接防御力 : " + ArmorsDatabase.GetItemLists()[sentakuCA].GetGuard()
        + "\r\n 追加ユニットコスト : " + ArmorsDatabase.GetItemLists()[sentakuCA].GetUnitcost() + "コイン"
        + "\r\n 対遠隔攻撃 : " + ArmorsDatabase.GetItemLists()[sentakuCA].GetBulletproofness() + "%軽減"
        + "\r\n 重量 : " + ArmorsDatabase.GetItemLists()[sentakuCA].GetUnitspeeddown()
        + "\r\n 情報 : " + ArmorsDatabase.GetItemLists()[sentakuCA].GetInformation();

    }
    public void CALeftArrow()
    {
        sentakuCA -= 1;

        if (sentakuCA < 0)
        {
            sentakuCA = 0;
            CArmorImage.sprite = ArmorsDatabase.GetItemLists()[sentakuCA].GetIcon();

        }
        CArmorImage.sprite = ArmorsDatabase.GetItemLists()[sentakuCA].GetIcon();
        //武器及び防具の情報表示
        CAName.text = ArmorsDatabase.GetItemLists()[sentakuCA].GetItemName();


        CAInfo.text =
        
        " 近接防御力 : " + ArmorsDatabase.GetItemLists()[sentakuCA].GetGuard()
        + "\r\n 追加ユニットコスト : " + ArmorsDatabase.GetItemLists()[sentakuCA].GetUnitcost() + "コイン"
        + "\r\n 対遠隔攻撃 : " + ArmorsDatabase.GetItemLists()[sentakuCA].GetBulletproofness() + "%軽減"
        + "\r\n 重量 : " + ArmorsDatabase.GetItemLists()[sentakuCA].GetUnitspeeddown()
        + "\r\n 情報 : " + ArmorsDatabase.GetItemLists()[sentakuCA].GetInformation();

    }
    public void LWRightArrow()//遠隔キャラの武器
    {
        if (CanUseTech >= LWeaponsDatabase.GetItemLists()[sentakuLW + 1].GetKindOfTech())
        {
            sentakuLW += 1;
        } else
        {
        }
        LWeaponImage.sprite = LWeaponsDatabase.GetItemLists()[sentakuLW].GetIcon();

        if (LWeaponImage.sprite == null)
        {
            sentakuLW = 0;
            LWeaponImage.sprite = LWeaponsDatabase.GetItemLists()[sentakuLW].GetIcon();
            
        }
        //武器及び防具の情報表示
        LWName.text = LWeaponsDatabase.GetItemLists()[sentakuLW].GetItemName();

        LWInfo.text =
        " 近接攻撃力 : " + LWeaponsDatabase.GetItemLists()[sentakuLW].GetATK()
        + "\r\n 近接防御力 : " + LWeaponsDatabase.GetItemLists()[sentakuLW].GetGuard()
        + "\r\n 遠隔攻撃力 : " + LWeaponsDatabase.GetItemLists()[sentakuLW].GetBulletATK()
        + "\r\n 遠隔攻撃速度 : " + LWeaponsDatabase.GetItemLists()[sentakuLW].GetBulletATKSpeed() + "/100秒に1回"
        + "\r\n 弾速 : " + LWeaponsDatabase.GetItemLists()[sentakuLW].GetBulletSpeed() + "/100秒に1回"
        + "\r\n 弾の飛距離 : " + LWeaponsDatabase.GetItemLists()[sentakuLW].GetBulletRange() + "/100秒に1回"
        + "\r\n 弾の命中率　:　" + LWeaponsDatabase.GetItemLists()[sentakuLW].GetBulletAccuracy() + "/ターゲットから2*Xfだけずらして弾を発射する"
        + "\r\n 使う弾の名前 : " + LWeaponsDatabase.GetItemLists()[sentakuLW].Getbulletgameobject()
        + "\r\n 追加ユニットコスト : " + LWeaponsDatabase.GetItemLists()[sentakuLW].GetUnitcost() + "コイン"
        + "\r\n 重量 : " + LWeaponsDatabase.GetItemLists()[sentakuLW].GetUnitspeeddown()
        + "\r\n 情報 : " + LWeaponsDatabase.GetItemLists()[sentakuLW].GetInformation();
    }

    public void LWLeftArrow()
    {
        sentakuLW -= 1;


        if (sentakuLW < 0)
        {
            sentakuLW = 0;
            LWeaponImage.sprite = LWeaponsDatabase.GetItemLists()[sentakuLW].GetIcon();
        }
        LWeaponImage.sprite = LWeaponsDatabase.GetItemLists()[sentakuLW].GetIcon();
        //武器及び防具の情報表示
        LWName.text = LWeaponsDatabase.GetItemLists()[sentakuLW].GetItemName();

        LWInfo.text =
        " 近接攻撃力 : " + LWeaponsDatabase.GetItemLists()[sentakuLW].GetATK()
        + "\r\n 近接防御力 : " + LWeaponsDatabase.GetItemLists()[sentakuLW].GetGuard()
        + "\r\n 遠隔攻撃力 : " + LWeaponsDatabase.GetItemLists()[sentakuLW].GetBulletATK()
        + "\r\n 遠隔攻撃速度 : " + LWeaponsDatabase.GetItemLists()[sentakuLW].GetBulletATKSpeed() + "/100秒に1回"
        + "\r\n 弾速 : " + LWeaponsDatabase.GetItemLists()[sentakuLW].GetBulletSpeed() + "/100秒に1回"
        + "\r\n 弾の飛距離 : " + LWeaponsDatabase.GetItemLists()[sentakuLW].GetBulletRange() + "/100秒に1回"
        + "\r\n 弾の命中率　:　" + LWeaponsDatabase.GetItemLists()[sentakuLW].GetBulletAccuracy() + "/ターゲットから2*Xfだけずらして弾を発射する"
        + "\r\n 使う弾の名前 : " + LWeaponsDatabase.GetItemLists()[sentakuLW].Getbulletgameobject()
        + "\r\n 追加ユニットコスト : " + LWeaponsDatabase.GetItemLists()[sentakuLW].GetUnitcost() + "コイン"
        + "\r\n 重量 : " + LWeaponsDatabase.GetItemLists()[sentakuLW].GetUnitspeeddown()
        + "\r\n 情報 : " + LWeaponsDatabase.GetItemLists()[sentakuLW].GetInformation();
    }
    public void LARightArrow()//遠隔キャラの防具
    {
        if (CanUseTech >= ArmorsDatabase.GetItemLists()[sentakuLA + 1].GetKindOfTech())
        {
            sentakuLA += 1;
        } else
        {
        }
        LArmorImage.sprite = ArmorsDatabase.GetItemLists()[sentakuLA].GetIcon();

        if (LArmorImage.sprite == null)
        {
            sentakuLA = 0;
            LArmorImage.sprite = ArmorsDatabase.GetItemLists()[sentakuLA].GetIcon();

        }

        //武器及び防具の情報表示
        LAName.text = ArmorsDatabase.GetItemLists()[sentakuLA].GetItemName();

        LAInfo.text =

        " 近接防御力 : " + ArmorsDatabase.GetItemLists()[sentakuLA].GetGuard()
        + "\r\n 追加ユニットコスト : " + ArmorsDatabase.GetItemLists()[sentakuLA].GetUnitcost() + "コイン"
        + "\r\n 対遠隔攻撃 : " + ArmorsDatabase.GetItemLists()[sentakuLA].GetBulletproofness() + "%軽減"
        + "\r\n 重量 : " + ArmorsDatabase.GetItemLists()[sentakuLA].GetUnitspeeddown()
        + "\r\n 情報 : " + ArmorsDatabase.GetItemLists()[sentakuLA].GetInformation();
    }
    
    
    public void LALeftArrow()
    {
        sentakuLA -= 1;


        if (sentakuLA < 0)
        {
            sentakuLA = 0;
            LArmorImage.sprite = ArmorsDatabase.GetItemLists()[sentakuLA].GetIcon();
        }
        LArmorImage.sprite = ArmorsDatabase.GetItemLists()[sentakuLA].GetIcon();
        //武器及び防具の情報表示
        LAName.text = ArmorsDatabase.GetItemLists()[sentakuLA].GetItemName();

        LAInfo.text =
        " 近接防御力 : " + ArmorsDatabase.GetItemLists()[sentakuLA].GetGuard()
        + "\r\n 追加ユニットコスト : " + ArmorsDatabase.GetItemLists()[sentakuLA].GetUnitcost() + "コイン"
        + "\r\n 対遠隔攻撃 : " + ArmorsDatabase.GetItemLists()[sentakuLA].GetBulletproofness() + "%軽減"
        + "\r\n 重量 : " + ArmorsDatabase.GetItemLists()[sentakuLA].GetUnitspeeddown()
        + "\r\n 情報 : " + ArmorsDatabase.GetItemLists()[sentakuLA].GetInformation();
    }

    //-------------------------------------------------------------------------------------
    //CWInfo.text = " 近接攻撃力 : " + CWeaponsDatabase.GetItemLists()[sentakuCW].GetATK()
    //    + "\r\n 近接攻撃速度 : " + CWeaponsDatabase.GetItemLists()[sentakuCW].GetATKSpeed() + "/100秒に1回"
    //    + "\r\n 防御力 : " + CWeaponsDatabase.GetItemLists()[sentakuCW].GetGuard()
    //    + "\r\n 追加ユニットコスト : " + CWeaponsDatabase.GetItemLists()[sentakuCW].GetUnitcost() + "コイン"
    //    + "\r\n 対遠隔攻撃 : " + CWeaponsDatabase.GetItemLists()[sentakuCW].GetBulletproofness() + "%軽減"
    //    + "\r\n 遠隔攻撃力 : " + CWeaponsDatabase.GetItemLists()[sentakuCW].GetBulletATK()
    //    + "\r\n 遠隔攻撃速度 : " + CWeaponsDatabase.GetItemLists()[sentakuCW].GetBulletATKSpeed() + "/100秒に1回"
    //    + "\r\n 重量 : " + CWeaponsDatabase.GetItemLists()[sentakuCW].GetUnitspeeddown()
    //    + "\r\n 情報 : " + CWeaponsDatabase.GetItemLists()[sentakuCW].GetInformation();
    //装備に関するスクリプト
    public void CWEquipClick()
    {
        if (Hanbetu == Faction.KINOKO)
        {
            kinos.WEquipname = CWeaponsDatabase.GetItemLists()[sentakuCW].GetItemName();
            kinos.WEquipATK = CWeaponsDatabase.GetItemLists()[sentakuCW].GetATK();
            kinos.WEquipATKspeed = CWeaponsDatabase.GetItemLists()[sentakuCW].GetATKSpeed();
            kinos.WEquipBulletATK = CWeaponsDatabase.GetItemLists()[sentakuCW].GetBulletATK();
            kinos.WEquipBulletATKspeed = CWeaponsDatabase.GetItemLists()[sentakuCW].GetBulletATKSpeed();
            kinos.WEquipBulletproofness = CWeaponsDatabase.GetItemLists()[sentakuCW].GetBulletproofness();
            kinos.WEquipGuard = CWeaponsDatabase.GetItemLists()[sentakuCW].GetGuard();
            kinos.WEquipMass = CWeaponsDatabase.GetItemLists()[sentakuCW].GetUnitspeeddown();
            kinos.WEquipUnitcost = CWeaponsDatabase.GetItemLists()[sentakuCW].GetUnitcost();


            
        }
        else if (Hanbetu == Faction.TAKENOKO)
        {
            takey.WEquipname = CWeaponsDatabase.GetItemLists()[sentakuCW].GetItemName();
            takey.WEquipATK = CWeaponsDatabase.GetItemLists()[sentakuCW].GetATK();
            takey.WEquipATKspeed = CWeaponsDatabase.GetItemLists()[sentakuCW].GetATKSpeed();
            takey.WEquipBulletATK = CWeaponsDatabase.GetItemLists()[sentakuCW].GetBulletATK();
            takey.WEquipBulletATKspeed = CWeaponsDatabase.GetItemLists()[sentakuCW].GetBulletATKSpeed();
            takey.WEquipBulletproofness = CWeaponsDatabase.GetItemLists()[sentakuCW].GetBulletproofness();
            takey.WEquipGuard = CWeaponsDatabase.GetItemLists()[sentakuCW].GetGuard();
            takey.WEquipMass = CWeaponsDatabase.GetItemLists()[sentakuCW].GetUnitspeeddown();
            takey.WEquipUnitcost = CWeaponsDatabase.GetItemLists()[sentakuCW].GetUnitcost();
        }
        else
        {

        }
    }
    public void CAEquipClick()
    {
        if (Hanbetu == Faction.KINOKO)
        {
            kinos.AEquipname = ArmorsDatabase.GetItemLists()[sentakuCA].GetItemName();
            kinos.AEquipATK = ArmorsDatabase.GetItemLists()[sentakuCA].GetATK();
            kinos.AEquipATKspeed = ArmorsDatabase.GetItemLists()[sentakuCA].GetATKSpeed();
            kinos.AEquipBulletATK = ArmorsDatabase.GetItemLists()[sentakuCA].GetBulletATK();
            kinos.AEquipBulletATKspeed = ArmorsDatabase.GetItemLists()[sentakuCA].GetBulletATKSpeed();
            kinos.AEquipBulletproofness = ArmorsDatabase.GetItemLists()[sentakuCA].GetBulletproofness();
            kinos.AEquipGuard = ArmorsDatabase.GetItemLists()[sentakuCA].GetGuard();
            kinos.AEquipMass = ArmorsDatabase.GetItemLists()[sentakuCA].GetUnitspeeddown();
            kinos.AEquipUnitcost = ArmorsDatabase.GetItemLists()[sentakuCA].GetUnitcost();
        }
        else if (Hanbetu == Faction.TAKENOKO)
        {
            takey.AEquipname = ArmorsDatabase.GetItemLists()[sentakuCA].GetItemName();
            takey.AEquipATK = ArmorsDatabase.GetItemLists()[sentakuCA].GetATK();
            takey.AEquipATKspeed = ArmorsDatabase.GetItemLists()[sentakuCA].GetATKSpeed();
            takey.AEquipBulletATK = ArmorsDatabase.GetItemLists()[sentakuCA].GetBulletATK();
            takey.AEquipBulletATKspeed = ArmorsDatabase.GetItemLists()[sentakuCA].GetBulletATKSpeed();
            takey.AEquipBulletproofness = ArmorsDatabase.GetItemLists()[sentakuCA].GetBulletproofness();
            takey.AEquipGuard = ArmorsDatabase.GetItemLists()[sentakuCA].GetGuard();
            takey.AEquipMass = ArmorsDatabase.GetItemLists()[sentakuCA].GetUnitspeeddown();
            takey.AEquipUnitcost = ArmorsDatabase.GetItemLists()[sentakuCA].GetUnitcost();
        }
        else
        {

        }
    }
    public void LWEquipClick()
    {
        if(Hanbetu == Faction.KINOKO)
        {
            kinob.WEquipname = LWeaponsDatabase.GetItemLists()[sentakuLW].GetItemName();
            kinob.WEquipATK = LWeaponsDatabase.GetItemLists()[sentakuLW].GetATK();
            kinob.WEquipATKspeed = LWeaponsDatabase.GetItemLists()[sentakuLW].GetATKSpeed();
            kinob.WEquipBulletATK = LWeaponsDatabase.GetItemLists()[sentakuLW].GetBulletATK();
            kinob.WEquipBulletATKspeed = LWeaponsDatabase.GetItemLists()[sentakuLW].GetBulletATKSpeed();
            kinob.WEquipBulletspeed = LWeaponsDatabase.GetItemLists()[sentakuLW].GetBulletSpeed();
            kinob.WEquipBulletrange = LWeaponsDatabase.GetItemLists()[sentakuLW].GetBulletRange();
            kinob.WEquipBulletAccuracy = LWeaponsDatabase.GetItemLists()[sentakuLW].GetBulletAccuracy();
            kinob.WEquipBulletgameobject = LWeaponsDatabase.GetItemLists()[sentakuLW].Getbulletgameobject();
            kinob.WEquipBulletproofness = LWeaponsDatabase.GetItemLists()[sentakuLW].GetBulletproofness();
            kinob.WEquipGuard = LWeaponsDatabase.GetItemLists()[sentakuLW].GetGuard();
            kinob.WEquipMass = LWeaponsDatabase.GetItemLists()[sentakuLW].GetUnitspeeddown();
            kinob.WEquipUnitcost = LWeaponsDatabase.GetItemLists()[sentakuLW].GetUnitcost();
        }
        else if (Hanbetu == Faction.TAKENOKO)
        {
            takem.WEquipname = LWeaponsDatabase.GetItemLists()[sentakuLW].GetItemName();
            takem.WEquipATK = LWeaponsDatabase.GetItemLists()[sentakuLW].GetATK();
            takem.WEquipATKspeed = LWeaponsDatabase.GetItemLists()[sentakuLW].GetATKSpeed();
            takem.WEquipBulletATK = LWeaponsDatabase.GetItemLists()[sentakuLW].GetBulletATK();
            takem.WEquipBulletATKspeed = LWeaponsDatabase.GetItemLists()[sentakuLW].GetBulletATKSpeed();
            takem.WEquipBulletspeed = LWeaponsDatabase.GetItemLists()[sentakuLW].GetBulletSpeed();
            takem.WEquipBulletrange = LWeaponsDatabase.GetItemLists()[sentakuLW].GetBulletRange();
            takem.WEquipBulletAccuracy = LWeaponsDatabase.GetItemLists()[sentakuLW].GetBulletAccuracy();
            takem.WEquipBulletgameobject = LWeaponsDatabase.GetItemLists()[sentakuLW].Getbulletgameobject();
            takem.WEquipBulletproofness = LWeaponsDatabase.GetItemLists()[sentakuLW].GetBulletproofness();
            takem.WEquipGuard = LWeaponsDatabase.GetItemLists()[sentakuLW].GetGuard();
            takem.WEquipMass = LWeaponsDatabase.GetItemLists()[sentakuLW].GetUnitspeeddown();
            takem.WEquipUnitcost = LWeaponsDatabase.GetItemLists()[sentakuLW].GetUnitcost();
        }
        else
        {

        }
    }
    public void LAEquipClick()
    {
        if (Hanbetu == Faction.KINOKO)
        {
            kinob.AEquipname = ArmorsDatabase.GetItemLists()[sentakuLA].GetItemName();
            kinob.AEquipATK = ArmorsDatabase.GetItemLists()[sentakuLA].GetATK();
            kinob.AEquipATKspeed = ArmorsDatabase.GetItemLists()[sentakuLA].GetATKSpeed();
            kinob.AEquipBulletATK = ArmorsDatabase.GetItemLists()[sentakuLA].GetBulletATK();
            kinob.AEquipBulletATKspeed = ArmorsDatabase.GetItemLists()[sentakuLA].GetBulletATKSpeed();
            kinob.AEquipBulletproofness = ArmorsDatabase.GetItemLists()[sentakuLA].GetBulletproofness();
            kinob.AEquipGuard = ArmorsDatabase.GetItemLists()[sentakuLA].GetGuard();
            kinob.AEquipMass = ArmorsDatabase.GetItemLists()[sentakuLA].GetUnitspeeddown();
            kinob.AEquipUnitcost = ArmorsDatabase.GetItemLists()[sentakuLA].GetUnitcost();
        }
        else if (Hanbetu == Faction.TAKENOKO)
        {
            takem.AEquipname = ArmorsDatabase.GetItemLists()[sentakuLA].GetItemName();
            takem.AEquipATK = ArmorsDatabase.GetItemLists()[sentakuLA].GetATK();
            takem.AEquipATKspeed = ArmorsDatabase.GetItemLists()[sentakuLA].GetATKSpeed();
            takem.AEquipBulletATK = ArmorsDatabase.GetItemLists()[sentakuLA].GetBulletATK();
            takem.AEquipBulletATKspeed = ArmorsDatabase.GetItemLists()[sentakuLA].GetBulletATKSpeed();
            takem.AEquipBulletproofness = ArmorsDatabase.GetItemLists()[sentakuLA].GetBulletproofness();
            takem.AEquipGuard = ArmorsDatabase.GetItemLists()[sentakuLA].GetGuard();
            takem.AEquipMass = ArmorsDatabase.GetItemLists()[sentakuLA].GetUnitspeeddown();
            takem.AEquipUnitcost = ArmorsDatabase.GetItemLists()[sentakuLA].GetUnitcost();
        }
        else
        {

        }
    }
    public void EnemyCWeaponsIn(Items EnemyHaveCWeapons)
    {
        if (Hanbetu == Faction.TAKENOKO)
        {
            kinos.EWEquipname = EnemyHaveCWeapons.GetItemName();
            kinos.EWEquipATK = EnemyHaveCWeapons.GetATK();
            kinos.EWEquipATKspeed = EnemyHaveCWeapons.GetATKSpeed();
            kinos.EWEquipBulletATK = EnemyHaveCWeapons.GetBulletATK();
            kinos.EWEquipBulletATKspeed = EnemyHaveCWeapons.GetBulletATKSpeed();
            kinos.EWEquipBulletproofness = EnemyHaveCWeapons.GetBulletproofness();
            kinos.EWEquipGuard = EnemyHaveCWeapons.GetGuard();
            kinos.EWEquipMass = EnemyHaveCWeapons.GetUnitspeeddown();
            kinos.EWEquipUnitcost = EnemyHaveCWeapons.GetUnitcost();
        }else if (Hanbetu == Faction.KINOKO)
        {
            takey.EWEquipname = EnemyHaveCWeapons.GetItemName();
            takey.EWEquipATK = EnemyHaveCWeapons.GetATK();
            takey.EWEquipATKspeed = EnemyHaveCWeapons.GetATKSpeed();
            takey.EWEquipBulletATK = EnemyHaveCWeapons.GetBulletATK();
            takey.EWEquipBulletATKspeed = EnemyHaveCWeapons.GetBulletATKSpeed();
            takey.EWEquipBulletproofness = EnemyHaveCWeapons.GetBulletproofness();
            takey.EWEquipGuard = EnemyHaveCWeapons.GetGuard();
            takey.EWEquipMass = EnemyHaveCWeapons.GetUnitspeeddown();
            takey.EWEquipUnitcost = EnemyHaveCWeapons.GetUnitcost();
        }
    }

    public void EnemyLWeaponsIn(Items EnemyHaveLWeapons)
    {
        if (Hanbetu == Faction.TAKENOKO)
        {
            kinob.EWEquipname = EnemyHaveLWeapons.GetItemName();
            kinob.EWEquipATK = EnemyHaveLWeapons.GetATK();
            kinob.EWEquipATKspeed = EnemyHaveLWeapons.GetATKSpeed();
            kinob.EWEquipBulletATK = EnemyHaveLWeapons.GetBulletATK();
            kinob.EWEquipBulletATKspeed = EnemyHaveLWeapons.GetBulletATKSpeed();
            kinob.EWEquipBulletspeed = EnemyHaveLWeapons.GetBulletSpeed();
            kinob.EWEquipBulletrange = EnemyHaveLWeapons.GetBulletRange();
            kinob.WEquipBulletAccuracy = EnemyHaveLWeapons.GetBulletAccuracy();
            kinob.EWEquipBulletgameobject = EnemyHaveLWeapons.Getbulletgameobject();
            kinob.EWEquipBulletproofness = EnemyHaveLWeapons.GetBulletproofness();
            kinob.EWEquipGuard = EnemyHaveLWeapons.GetGuard();
            kinob.EWEquipMass = EnemyHaveLWeapons.GetUnitspeeddown();
            kinob.EWEquipUnitcost = EnemyHaveLWeapons.GetUnitcost();
        }
        else if (Hanbetu == Faction.KINOKO)
        {
            takem.WEquipname = EnemyHaveLWeapons.GetItemName();
            takem.WEquipATK = EnemyHaveLWeapons.GetATK();
            takem.WEquipATKspeed = EnemyHaveLWeapons.GetATKSpeed();
            takem.WEquipBulletATK = EnemyHaveLWeapons.GetBulletATK();
            takem.WEquipBulletATKspeed = EnemyHaveLWeapons.GetBulletATKSpeed();
            takem.WEquipBulletspeed = EnemyHaveLWeapons.GetBulletSpeed();
            takem.WEquipBulletrange = EnemyHaveLWeapons.GetBulletRange();
            takem.WEquipBulletAccuracy = EnemyHaveLWeapons.GetBulletAccuracy();
            takem.WEquipBulletgameobject = EnemyHaveLWeapons.Getbulletgameobject();
            takem.WEquipBulletproofness = EnemyHaveLWeapons.GetBulletproofness();
            takem.WEquipGuard = EnemyHaveLWeapons.GetGuard();
            takem.WEquipMass = EnemyHaveLWeapons.GetUnitspeeddown();
            takem.WEquipUnitcost = EnemyHaveLWeapons.GetUnitcost();
        }
    }

    public void EnemyCArmorsIn(Items EnemyHaveCArmors)
    {
        if (Hanbetu == Faction.TAKENOKO)
        {
            kinos.AEquipname = EnemyHaveCArmors.GetItemName();
            kinos.AEquipATK = EnemyHaveCArmors.GetATK();
            kinos.AEquipATKspeed = EnemyHaveCArmors.GetATKSpeed();
            kinos.AEquipBulletATK = EnemyHaveCArmors.GetBulletATK();
            kinos.AEquipBulletATKspeed = EnemyHaveCArmors.GetBulletATKSpeed();
            kinos.AEquipBulletproofness = EnemyHaveCArmors.GetBulletproofness();
            kinos.AEquipGuard = EnemyHaveCArmors.GetGuard();
            kinos.AEquipMass = EnemyHaveCArmors.GetUnitspeeddown();
            kinos.AEquipUnitcost = EnemyHaveCArmors.GetUnitcost();
        }
        else if (Hanbetu == Faction.KINOKO)
        {
            takem.AEquipname = EnemyHaveCArmors.GetItemName();
            takem.AEquipATK = EnemyHaveCArmors.GetATK();
            takem.AEquipATKspeed = EnemyHaveCArmors.GetATKSpeed();
            takem.AEquipBulletATK = EnemyHaveCArmors.GetBulletATK();
            takem.AEquipBulletATKspeed = EnemyHaveCArmors.GetBulletATKSpeed();
            takem.AEquipBulletproofness = EnemyHaveCArmors.GetBulletproofness();
            takem.AEquipGuard = EnemyHaveCArmors.GetGuard();
            takem.AEquipMass = EnemyHaveCArmors.GetUnitspeeddown();
            takem.AEquipUnitcost = EnemyHaveCArmors.GetUnitcost();
        }
    }

    public void EnemyLArmorsIn(Items EnemyHaveLArmors)
    {
        if (Hanbetu == Faction.TAKENOKO)
        {
            kinob.AEquipname = EnemyHaveLArmors.GetItemName();
            kinob.AEquipATK = EnemyHaveLArmors.GetATK();
            kinob.AEquipATKspeed = EnemyHaveLArmors.GetATKSpeed();
            kinob.AEquipBulletATK = EnemyHaveLArmors.GetBulletATK();
            kinob.AEquipBulletATKspeed = EnemyHaveLArmors.GetBulletATKSpeed();
            kinob.AEquipBulletproofness = EnemyHaveLArmors.GetBulletproofness();
            kinob.AEquipGuard = EnemyHaveLArmors.GetGuard();
            kinob.AEquipMass = EnemyHaveLArmors.GetUnitspeeddown();
            kinob.AEquipUnitcost = EnemyHaveLArmors.GetUnitcost();
        }
        else if (Hanbetu == Faction.KINOKO)
        {
            takem.AEquipname = EnemyHaveLArmors.GetItemName();
            takem.AEquipATK = EnemyHaveLArmors.GetATK();
            takem.AEquipATKspeed = EnemyHaveLArmors.GetATKSpeed();
            takem.AEquipBulletATK = EnemyHaveLArmors.GetBulletATK();
            takem.AEquipBulletATKspeed = EnemyHaveLArmors.GetBulletATKSpeed();
            takem.AEquipBulletproofness = EnemyHaveLArmors.GetBulletproofness();
            takem.AEquipGuard = EnemyHaveLArmors.GetGuard();
            takem.AEquipMass = EnemyHaveLArmors.GetUnitspeeddown();
            takem.AEquipUnitcost = EnemyHaveLArmors.GetUnitcost();
        }
    }
}