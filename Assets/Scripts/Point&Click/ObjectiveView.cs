
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace DUFE.PointAndClick
{

    public class ObjectiveView : MonoBehaviour
    {
        [Header("Text Objects")]
        public TextMeshProUGUI nameObject;
        public TextMeshProUGUI resultObject;
        public TextMeshProUGUI moneyObject;

        internal void setName(string objectiveName)
        {
            nameObject.text = objectiveName;
        }

        internal void setResult(string objectiveResult)
        {
            resultObject.text = objectiveResult;
        }

        internal void setMoneyLost(float moneyValue)
        {
            moneyObject.text = Math.Round(moneyValue).ToString();
        }
    }
}
