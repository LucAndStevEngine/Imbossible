using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayer : MonoBehaviour
{
    public Ability ability;

    public float speed = 10.0f;

	// Use this for initialization
	void Start ()
    {
  		
	}

    void Awake()
    {
        ability.Init();
    }

    // Update is called once per frame
    void Update ()
    {
        float xDirection = Input.GetAxis("Horizontal");
        float yDirection = Input.GetAxis("Vertical");

        MoveCharacter(new Vector2(xDirection, yDirection));


        float xLookDirection = Input.GetAxis("RightHorizontal");
        float yLookDirection = Input.GetAxis("RightVertical");
        Debug.Log(xLookDirection);
        Debug.Log(yLookDirection);

        RotateDirection(new Vector2(xLookDirection, yLookDirection));

        if(Input.GetKeyDown(KeyCode.A))
        {
            ability.UseAbility();
        }

        ability.UpdateAbility();
    }

    void MoveCharacter(Vector2 direction)
    {
        transform.position += new Vector3(direction.x, 0, direction.y) * speed * Time.deltaTime;
    }

    void RotateDirection(Vector2 direction)
    {
        transform.eulerAngles = new Vector3(0, Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg + 90, 0);

    }
}
