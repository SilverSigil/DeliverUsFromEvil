using DUFE.Core;
using DUFE.PointAndClick.Drag;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace DUFE.PointAndClick
{
    /// <summary>
    /// Once an outcome has been achieved, the objective object is added to the list of objectives done in sceneManager. 
    /// </summary>
    public class Objective : MonoBehaviour
    {
        [Header("Sentences shown on ending screen")]
        public string objectiveName;
        [TextArea]
        public string objectiveResult;
        [Header("Value of the money lost")]
        public float moneyValue; 
        //[Header("Is the objective optional to complete the level ?")]
        //public bool isOptional = false; 

        public void addObjective()
        {
            FindAnyObjectByType<SceneManager>().addObjective(GetComponent<Objective>());
        }
    }


}