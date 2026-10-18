using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 12f;


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

        //Move the player left and right
        transform.Translate(Vector3.right * moveInput.x * speed * Time.deltaTime);

        //Calculate the exact screen edge based on the camera
        float screenEdge = Camera.main.orthographicSize * Camera.main.aspect;

        // Clamp to the screen edge
        Vector3 clampedPos = transform.position;
        clampedPos.x = Mathf.Clamp(clampedPos.x, -screenEdge, screenEdge);
        transform.position = clampedPos;
    }
}
