using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewStoryScene", menuName = "Data/New Story Scene")]
[System.Serializable]

public class StorySceneInfo : ScriptableObject
{
    public List<Sentence> sentences;
    public StorySceneInfo nextScene;


    [System.Serializable]

    public struct Sentence
    {
        public string text;
        public SpeakerInfo speaker;
    }

}
