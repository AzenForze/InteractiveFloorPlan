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

    private List<Image> items;

    private List<List<Sprite>> images;

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

        changeSelection(0);
    }

    // Update is called once per frame
    void Update()
    {
        if(selectionChange)
        {
            changeSelection(roomChoice);
        }
    }

    private void changeSelection(int choice)
    {
        for (int i = 0; i < 10; ++i)
        {
            items[i].sprite = images[choice][i];
        }
    }

    private void LoadRoomImages()
    {
        images = new List<List<Sprite>>()
        {
            new List<Sprite>()
            {
                Resources.Load<Sprite>("sofa"),
                Resources.Load<Sprite>("chair"),
                Resources.Load<Sprite>("table"),
                Resources.Load<Sprite>("bookshelf"),
                Resources.Load<Sprite>("cube"),
                Resources.Load<Sprite>("cube"),
                Resources.Load<Sprite>("cube"),
                Resources.Load<Sprite>("cube"),
                Resources.Load<Sprite>("cube"),
                Resources.Load<Sprite>("cube")
            },
            new List<Sprite>()
            {
                Resources.Load<Sprite>("bed"),
                Resources.Load<Sprite>("chair"),
                Resources.Load<Sprite>("bookshelf"),
                Resources.Load<Sprite>("table"),
                Resources.Load<Sprite>("sofa"),
                Resources.Load<Sprite>("cube"),
                Resources.Load<Sprite>("cube"),
                Resources.Load<Sprite>("cube"),
                Resources.Load<Sprite>("cube"),
                Resources.Load<Sprite>("cube")
            },
            new List<Sprite>()
            {
                Resources.Load<Sprite>("stove"),
                Resources.Load<Sprite>("chair"),
                Resources.Load<Sprite>("table"),
                Resources.Load<Sprite>("sink"),
                Resources.Load<Sprite>("fridge"),
                Resources.Load<Sprite>("cube"),
                Resources.Load<Sprite>("cube"),
                Resources.Load<Sprite>("cube"),
                Resources.Load<Sprite>("cube"),
                Resources.Load<Sprite>("cube")
            },
            new List<Sprite>()
            {
                Resources.Load<Sprite>("shower"),
                Resources.Load<Sprite>("sink"),
                Resources.Load<Sprite>("cube"),
                Resources.Load<Sprite>("cube"),
                Resources.Load<Sprite>("cube"),
                Resources.Load<Sprite>("cube"),
                Resources.Load<Sprite>("cube"),
                Resources.Load<Sprite>("cube"),
                Resources.Load<Sprite>("cube"),
                Resources.Load<Sprite>("cube")
            }
        };
    }

    private void DropdownValueChanged(Dropdown change)
    {
        selectionChange = true;
        roomChoice = change.value;
    }

    private void SetItemSlots()
    {
        items = new List<Image>(10);

        items.Add(GameObject.Find("ItemImage").GetComponent<Image>());

        for(int i = 1; i < 10; ++i)
        {
            items.Add(GameObject.Find($"ItemImage{i}").GetComponent<Image>());
        }
    }

}
