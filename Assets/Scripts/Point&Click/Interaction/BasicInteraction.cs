using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BasicInteraction : MonoBehaviour, IINteractable
{
    public UnityEvent onInteract;

    public void OnInteract()
    {
        onInteract?.Invoke();
    }


}
