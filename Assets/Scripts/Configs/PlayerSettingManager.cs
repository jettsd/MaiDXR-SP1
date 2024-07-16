using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using UnityEngine.XR.Interaction.Toolkit;

public class PlayerSettingManager : MonoBehaviour
{
    private Transform LHandTransform = null;
    private Transform RHandTransform = null;
    private Transform PlayerTransform = null;
    private ControllerHapticManager[] HapticManagers = null;
    private ActionBasedContinuousMoveProvider MoveProvider;
    private ActionBasedContinuousTurnProvider TurnProvider;


    public ValueManager PlayerHeightManager;
    public float HandSize = 8;
    public float HandPositionX = 0;
    public float HandPositionY = 0;
    public float HandPositionZ = 0;
    public float MovementSpeed = 0;
    public float TurnSpeed = 0;
    public List<Slider> Sliders;
    public Locker Locker;
    public NoneVRSettingManager NVRManager;
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
        HapticManagers = XRObj.GetComponentsInChildren<ControllerHapticManager>();
        MoveProvider = XRObj.GetComponent<ActionBasedContinuousMoveProvider>();
        TurnProvider = XRObj.GetComponent<ActionBasedContinuousTurnProvider>();
        Locker.LocalMotion = XRObj;
        NVRManager.NVRCameraTargetFP = XRObj.transform.Find("Camera Offset").Find("Main Camera");
        NVRManager.GetNVRMode();
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
        GetMovementSpeed();
        GetTurnSpeed();

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
                case "MovementSpeed":
                    slider.value = MovementSpeed;
                    break;
                case "TurnSpeed":
                    slider.value = TurnSpeed;
                    break;
            }
        }
    }
    private void GetPlayerHeight()
    {
        if (PlayerConfig.HasKey("PlayerHeight"))
            PlayerHeightManager.Value = (float)PlayerConfig.GetDouble("PlayerHeight");
        SetPlayerHeight();
    }
    private void GetHandSize()
    {
        if (PlayerConfig.HasKey("HandSize"))
            HandSize = (float)PlayerConfig.GetDouble("HandSize");
        SetHandSize(HandSize);
    }
    private void GetHandPositionX()
    {
        if (PlayerConfig.HasKey("HandPositionX"))
            HandPositionX = (float)PlayerConfig.GetDouble("HandPositionX");
        SetHandPositionX(HandPositionX);
    }
    private void GetHandPositionY()
    {
        if (PlayerConfig.HasKey("HandPositionY"))
            HandPositionY = (float)PlayerConfig.GetDouble("HandPositionY");
        SetHandPositionY(HandPositionY);
    }
    private void GetHandPositionZ()
    {
        if (PlayerConfig.HasKey("HandPositionZ"))
            HandPositionZ = (float)PlayerConfig.GetDouble("HandPositionZ");
        SetHandPositionZ(HandPositionZ);
    }
    void GetHapticDuration()
    {
        if (PlayerConfig.HasKey("HapticDuration"))
            HapticManagers[0].duration = (float)PlayerConfig.GetDouble("HapticDuration");
        SetHapticDuration(HapticManagers[0].duration);
    }
    void GetHapticAmplitude()
    {
        if (PlayerConfig.HasKey("HapticAmplitude"))
            HapticManagers[0].amplitude = (float)PlayerConfig.GetDouble("HapticAmplitude");
        SetHapticAmplitude(HapticManagers[0].amplitude);
    }
    void GetMovementSpeed()
    {
        if (PlayerConfig.HasKey("MovementSpeed"))
            MovementSpeed = (float)PlayerConfig.GetDouble("MovementSpeed");
        SetMovementSpeed(MovementSpeed);
    }
    void GetTurnSpeed()
    {
        if (PlayerConfig.HasKey("TurnSpeed"))
            TurnSpeed = (float)PlayerConfig.GetDouble("TurnSpeed");
        SetTurnSpeed(TurnSpeed);
    }

    public void SetPlayerHeight()
    {
        PlayerTransform.position = new Vector3(PlayerTransform.position.x, PlayerHeightManager.Value, PlayerTransform.position.z);
        PlayerConfig.SetDouble("PlayerHeight", PlayerHeightManager.Value);
    }
    public void SetHandSize(float value)
    {
        PlayerConfig.SetDouble("HandSize", value);
        value = value / 100;
        LHandTransform.localScale = new Vector3(value, value, value);
        RHandTransform.localScale = new Vector3(value, value, value);
    }
    public void SetHandPositionX(float value)
    {
        PlayerConfig.SetDouble("HandPositionX", value);
        value = value / 100;
        LHandTransform.localPosition = new Vector3(value, LHandTransform.localPosition.y, LHandTransform.localPosition.z);
        RHandTransform.localPosition = new Vector3(-value, RHandTransform.localPosition.y, RHandTransform.localPosition.z);
    }
    public void SetHandPositionY(float value)
    {
        PlayerConfig.SetDouble("HandPositionY", value);
        value = value / 100;
        LHandTransform.localPosition = new Vector3(LHandTransform.localPosition.x, value, LHandTransform.localPosition.z);
        RHandTransform.localPosition = new Vector3(RHandTransform.localPosition.x, value, RHandTransform.localPosition.z);
    }
    public void SetHandPositionZ(float value)
    {
        PlayerConfig.SetDouble("HandPositionZ", value);
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
        PlayerConfig.SetDouble("HapticDuration", duration);
    }
    public void SetHapticAmplitude(float amplitude)
    {
        foreach (var controller in HapticManagers)
        {
            controller.amplitude = amplitude;
        }
        PlayerConfig.SetDouble("HapticAmplitude", amplitude);
    }
    public void SetMovementSpeed(float movementSpeed)
    {
        MoveProvider.moveSpeed = movementSpeed;
        PlayerConfig.SetDouble("MovementSpeed", movementSpeed);
    }
    public void SetTurnSpeed(float turnSpeed)
    {
        TurnProvider.turnSpeed = turnSpeed;
        PlayerConfig.SetDouble("TurnSpeed", turnSpeed);
    }
    private static class PlayerConfig
    {
        static JObject playerConfig;
        public static bool hasInitialized = false;
        private static void ensureInitialization() {
            if (hasInitialized) 
                return;
            GetPlayerConfig();
            hasInitialized = true;
        }
        public static bool HasKey(string key) {
            ensureInitialization();
            return playerConfig.ContainsKey(key);
        }
        public static void SetDouble(string key, double number) {
            ensureInitialization();
            playerConfig[key] = number;
            SetPlayerConfig();
        }
        public static double GetDouble(string key) {
            ensureInitialization();
            return playerConfig.Value<double>(key);
        }

        public static void SetPlayerConfig() {
            JsonConfig.SetJObject("PlayerConfig", playerConfig);
        }
        public static void GetPlayerConfig() {
            if (JsonConfig.HasKey("PlayerConfig"))
                playerConfig = JsonConfig.GetJObject("PlayerConfig");
            else
                playerConfig = new JObject();
        }
    }
}
