using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Detect a collision from the UI to the 2d objects. 
/// Also used to add actions 
/// </summary>
public class InputManager : MonoBehaviour
{
    Camera cam; 
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 mousePos = Input.mousePosition; 
        mousePos = cam.ScreenToWorldPoint(mousePos);

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(mousePos);
            RaycastHit hit; 
            if(Physics.Raycast(ray, out hit, 100))
            {
                if (hit.collider.GetComponent<IINteractable>()!=null)
                {
                    Debug.Log(hit.collider.gameObject.name);
                }
            }
        }
    }
}
