using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class ItemScript : MonoBehaviour
{
    //1
    public ReactiveProperty<int> KiCount = new ReactiveProperty<int>(0);
    public ReactiveProperty<int> IsiCount = new ReactiveProperty<int>(0);
    public ReactiveProperty<int> UmaCount = new ReactiveProperty<int>(0);
    public ReactiveProperty<int> SakanaCount = new ReactiveProperty<int>(0);
    public ReactiveProperty<int> HikakuCount = new ReactiveProperty<int>(0);
    public ReactiveProperty<int> SenniCount = new ReactiveProperty<int>(0);
    public ReactiveProperty<int> SekitanCount = new ReactiveProperty<int>(0);
    public ReactiveProperty<int> KinnkousekiCount = new ReactiveProperty<int>(0);
    public ReactiveProperty<int> DoukousekiCount = new ReactiveProperty<int>(0);
    public ReactiveProperty<int> SuzukousekiCount = new ReactiveProperty<int>(0);
    public ReactiveProperty<int> TetsukousekiCount = new ReactiveProperty<int>(0);
    //2
    public ReactiveProperty<int> KinCount = new ReactiveProperty<int>(0);
    public ReactiveProperty<int> DouCount = new ReactiveProperty<int>(0);
    public ReactiveProperty<int> SuzuCount = new ReactiveProperty<int>(0);
    public ReactiveProperty<int> SeidouCount = new ReactiveProperty<int>(0);
    public ReactiveProperty<int> TetsuCount = new ReactiveProperty<int>(0);
    public ReactiveProperty<int> TekkouCount = new ReactiveProperty<int>(0);
    //Buki
    public ReactiveProperty<int> KonbouCount = new ReactiveProperty<int>(0);
    public ReactiveProperty<int> SeidoukenCount = new ReactiveProperty<int>(0);
    public ReactiveProperty<int> YariCount = new ReactiveProperty<int>(0);
    public ReactiveProperty<int> TekkenCount = new ReactiveProperty<int>(0);
    public ReactiveProperty<int> KatanaCount = new ReactiveProperty<int>(0);
    //Bougu
    public ReactiveProperty<int> YumiCount = new ReactiveProperty<int>(0);
    public ReactiveProperty<int> MasukettoCount = new ReactiveProperty<int>(0);
    public ReactiveProperty<int> RaihuruCount = new ReactiveProperty<int>(0);
    public ReactiveProperty<int> KawayoroiCount = new ReactiveProperty<int>(0);
    public ReactiveProperty<int> SeidoukiCount = new ReactiveProperty<int>(0);
    public ReactiveProperty<int> TetsuyoroiCount = new ReactiveProperty<int>(0);
    public ReactiveProperty<int> GusokuCount = new ReactiveProperty<int>(0);
    public ReactiveProperty<int> KattyuuCount = new ReactiveProperty<int>(0);
    public ReactiveProperty<int> BankinyoroiCount = new ReactiveProperty<int>(0);
    public ReactiveProperty<int> KyoukouCount = new ReactiveProperty<int>(0);
    public ReactiveProperty<int> Gunpuku = new ReactiveProperty<int>(0);

    //アイテム羅列

    // Start is called before the first frame update
    void Start()
    {
        KiCount.Subscribe(_ => ChangeLog());
        IsiCount.Subscribe(_ => ChangeLog());
        UmaCount.Subscribe(_ => ChangeLog());
        SakanaCount.Subscribe(_ => ChangeLog());
        HikakuCount.Subscribe(_ => ChangeLog());
        SenniCount.Subscribe(_ => ChangeLog());
        SekitanCount.Subscribe(_ => ChangeLog());
        KinnkousekiCount.Subscribe(_ => ChangeLog());
        DoukousekiCount.Subscribe(_ => ChangeLog());
        SuzukousekiCount.Subscribe(_ => ChangeLog());
        TetsukousekiCount.Subscribe(_ => ChangeLog());

        KinCount.Subscribe(_ => ChangeLog());
        DouCount.Subscribe(_ => ChangeLog());
        SuzuCount.Subscribe(_ => ChangeLog());
        SeidouCount.Subscribe(_ => ChangeLog());
        TetsuCount.Subscribe(_ => ChangeLog());
        TekkouCount.Subscribe(_ => ChangeLog());

        KonbouCount.Subscribe(_ => ChangeLog());
        SeidoukenCount.Subscribe(_ => ChangeLog());
        YariCount.Subscribe(_ => ChangeLog());
        TekkenCount.Subscribe(_ => ChangeLog());
        KatanaCount.Subscribe(_ => ChangeLog());

        YumiCount.Subscribe(_ => ChangeLog());
        MasukettoCount.Subscribe(_ => ChangeLog());
        RaihuruCount.Subscribe(_ => ChangeLog());
        KawayoroiCount.Subscribe(_ => ChangeLog());
        SeidoukiCount.Subscribe(_ => ChangeLog());
        TetsuyoroiCount.Subscribe(_ => ChangeLog());
        GusokuCount.Subscribe(_ => ChangeLog());
        KattyuuCount.Subscribe(_ => ChangeLog());
        BankinyoroiCount.Subscribe(_ => ChangeLog());
        KyoukouCount.Subscribe(_ => ChangeLog());
        Gunpuku.Subscribe(_ => ChangeLog());


    }

    // Update is called once per frame
    void ChangeLog()
    {
        Debug.Log(KiCount.Value); //Value忘れない
        Debug.Log(IsiCount.Value);
        Debug.Log(UmaCount.Value);
        Debug.Log(SakanaCount.Value);
        Debug.Log(HikakuCount.Value);
        Debug.Log(SenniCount.Value);
        Debug.Log(SekitanCount.Value);
        Debug.Log(KinnkousekiCount.Value);
        Debug.Log(DoukousekiCount.Value);
        Debug.Log(SuzukousekiCount.Value);
        Debug.Log(TetsukousekiCount.Value);

        Debug.Log(KinCount.Value);
        Debug.Log(DouCount.Value);
        Debug.Log(SuzuCount.Value);
        Debug.Log(SeidouCount.Value);
        Debug.Log(TetsuCount.Value);
        Debug.Log(TekkouCount.Value);

        Debug.Log(KonbouCount.Value);
        Debug.Log(SeidoukenCount.Value);
        Debug.Log(YariCount.Value);
        Debug.Log(TekkenCount.Value);
        Debug.Log(KatanaCount.Value);

        Debug.Log(YumiCount.Value);
        Debug.Log(MasukettoCount.Value);
        Debug.Log(RaihuruCount.Value);
        Debug.Log(KawayoroiCount.Value);
        Debug.Log(SeidoukiCount.Value);
        Debug.Log(TetsuyoroiCount.Value);
        Debug.Log(GusokuCount.Value);
        Debug.Log(KattyuuCount.Value);
        Debug.Log(BankinyoroiCount.Value);
        Debug.Log(KyoukouCount.Value);
        Debug.Log(Gunpuku.Value);

    }
}
