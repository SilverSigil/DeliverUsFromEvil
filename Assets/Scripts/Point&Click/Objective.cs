using DUFE.PointAndClick.Drag;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace DUFE.PointAndClick
{
    [RequireComponent(typeof(InteractiveSpace))]
    public class Objective : MonoBehaviour
    {
        [Header("Sentences shown on ending screen")]
        public string objectiveName;
        public string objectiveResult;
        [Header("Value of the money lost")]
        public float moneyValue; 
        [Header("Event on item drop")]
        public UnityEvent onDrop; 
        [Header("Is the objective optional to complete the level ?")]
        public bool isOptional = false; 
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }


}