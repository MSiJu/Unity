using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DangerWallCont : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //プレイヤーが触れた時ゲームをリセット
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //GameControllerのDecreaseDeathCountにアクセス
            FindObjectOfType<GameController>().DecreaseDeathCount();

            //シーンの再読み込み
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
