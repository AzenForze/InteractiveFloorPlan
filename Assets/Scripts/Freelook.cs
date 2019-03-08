using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Controller;

public class Freelook : MonoBehaviour
{
    CreateWalls createWallsScript;

    private IState state;

    public IState freecamState;
    public IState overviewState;

    public int XSensitivity = 2;
    public int YSensitivity = 2;

    public int baseSpeed = 10;
    public int speedModifier = 3;
    public float keySensivity = 20;

    public Camera flyCamera;
    
    // Start is called before the first frame update
    void Start()
    {
        CreateWalls createWallsScript = GetComponent<CreateWalls>();
        createWallsScript.enabled = false;
        freecamState = new FreecamState(this);
        overviewState = new OverviewState(this, flyCamera, createWallsScript);

        state = freecamState;
        state.Enter();
    }

    public void ChangeState(IState newState)
    {
        state.Exit();
        state = newState;
        state.Enter();
    }

    // Update is called once per frame
    void Update()
    {
        state.Update();

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
