using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UniRx;

public class NoBrokenScript : MonoBehaviour
{
    public static Object NoBrokenObjectInMapScene;
    [SerializeField]
    PointsInfo pointinfocs;
    [SerializeField]
    public static string SelectPointName { get; private set; }
    [SerializeField]
    public static string SelectPointTag { get; private set; }
    [SerializeField]
    string PointName;
    [SerializeField]
    string PointTerrain;
    [SerializeField]
    string PointTemperature;
    [SerializeField]
    int PointIncome;
    bool hantei = true;
    [SerializeField]
    private Text PointNameText;
    [SerializeField]
    private Text PointTerrainText;
    [SerializeField]
    private Text PointTemperatureText;
    [SerializeField]
    private Text PointIncomeText;
    [SerializeField]
    Image BImage;
    [SerializeField]
    Sprite[] BuildingSprites;
    [SerializeField]
    GameObject Bcontent;
    [SerializeField]
    Image UImage;
    [SerializeField]
    Sprite[] UnitSprites;
    [SerializeField]
    GameObject Ucontent;
    [SerializeField]
    string CountryName;

    public static string MySeiryokuName;

    [SerializeField]
    GameObject PlayerWindowAvarable;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        //PlayerWindowAvarable.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            SceneManager.LoadScene("title");
        }
        //if (PlayerWindowAvarable == false)
        //{
        //    WindowScript.isDragging = false;
        //}
        if (SceneManager.GetActiveScene().name == "map" && hantei == true)
        {
            
            hantei = false;
            Debug.Log(SelectPointName);
            GameObject firstgetobj = GameObject.Find(SelectPointName);
            Debug.Log(firstgetobj);
            if(firstgetobj != null)
            {
                pointinfocs = firstgetobj.GetComponent<PointsInfo>();
            }
            NoBrokenObjectInMapScene =  GameObject.Find("NoBrokenGameObject");
            
            
        }

    }
    public void Pointsclick(BaseEventData data)
    {
        PlayerWindowAvarable.SetActive(true);
        foreach (Transform n in Bcontent.transform)
        {
            GameObject.Destroy(n.gameObject);
        }
        foreach (Transform o in Ucontent.transform)
        {
            GameObject.Destroy(o.gameObject);
        }
        
        GameObject SelectPoint = (data as PointerEventData).pointerClick;
        SelectPointName = SelectPoint.name;

        PointName = SelectPoint.GetComponent<PointsInfo>().Name;
        PointTerrain = SelectPoint.GetComponent<PointsInfo>().pointTerrain.ToString();
        PointTemperature = SelectPoint.GetComponent<PointsInfo>().pointTemperature.ToString();
        PointIncome = SelectPoint.GetComponent<PointsInfo>().PointIncome;
        
        PointNameText.text = PointName;
        PointTerrainText.text = PointTerrain;
        //PointTemperatureText.text = SelectPoint.GetComponent<PointsInfo>().pointTemperature.ToString();
        PointIncomeText.text = PointIncome.ToString();
        SeiryokuHanbetu();



        foreach (var buildings in SelectPoint.GetComponent<PointsInfo>().pointBuildingList)
        {
            Image BuildingImage = Instantiate(BImage, new Vector3(0, 0, 0), Quaternion.identity);
            BuildingImage.transform.SetParent(Bcontent.transform, false);

            if (buildings.ToString() == "Ki")
            {
                BuildingImage.sprite = BuildingSprites[0];
            }
            else if (buildings.ToString() == "Sougen")
            {
                BuildingImage.sprite = BuildingSprites[1];
            }
            else if (buildings.ToString() == "Ishikiriba")
            {
                BuildingImage.sprite = BuildingSprites[2];
            }
            else if (buildings.ToString() == "Kaigan")
            {
                BuildingImage.sprite = BuildingSprites[3];
            }
            else if (buildings.ToString() == "Minato")
            {
                BuildingImage.sprite = BuildingSprites[4];
            }
            else if (buildings.ToString() == "Bokujou")
            {
                BuildingImage.sprite = BuildingSprites[5];
            }
            else if (buildings.ToString() == "Hatake")
            {
                BuildingImage.sprite = BuildingSprites[6];
            }
            else if (buildings.ToString() == "SekitanKouzan")
            {
                BuildingImage.sprite = BuildingSprites[7];
            }
            else if (buildings.ToString() == "KinKouzan")
            {
                BuildingImage.sprite = BuildingSprites[8];
            }
            else if (buildings.ToString() == "DouKouzan")
            {
                BuildingImage.sprite = BuildingSprites[9];
            }
            else if (buildings.ToString() == "SuzuKouzan")
            {
                BuildingImage.sprite = BuildingSprites[10];
            }
            else if (buildings.ToString() == "TetsuKouzan")
            {
                BuildingImage.sprite = BuildingSprites[11];
            }
            else if (buildings.ToString() == "Areti")
            {
                BuildingImage.sprite = BuildingSprites[12];
            }
            else if (buildings.ToString() == "Koubou")
            {
                BuildingImage.sprite = BuildingSprites[13];
            }
            else if (buildings.ToString() == "Kajiba")
            {
                BuildingImage.sprite = BuildingSprites[14];
            }
            else if (buildings.ToString() == "GunjuKoujou")
            {
                BuildingImage.sprite = BuildingSprites[15];
            }
            else if (buildings.ToString() == "Koujou")
            {
                BuildingImage.sprite = BuildingSprites[16];
            }
            else if (buildings.ToString() == "Seitetsujo")
            {
                BuildingImage.sprite = BuildingSprites[17];
            }
            else if (buildings.ToString() == "Seikoujo")
            {
                BuildingImage.sprite = BuildingSprites[18];
            }


            //イメージを追加する処理を書いている途中 
        }
        foreach (var units in SelectPoint.GetComponent<PointsInfo>().pointUnitList)
        {
            Image UnitImage = Instantiate(UImage, new Vector3(0, 0, 0), Quaternion.identity);
            UnitImage.transform.SetParent(Ucontent.transform, false);

            if (units.ToString() == "Kenshi")
            {
                UnitImage.sprite = UnitSprites[0];
            }
            else if (units.ToString() == "Yarihei")
            {
                UnitImage.sprite = UnitSprites[1];
            }
            else if (units.ToString() == "Yumihei")
            {
                UnitImage.sprite = UnitSprites[2];
            }
            else if (units.ToString() == "Juhei")
            {
                UnitImage.sprite = UnitSprites[3];
            }


            //イメージを追加する処理を書いている途中 
        }
    }
    
    public void SentakuOnclick()
    {
        SelectPointTag = GameObject.Find(SelectPointName).tag;
        //Debug.Log(SelectPointTag);
        SceneManager.LoadScene("map");
        PlayerWindowAvarable.SetActive(false);
        SeiryokuHanbetu();
    }

    public void SeiryokuHanbetu()
    {
        if (GameObject.Find(SelectPointName).tag == "SeiryokuA")
        {
            CountryName = "A_Country";
        }
        else if (GameObject.Find(SelectPointName).tag == "SeiryokuB")
        {
            CountryName = "B_Country";
        }
        else if (GameObject.Find(SelectPointName).tag == "SeiryokuC")
        {
            CountryName = "C_Country";
        }
        else if (GameObject.Find(SelectPointName).tag == "SeiryokuD")
        {
            CountryName = "D_Country";
        }
        else if (GameObject.Find(SelectPointName).tag == "SeiryokuB")
        {
            CountryName = "E_Country";
        }
        else if (GameObject.Find(SelectPointName).tag == "SeiryokuE")
        {
            CountryName = "F_Country";
        }
        else if (GameObject.Find(SelectPointName).tag == "SeiryokuF")
        {
            CountryName = "G_Country";
        }
        else if (GameObject.Find(SelectPointName).tag == "SeiryokuH")
        {
            CountryName = "H_Country";
        }
        else if (GameObject.Find(SelectPointName).tag == "SeiryokuI")
        {
            CountryName = "I_Country";
        }
        else if (GameObject.Find(SelectPointName).tag == "SeiryokuJ")
        {
            CountryName = "J_Country";
        }
        else if (GameObject.Find(SelectPointName).tag == "SeiryokuK")
        {
            CountryName = "K_Country";
        }
        MySeiryokuName = CountryName;
        Debug.Log(CountryName);
    }
}