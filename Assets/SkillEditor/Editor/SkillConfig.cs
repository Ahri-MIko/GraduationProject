// using System;
// using System.Collections.Generic;
// using UnityEngine;
//
// namespace SkillEditor
// {
//     [Serializable]
//     public class SkillClip
//     {
//         public float start;
//         public float duration;
//     }
//
//     [Serializable]
//     public class SkillAudioClip : SkillClip
//     {
//         public AudioClip clip;
//     }
//
//     [Serializable]
//     public class SkillVFXClip : SkillClip
//     {
//         public GameObject prefab;
//     }
//
//     [Serializable]
//     public class SkillEvent
//     {
//         public string name;
//     }
//
//     [CreateAssetMenu(fileName = "SkillConfig", menuName = "SkillEditor/SkillConfig")]
//     public class SkillConfig : ScriptableObject
//     {
//         public AnimationClip clip;
//         public List<SkillAudioClip> skillAudioClips;
//         public List<SkillVFXClip> skillVFXClips;
//         public List<SkillEvent> skillEvents;
//     }
// }