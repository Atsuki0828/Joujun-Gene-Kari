using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitValueScript : MonoBehaviour
{
    public Text SolV;
    public Text RanV;

    // V=Value 要は生産コスト
    public KinoSwordScript kinos;
    public KinoBowScript kinob;
    public TakeYariScript takey;
    public TakeMusketScript takem;

    public int TSV;
    public int TRV;
    public int KSV;
    public int KRV;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TSV = takey.WEquipUnitcost + takey.AEquipUnitcost;
        TRV = takem.WEquipUnitcost + takem.AEquipUnitcost;
        KSV = kinos.WEquipUnitcost + kinos.AEquipUnitcost;
        KRV = kinob.WEquipUnitcost + kinob.AEquipUnitcost;

        if (PlayerScript.Hanbetu == Faction.TAKENOKO)
        {
            SolV.text = TSV.ToString() + "C Soldier[1]";
            RanV.text = TRV.ToString() + "C Ranger[2]";
        }
        if (PlayerScript.Hanbetu == Faction.KINOKO)
        {
            SolV.text = KSV.ToString() + "C Soldier[1]";
            RanV.text = KRV.ToString() + "C Ranger[2]";
        }
    }
}
