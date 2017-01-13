using UnityEngine;
using FMODUnity;

// This is a simple example of how to update a parameter of your FMOD event using scripting.
// In this example we increase the value of the parameter every time the space bar is pressed.

// Instructions for use:
// 1. Place this script on the same GameObject as the StudioEventEmitter that you want to update
// 2. When you enter Play Mode, the chosen parameter of the StudioEventEmitter will increase each time you press the space bar

public class UpdateEventParameterWithKeyPresses : MonoBehaviour 
{
	// This line creates a field in the Inspector panel where you can type the name of the parameter you want to update
	public string parameterName;

	// This line creates a checkbox in the Inspector panel. If ticked, it will print a message to the console when it updates the parameter.
	public bool showDebugMessage;

	// This code is private - it's just used to keep track of things within the script, and doesn't create a field in the Inspector panel
	private StudioEventEmitter eventEmitter;
	private int numberOfPresses;

	// Awake is called when the GameObject with this script on it first appears in the game
	void Awake ()
	{
		// Set up a reference to the StudioEventEmitter on the same GameObject as this script
		eventEmitter = GetComponent<StudioEventEmitter>();

		// Set our counter to 0
		numberOfPresses = 0;
	}

	// Update is called once per frame
	void Update () 
	{
		// IF the spacebar has just been pressed...
		if(Input.GetKeyDown(KeyCode.Space))
		{
			// If it has, increase our counter by 1
			numberOfPresses += 1;

			// Now pass the data to the StudioEventEmitter, using the parameter name we set in the Inspector panel
			eventEmitter.SetParameter(parameterName, numberOfPresses);

			// If the "show debug message" checkbox is ticked, send a message to the console
			if(showDebugMessage)
			{
				Debug.Log("Setting parameter " + parameterName + " to " + numberOfPresses, gameObject);
			}
		}
	}
}