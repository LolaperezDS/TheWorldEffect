using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputs : MonoBehaviour
{
	public PlayerController controller;
	[SerializeField] private Animation distortion;
	[SerializeField] private AudioSource sound;

	[SerializeField] private GameObject projectilePrefab;

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

		if (Input.GetKeyDown(KeyCode.F) && !isTimeStopping && !timeStopped)
        {
			Fire();
        }
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

	private void Fire()
    {
		Vector3 screenparams = new Vector3(1920, 1080, 0);
		GameObject temp_projectile;
		for (int i = 0; i < 10; i++)
        {
			Vector3 randomOtkl = new Vector3(Random.Range(-0.2f, 0.2f), Random.Range(-0.2f, 0.2f), 0);
			temp_projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
			temp_projectile.GetComponent<projectileScript>().SetUp(((Input.mousePosition - screenparams / 2).normalized + randomOtkl), 10);
		}
    }
}
