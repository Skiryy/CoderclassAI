using UnityEngine;

public class Batterymanager : MonoBehaviour
{
    [SerializeField] KeyCode CollectKey = KeyCode.E;
    [SerializeField] GameObject[] HoverObject;
    private bool mouseHover = false;

    void Start()
    {
        // Zorgt ervoor dat alle batterijen hun normale textuur hebben.
        foreach (GameObject obj in HoverObject)
        {
            obj.SetActive(false);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(CollectKey) && mouseHover)
        {
            FindObjectOfType<Flashlightmanager>().ReceiveBattery(100);
            Destroy(gameObject);
        }
    }

    private void OnMouseEnter()
    {
        mouseHover = true;

        foreach (GameObject obj in HoverObject)
        {
            obj.SetActive(true); // Laat hover zien
        }
    }

    private void OnMouseExit()
    {
        mouseHover = false;

        foreach (GameObject obj in HoverObject)
        {
            obj.SetActive(false); // Verberg hover
        }
    }
}
