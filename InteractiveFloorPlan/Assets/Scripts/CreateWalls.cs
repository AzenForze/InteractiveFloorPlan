using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateWalls : MonoBehaviour
{
    public Camera theCamera;
    public GameObject wallPrefab;

    bool creating;
    Vector3 startPos;
    Vector3 endPos;
    GameObject wall;
    bool xSnapping = false;
    bool zSnapping = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        getInput();

    }

    void getInput()
    {
        if(Input.GetMouseButtonDown(0))
        {
            setStart();
        } else if (Input.GetMouseButtonUp(0)) {
            setEnd();
        } else {
            if(creating)
            {
                adjust();
            }
        }

        if(Input.GetKeyDown(KeyCode.Z))
        {
            zSnapping = true;
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            xSnapping = true;
        }
        else if( Input.GetKeyUp(KeyCode.Z))
        {
            zSnapping = false;
        }
        else if(Input.GetKeyUp(KeyCode.X))
        {
            xSnapping = false;
        }
    }

    void setStart()
    {
        creating = true;
        startPos = gridSnap(getWorldPoint());
        wall = Instantiate(wallPrefab, startPos, Quaternion.identity);
    }

    void setEnd()
    {
        creating = false;
    }

    void adjust()
    {
        endPos = gridSnap(getWorldPoint());
        if(xSnapping)
        {
            endPos.x = startPos.x;
        }
        else if(zSnapping)
        {
            endPos.z = startPos.z;
        }

        adjustWall();
    }

    void adjustWall()
    {
        wall.transform.LookAt(endPos);
        var distance = Vector3.Distance(startPos, endPos);
        wall.transform.position = startPos + distance / 2 * (endPos - startPos).normalized;
        wall.transform.localScale = new Vector3(wall.transform.localScale.x, wall.transform.localScale.y, distance + (float)0.5);
    }

    Vector3 gridSnap(Vector3 position, float granularity = (float)1.0)
    {
        float xpos = position.x;
        xpos = xpos / granularity;
        xpos = Mathf.Round(xpos) * granularity;

        float zpos = position.z;
        zpos = zpos / granularity;
        zpos = Mathf.Round(zpos) * granularity;

        return new Vector3(xpos, position.y, zpos);
    }

    Vector3 getWorldPoint()
    {
        int layerMask = 1 << 8;
        Ray ray = theCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask);
        return hit.point;
    }
}
