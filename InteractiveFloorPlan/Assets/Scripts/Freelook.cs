using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freelook : MonoBehaviour
{
    int baseSpeed = 10;

    float rotationX = 0f;
    float rotationY = 0f;

    CreateWalls createWallsScript;

    enum CameraMode
    {
        Free,
        TopDown
    }

    CameraMode mode = CameraMode.Free;

    public int XSensitivity = 2;
    public int YSensitivity = 2;
    public int speedModifier = 3;
    public float keySensivity = 20;

    public Camera flyCamera;
    
    // Start is called before the first frame update
    void Start()
    {
        createWallsScript = GetComponent<CreateWalls>();
        EnableFree();
    }

    void EnableFree()
    {
        mode = CameraMode.Free;
        flyCamera.transform.localRotation = Quaternion.AngleAxis(0, Vector3.left);
        Cursor.lockState = CursorLockMode.Locked;
        createWallsScript.enabled = false;
    }

    void EnableTopDown()
    {
        mode = CameraMode.TopDown;

        transform.localRotation = Quaternion.AngleAxis(transform.localEulerAngles.y, Vector3.up);
        transform.localRotation *= Quaternion.AngleAxis(0, Vector3.left);

        flyCamera.transform.localRotation = Quaternion.AngleAxis(-90, Vector3.left);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        createWallsScript.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("t"))
        {
            if(mode == CameraMode.Free)
            {
                EnableTopDown();
            }
            else if(mode == CameraMode.TopDown)
            {
                EnableFree();
            }
        }

        if (mode == CameraMode.Free)
        {
            // instead of going from 0 to 360 cw, go from -180 to 180 ccw, keeping 0 the same
            var direction = 540 - transform.localEulerAngles.x; // (360 - x) + 180 = 540 - x
            direction %= 360;
            direction -= 180;

            rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * XSensitivity;
            rotationX = ((rotationX + 180) % 360) - 180;
            rotationY = direction + Input.GetAxis("Mouse Y") * YSensitivity;
            rotationY = Mathf.Clamp(rotationY, -90, 90);

            transform.localRotation = Quaternion.AngleAxis(rotationX, Vector3.up);
            transform.localRotation *= Quaternion.AngleAxis(rotationY, Vector3.left);
        }

        if (mode == CameraMode.TopDown)
        {

        }

        var finalSpeed = baseSpeed * Time.deltaTime;
        if(Input.GetKey(KeyCode.LeftShift))
        {
            finalSpeed *= speedModifier;
        }

        if (Input.GetKey("w")) transform.position += transform.forward * finalSpeed;
        else if (Input.GetKey("s")) transform.position -= transform.forward * finalSpeed;

        if (Input.GetKey("a")) transform.position += -transform.right * finalSpeed;
        else if (Input.GetKey("d")) transform.position += transform.right * finalSpeed;

        if (Input.GetKey("f")) transform.position += -Vector3.up * finalSpeed;
        if (Input.GetKey("r")) transform.position += Vector3.up * finalSpeed;

        if (Input.GetKey("q")) transform.localRotation *= Quaternion.AngleAxis(-keySensivity * Time.deltaTime, Vector3.up);
        if (Input.GetKey("e")) transform.localRotation *= Quaternion.AngleAxis(keySensivity * Time.deltaTime, Vector3.up);
    }
}
