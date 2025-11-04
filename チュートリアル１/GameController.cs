using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEditor.Progress;

//死んだ回数を動的確保
public static class DeathScore
{
    public static int DeathCount;
}

public class GameController : MonoBehaviour
{
    public TextMeshProUGUI CountText;
    public TextMeshProUGUI WINText;
    public TextMeshProUGUI DeathCountText;

    private GameObject[] Items;
    private int itemCount;

    // Start is called before the first frame update
    void Start()
    {
        //itemタグのオブジェクトを（複数個）探索
        Items = GameObject.FindGameObjectsWithTag("item");

        //配列で確保されたitemのオブジェクトの数をカウント
        itemCount = Items.Length;

        //TextMeshProへ各スコアを反映
        CountText.text = "Items Count: " + itemCount;
        DeathCountText.text = "Death Count: " + DeathScore.DeathCount;

        //勝利演出を非表示に
        WINText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //itemのカウントとスコアの反映
    public void DecreaseItemCount()
    {
        itemCount--;
        CountText.text = "Items Count: " + itemCount;

        //ゲームクリア時の処理
        if (itemCount == 0)
        {
            //クリア演出を表示
            WINText.enabled = true;

            //PlayerContのWinCountへアクセス
            FindObjectOfType<PlayerCont>().WinCount();
        }
    }

    //死んだ回数をカウント
    public void DecreaseDeathCount()
    {
        //別のクラスのDeathScoreにアクセスし死んだ回数をカウント
        DeathScore.DeathCount++;

        //デススコアを反映
        DeathCountText.text = "Death Count: " + DeathScore.DeathCount;
    }
}
