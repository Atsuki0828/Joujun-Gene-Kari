using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShigenPanelScript : MonoBehaviour
{
    public GameObject ShigenPanel;
    public GameObject BukiPanel;
    public GameObject BoguPanel;
    public GameObject ItemPanel;
    public GameObject SyojihinPanel;
    // Start is called before the first frame update
    void Start()
    {
        ShigenPanel.SetActive(false);
        BukiPanel.SetActive(true);
        BoguPanel.SetActive(false);
        ItemPanel.SetActive(false);
        SyojihinPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PanelClose()
    {
        ShigenPanel.SetActive(false);
    }
    public void BukiButton()
    {
        BukiPanel.SetActive(true);
        BoguPanel.SetActive(false);
        ItemPanel.SetActive(false);
        SyojihinPanel.SetActive(false);
    }
    public void BoguButton()
    {
        BukiPanel.SetActive(false);
        BoguPanel.SetActive(true);
        ItemPanel.SetActive(false);
        SyojihinPanel.SetActive(false);

    }
    public void ItemButton()
    {
        BukiPanel.SetActive(false);
        BoguPanel.SetActive(false);
        ItemPanel.SetActive(true);
        SyojihinPanel.SetActive(false);

    }
    public void SyojihinButton()
    {
        BukiPanel.SetActive(false);
        BoguPanel.SetActive(false);
        ItemPanel.SetActive(false);
        SyojihinPanel.SetActive(true);

    }
}
