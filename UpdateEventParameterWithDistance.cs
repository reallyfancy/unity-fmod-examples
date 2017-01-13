using UnityEngine;
using FMODUnity;

// This is a simple example of how to update a parameter of your FMOD event using scripting.
// In this example, we sends the distance between two GameObjects as a parameter to a StudioEventEmitter.

// Instructions for use:
// 1. Place this script on the same GameObject as the StudioEventEmitter that you want to update
// 2. Drag a GameObject into the "Object One" field in the Inspector panel
// 3. Drag a different GameObject into the "Object Two" field in the Inspector panel
// 3. Type the name of the parameter that you want to update in the "Parameter Name" field in the Inspector panel
// 4. When you enter Play Mode, the chosen parameter of the StudioEventEmitter will be set to the distance between the two chosen GameObjects.

public class UpdateEventParameterWithDistance : MonoBehaviour 
{
	// This line creates a field in the Inspector panel where you can drag one of the GameObject that you want to measure the distance between
	public Transform objectOne;						

	// This line creates a field in the Inspector panel where you can drag the other GameObject that you want to measure the distance between
	public Transform objectTwo;						

	// This line creates a field in the Inspector panel where you can type the name of the parameter you want to update
	public string parameterName;

	// This line creates a checkbox in the Inspector panel. If ticked, it will print a message to the console when it updates the parameter.
	public bool showDebugMessage;

	// This code is private - it's just used to keep track of things within the script, and doesn't create a field in the Inspector panel
	private StudioEventEmitter eventEmitter;
	private float previousParameterValue;
	private bool hasParameterEverBeenUpdated;

	// Awake is called when the GameObject with this script on it first appears in the game
	void Awake ()
	{
		// Set up a reference to the StudioEventEmitter on the same GameObject as this script
		eventEmitter = GetComponent<StudioEventEmitter>();
	}

	void Update () 
	{
		// Calculate the distance between the two specified objects
		float newValue = Vector3.Distance(objectOne.position, objectTwo.position);

		// If the parameter has never been updated OR the new parameter value has changed since the last frame...
		if(!hasParameterEverBeenUpdated || newValue != previousParameterValue)
		{
			// Pass the data to the StudioEventEmitter, using the parameter name we set in the Inspector panel
			eventEmitter.SetParameter(parameterName, newValue);

			// If the "show debug message" checkbox is ticked, send a message to the console
			if(showDebugMessage)
			{
				Debug.Log("Setting parameter " + parameterName + " to " + newValue, gameObject);
			}

			// Record that the parameter has ever been updated
			hasParameterEverBeenUpdated = true;
		}

		// Record the parameter value so we can check if it has changed during the next frame
		previousParameterValue = newValue;
	}
}
