using UnityEngine;

public class FPCamera : MonoBehaviour
{
    public float sens = 100f;
    public Transform player;
    private float xRotation = 0f;
    private bool currentlypaused = false;
    [SerializeField] private GameObject Paused;
    [SerializeField] private GameObject unPaused;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sens * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sens * Time.deltaTime;

        
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); 
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        player.Rotate(Vector3.up * mouseX);
        if (Input.GetKeyDown(KeyCode.Escape)) { Pausetoggle(); }
    }

    private void Pausetoggle()
    {
        if (currentlypaused) 
        {
            Cursor.lockState = CursorLockMode.Locked;
            Paused.SetActive(false);
            unPaused.SetActive(true);
            currentlypaused = false;
            Time.timeScale = 1;
            
        }
        else 
        {
            Cursor.lockState = CursorLockMode.None;
            Paused.SetActive(true);
            unPaused.SetActive(false);
            currentlypaused = true;
            Time.timeScale = 0;
        }
        
    }
}
