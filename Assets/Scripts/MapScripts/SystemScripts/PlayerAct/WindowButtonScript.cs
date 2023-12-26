using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WindowButtonScript : MonoBehaviour
{
    [SerializeField]
    GameObject Pwindow;
    [SerializeField]
    GameObject EPwindow;
    [SerializeField]
    GameObject Bwindow;
    [SerializeField]
    GameObject Uwindow;
    [SerializeField]
    GameObject ShigenWindow;
    [SerializeField]
    GameObject Pbutton;
    [SerializeField]
    GameObject EPbutton;
    [SerializeField]
    GameObject Bbutton;
    [SerializeField]
    GameObject Ubutton;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void PWindow()
    {
        ShigenWindow.SetActive(true);
    }
    public void EPWindow()
    {
        //SceneManager.LoadScene("game"); //あとで実装

    }
    public void BWindow()
    {
        
    }
    public void UWindow()
    {

    }

}
