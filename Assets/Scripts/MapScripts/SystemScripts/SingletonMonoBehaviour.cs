using UnityEngine;

public abstract class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
{

    //singletonという書き方。変数をstaticの様にしつつ、inspector上にも表示出来る。　
    //元の情報が書いてあるスクリプトに、***script : SingletonMonoBehavior<***script>　を書き（CoreScript参照）、その情報を取りたい時には、***script.instance.変数　とする。

    private static T instance;
    //instanceに目的のスクリプトの変数を全て突っ込んでる感覚

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<T>();
                if (instance == null)
                {
                    var go = new GameObject(nameof(T));
                    instance = go.AddComponent<T>();
                }
            }

            return instance;
        }
    }

    protected virtual void Awake()
    {
        CheckInstance();
    }

    /// <summary>
    /// 他のGameObjectにアタッチされているか調べる。
    /// アタッチされている場合は自身を破棄する。
    /// </summary>
    /// <returns></returns>
    protected bool CheckInstance()
    {
        if (instance == null)
        {
            instance = this as T;
            return true;
        }

        if (Instance == this)
        {
            return true;
        }

        Destroy(this);
        return false;
    }
}