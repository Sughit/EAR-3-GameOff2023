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
    [Header("CurrentMoney")]
    public Text currentMoney;
    [Header("Stats")]
    public float rodLength;
    public int numBait;
    public int widthInv=128;
    public int heightInv=96;

    static bool rodI;
    static bool rodII;
    static bool rodMax;

    static bool baitI;
    static bool baitII;
    static bool baitMax;

    static bool invI;
    static bool invII;
    static bool invMax;
    GameObject canvas;
    GameObject camera;

    public void Canvas()
    {
        RememberFish.numCodS = 0;
        RememberFish.numBarracudaS = 0;
        RememberFish.numSalmonS = 0;
        RememberFish.numHerringS = 0;
        RememberFish.numTunaS = 0;
        RememberFish.numCodB = 0;
        RememberFish.numBarracudaB = 0;
        RememberFish.numSalmonB = 0;
        RememberFish.numHerringB = 0;
        RememberFish.numTunaB = 0;
        camera = GameObject.Find("Main Camera");
        canvas = GameObject.Find("Canvas");
        Destroy(canvas.gameObject);
        Destroy(camera.gameObject);
    }

    void Start()
    {
        currentMoney.text=$"Money: {DayManager.moneyNum}";

        rodLength=StartFishing.maxDepth;
        numBait=StartFishing.maxNumBait;

        if(rodI) rodText.text="Rod I";
        else if(rodII) rodText.text="Rod II";
        else if(rodMax) rodText.text="Rod III";

        if(!rodMax) rodButtonText.text=$"Price: {rodPrice}";
        else rodButtonText.text="Maxed out";

        if(baitI) baitText.text="Bait I";
        else if(baitII) baitText.text="Bait II";
        else if(baitMax) baitText.text="Bait III"; 
        
        if(!baitMax) baitButtonText.text=$"Price: {baitPrice}";
        else baitButtonText.text="Maxed out";

        if(invI) inventoryText.text="Inventory I";
        else if(invII) inventoryText.text="Inventory II";
        else if(invMax) inventoryText.text="Inventory III";
        
        if(!invMax) inventoryButtonText.text=$"Price: {inventoryPrice}";
        else inventoryButtonText.text="Maxed out";
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
                DayManager.moneyNum-=rodPrice;
                currentMoney.text=$"Money: {DayManager.moneyNum}";
                rodPrice=30;
                rodText.text="Rod II";
                rodButtonText.text=$"Price: {rodPrice}";
            }
            else if(rodII)
            {
                StartFishing.maxDepth=-100;
                rodLength=StartFishing.maxDepth;
                DayManager.moneyNum-=rodPrice;
                currentMoney.text=$"Money: {DayManager.moneyNum}";
                // rodPrice=40;
                rodMax=true;
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
                DayManager.moneyNum-=baitPrice;
                currentMoney.text=$"Money: {DayManager.moneyNum}";
                baitPrice=35;
                baitText.text="Bait II";
                baitButtonText.text=$"Price: {baitPrice}";
            }
            else if(baitII)
            {
                StartFishing.maxNumBait=7;
                numBait=StartFishing.maxNumBait;
                DayManager.moneyNum-=baitPrice;
                currentMoney.text=$"Money: {DayManager.moneyNum}";
                //baitPrice=50;
                baitMax=true;
                baitText.text="Bait III";
                baitButtonText.text="Maxed out";
            }
        }
    }

    public void UpgradeInventory()
    {
        if(DayManager.moneyNum >= inventoryPrice)
        {
            if(SetInvSize.width==4*96 && SetInvSize.height==3*96)
            {
                invI=true;
            }
            else if(SetInvSize.width==5*96 && SetInvSize.height==4*96)
            {
                invI=false;
                invII=true;
            }

            if(invI)
            {
                SetInvSize.width=5*96;
                SetInvSize.height=4*96;
                DayManager.moneyNum-=inventoryPrice;
                currentMoney.text=$"Money: {DayManager.moneyNum}";
                inventoryPrice=40;
                inventoryText.text="Inventory II";
                inventoryButtonText.text=$"Price: {inventoryPrice}";
            }
            else if(invII)
            {
                SetInvSize.width=5*96;
                SetInvSize.height=5*96;
                DayManager.moneyNum-=inventoryPrice;
                currentMoney.text=$"Money: {DayManager.moneyNum}";
                //inventoryPrice=50;
                invMax=true;
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
