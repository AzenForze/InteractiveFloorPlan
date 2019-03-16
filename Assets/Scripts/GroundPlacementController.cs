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

    private List<List<GameObject>> furnitureItems;

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

        // Initial object
        placeableObjectPrefab = furnitureItems[0][0];

        // Button Listener
        Slot1_Button.onClick.AddListener(() => { SlotAdd(0); });
        Slot2_Button.onClick.AddListener(() => { SlotAdd(1); });
        Slot3_Button.onClick.AddListener(() => { SlotAdd(2); });
        Slot4_Button.onClick.AddListener(() => { SlotAdd(3); });
        Slot5_Button.onClick.AddListener(() => { SlotAdd(4); });
        Slot6_Button.onClick.AddListener(() => { SlotAdd(5); });
        Slot7_Button.onClick.AddListener(() => { SlotAdd(6); });
        Slot8_Button.onClick.AddListener(() => { SlotAdd(7); });
        Slot9_Button.onClick.AddListener(() => { SlotAdd(8); });
        Slot10_Button.onClick.AddListener(() => { SlotAdd(9); });

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

    private void SlotAdd(int slotNum)
    {
        Slot_select = true;
        category = roomSelection.value;
        placeableObjectPrefab = furnitureItems[category][slotNum];
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

        if(Input.GetKeyDown(newObjectHotkey) || Slot_select)
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
        furnitureItems = new List<List<GameObject>>()
        {
            new List<GameObject>()
            {
                Resources.Load<GameObject>("Prefabs/Default_Pivot"),
                Resources.Load<GameObject>("Prefabs/Default_Pivot"),
                Resources.Load<GameObject>("Prefabs/Default_Pivot"),
                Resources.Load<GameObject>("Prefabs/Default_Pivot"),
                Resources.Load<GameObject>("Prefabs/Default_Pivot"),
                Resources.Load<GameObject>("Prefabs/Default_Pivot"),
                Resources.Load<GameObject>("Prefabs/Default_Pivot"),
                Resources.Load<GameObject>("Prefabs/Default_Pivot"),
                Resources.Load<GameObject>("Prefabs/Default_Pivot"),
                Resources.Load<GameObject>("Prefabs/Default_Pivot")
            },
            new List<GameObject>()
            {
                Resources.Load<GameObject>("Prefabs/Default_Pivot"),
                Resources.Load<GameObject>("Prefabs/Default_Pivot"),
                Resources.Load<GameObject>("Prefabs/Default_Pivot"),
                Resources.Load<GameObject>("Prefabs/Default_Pivot"),
                Resources.Load<GameObject>("Prefabs/Default_Pivot"),
                Resources.Load<GameObject>("Prefabs/Default_Pivot"),
                Resources.Load<GameObject>("Prefabs/Default_Pivot"),
                Resources.Load<GameObject>("Prefabs/Default_Pivot"),
                Resources.Load<GameObject>("Prefabs/Default_Pivot"),
                Resources.Load<GameObject>("Prefabs/Default_Pivot")
            },
            new List<GameObject>()
            {
                Resources.Load<GameObject>("Prefabs/Default_Pivot"),
                Resources.Load<GameObject>("Prefabs/Default_Pivot"),
                Resources.Load<GameObject>("Prefabs/Default_Pivot"),
                Resources.Load<GameObject>("Prefabs/Default_Pivot"),
                Resources.Load<GameObject>("Prefabs/Default_Pivot"),
                Resources.Load<GameObject>("Prefabs/Default_Pivot"),
                Resources.Load<GameObject>("Prefabs/Default_Pivot"),
                Resources.Load<GameObject>("Prefabs/Default_Pivot"),
                Resources.Load<GameObject>("Prefabs/Default_Pivot"),
                Resources.Load<GameObject>("Prefabs/Default_Pivot")
            },
            new List<GameObject>()
            {
                Resources.Load<GameObject>("Prefabs/Default_Pivot"),
                Resources.Load<GameObject>("Prefabs/Default_Pivot"),
                Resources.Load<GameObject>("Prefabs/Default_Pivot"),
                Resources.Load<GameObject>("Prefabs/Default_Pivot"),
                Resources.Load<GameObject>("Prefabs/Default_Pivot"),
                Resources.Load<GameObject>("Prefabs/Default_Pivot"),
                Resources.Load<GameObject>("Prefabs/Default_Pivot"),
                Resources.Load<GameObject>("Prefabs/Default_Pivot"),
                Resources.Load<GameObject>("Prefabs/Default_Pivot"),
                Resources.Load<GameObject>("Prefabs/Default_Pivot")
            }
        };
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
