using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemCOnt : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //プレイヤーが触れた時 item を削除
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //GameControllerのDecreaseItemCountへアクセス
            FindObjectOfType<GameController>().DecreaseItemCount();
            Destroy(this.gameObject);
        }
    }
}
