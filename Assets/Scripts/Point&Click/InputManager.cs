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


        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D rayHit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));
            {
                if (rayHit.collider)
                {

                    if (rayHit.collider.GetComponent<IINteractable>() != null)
                    {
                        rayHit.collider.GetComponent<IINteractable>().OnInteract();
                    }
                }

            }
        }
    }
}
