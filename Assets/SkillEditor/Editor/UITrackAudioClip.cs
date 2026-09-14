// using UnityEngine;
// using UnityEngine.EventSystems;
// using UnityEngine.UI;
//
// namespace SkillEditor
// {
//     public class UITrackAudioClip : Selectable, IDragHandler
//     {
//         private RectTransform rectTransform;
//
//         protected override void Awake()
//         {
//             base.Awake();
//             rectTransform = transform as RectTransform;
//         }
//
//         public void OnDrag(PointerEventData eventData)
//         {
//             if (eventData.button == PointerEventData.InputButton.Left)
//             {
//                 rectTransform.anchoredPosition += new Vector2(eventData.delta.x, 0);
//             }
//         }
//     }
// }