using UnityEngine;

public class CamAtirar : MonoBehaviour
{
    public Camera cameraPlayer;
    public GameObject projetil;
    public Transform pontoDisparo;

    void Start()
    {
        // Esconde e trava o cursor no centro da tela
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Atirar();
        }

        if (Input.GetMouseButton(1))
        {
            Time.timeScale = 0.2f;
            Time.fixedDeltaTime = 0.02f * Time.timeScale;
        }
        else
        {
            Time.timeScale = 1f;
            Time.fixedDeltaTime = 0.02f;
        }
    }

    public void Atirar()
    {
        Instantiate(
            projetil,
            pontoDisparo.position,
            Quaternion.LookRotation(cameraPlayer.transform.forward)
        );
    }
}