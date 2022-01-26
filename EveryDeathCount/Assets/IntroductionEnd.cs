using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class IntroductionEnd : MonoBehaviour, IInteractable
{
    public void OnClickAction(InputAction.CallbackContext context)
    {
        Debug.Log("load trump");
        SceneManager.LoadScene("Trump");
    }
}
