using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace DUFE.UI.Popup
{
    public class Popup : MonoBehaviour
    {
        [Header("Variables popup")]
        public string title;
        [TextArea()]
        public string content;
        [Header("Destroy the popup ?")]
        public bool destroy = true; 
        [Header("Scene reference")]
        public Transform popupParent;
        public GameObject popupPrefab;

        public void PopupInstantiate()
        {
            GameObject g = Instantiate(popupPrefab, popupParent);
            g.transform.Find("Title").GetComponent<TextMeshProUGUI>().text = title;
            g.transform.Find("Content").GetComponent<TextMeshProUGUI>().text = content;
            if(destroy == true)
            {
                g.transform.Find("destroyObj").gameObject.SetActive(true);
            }
        }
    }

}