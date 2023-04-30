using DUFE.Inventory;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace DUFE.PointAndClick.Drag
{

    public class DragAndDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
    {
        [SerializeField] private Canvas canvas;
        private RectTransform rectTransform;
        private CanvasGroup canvasGroup;
        public Vector3 defaultPos;
        public string currentValue;
        public bool droppedOnSlot;
        public string currentTag;
        public InteractiveSpace itemslot;
        private HorizontalLayoutGroup parent; 

        private void Awake()
        {
            parent = GetComponentInParent<HorizontalLayoutGroup>(); 
            canvas = GetComponentInParent<Canvas>();
            defaultPos = this.transform.localPosition;
            rectTransform = GetComponent<RectTransform>();
            canvasGroup = GetComponent<CanvasGroup>();

        }

        public void OnDrag(PointerEventData eventData)
        {
            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }
        public void OnPointerDown(PointerEventData eventData)
        {

        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            //if we take it off a slot
            if (droppedOnSlot == true)
            {
                Debug.Log(itemslot);
            }

            eventData.pointerDrag.GetComponent<DragAndDrop>().droppedOnSlot = false;
            canvasGroup.alpha = 0.6f;
            canvasGroup.blocksRaycasts = false;
        }
        public void OnEndDrag(PointerEventData eventData)
        {
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Camera cam = Camera.main;
            RaycastHit2D rayHit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));
            if (rayHit)
            {
                Debug.Log("hit");
                if (rayHit.collider.GetComponent<InteractiveSpace>() == true)
                {
                    rayHit.collider.GetComponent<InteractiveSpace>().onInteract(GetComponent<InventorySlot>());
                    Destroy(gameObject);
                }
                else
                {
                    LayoutRebuilder.ForceRebuildLayoutImmediate(parent.GetComponent<RectTransform>());
                    transform.localPosition = defaultPos;
                    LayoutRebuilder.ForceRebuildLayoutImmediate(parent.GetComponent<RectTransform>());
                }

            } else
            {

                LayoutRebuilder.ForceRebuildLayoutImmediate(parent.GetComponent<RectTransform>());
                transform.localPosition = defaultPos;
                LayoutRebuilder.ForceRebuildLayoutImmediate(parent.GetComponent<RectTransform>());
            }
            canvasGroup.alpha = 1f;
            canvasGroup.blocksRaycasts = true;
        }



        public void OnDrop(PointerEventData eventData)
        {
            throw new System.NotImplementedException();
        }

        public static T CopyComponent<T>(T original, GameObject destination) where T : Component
        {
            var type = original.GetType();
            var copy = destination.AddComponent(type);
            var fields = type.GetFields();
            foreach (var field in fields) field.SetValue(copy, field.GetValue(original));
            return copy as T;
        }

    }

}