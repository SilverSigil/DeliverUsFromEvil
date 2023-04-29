using DUFE.PointAndClick;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace DUFE.Core
{

    public class SceneManager : MonoBehaviour
    {
        [Header("Default Variables")]
        [Header("Time in seconds")]
        public float timeRemaining = 60f;
        [Header("Main objective")]
        public string objectiveString;
        [Header("List of Objectives for the level")]
        public List<Objective> objectives;
        [Header("Company money")]
        public float companyMoney = 95000f;
        [Header("End of scene Event")]
        public UnityEvent end;
        [Header("Is the game started ?")]
        private bool startedScene = false;
        [Header("Scene reference")]
        public TextMeshProUGUI companytxt; 
        public TextMeshProUGUI objectiveTxt;
        public TextMeshProUGUI timeTxt;
        public GameObject resultWindow; 
        public CanvasGroup mainCanvas;

        void Start()
        {
            companytxt.text = companyMoney.ToString();
            objectiveTxt.text = objectiveString;
            timeTxt.text = timeRemaining.ToString();
            mainCanvas.blocksRaycasts = false; 
        }

        // Update is called once per frame
        void Update()
        {
            if(startedScene == true)
            {
                timeRemaining -= Time.deltaTime;
                timeTxt.text = Math.Round(timeRemaining).ToString();

                if (timeRemaining <= 0f)
                {
                    end?.Invoke(); 
                }
            }
        }

        public void startScene()
        {
            mainCanvas.blocksRaycasts = true;
            startedScene = true; 
        }

        public float getTimeRemaining()
        {
            return (float)System.Math.Round(timeRemaining); 
        }
    }

}