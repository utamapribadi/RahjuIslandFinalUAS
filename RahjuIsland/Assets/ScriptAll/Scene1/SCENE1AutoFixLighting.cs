using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCENE1AutoFixLighting : MonoBehaviour {
	public bool Already = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		#if UNITY_EDITOR
		if (UnityEditor.Lightmapping.giWorkflowMode == UnityEditor.Lightmapping.GIWorkflowMode.Iterative && Already == false) {
			DynamicGI.UpdateEnvironment ();

			Already = true;
		}
		#endif
	}
		
}
