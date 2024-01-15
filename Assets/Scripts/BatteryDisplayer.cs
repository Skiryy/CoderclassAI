using UnityEngine;
using UnityEngine.UI;
using TMPro; // Dit wordt toegevoegd omdat de text functie van unity zo heet.

public class BatteryUIStatic : MonoBehaviour
{
    [SerializeField] Flashlightmanager flashlightManager;
    [SerializeField] TextMeshProUGUI batteryDisplay;

    void Update()
    {
        if (flashlightManager != null && batteryDisplay != null)
        {
            batteryDisplay.text = "Battery: " + flashlightManager.currentBattery.ToString();
        }
    }
}
