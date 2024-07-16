# MaiDXR - SinglePlayer
Open Source VR Arcade Simulator

**About this project**
---
- This project is an update of [https://github.com/xiaopeng12138/MaiMai-VR](https://github.com/xiaopeng12138/MaiDXR). 
- Support DX version or above
- The model is almost 1:1 to DX cabinet/framework
- Using native touch input and light outupt
- 90hz or 120hz capture (Bitblt) (Thanks @Thalesalex for the recommendation)
- Customizable haptic feedback
- 3rd person camera and smooth camera
- 3 customizable buttons

**About NightMode fork**
---
- (new) optimize model for performance
- (new) environment - darkroom
- (fix) LIV maimai model not render
- (change) real time ring light to material (more FPS)
- (change) remove 2nd player model and monitor

**About SinglePlayer fork**
---
- Reverted world textures to that of the orginal project
- Added sliders for movement and turn speed
- General bug fixes

**Preview**
---
<img src="https://github.com/jettsd/MaiDXR-sp1/blob/main/PreviewImage/MaiDXR-SP1_PreviewImage.png?raw=true" width="250" />

**Used repository**
---
- [MaiMai-VR](https://github.com/HelloKS/MaiMai-VR)
- [Mai2Touch](https://github.com/Sucareto/Mai2Touch)
- [MrcXrtHelpers](https://github.com/TonyViT/MrcXrtHelpers)
- [uWindowCapture](https://github.com/hecomi/uWindowCapture)
- [uNvEncoder](https://github.com/hecomi/uNvEncoder)
- [uNvPipe](https://github.com/hecomi/uNvPipe)
- [uPacketDivision](https://github.com/hecomi/uPacketDivision)
- [WACVR](https://github.com/xiaopeng12138/WACVR)

**Build requirements**
---
- Current Unity version: 2021.3.8f1

**Supported platform**
---
- All SteamVR device (Index，HTC，Oculus)
- All Oculus device (Oculus Desktop App)
- Tested on Quest 2 through Oculus link (Native and via SteamVR) and ALVR (via SteamVR). The Hand Balls position is by default adjusted for the Quest 2 controller.

**How to use**
---
- Get game somehow and make sure it will run properly. (DO NOT ASK ANYTHING THAT IS DIRECTLY RELATED TO THE GAME IT SELF)
- Download [latest version of MaiDXR](https://github.com/xiaopeng12138/MaiDXR/releases)
- Download and install [com0com](https://storage.googleapis.com/google-code-archive-downloads/v2/code.google.com/powersdr-iq/setup_com0com_W7_x64_signed.exe)
- Configure com0com to bind COM3 and COM5 (it must be these two ports), COM4 and COM6 is optional (bind them will make your startup process faster).
- You must enable the enable buffer option in com0com on both ports of all pairs. Otherwise, your MaiDXR will crash after the logo.
- Disable DummyTouchPanel in mai2.ini.
- If you need button light, pls bind COM21 to COM51 (it must be these two ports)(Do not disable DummyLED!).
- Run the game in window mode by adding [Unity Standalone Player command line arguments](https://docs.unity3d.com/Manual/PlayerCommandLineArguments.html) in xxxxx.bat and make sure there is no black bar. Recommend setting for 1080p or greater display: "xxxxxx.exe -screen-fullscreen 0 -screen-width 585 -screen-height 1050"
- If you want the game to run at 1080p in windows turn your monitor to portrait and in xxxx.bat change the resolution to "-screen-width 1080 -screen-height 1920"
- - Start MaiDXR first then start the game.
- If your touch is not working, try to Enter the test menu and exit it.


**Configuration**
---
The green button on the bottom of the cabinet is lock button. Long press it will disable all unnecessary buttons, controller pointer, and the config panel.

You can adjust all settings in the config panel or via config.json. The changes of config.json will only apply after the MaiDXR reboot. 

If you want to adjust the settings, please take a step back. The controller pointer will automatically be disabled when the controller are too close to the cabinet.

Some configs in config.json are only the index of the dropdown.

You can use the pointer to point the third-person camera and grab it to the position where you want to be.

**Original Readme (credit and more detail)**
---
[readme](https://github.com/AsamiKafune/MaiDXR-NightMode/blob/main/oldreadme.md)

