using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsInfo : MonoBehaviour
{

    public enum PointTerrain
    {
        Heiti,Kouya,Sougen,Mori,Yama,Kaigan,Sabaku
    }
    public enum PointTemperature
    {
        Hutu,Atui,Samui,Gokkan
    }
    public int PointIncome;
    public enum PointBuilding
    {
        Ki,Sougen,Ishikiriba,Kaigan,Minato,Bokujou,Hatake,SekitanKouzan,KinKouzan,DouKouzan,SuzuKouzan,TetsuKouzan,Areti,Koubou,Kajiba,GunjuKoujou,Koujou,Seitetsujo,Seikoujo
    }

    public string Name;
    public PointTerrain pointTerrain;
    public PointTemperature pointTemperature;
    public PointBuilding[] pointBuildingList;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
