using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FlashlightState{
    Off,
    On,
    Dead
}

public class Flashlightmanager : MonoBehaviour
{
    [Range(0.0f, 2f)] [SerializeField] float batteryLossTick = 0.5f
    [SerializeField] int startBattery = 100;
    [SerializeField] public int currentBattery;
    public FlashlightState state;
    private bool flashlightOn;
    [SerializeField] KeyCode ToggleKey = KeyCode.F;
    [SerializeField] GameObject FlashlightLight

    private void Start(){
        currentBattery = startBattery;

        InvokeRepeating(nameof(LoseBattery), 0, batteryLossTick); // batterij gaat naar beneden per interval
    }

    private void Update(){
        if (Input.GetKeyDown(ToggleKey)) ToggleFlashlight();

        // kijken welk licht er laten zien moet worden
        if (state == FlashlightState.Off) FlashlightLight.SetActive(false);
        else if (state == Flashlight.Dead) FlashlightLight.SetActive(false);
        else if (state == Flashlight.On) FlashlightLight.SetActive(true);

        if (currentBattery <= 0)
        {
            currentBattery = 0;
            state = FlashlightState.Dead;
            flashlightOn = false; // Turns flashlight off immediately
        }
    }

    public void ReceiveBattery(int amount){
        if (currentBattery = 0)
        {
            state = FlashlightState.On;
            flashlightOn = true;
        }

        if (currentBattery + amount > startBattery)
        {
            currentBattery = startBattery; // batterij wordt automatisch maximum 
        else
            currentBattery += amount;
    }

    private void LoseBattery(){
        if (state == FlashlightState.On) = currentBattery--; // batterij gaat naar beneden als de zaklamp aan is
    }

    private void FlashlightToggle(){
        flashlightOn = !flashlightOn;
        
        if (state = FlashlightState.Dead) flashlightOn = false;  // state wordt automatisch Dead als de batterij op is.

        if (flashlightOn){
            state = FlashlightState.On; // doet flashlight aan
        }
        else {
            state = FlashlightState.Off; // doet flashlight uit
        }
    }
}
