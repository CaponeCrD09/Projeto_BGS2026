using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform player;

    [Header("Posição da câmera")]
    public float distancia = 4f;
    public float altura = 1.8f;
    public float offsetOmbro = 0.6f;

    [Header("Mouse")]
    public float sensibilidade = 200f;

    [Header("Suavização")]
    public float suavizacao = 10f;


    float mouseX;
    float mouseY;


    public float limiteCima = 70f;
    public float limiteBaixo = -30f;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


    void LateUpdate()
    {
        // Controle do mouse – use unscaledDeltaTime
        mouseX += Input.GetAxis("Mouse X") * sensibilidade * Time.unscaledDeltaTime;
        mouseY -= Input.GetAxis("Mouse Y") * sensibilidade * Time.unscaledDeltaTime;

        mouseY = Mathf.Clamp(mouseY, limiteBaixo, limiteCima);

        Quaternion rotacao = Quaternion.Euler(mouseY, mouseX, 0);

        Vector3 posicaoDesejada =
            player.position
            + Vector3.up * altura
            + rotacao * new Vector3(offsetOmbro, 0, -distancia);

        // Movimento suave – use unscaledDeltaTime
        transform.position =
            Vector3.Lerp(
                transform.position,
                posicaoDesejada,
                suavizacao * Time.unscaledDeltaTime
            );

        transform.LookAt(player.position + Vector3.up * 1.4f);
    }
}