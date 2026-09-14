// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Text;
// using TMPro;
// using UnityEditor;
// using UnityEngine;
// using UnityEngine.UI;
//
// namespace SkillEditor
// {
//     public class UIQuickBinder : Editor
//     {
//         private static Dictionary<Type, string> dict = new()
//         {
//             {typeof(Button), "Btn"},
//             {typeof(TMP_InputField), "Input"},
//             {typeof(TextMeshProUGUI), "Text"}
//         };
//
//         [MenuItem("GameObject/生成绑定", false, 1)]
//         public static void GenerateBinding()
//         {
//             if (Selection.gameObjects.Length != 1)
//             {
//                 EditorUtility.DisplayDialog("错误", "请选择1个GameObject", "哦");
//             }
//             var selectObject = Selection.gameObjects[0];
//
//             var sb = new StringBuilder();
//             var stk = new Stack<Transform>();
//             stk.Push(selectObject.transform);
//
//             foreach (Transform child in selectObject.transform)
//             {
//
//             }
//
//             foreach ((var type, string suffix) in dict)
//             {
//                 var components = selectObject
//                     .GetComponentsInChildren(type, true)
//                     .Where(x => x.name.EndsWith(suffix));
//                 foreach (var com in components)
//                 {
//                     sb.Append($"{com.name} =");
//                 }
//             }
//         }
//     }
// }