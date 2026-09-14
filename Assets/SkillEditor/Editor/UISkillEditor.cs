// using System;
// using System.Collections.Generic;
// using Kirara;
// using TMPro;
// using UnityEditor;
// using UnityEngine;
// using UnityEngine.UI;
//
// namespace SkillEditor
// {
//     public class UISkillEditor : MonoBehaviour
//     {
//         // UI
//         public Button SetBtn;
//         public Button GoBeginningBtn;
//         public Button PreviousFrameBtn;
//         public Button PlayBtn;
//         public Button NextFrameBtn;
//         public Button GoEndBtn;
//         public TMP_InputField FrameIdxInput;
//         public TMP_InputField TimeScaleInput;
//
//         public Transform FrameItemRoot;
//         public GameObject FrameItem;
//
//         public GameObject target;
//         public SkillConfig config;
//         public AudioClip audioClip;
//         public AnimationClip animationClip;
//         public GameObject go;
//
//         public RectTransform UIAnimationTrack;
//
//         private List<SkillConfig> skillConfigs;
//         private bool isPlaying;
//         private float time;
//         private int frameIdx;
//         private int frameRate;
//
//         private FrameInfo frameInfo;
//
//         private void Awake()
//         {
//             isPlaying = false;
//             time = 0f;
//
//             frameRate = 60;
//
//             frameIdx = 0;
//             FrameIdxInput.text = "0";
//             FrameIdxInput.onEndEdit.AddListener(text =>
//             {
//                 SetTime(float.Parse(text) / frameRate);
//             });
//
//             Time.timeScale = 1f;
//             TimeScaleInput.onEndEdit.AddListener(text =>
//             {
//                 Time.timeScale = float.Parse(text);
//             });
//
//             frameInfo = ScriptableObject.CreateInstance<FrameInfo>();
//
//             SetBtn.onClick.AddListener(() =>
//             {
//                 if (target == null || config == null) return;
//
//                 float frameCnt = config.clip.length * frameRate;
//                 UIAnimationTrack.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, frameCnt * 10f);
//             });
//
//             GoBeginningBtn.onClick.AddListener(() =>
//             {
//                 SetTime(0f);
//             });
//
//             PreviousFrameBtn.onClick.AddListener(() =>
//             {
//                 if (time > 0f)
//                 {
//                     SetTime(Math.Max(0f, time - 1f / frameRate));
//                 }
//             });
//
//             PlayBtn.onClick.AddListener(() =>
//             {
//                 isPlaying = !isPlaying;
//             });
//
//             NextFrameBtn.onClick.AddListener(() =>
//             {
//                 if (time < config.clip.length)
//                 {
//                     SetTime(Math.Min(config.clip.length, time + 1f / frameRate));
//                 }
//             });
//
//             GoEndBtn.onClick.AddListener(() =>
//             {
//                 SetTime(config.clip.length);
//             });
//         }
//
//         private void Update()
//         {
//             if (config != null)
//             {
//                 if (isPlaying)
//                 {
//                     float t = time + Time.deltaTime;
//                     if (t > config.clip.length)
//                     {
//                         t = 0f;
//                     }
//                     SetTime(t);
//                 }
//             }
//         }
//
//         private void SetFrameIdx(int frameIdx)
//         {
//             if (frameIdx == this.frameIdx) return;
//             FrameIdxInput.text = frameIdx.ToString();
//
//             this.frameIdx = frameIdx;
//             SetTime(frameIdx / (float)frameRate);
//         }
//
//         private void SetTime(float time)
//         {
//             this.time = time;
//             FrameIdxInput.text = (time * frameRate).ToString();
//             config.clip.SampleAnimation(target, time);
//         }
//     }
// }