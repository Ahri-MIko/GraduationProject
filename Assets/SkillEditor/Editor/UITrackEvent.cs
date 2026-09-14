// using Kirara;
// using UnityEditor;
// using UnityEngine;
// using UnityEngine.EventSystems;
//
// namespace SkillEditor
// {
//     public class UITrackEvent : MonoBehaviour, IDragHandler, IPointerClickHandler
//     {
//         private RectTransform rectTransform;
//         private SkillEventConfig config;
//
//         private void Awake()
//         {
//             rectTransform = transform as RectTransform;
//             config = ScriptableObject.CreateInstance<SkillEventConfig>();
//         }
//
//         public void OnDrag(PointerEventData eventData)
//         {
//             if (eventData.button == PointerEventData.InputButton.Left)
//             {
//                 rectTransform.anchoredPosition += new Vector2(eventData.delta.x, 0);
//             }
//         }
//
//         public void OnPointerClick(PointerEventData eventData)
//         {
//             if (eventData.button == PointerEventData.InputButton.Left)
//             {
//                 AssetDatabase.OpenAsset(config);
//             }
//             if (eventData.button == PointerEventData.InputButton.Right)
//             {
//                 UIManager.Instance.Create<UIMenu>()
//                     .Set(eventData.position)
//                     .Add(UIManager.Instance.Create<UIMenuAction>().Set("删除", () =>
//                     {
//                         Destroy(gameObject);
//                     }));
//             }
//         }
//     }
// }