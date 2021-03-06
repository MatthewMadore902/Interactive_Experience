using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
	public GameObject currentInterObj = null;
	public Interactables_Manager currentInteractObjScript = null;
	[Header("Win and Last Step")]
	public int winCount;
	public GameObject winText;
	public GameObject lastStep;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space) && currentInterObj == true)
		{ Checkinteraction(); }
		if (winCount == 5)
		{ lastStep.SetActive(true); }
		if (winCount == 6)
		{ lastStep.SetActive(false);  winText.SetActive(true); }
	}
	void Checkinteraction()
	{
		Debug.Log("This is a " + currentInterObj.name);

		if (currentInteractObjScript.interType == Interactables_Manager.Interactable_Type.nothing)
		{ currentInteractObjScript.Nothing(); }

		else if (currentInteractObjScript.interType == Interactables_Manager.Interactable_Type.info)
		{ currentInteractObjScript.InfoMessage(); }

		else if (currentInteractObjScript.interType == Interactables_Manager.Interactable_Type.pickUp)
		{ currentInteractObjScript.PickUp(); winCount++; }

		else if (currentInteractObjScript.interType == Interactables_Manager.Interactable_Type.dialouge)
		{ currentInteractObjScript.Dialouge(); }
	}
	private void OnTriggerStay2D(Collider2D other)
	{
		if (other.CompareTag("InterObject") == true)
		{ currentInterObj = other.gameObject; currentInteractObjScript = currentInterObj.GetComponent<Interactables_Manager>(); }
	}
	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.CompareTag("InterObject") == true)
		{
			currentInterObj = null;
			currentInteractObjScript = null;
		}
	}
}
