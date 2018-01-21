using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WorldInteraction : MonoBehaviour {
	NavMeshAgent PlayerAgent;

	// Use this for initialization
	void Start () {
		PlayerAgent = GetComponent<NavMeshAgent>();

	}


	// Update is called once per frame
	void Update () 
	{
		if (Input.GetMouseButtonDown (0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject()) 
		{
			GetInteraction ();	
		}
	}

	void GetInteraction()
	{
		Ray InteractionRay = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit interactionInfo;
		if (Physics.Raycast (InteractionRay, out interactionInfo, Mathf.Infinity)) 
		{
			GameObject interactedObject = interactionInfo.collider.gameObject;
			if (interactedObject.tag == "Interactable Object") {
				Debug.Log ("Interactable Object.");
			} 
			else 
			{
				PlayerAgent.destination = interactionInfo.point;
			}
		}
	}
}
