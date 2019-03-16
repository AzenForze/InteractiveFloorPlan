using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropdownControl : MonoBehaviour
{
    public Dropdown roomSelection;
    private bool selectionChange = false;
    private int roomChoice = 0;

    private Image item1, item2,
        item3, item4, item5, item6,
        item7, item8, item9, item10;

    private Sprite LR1, LR2, LR3, LR4,
        LR5, LR6, LR7, LR8, LR9, LR10,
        B1, B2, B3, B4, B5, B6, B7, B8, 
        B9, B10, K1, K2, K3, K4, K5, K6, 
        K7, K8, K9, K10, BA1, BA2, BA3, 
        BA4, BA5, BA6, BA7, BA8, BA9, BA10;


    // Start is called before the first frame update
    void Start()
    {
        //Dropdown Listener
        roomSelection.onValueChanged.AddListener(delegate { DropdownValueChanged(roomSelection); });

        LoadRoomImages();

        SetItemSlots();

        SetInventoryToLivingRoom();

    }

    // Update is called once per frame
    void Update()
    {
        if(selectionChange)
        {
            switch(roomChoice)
            {
                // Set Living Room
                case 0:
                    SetInventoryToLivingRoom();
                    break;
                // Set Bedroom
                case 1:
                    SetInventoryToBedroom();
                    break;
                // Set Kitchen
                case 2:
                    SetInventoryToKitchen();
                    break;
                // Set Bathroom
                case 3:
                    SetInventoryToBathroom();
                    break;
                default:
                    break;
            }

        }
        
    }
    private void LoadRoomImages()
    {
        LR1= Resources.Load<Sprite>("sofa");
        LR2 = Resources.Load<Sprite>("chair");
        LR3 = Resources.Load<Sprite>("table");
        LR4 = Resources.Load<Sprite>("bookshelf");
        LR5 = Resources.Load<Sprite>("cube");
        LR6 = Resources.Load<Sprite>("cube");
        LR7 = Resources.Load<Sprite>("cube");
        LR8 = Resources.Load<Sprite>("cube");
        LR9 = Resources.Load<Sprite>("cube");
        LR10 = Resources.Load<Sprite>("cube");
        B1 = Resources.Load<Sprite>("bed");
        B2 = Resources.Load<Sprite>("chair");
        B3 = Resources.Load<Sprite>("bookshelf");
        B4 = Resources.Load<Sprite>("table");
        B5 = Resources.Load<Sprite>("sofa");
        B6 = Resources.Load<Sprite>("cube");
        B7 = Resources.Load<Sprite>("cube");
        B8 = Resources.Load<Sprite>("cube");
        B9 = Resources.Load<Sprite>("cube");
        B10 = Resources.Load<Sprite>("cube");
        K1 = Resources.Load<Sprite>("stove");
        K2 = Resources.Load<Sprite>("chair");
        K3 = Resources.Load<Sprite>("table");
        K4 = Resources.Load<Sprite>("sink");
        K5 = Resources.Load<Sprite>("fridge");
        K6 = Resources.Load<Sprite>("cube");
        K7 = Resources.Load<Sprite>("cube");
        K8 = Resources.Load<Sprite>("cube");
        K9 = Resources.Load<Sprite>("cube");
        K10 = Resources.Load<Sprite>("cube");
        BA1 = Resources.Load<Sprite>("shower");
        BA2 = Resources.Load<Sprite>("sink");
        BA3 = Resources.Load<Sprite>("cube");
        BA4 = Resources.Load<Sprite>("cube");
        BA5 = Resources.Load<Sprite>("cube");
        BA6 = Resources.Load<Sprite>("cube");
        BA7 = Resources.Load<Sprite>("cube");
        BA8 = Resources.Load<Sprite>("cube");
        BA9 = Resources.Load<Sprite>("cube");
        BA10 = Resources.Load<Sprite>("cube");
    }

    private void SetInventoryToBathroom()
    {
        item1.sprite = BA1;
        item2.sprite = BA2;
        item3.sprite = BA3;
        item4.sprite = BA4;
        item5.sprite = BA5;
        item6.sprite = BA6;
        item7.sprite = BA7;
        item8.sprite = BA8;
        item9.sprite = BA9;
        item10.sprite = BA10;

    }

    private void SetInventoryToKitchen()
    {
        item1.sprite = K1;
        item2.sprite = K2;
        item3.sprite = K3;
        item4.sprite = K4;
        item5.sprite = K5;
        item6.sprite = K6;
        item7.sprite = K7;
        item8.sprite = K8;
        item9.sprite = K9;
        item10.sprite = K10;
    }

    private void SetInventoryToBedroom()
    {
        item1.sprite = B1;
        item2.sprite = B2;
        item3.sprite = B3;
        item4.sprite = B4;
        item5.sprite = B5;
        item6.sprite = B6;
        item7.sprite = B7;
        item8.sprite = B8;
        item9.sprite = B9;
        item10.sprite = B10;
    }

    private void SetInventoryToLivingRoom()
    {
        item1.sprite = LR1;
        item2.sprite = LR2;
        item3.sprite = LR3;
        item4.sprite = LR4;
        item5.sprite = LR5;
        item6.sprite = LR6;
        item7.sprite = LR7;
        item8.sprite = LR8;
        item9.sprite = LR9;
        item10.sprite = LR10;
    }

    private void DropdownValueChanged(Dropdown change)
    {
        selectionChange = true;
        roomChoice = change.value;
    }

    private void SetItemSlots()
    {
        item1 = GameObject.Find("ItemImage").GetComponent<Image>();
        item2 = GameObject.Find("ItemImage1").GetComponent<Image>();
        item3 = GameObject.Find("ItemImage2").GetComponent<Image>();
        item4 = GameObject.Find("ItemImage3").GetComponent<Image>();
        item5 = GameObject.Find("ItemImage4").GetComponent<Image>();
        item6 = GameObject.Find("ItemImage5").GetComponent<Image>();
        item7 = GameObject.Find("ItemImage6").GetComponent<Image>();
        item8 = GameObject.Find("ItemImage7").GetComponent<Image>();
        item9 = GameObject.Find("ItemImage8").GetComponent<Image>();
        item10 = GameObject.Find("ItemImage9").GetComponent<Image>();

    }

}
