using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    Queue<string> sentences;

    string[] choises;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public Image characterImage;

    public Animator animator;

    public GameObject choisesBox;
    public GameObject selectionPref;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);

        characterImage.sprite = dialogue.characterImage;
        nameText.text = dialogue.name;

        choises = new string[dialogue.choises.Length];
        for (int i = 0; i < choises.Length; i++)
        {
            choises[i] = dialogue.choises[i];
        }

        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            if (letter == "/".ToCharArray()[0])
            {
                choisesBox.SetActive(true);
                for(int i = 0; i < choises.Length; i++)
                {
                    GameObject selectionButton = Instantiate(selectionPref, choisesBox.transform);
                    selectionButton.GetComponentInChildren<TextMeshProUGUI>().text = choises[i];
                }
            } else
            {
                choisesBox.SetActive(false);
                dialogueText.text += letter;
            }
            yield return null;
        }
    }

    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
    }
}
