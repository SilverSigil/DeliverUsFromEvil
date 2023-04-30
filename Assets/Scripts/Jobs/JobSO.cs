using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DUFE.Jobs
{

    [Serializable]
    [CreateAssetMenu(fileName = "Job", menuName = "ScriptableObject/Job", order = 100)]
    public class JobSO : ScriptableObject
    {
        [TextArea]
        public string jobDescription;
        /// <summary>
        /// Character who's asking for the job
        /// </summary>
        public string CharacterName;
        /// <summary>
        /// Ink story to add
        /// </summary>
        public TextAsset storyInk; 
    }

}