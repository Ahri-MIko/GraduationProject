// using System;
// using Kirara;
// using UnityEngine;
// using UnityEngine.EventSystems;
//
// namespace SkillEditor
// {
//     public class UITrack : MonoBehaviour, IPointerClickHandler
//     {
//         private Vector2 pos;
//
//         public void OnPointerClick(PointerEventData eventData)
//         {
//             if (eventData.button == PointerEventData.InputButton.Right)
//             {
//                 Vector2 pointerPos = eventData.position;
//                 UIManager.Instance.Create<UIMenu>()
//                     .Set(pointerPos)
//                     .Add(UIManager.Instance.Create<UIMenuAction>().Set("Add Event", () =>
//                     {
//                         var trackEvent = UIManager.Instance.Create<UITrackEvent>(transform);
//                         var rectTransform = trackEvent.transform as RectTransform;
//                         RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform,
//                             pointerPos, null, out var localPoint);
//                         rectTransform.anchoredPosition =
//                             new Vector2(localPoint.x, 0);
//                     }));
//             }
//         }
//     }
// }