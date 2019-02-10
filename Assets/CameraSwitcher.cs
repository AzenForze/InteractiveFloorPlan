using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public GameObject flyCamera;

    UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController FPController;
    Camera FPCamera;
    Rigidbody body;

    bool flying = false;

    // Start is called before the first frame update
    void Start()
    {
        FPController = GetComponent<UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController>();
        FPCamera = FPController.cam;
        body = GetComponent<Rigidbody>();

        FPController.enabled = true;
        FPCamera.enabled = true;
        flyCamera.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("c"))
        {
            flying = !flying;

            if(flying)
            {
                FPController.enabled = false;
                FPCamera.enabled = false;
                flyCamera.SetActive(true);
                flyCamera.transform.position = FPController.transform.position;
                flyCamera.transform.rotation = FPController.transform.rotation;
            }
            else
            {
                FPController.enabled = true;
                FPCamera.enabled = true;
                FPCamera.enabled = true;
                flyCamera.SetActive(false);
            }
        }
    }
}
