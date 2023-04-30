using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataHolder : Singleton<DataHolder>
{
    public float characterRating;

    public void setCharacterRating(float newRating)
    {
        characterRating = (float)Math.Round(newRating, 2); 
    }
}
