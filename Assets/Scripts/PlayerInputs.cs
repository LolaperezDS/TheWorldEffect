using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputs : MonoBehaviour
{
	public PlayerController controller;
	[SerializeField] private Animation distortion;
	[SerializeField] private AudioSource sound;

	public float runSpeed = 40f;

	float horizontalMove = 0f;
	bool jump = false;


	[SerializeField] private bool isTimeStopping = false;
	[SerializeField] private bool timeStopped = false;
	[SerializeField] private float temp_time = 2f;
	private float tempOfAnim = 2f;

    private void Start()
    {
		sound = GetComponent<AudioSource>();
	}

    void Update()
	{

		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

		if (Input.GetButtonDown("Jump"))
		{
			jump = true;
		}

		if (Input.GetKeyDown(KeyCode.T))
        {
			if (!isTimeStopping)
            {
				sound.Play();
				distortion.Play();
			}
			isTimeStopping = true;
		}
		TimeStop();
	}

	void FixedUpdate()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
		jump = false;
	}


	private void TimeStop()
    {
		if (temp_time > tempOfAnim)
        {
			temp_time = tempOfAnim;
			isTimeStopping = false;
			timeStopped = false;
		}
		if (temp_time < 0)
		{
			temp_time = 0;
			isTimeStopping = false;
			timeStopped = true;
		}
		if (isTimeStopping)
        {
			if (timeStopped)
            {
				temp_time += Time.deltaTime;
			}
            else
            {
				temp_time -= Time.deltaTime;
			}
		}
		TimeCustom.SetNewMultiplayerOnTime(Mathf.Lerp(0, 1, temp_time / tempOfAnim));
	}
}
