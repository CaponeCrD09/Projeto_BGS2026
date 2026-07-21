using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJump : MonoBehaviour
{
    public float jumpForce = 5f;       // Força do pulo
    public float checkRadius = 0.2f;    // Tamanho do raio de checagem do chão
    public Transform groundCheck;       // Objeto vazio colocado nos pés do personagem
    public LayerMask groundLayer;       // Layer definida para o chão (ex: "Ground")

    private Rigidbody rig;
    public bool isGrounded;

    void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // 1. Checa se o personagem está tocando o chão
        if (groundCheck != null)
        {
            isGrounded = Physics.CheckSphere(groundCheck.position, checkRadius, groundLayer);
        }

        // 2. Verifica se o comando de pulo foi acionado (Espaço no Teclado OU Botão de baixo do Controle, ex: A no Xbox / X no PlayStation)
        bool jumpPressed = false;

        if (Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            jumpPressed = true;
        }

        if (Gamepad.current != null && Gamepad.current.buttonSouth.wasPressedThisFrame)
        {
            jumpPressed = true;
        }

        // 3. Executa o pulo se estiver no chão e pressionou o botão
        if (jumpPressed && isGrounded)
        {
            Jump();
        }
    }

    private void Jump()
    {
        // Reseta a velocidade vertical atual para garantir que o pulo tenha sempre a mesma altura
        rig.linearVelocity = new Vector3(rig.linearVelocity.x, 0f, rig.linearVelocity.z);

        // Aplica a força para cima usando o modo de Impulso
        rig.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    // Desenha uma esfera vermelha no editor da Unity para ajudar a posicionar o GroundCheck visualmente
    private void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, checkRadius);
        }
    }
}
