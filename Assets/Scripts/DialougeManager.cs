using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialougeManager : MonoBehaviour
{
    public GameObject dialougeUI;
    public Text dialougeText;
    public GameObject Player;
    public Animator animator;
    public Queue<string> sentances;
    // Start is called before the first frame update
    public void Start()
    { sentances = new Queue<string>(); }
    public void StartDialouge(string[] sentance)
    {
        sentances.Clear(); dialougeUI.SetActive(true);
        Player.GetComponent<Player_Controller>().enabled = false; Player.GetComponent<PlayerInteractions>().enabled = false;
        animator.SetFloat("Speed", 0); Player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        foreach (string currentLine in sentance)
        { sentances.Enqueue(currentLine); }
        DisplayNextLine();
    }
    public void DisplayNextLine()
    {
        if (sentances.Count == 0) { EndDialouge(); return; }
        string currentLine = sentances.Dequeue(); dialougeText.text = currentLine;
    }
    public void EndDialouge()
    { dialougeUI.SetActive(false); Player.GetComponent<Player_Controller>().enabled = true; Player.GetComponent<PlayerInteractions>().enabled = true; }
}
