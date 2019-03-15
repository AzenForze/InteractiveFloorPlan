using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GroundPlacementController : MonoBehaviour
{
    private GameObject placeableObjectPrefab;

    [SerializeField]
    private KeyCode newObjectHotkey = KeyCode.P;
    private KeyCode deleteObjectHotkey = KeyCode.Backspace;

    private GameObject currentPlaceableObject;
    private GameObject LR1, LR2, LR3, LR4,
        LR5, LR6, LR7, LR8, LR9, LR10,
        B1, B2, B3, B4, B5, B6, B7, B8,
        B9, B10, K1, K2, K3, K4, K5, K6,
        K7, K8, K9, K10, BA1, BA2, BA3,
        BA4, BA5, BA6, BA7, BA8, BA9, BA10;
    private float iRotation;
    private float speed = 10f;

    private bool Slot_select = false;

    public Button Slot1_Button, Slot2_Button,
        Slot3_Button, Slot4_Button, Slot5_Button,
        Slot6_Button, Slot7_Button, Slot8_Button,
        Slot9_Button, Slot10_Button;

    public Dropdown roomSelection;

    private int category;

    // Start is called before the first frame update
    void Start()
    {
        // Load all items to be used
        LoadRoomItems();
        // Button Listener 
        Slot1_Button.onClick.AddListener(Slot1Add);
        Slot2_Button.onClick.AddListener(Slot2Add);
        Slot3_Button.onClick.AddListener(Slot3Add);
        Slot4_Button.onClick.AddListener(Slot4Add);
        Slot5_Button.onClick.AddListener(Slot5Add);
        Slot6_Button.onClick.AddListener(Slot6Add);
        Slot7_Button.onClick.AddListener(Slot7Add);
        Slot8_Button.onClick.AddListener(Slot8Add);
        Slot9_Button.onClick.AddListener(Slot9Add);
        Slot10_Button.onClick.AddListener(Slot10Add);

    }
    // Update is called once per frame
    void Update()
    {
        HandleNewHKObject();
        if(currentPlaceableObject != null)
        {
            MoveCurrPlaceableToMouse();
            RotateFromInput();
            ReleaseIfClicked();
        }
    }

    private void Slot1Add()
    {
        Slot_select = true;
        category = roomSelection.value;

        switch(category)
        {
            case 0:
                placeableObjectPrefab = LR1;
                break;
            case 1:
                placeableObjectPrefab = B1;
                break;
            case 2:
                placeableObjectPrefab = K1;
                break;
            case 3:
                placeableObjectPrefab = BA1;
                break;
        }
        
    }
    private void Slot2Add()
    {
        Slot_select = true;
        category = roomSelection.value;

        switch (category)
        {
            case 0:
                placeableObjectPrefab = LR2;
                break;
            case 1:
                placeableObjectPrefab = B2;
                break;
            case 2:
                placeableObjectPrefab = K2;
                break;
            case 3:
                placeableObjectPrefab = BA2;
                break;
        }
    }
    private void Slot3Add()
    {
        Slot_select = true;
        category = roomSelection.value;
        switch (category)
        {
            case 0:
                placeableObjectPrefab = LR3;
                break;
            case 1:
                placeableObjectPrefab = B3;
                break;
            case 2:
                placeableObjectPrefab = K3;
                break;
            case 3:
                placeableObjectPrefab = BA3;
                break;
        }
    }
    private void Slot4Add()
    {
        Slot_select = true;
        category = roomSelection.value;
        switch (category)
        {
            case 0:
                placeableObjectPrefab = LR4;
                break;
            case 1:
                placeableObjectPrefab = B4;
                break;
            case 2:
                placeableObjectPrefab = K4;
                break;
            case 3:
                placeableObjectPrefab = BA4;
                break;
        }
    }
    private void Slot5Add()
    {
        Slot_select = true;
        category = roomSelection.value;
        switch (category)
        {
            case 0:
                placeableObjectPrefab = LR5;
                break;
            case 1:
                placeableObjectPrefab = B5;
                break;
            case 2:
                placeableObjectPrefab = K5;
                break;
            case 3:
                placeableObjectPrefab = BA5;
                break;
        }
    }
    private void Slot6Add()
    {
        Slot_select = true;
        category = roomSelection.value;
        switch (category)
        {
            case 0:
                placeableObjectPrefab = LR6;
                break;
            case 1:
                placeableObjectPrefab = B6;
                break;
            case 2:
                placeableObjectPrefab = K6;
                break;
            case 3:
                placeableObjectPrefab = BA6;
                break;
        }
    }
    private void Slot7Add()
    {
        Slot_select = true;
        category = roomSelection.value;
        switch (category)
        {
            case 0:
                placeableObjectPrefab = LR7;
                break;
            case 1:
                placeableObjectPrefab = B7;
                break;
            case 2:
                placeableObjectPrefab = K7;
                break;
            case 3:
                placeableObjectPrefab = BA7;
                break;
        }
    }
    private void Slot8Add()
    {
        Slot_select = true;
        category = roomSelection.value;
        switch (category)
        {
            case 0:
                placeableObjectPrefab = LR8;
                break;
            case 1:
                placeableObjectPrefab = B8;
                break;
            case 2:
                placeableObjectPrefab = K8;
                break;
            case 3:
                placeableObjectPrefab = BA8;
                break;
        }
    }
    private void Slot9Add()
    {
        Slot_select = true;
        category = roomSelection.value;
        switch (category)
        {
            case 0:
                placeableObjectPrefab = LR9;
                break;
            case 1:
                placeableObjectPrefab = B9;
                break;
            case 2:
                placeableObjectPrefab = K9;
                break;
            case 3:
                placeableObjectPrefab = BA9;
                break;
        }
    }
    private void Slot10Add()
    {
        Slot_select = true;
        category = roomSelection.value;
        switch (category)
        {
            case 0:
                placeableObjectPrefab = LR10;
                break;
            case 1:
                placeableObjectPrefab = B10;
                break;
            case 2:
                placeableObjectPrefab = K10;
                break;
            case 3:
                placeableObjectPrefab = BA10;
                break;
        }
    }

    private void ReleaseIfClicked()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            GameObjectExtensions.ChangeLayers(currentPlaceableObject, "Default");
            currentPlaceableObject = null;
        }
    }

    private void RotateFromInput()
    {
        
        
        if (Input.GetKey(KeyCode.X))
        {
            iRotation += 0.1f;
            
        }

        if (Input.GetKey(KeyCode.Z))
        {
            iRotation -= 0.1f;
        }

        currentPlaceableObject.transform.Rotate(Vector3.up, iRotation * 10f);

        
        //iRotation += Input.mouseScrollDelta.y;
        //currentPlaceableObject.transform.Rotate(Vector3.up, iRotation * 10f);
    }

    private void MoveCurrPlaceableToMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo))
        {
            currentPlaceableObject.transform.position = hitInfo.point;
            currentPlaceableObject.transform.rotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);
        }
    }

    private void HandleNewHKObject()
    {
        if(Input.GetKeyDown(deleteObjectHotkey))
        {
            Destroy(currentPlaceableObject);
        }

        if(Input.GetKeyDown(newObjectHotkey)|| Slot_select)
        {
            if(currentPlaceableObject == null)
            {
                currentPlaceableObject = Instantiate(placeableObjectPrefab);
                //currentPlaceableObject.layer = LayerMask.NameToLayer("Ignore Raycast");
                Slot_select = false;
            }
            else
            {
                Destroy(currentPlaceableObject);
                //currentPlaceableObject.layer = LayerMask.NameToLayer("Default");
                Slot_select = false;
            }

        }
    }

    private void LoadRoomItems()
    {
        /*
        LR1 = Resources.Load<GameObject>("sofa");
        LR2 = Resources.Load<GameObject>("chair");
        LR3 = Resources.Load<GameObject>("table");
        LR4 = Resources.Load<GameObject>("bookshelf");
        LR5 = Resources.Load<GameObject>("Default_Pivot");
        LR6 = Resources.Load<GameObject>("Default_Pivot");
        LR7 = Resources.Load<GameObject>("Default_Pivot");
        LR8 = Resources.Load<GameObject>("Default_Pivot");
        LR9 = Resources.Load<GameObject>("Default_Pivot");
        LR10 = Resources.Load<GameObject>("Default_Pivot");
        B1 = Resources.Load<GameObject>("bed");
        B2 = Resources.Load<GameObject>("chair");
        B3 = Resources.Load<GameObject>("bookshelf");
        B4 = Resources.Load<GameObject>("table");
        B5 = Resources.Load<GameObject>("sofa");
        B6 = Resources.Load<GameObject>("Default_Pivot");
        B7 = Resources.Load<GameObject>("Default_Pivot");
        B8 = Resources.Load<GameObject>("Default_Pivot");
        B9 = Resources.Load<GameObject>("Default_Pivot");
        B10 = Resources.Load<GameObject>("Default_Pivot");
        K1 = Resources.Load<GameObject>("stove");
        K2 = Resources.Load<GameObject>("chair");
        K3 = Resources.Load<GameObject>("table");
        K4 = Resources.Load<GameObject>("sink");
        K5 = Resources.Load<GameObject>("fridge");
        K6 = Resources.Load<GameObject>("Default_Pivot");
        K7 = Resources.Load<GameObject>("Default_Pivot");
        K8 = Resources.Load<GameObject>("Default_Pivot");
        K9 = Resources.Load<GameObject>("Default_Pivot");
        K10 = Resources.Load<GameObject>("Default_Pivot");
        BA1 = Resources.Load<GameObject>("shower");
        BA2 = Resources.Load<GameObject>("sink");
        BA3 = Resources.Load<GameObject>("Default_Pivot");
        BA4 = Resources.Load<GameObject>("Default_Pivot");
        BA5 = Resources.Load<GameObject>("Default_Pivot");
        BA6 = Resources.Load<GameObject>("Default_Pivot");
        BA7 = Resources.Load<GameObject>("Default_Pivot");
        BA8 = Resources.Load<GameObject>("Default_Pivot");
        BA9 = Resources.Load<GameObject>("Default_Pivot");
        BA10 = Resources.Load<GameObject>("Default_Pivot");
        */
        LR1 = Resources.Load<GameObject>("Prefabs/Default_Pivot");
        LR2 = Resources.Load<GameObject>("Prefabs/Default_Pivot");
        LR3 = Resources.Load<GameObject>("Prefabs/Default_Pivot");
        LR4 = Resources.Load<GameObject>("Prefabs/Default_Pivot");
        LR5 = Resources.Load<GameObject>("Prefabs/Default_Pivot");
        LR6 = Resources.Load<GameObject>("Prefabs/Default_Pivot");
        LR7 = Resources.Load<GameObject>("Prefabs/Default_Pivot");
        LR8 = Resources.Load<GameObject>("Prefabs/Default_Pivot");
        LR9 = Resources.Load<GameObject>("Prefabs/Default_Pivot");
        LR10 = Resources.Load<GameObject>("Prefabs/Default_Pivot");
        B1 = Resources.Load<GameObject>("Prefabs/Default_Pivot");
        B2 = Resources.Load<GameObject>("Prefabs/Default_Pivot");
        B3 = Resources.Load<GameObject>("Prefabs/Default_Pivot");
        B4 = Resources.Load<GameObject>("Prefabs/Default_Pivot");
        B5 = Resources.Load<GameObject>("Prefabs/Default_Pivot");
        B6 = Resources.Load<GameObject>("Prefabs/Default_Pivot");
        B7 = Resources.Load<GameObject>("Prefabs/Default_Pivot");
        B8 = Resources.Load<GameObject>("Prefabs/Default_Pivot");
        B9 = Resources.Load<GameObject>("Prefabs/Default_Pivot");
        B10 = Resources.Load<GameObject>("Prefabs/Default_Pivot");
        K1 = Resources.Load<GameObject>("Prefabs/Default_Pivot");
        K2 = Resources.Load<GameObject>("Prefabs/Default_Pivot");
        K3 = Resources.Load<GameObject>("Prefabs/Default_Pivot");
        K4 = Resources.Load<GameObject>("Prefabs/Default_Pivot");
        K5 = Resources.Load<GameObject>("Prefabs/Default_Pivot");
        K6 = Resources.Load<GameObject>("Prefabs/Default_Pivot");
        K7 = Resources.Load<GameObject>("Prefabs/Default_Pivot");
        K8 = Resources.Load<GameObject>("Prefabs/Default_Pivot");
        K9 = Resources.Load<GameObject>("Prefabs/Default_Pivot");
        K10 = Resources.Load<GameObject>("Prefabs/Default_Pivot");
        BA1 = Resources.Load<GameObject>("Prefabs/Default_Pivotr");
        BA2 = Resources.Load<GameObject>("Prefabs/Default_Pivot");
        BA3 = Resources.Load<GameObject>("Prefabs/Default_Pivot");
        BA4 = Resources.Load<GameObject>("Prefabs/Default_Pivot");
        BA5 = Resources.Load<GameObject>("Prefabs/Default_Pivot");
        BA6 = Resources.Load<GameObject>("Prefabs/Default_Pivot");
        BA7 = Resources.Load<GameObject>("Prefabs/Default_Pivot");
        BA8 = Resources.Load<GameObject>("Prefabs/Default_Pivot");
        BA9 = Resources.Load<GameObject>("Prefabs/Default_Pivot");
        BA10 = Resources.Load<GameObject>("Prefabs/Default_Pivot");
    }
}

public static class GameObjectExtensions
{
    public static void ChangeLayers(GameObject go, string name)
    {
        ChangeLayers(go, LayerMask.NameToLayer(name));
    }

    public static void ChangeLayers(GameObject go, int layer)
    {
        go.layer = layer;
        foreach (Transform child in go.transform)
        {
            ChangeLayers(child.gameObject, layer);
        }
    }
}
