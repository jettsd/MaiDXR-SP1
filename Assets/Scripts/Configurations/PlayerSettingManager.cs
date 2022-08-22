using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;

public class PlayerSettingManager : MonoBehaviour
{
    private Transform LHandTransform = null;
    private Transform RHandTransform = null;
    private Transform PlayerTransform = null;
    private ControllerHapticManager[] HapticManagers = null;

    public ValueManager PlayerHeightManager;
    public float HandSize = 8;
    public float HandPositionX = 0;
    public float HandPositionY = 0;
    public float HandPositionZ = 0;
    public List<Slider> Sliders;
    
    void Start()
    {
        SetTarget(gameObject);
        SetSliders();
    }
    public void SetTarget(GameObject XRObj)
    {
        LHandTransform = XRObj.transform.Find("Camera Offset").Find("LeftHand Controller").Find("LHand");
        RHandTransform = XRObj.transform.Find("Camera Offset").Find("RightHand Controller").Find("RHand");
        PlayerTransform = XRObj.transform;
        HapticManagers = GetComponentsInChildren<ControllerHapticManager>();
        GetSetConfigs();
    }
    private void GetSetConfigs()
    {
        GetPlayerHeight();
        GetHandSize();
        GetHandPositionX();
        GetHandPositionY();
        GetHandPositionZ();
        GetHapticDuration();
        GetHapticAmplitude();
    }
    private void SetSliders()
    {
        foreach (Slider slider in Sliders)
        {
            switch (slider.gameObject.name)
            {
                case "HandS":
                    slider.value = HandSize;
                    break;
                case "HandX":
                    slider.value = HandPositionX;
                    break;
                case "HandY":
                    slider.value = HandPositionY;
                    break;
                case "HandZ":
                    slider.value = HandPositionZ;
                    break;
                case "HpDuration":
                    slider.value = HapticManagers[0].duration;
                    break;
                case "HpAmplitude":
                    slider.value = HapticManagers[0].amplitude;
                    break;
            }
        }
    }
    private void GetPlayerHeight()
    {
        if (JsonConfig.HasKey("PlayerHeight"))
            PlayerHeightManager.Value = (float)JsonConfig.GetDouble("PlayerHeight");
        SetPlayerHeight();
    }
    private void GetHandSize()
    {
        if (JsonConfig.HasKey("HandSize"))
            HandSize = (float)JsonConfig.GetDouble("HandSize");
        SetHandSize(HandSize);
    }
    private void GetHandPositionX()
    {
        if (JsonConfig.HasKey("HandPositionX"))
            HandPositionX = (float)JsonConfig.GetDouble("HandPositionX");
        SetHandPositionX(HandPositionX);
    }
    private void GetHandPositionY()
    {
        if (JsonConfig.HasKey("HandPositionY"))
            HandPositionY = (float)JsonConfig.GetDouble("HandPositionY");
        SetHandPositionY(HandPositionY);
    }
    private void GetHandPositionZ()
    {
        if (JsonConfig.HasKey("HandPositionZ"))
            HandPositionZ = (float)JsonConfig.GetDouble("HandPositionZ");
        SetHandPositionZ(HandPositionZ);
    }
    void GetHapticDuration()
    {
        if (JsonConfig.HasKey("HapticDuration"))
            HapticManagers[0].duration = (float)JsonConfig.GetDouble("HapticDuration");
        SetHapticDuration(HapticManagers[0].duration);
    }
    void GetHapticAmplitude()
    {
        if (JsonConfig.HasKey("HapticAmplitude"))
            HapticManagers[0].amplitude = (float)JsonConfig.GetDouble("HapticAmplitude") * 10;
        SetHapticAmplitude(HapticManagers[0].amplitude);
    }

    public void SetPlayerHeight()
    {
        PlayerTransform.position = new Vector3(PlayerTransform.position.x, PlayerHeightManager.Value, PlayerTransform.position.z);
        JsonConfig.SetDouble("PlayerHeight", PlayerHeightManager.Value);
    }
    public void SetHandSize(float value)
    {
        JsonConfig.SetDouble("HandSize", value);
        value = value / 100;
        LHandTransform.localScale = new Vector3(value, value, value);
        RHandTransform.localScale = new Vector3(value, value, value);
    }
    public void SetHandPositionX(float value)
    {
        JsonConfig.SetDouble("HandPositionX", value);
        value = value / 100;
        LHandTransform.localPosition = new Vector3(value, LHandTransform.localPosition.y, LHandTransform.localPosition.z);
        RHandTransform.localPosition = new Vector3(-value, RHandTransform.localPosition.y, RHandTransform.localPosition.z);
    }
    public void SetHandPositionY(float value)
    {
        JsonConfig.SetDouble("HandPositionY", value);
        value = value / 100;
        LHandTransform.localPosition = new Vector3(LHandTransform.localPosition.x, value, LHandTransform.localPosition.z);
        RHandTransform.localPosition = new Vector3(RHandTransform.localPosition.x, value, RHandTransform.localPosition.z);
    }
    public void SetHandPositionZ(float value)
    {
        JsonConfig.SetDouble("HandPositionZ", value);
        value = value / 100;
        LHandTransform.localPosition = new Vector3(LHandTransform.localPosition.x, LHandTransform.localPosition.y, value);
        RHandTransform.localPosition = new Vector3(RHandTransform.localPosition.x, RHandTransform.localPosition.y, value);
    }
    public void SetHapticDuration(float duration)
    {
        foreach (var controller in HapticManagers)
        {
            controller.duration = duration;
        }
        JsonConfig.SetDouble("HapticDuration", duration);
    }
    public void SetHapticAmplitude(float amplitude)
    {
        amplitude /= 10;
        foreach (var controller in HapticManagers)
        {
            controller.amplitude = amplitude;
        }
        JsonConfig.SetDouble("HapticAmplitude", amplitude);
    }
}
