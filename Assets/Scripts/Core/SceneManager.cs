using DUFE.Audio;
using DUFE.PointAndClick;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace DUFE.Core
{
    /// <summary>
    /// Controls the scene and stores the progress. It is not persistent through scenes. 
    /// DataHolder will hold the data between scenes.
    /// </summary>
    public class SceneManager : MonoBehaviour
    {
        [Header("Default Variables")]
        [Header("Time in seconds")]
        public float timeRemaining = 60f;

        [Header("Main objective")]
        public string objectiveString;

        [Header("List of Objectives done for the level")]
        public List<Objective> objectives;
        public List<Objective> possibleObjectives;

        [Header("Company money")]
        public float companyMoney = 95000f;
        private float companyMoneyInitial;

        [Header("End of scene Event")]
        public UnityEvent end;

        [Header("Is the game started ?")]
        private bool startedScene = false;
        private bool endofScene = false;

        [Header("Scene reference")]
        public TextMeshProUGUI companytxt; 
        public TextMeshProUGUI objectiveTxt;
        public TextMeshProUGUI timeTxt;
        [Header("Result reference")]
        public GameObject resultWindow; 
        public CanvasGroup mainCanvas;
        [Header("Objective reference")]
        public GameObject objectiveParent;
        [Header("Prefabs")]
        public GameObject objectivePrefab;
        private AudioManager am; 

        void Start()
        {
            companyMoneyInitial = companyMoney;
            possibleObjectives = FindObjectsOfType<Objective>(true).ToList(); 
            companytxt.text = companyMoney.ToString();
            objectiveTxt.text = objectiveString;
            timeTxt.text = timeRemaining.ToString();
            ///To avoid interaction before end of whatever comes first in scene
            mainCanvas.blocksRaycasts = false; 
        }

        // Update is called once per frame
        void Update()
        {
            if(startedScene == true)
            {
                if (timeRemaining <= 0f && endofScene == false)
                {
                    endofScene = true;
                    endScene(); 
                } 
                else if(endofScene == false)
                {
                    timeRemaining -= Time.deltaTime;
                    timeTxt.text = Math.Round(timeRemaining).ToString();

                }
            }
        }

        private void showResultEnd()
        {
            Debug.Log(objectives.Count);
            foreach(Objective c in objectives)
            {
                GameObject g  = Instantiate(objectivePrefab, objectiveParent.transform);
                g.GetComponent<ObjectiveView>().setName(c.objectiveName);
                g.GetComponent<ObjectiveView>().setResult(c.objectiveResult);
                g.GetComponent<ObjectiveView>().setMoneyLost(c.moneyValue);
                g.SetActive(true);
            }
            resultWindow.SetActive(true); 
        }

        internal void addObjective(Objective objective)
        {
            companyMoney -= objective.moneyValue;
            companytxt.text = companyMoney.ToString();
            objectives.Add(objective);
        }

        public float calculateRating()
        {
            float f = 0f;
            f =  ((companyMoneyInitial-companyMoney / companyMoneyInitial) * 100);
            switch (f)
            {
                case >70f:
                    f = 5; 
                    break;
                case > 50f:
                    f = 4;
                    break;
                case > 30f:
                    f = 3;
                    break;
                case > 20f:
                    f = 2;
                    break;
                default:
                    f = 1;
                    break;
            }
            return f; 
        }
        public void endScene()
        {
            timeRemaining = 0;
            timeTxt.text = Math.Round(timeRemaining).ToString();
            float f  = calculateRating(); 
            showResultEnd();
            end?.Invoke();
        }

        public void startScene()
        {
            ///To avoid interaction before end of whatever comes first in scene
            mainCanvas.blocksRaycasts = true;
            startedScene = true; 
        }

        public float getTimeRemaining()
        {
            return (float) Math.Round(timeRemaining); 
        }

        public void setTimeRemaining(float f)
        {
            timeRemaining = f;
        }


    }

}