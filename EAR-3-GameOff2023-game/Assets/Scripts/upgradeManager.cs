using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class upgradeManager : MonoBehaviour
{
    public Text rodText;
    public Text baitText;
    public Text inventoryText;
    [Space]
    public Text rodButtonText;
    public Text baitButtonText;
    public Text inventoryButtonText;
    [Space]
    public GameObject transition;
    [Header("Priceses")]
    public int rodPrice=20;
    public int baitPrice=25;
    public int inventoryPrice=30;
    [Header("Stats")]
    public float rodLength;
    public int numBait;
    public int widthInv=128;
    public int heightInv=96;

    bool rodI;
    bool rodII;

    bool baitI;
    bool baitII;

    bool invI;
    bool invII;

    void Start()
    {
        rodLength=StartFishing.maxDepth;
        numBait=StartFishing.maxNumBait;

        rodText.text="Rod I";
        rodButtonText.text=$"Price: {rodPrice}";

        baitText.text="Bait I";
        baitButtonText.text=$"Price: {baitPrice}";

        inventoryText.text="Inventory I";
        inventoryButtonText.text=$"Price: {inventoryPrice}";
    }

    public void UpgradeRod()
    {
        if(DayManager.moneyNum >= rodPrice)
        {
            if(StartFishing.maxDepth==-50)
            {
                rodI=true;
            }
            else if(StartFishing.maxDepth==-75)
            {
                rodI=false;
                rodII=true;
            }

            if(rodI)
            {
                StartFishing.maxDepth=-75;
                rodLength=StartFishing.maxDepth;
                rodPrice=30;
                rodText.text="Rod II";
                rodButtonText.text=$"Price: {rodPrice}";
            }
            else if(rodII)
            {
                StartFishing.maxDepth=-100;
                rodLength=StartFishing.maxDepth;
                rodPrice=40;
                rodText.text="Rod III";
                rodButtonText.text="Maxed out";
            }
        }
    }

    public void UpgradeBait()
    {
        if(DayManager.moneyNum >= baitPrice)
        {
            if(StartFishing.maxNumBait==3)
            {
                baitI=true;
            }
            else if(StartFishing.maxNumBait==5)
            {
                baitI=false;
                baitII=true;
            }

            if(baitI)
            {
                StartFishing.maxNumBait=5;
                numBait=StartFishing.maxNumBait;
                baitPrice=35;
                baitText.text="Bait II";
                baitButtonText.text=$"Price: {baitPrice}";
            }
            else if(baitII)
            {
                StartFishing.maxNumBait=7;
                numBait=StartFishing.maxNumBait;
                baitPrice=50;
                baitText.text="Bait III";
                baitButtonText.text="Maxed out";
            }
        }
    }

    public void UpgradeInventory()
    {
        if(DayManager.moneyNum >= inventoryPrice)
        {
            if(SetInvSize.width==4*32 && SetInvSize.height==3*32)
            {
                invI=true;
            }
            else if(SetInvSize.width==5*32 && SetInvSize.height==4*32)
            {
                invI=false;
                invII=true;
            }

            if(invI)
            {
                SetInvSize.width=5*32;
                SetInvSize.height=4*32;
                inventoryPrice=40;
                inventoryText.text="Inventory II";
                inventoryButtonText.text=$"Price: {inventoryPrice}";
            }
            else if(invII)
            {
                SetInvSize.width=5*32;
                SetInvSize.height=5*32;
                inventoryPrice=50;
                inventoryText.text="Inventory III";
                inventoryButtonText.text="Maxed out";
            }
        }
    }

    public void GoToDock()
    {
        StartCoroutine(Transition());
    }

    IEnumerator Transition()
    {
        Animator transitionAnim=transition.GetComponent<Animator>();
        transitionAnim.SetTrigger("trans");
        StartFishing.numBait=StartFishing.maxNumBait;
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Dock");
    }
}
