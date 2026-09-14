// using System;
// using TMPro;
// using UnityEngine;
// using UnityEngine.UI;
//
// namespace SkillEditor
// {
//     public class UIMenuAction : MonoBehaviour
//     {
//         public UIMenu uiMenu;
//         public TextMeshProUGUI Text;
//         public Button Btn;
//
//         public UIMenuAction Set(string text, Action callback)
//         {
//             Text.text = text;
//             Btn.onClick.AddListener(() =>
//             {
//                 callback?.Invoke();
//                 if (uiMenu != null)
//                 {
//                     Destroy(uiMenu.gameObject);
//                 }
//             });
//             return this;
//         }
//     }
// }