using UnityEngine;
using FMODUnity;

// This is a simple example of how to test a parameter of your FMOD event
// This script should be used for testing only and disabled or removed once you have completed your test

// Instructions for use:
// 1. Place this script on the same GameObject as the StudioEventEmitter that you want to update
// 3. Type the name of the parameter that you want to update in the "Parameter Name" field in the Inspector panel
// 3. When you enter Play Mode, the chosen parameter of the StudioEventEmitter will be set to whatever "Parameter Value" is set to. Try changing this value in Play Mode.

public class TestUpdateFMODParameter : MonoBehaviour 
{
	// This line creates a field in the Inspector panel where you can type the name of the parameter you want to update
	public string parameterName;

	// This line creates a field in the Inspector panel where you can set the value of the parameter
	// This number can be edited in Edit Mode or Play Mode for live testing
	public float parameterValue;

	// This code is private - it's just used to keep track of things within the script, and doesn't create a field in the Inspector panel
	private StudioEventEmitter eventEmitter;

	// Awake is called when the GameObject with this script on it first appears in the game
	void Awake ()
	{
		// Set up a reference to the StudioEventEmitter on the same GameObject as this script
		eventEmitter = GetComponent<StudioEventEmitter>();
	}

	// Update is called once per frame
	void Update () 
	{
		// Now pass the data to the StudioEventEmitter, using the parameter name we set in the Inspector panel
		eventEmitter.SetParameter(parameterName, parameterValue);

		Debug.Log("Testing FMOD parameter! Setting parameter " + parameterName + " to " + parameterValue, gameObject);
	}
}