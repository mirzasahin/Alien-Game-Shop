using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject settingsMenu;
    public GameObject escText;

    public bool isSettingsMenuOpen = false;

    public CinemachineFreeLook freeLookCamera;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if(!isSettingsMenuOpen)
            {
                LockCamera();
                isSettingsMenuOpen = true;
                settingsMenu.SetActive(true);
                escText.SetActive(false);
            }
            else
            {
                UnlockCamera();
                isSettingsMenuOpen = false;
                settingsMenu.SetActive(false);
                escText.SetActive(true);
            }
        }
    }

    public void LockCamera()
    {
        freeLookCamera.m_XAxis.m_InputAxisName = "";
        freeLookCamera.m_YAxis.m_InputAxisName = "";
        Cursor.lockState = CursorLockMode.None;
    }

    // Kamerayý serbest býrakan fonksiyon
    public void UnlockCamera()
    {
        freeLookCamera.m_XAxis.m_InputAxisName = "Mouse X";
        freeLookCamera.m_YAxis.m_InputAxisName = "Mouse Y";
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void ResumeGame(int value = 1)
    {
        Time.timeScale = value;
    }
}
