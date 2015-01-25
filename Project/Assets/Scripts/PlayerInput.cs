using UnityEngine;
using XInputDotNetPure; // Required in C#

public class PlayerInput : MonoBehaviour
{
   // bool playerIndexSet = false;
    public PlayerIndex playerIndex;
    GamePadState state;
    GamePadState prevState;

	public bool GetPlayerInputAxis(string axis)
	{
		if (state.IsConnected) 
		{
			if ("Fire1" == axis) {
					return state.Buttons.A == ButtonState.Pressed;
			} else if ("Fire2" == axis) {
					return state.Buttons.B == ButtonState.Pressed;
			} else if ("Fire3" == axis) {
					return state.Buttons.X == ButtonState.Pressed;
			} else if ("Fire4" == axis) {
					return state.Buttons.Y == ButtonState.Pressed;
			}
		} 
		else
		{
		}

		return false;
	}

	public float GetPlayerInputAxisValue(string axis)
	{
		if ( state.IsConnected )
		{
			if ("Vertical" == axis) 
			{
				return state.ThumbSticks.Left.Y;
			} 
			else if ("Horizontal" == axis) 
			{
				return state.ThumbSticks.Left.X;
			}
		} 
		else
		{
		}

		return 0.0f;
	}

    // Use this for initialization
    void Start()
    {
        // No need to initialize anything for the plugin
    }

	private GamePadState getState()
	{
		return state;
	}

    // Update is called once per frame
    void Update()
    {
        prevState = state;
        state = GamePad.GetState(playerIndex);
    }


}
