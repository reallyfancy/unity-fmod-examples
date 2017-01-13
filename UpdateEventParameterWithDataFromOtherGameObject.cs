using UnityEngine;
using FMODUnity;

// This is a simple example of how to update a parameter of your FMOD event using scripting.
// In this example, we set the value of a parameter to the current world y position of another GameObject.

// Instructions for use:
// 1. Place this script on the same GameObject as the StudioEventEmitter that you want to update
// 2. Drag a GameObject into the "other" field in the Inspector panel
// 3. Type the name of the parameter that you want to update in the "parameter name" field in the Inspector panel
// 4. When you enter Play Mode, the chosen parameter of the StudioEventEmitter will be set to the chosen GameObject's world y position. Try changing the GameObject's world y position to see what happens.

public class UpdateEventParameterWithDataFromOtherGameObject : MonoBehaviour 
{
	// This line creates a field in the Inspector panel where you can drag the GameObject that you want to get your data from
	public GameObject other;	

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

	// Update is called once per frame
	void Update ()
	{
		// Get the data we want from the other GameObject - in this example, its current y position in the world
		float newValue = other.transform.position.y;

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