using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundPlacementController : MonoBehaviour
{
    [SerializeField]
    private GameObject placeableObjectPrefab;

    [SerializeField]
    private KeyCode newObjectHotkey = KeyCode.P;

    private GameObject currentPlaceableObject;
    private float iRotation;
    private float speed = 10f;
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

    private void ReleaseIfClicked()
    {
        if (Input.GetMouseButtonDown(0))
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
        if(Input.GetKeyDown(newObjectHotkey))
        {
            if(currentPlaceableObject == null)
            {
                currentPlaceableObject = Instantiate(placeableObjectPrefab);
                //currentPlaceableObject.layer = LayerMask.NameToLayer("Ignore Raycast");
            }
            else
            {
                Destroy(currentPlaceableObject);
                //currentPlaceableObject.layer = LayerMask.NameToLayer("Default");
            }

        }
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
