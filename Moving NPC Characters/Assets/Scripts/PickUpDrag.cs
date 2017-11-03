using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpDrag : MonoBehaviour
{
    float distance = 1;
    public GameObject obj;
    public string targetTag;


    void OnMouseDown()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        Instantiate(obj, GameObject.FindGameObjectWithTag(targetTag).transform.position, Quaternion.identity);
    }

    void OnMouseDrag()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        obj.transform.position = objPosition;
    }
}
