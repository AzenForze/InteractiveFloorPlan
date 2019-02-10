using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freelook : MonoBehaviour
{
    int baseSpeed = 10;

    float rotationX = 0f;
    float rotationY = 0f;

    public int XSensitivity = 100;
    public int YSensitivity = 100;
    

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // instead of going from 0 to 360 cw, go from -180 to 180 ccw, keeping 0 the same
        var direction = 540 - transform.localEulerAngles.x; // (360 - x) + 180 = 540 - x
        direction %= 360;
        direction -= 180;

        rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * XSensitivity;
        rotationX = ((rotationX+180) % 360)-180;
        rotationY = direction + Input.GetAxis("Mouse Y") * YSensitivity;
        rotationY = Mathf.Clamp(rotationY, -90, 90);

        transform.localRotation = Quaternion.AngleAxis(rotationX, Vector3.up);
        transform.localRotation *= Quaternion.AngleAxis(rotationY, Vector3.left);

        

        if (Input.GetKey("w")) transform.position += transform.forward * baseSpeed * Time.deltaTime;
        else if (Input.GetKey("s")) transform.position -= transform.forward * baseSpeed * Time.deltaTime;

        if (Input.GetKey("a")) transform.position += -transform.right * baseSpeed * Time.deltaTime;
        else if (Input.GetKey("d")) transform.position += transform.right * baseSpeed * Time.deltaTime;
    }
}
