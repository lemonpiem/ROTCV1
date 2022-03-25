using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BottomBarController : MonoBehaviour
{
    public TextMeshProUGUI barText;
    public TextMeshProUGUI personNameText;

    private int sentenceIndex = -1;
    public StorySceneInfo currentScene;
    private State state = State.Completed;

    private enum State
    {
        Playing, Completed
    }

    
    void Start()
    {
        StartCoroutine(TypeText(currentScene.sentences[++sentenceIndex].text));
    }

    private IEnumerator TypeText (string text)
    {
        barText.text = "";
        state = State.Playing;
        int wordIndex = 0;

        while (state != State.Completed)
        {
            barText.text += text[wordIndex];
            yield return new WaitForSeconds(0.05f);
            if (++wordIndex == text.Length)
            {
                state = State.Completed;}
                break;
            }
        }
}
    

