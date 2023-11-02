using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Money : MonoBehaviour
{
    public static float money;
    public static float fish;
    public Text textMoney;
    public Text textFish;

    void Update()
    {
        textMoney.text = Money.money.ToString();
        textFish.text = fish.ToString();

        if(Input.GetKeyDown(KeyCode.Alpha1))
            money++;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Fish")
        {
            Debug.Log("merge");
            Destroy(col.gameObject);
            fish++;

        }
        if(col.gameObject.tag == "Buyer" && fish > 0)
        {
            SceneManager.LoadScene("FishScaling");
        }
    }

}
