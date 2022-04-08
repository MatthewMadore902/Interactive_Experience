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
    public int winCount;
    public GameObject winText;
    [Header("Dialouge")]
    [TextArea(3, 10)]
    public string[] sentance;
    public Text infoText;
    public DialougeManager dM;
    [Header("NPC differant dialouge")]
    public GameObject npcBeforeGottenItem;
    public GameObject npcAfterItem;
    public GameObject itemNeeded;
    public bool questStarted;
    public bool itemGotten;



    // Start is called before the first frame update
    void Start()
    { infoText = GameObject.Find("infoText").GetComponent<Text>(); }

    public void Nothing()
    { Debug.Log("This Object" + this.gameObject.name + "Has No Type Yet"); }
    public void PickUp()
    { gameObject.SetActive(false); itemGotten = true;
        winCount++;
        if (winCount == 5)
        { winText.SetActive(true); }
        if (itemGotten == true)
        { npcBeforeGottenItem.SetActive(false); npcAfterItem.SetActive(true); }
    }
    public void InfoMessage()
    { StartCoroutine(ShowInfo(infoMessage, 3f)); infoText.text = infoMessage; }
    public void Dialouge()
    { FindObjectOfType<DialougeManager>().StartDialouge(sentance); GameObject.Find("DialougeUI").SetActive(true);
        QuestStarted();
    }
    IEnumerator ShowInfo(string message, float delay)
    { infoText.text = message; yield return new WaitForSeconds(delay); infoText.text = null; }
    public void QuestStarted()
    { questStarted = true; itemNeeded.SetActive(true);
    }



}
