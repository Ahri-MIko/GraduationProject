// using UnityEngine;
//
// namespace SkillEditor
// {
//     public class UIMenu : MonoBehaviour
//     {
//         [SerializeField] private Transform UIMenuActionRoot;
//
//         public UIMenu Set(Vector2 screenPos)
//         {
//             var rectTransform = transform as RectTransform;
//             RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform.parent as RectTransform, screenPos, null,
//                 out var localPos);
//             rectTransform.anchoredPosition = localPos;
//             return this;
//         }
//
//         public UIMenu Add(UIMenuAction uiMenuAction)
//         {
//             uiMenuAction.transform.SetParent(UIMenuActionRoot);
//             uiMenuAction.uiMenu = this;
//             return this;
//         }
//     }
// }