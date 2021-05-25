using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class market : MonoBehaviour
{
    bool axe = true; // character have a axe as default
    private int count = 0;
    public static int wood = 0;
    public static int plant = 0;
    public static float money = 0;
    float price = 100;
    public Image Market;
    public Text WoodPrice;
    public Text Inventory;
    // Start is called before the first frame update
    void Start()
    {
        Market.enabled = false;
        ShowChild(false);
    }

    // Update is called once per frame
    void Update()
    {
        count++;
        if (count == 1000) // every 1000th frame
        {
            price *= Random.Range(.8f, 1.3f); // wood price change randomly and tends to 4% price rise every 1000 frames
            WoodPrice.text = "sell for " + Mathf.Round(price) + "$"; // update wood price in market ui
            count = 0;
        }
    }

    void OnMouseDown() // called when market is being pressed 
    {
        Market.enabled = true;
        ShowChild(true);
        Character.MarketClosed = false;
    }
    void ShowChild(bool visible) // enable / disable children of market ui.
    {
        for (int i = 0; i < 4; i++)
        {
            Market.gameObject.transform.GetChild(i).gameObject.GetComponent<Button>().enabled = visible;
            Market.gameObject.transform.GetChild(i).GetChild(0).gameObject.GetComponent<Image>().enabled = visible;
            Market.gameObject.transform.GetChild(i).GetChild(1).gameObject.GetComponent<Text>().enabled = visible;
        }
    }
    public void UpdateInventory() // update character inventory 
    {
        Inventory.text = "wood: " + wood + "\n" + "$: " + Mathf.Round(money) + "\n" + "plant:" + plant;
    }
    // all these methods are called from ui buttons
    public void MarketClose()
    {
        Market.enabled = false;
        Character.MarketClosed = true;
        ShowChild(false);
    }
    public void BuySaw()
    {
        if (axe && money >= 1999)
        {
            GameObject.Find("Player").GetComponent<Animator>().SetBool("axe", false); // enable saw animation
            Character.chopingTime = 50;
            axe = false;
            money -= 1999;
            UpdateInventory();
        }
    }
    public void BuyPlant()
    {
        if (money >= 99)
        {
            plant++;
            money -= 99;
            UpdateInventory();
        }

    }
    public void SellWood()
    {
        if (wood > 0)
        {
            money += price;
            wood--;
            price *= .95f;
            UpdateInventory();
            WoodPrice.text = "sell for " + Mathf.Round(price) + "$";
        }
    }

}
