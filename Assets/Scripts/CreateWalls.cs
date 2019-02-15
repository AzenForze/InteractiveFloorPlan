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
    }

    void setStart()
    {
        creating = true;
        startPos = getWorldPoint();
        wall = Instantiate(wallPrefab, startPos, Quaternion.identity);
    }

    void setEnd()
    {
        creating = false;
    }

    void adjust()
    {
        endPos = getWorldPoint();
        adjustWall();
    }

    void adjustWall()
    {
        wall.transform.LookAt(endPos);
        var distance = Vector3.Distance(startPos, endPos);
        wall.transform.position = startPos + distance / 2 * (endPos - startPos).normalized;
        wall.transform.localScale = new Vector3(wall.transform.localScale.x, wall.transform.localScale.y, distance);
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
