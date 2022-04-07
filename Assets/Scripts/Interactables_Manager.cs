using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactables_Manager : MonoBehaviour
{
    public enum Interactable_Type
    { nothing, info, pickUp, dialouge }

    public Interactable_Type interType;
    public string infoMessage;
    [Header("Dialouge")]
    [TextArea(3, 10)]
    public string[] sentance;
    public Text infoText;
    public DialougeManager dM;
    [Header("NPC differant dialouge")]
    public GameObject questGiver;
    public GameObject questFinisher;
    public GameObject itemGiver;
    public bool questComplete;
    public bool questInProgress;

    // Start is called before the first frame update
    void Start()
    { infoText = GameObject.Find("infoText").GetComponent<Text>(); }

    public void Nothing()
    { Debug.Log("This Object" + this.gameObject.name + "Has No Type Yet"); }
    public void PickUp()
    { gameObject.SetActive(false); }
    public void InfoMessage()
    { StartCoroutine(ShowInfo(infoMessage, 3f)); infoText.text = infoMessage; }
    public void Dialouge()
    { FindObjectOfType<DialougeManager>().StartDialouge(sentance); GameObject.Find("DialougeUI").SetActive(true);
        if (questInProgress == true)
        { QuestInPorgress(); }
        if (questComplete == true)
        { QuestComplete(); }
    }
    IEnumerator ShowInfo(string message, float delay)
    { infoText.text = message; yield return new WaitForSeconds(delay); infoText.text = null; }
    public void QuestComplete()
    { questGiver.SetActive(false); questFinisher.SetActive(true); itemGiver.SetActive(false); }
    //Turn a sprite off and another on when a certain npc has been talked to
    public void QuestInPorgress()
    { itemGiver.SetActive(true); }

}
