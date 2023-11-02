using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class getMoney : MonoBehaviour
{
    public Text textMoney;
    public GameObject knife;
    int fishPrice;
    void Start()
    {
        fishPrice = Random.Range(300, 350);
    }
    void Update()
    {
        textMoney.text = Money.money.ToString();
    }

    public void Button()
    {
        StartCoroutine(Knife());
    }

    IEnumerator Knife()
    {
        knife.SetActive(true);

        yield return new WaitForSeconds(0.8f);

        for(int i=1; i<=Money.fish; i++)
            Money.money+= fishPrice;
        
        Money.fish = 0;

        SceneManager.LoadScene("SampleScene");
    }
}
