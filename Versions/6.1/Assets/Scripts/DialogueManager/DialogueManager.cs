using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    // Queue gestisce gli elementi al suo interno secondo un ordine FIFO
    private Queue <string> sentences;
    public GameObject dialogueBox;
    public GameObject btnPlay;

    public Text sentencesText;
    public bool finishDialogue;
    public float seconds;
    void Awake(){
        finishDialogue = false;
        sentences = new Queue<string>();
    }
    
    public void StartDialogue(Dialogue d){   
        dialogueBox.SetActive(true);
        sentences.Clear();
        foreach(string sentence in d.sentences){
            sentences.Enqueue(sentence);
        }
        NextSentence();  
    }

    public void NextSentence(){
        if(sentences.Count == 0){
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
        
    }
    IEnumerator TypeSentence(string sentence){
        sentencesText.text = "";
        foreach(char letter in sentence.ToCharArray()){
            sentencesText.text += letter;
            yield return new WaitForSeconds(seconds);
        }
        yield return null;
    }
    public void EndDialogue(){
        finishDialogue = true;
        btnPlay.SetActive(true);
        dialogueBox.SetActive(false);
    }
}
