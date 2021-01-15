using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchLight : MonoBehaviour
{

    [Space(15)]
    [Header("---- References injection ----")]
    [SerializeField] GameObject spotLight = default;
    [SerializeField] GameObject cilinder = default;
    [SerializeField] Animator handsAnimations = default;

    private void Awake()
    {
        TorchOff();
    }

    [ContextMenu("Torch on")]
    public void TorchOn()
    {
        spotLight?.SetActive(true);
        cilinder?.SetActive(true);
        handsAnimations?.SetBool("TorchActive", true);
    }

    [ContextMenu("Torch off")]
    public void TorchOff()
    {
        spotLight?.SetActive(false);
        cilinder?.SetActive(false);
        handsAnimations?.SetBool("TorchActive", false);
    }

}
