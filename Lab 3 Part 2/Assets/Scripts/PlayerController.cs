using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 12f;
    public float xLimit = 7.5f; 

    private InputSystem_Actions controls;

    void Awake()
    {
        controls = new InputSystem_Actions();
    }

    void OnEnable()
    {
        controls.Player.Enable();
    }

    void OnDisable()
    {
        controls.Player.Disable();
    }


    // Update is called once per frame
    void Update()
    {
        //Read Left/Right arrow keys
        Vector2 moveInput = controls.Player.Move.ReadValue<Vector2>();

        //Move the player
        transform.Translate(Vector3.right * moveInput.x * speed * Time.deltaTime);

        //Clamp position so they can't leave the screen
        Vector3 clampedPos = transform.position;
        clampedPos.x = Mathf.Clamp(clampedPos.x, -xLimit, xLimit);
        transform.position = clampedPos;
    }
}
