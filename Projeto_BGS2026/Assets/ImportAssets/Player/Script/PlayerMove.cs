using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    public float speed;
    public float rotationSpeed = 10f;
    public float h;
    public float v;
    public Rigidbody rig;
    public Vector3 mover;


    public Transform cameraTransform;

    void Start()
    {
        rig = GetComponent<Rigidbody>();

        if (cameraTransform == null && Camera.main != null)
        {
            cameraTransform = Camera.main.transform;
        }
    }

    void Update()
    {
        h = 0;
        v = 0;

        // 1. Verifica inputs do Teclado
        if (Keyboard.current != null)
        {
            if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed) v = 1f;
            if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed) v = -1f;
            if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed) h = -1f;
            if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed) h = 1f;
        }

        // 2. Verifica inputs do Controle (Gamepad) e prioriza se houver movimento no analógico
        if (Gamepad.current != null)
        {
            Vector2 stickInput = Gamepad.current.leftStick.ReadValue();

            // Só substitui os valores se o analógico estiver saindo da "zona morta"
            if (stickInput.magnitude > 0.1f)
            {
                h = stickInput.x;
                v = stickInput.y;
            }
        }

        Move();
    }

    public void Move()
    {
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        Vector3 moveDirection = (forward * v) + (right * h);

        // Limita a magnitude máxima para evitar andar mais rápido na diagonal com teclado
        if (moveDirection.magnitude > 1f)
        {
            moveDirection.Normalize();
        }

        mover = new Vector3(moveDirection.x * speed, rig.linearVelocity.y, moveDirection.z * speed);
        rig.linearVelocity = mover;

        if (moveDirection.magnitude > 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
