using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchLight : MonoBehaviour
{
    [Space(15)]
    [Header("--------- Parameters ---------")]
    [SerializeField] float torchDuration = 2f;

    [Space(15)]
    [Header("---- References injection ----")]
    [SerializeField] GameObject spotLight = default;
    //[SerializeField] GameObject cilinder = default;
    [SerializeField] Animator handsAnimations = default;

    [SerializeField] bool TorchIsOn = true;

    [SerializeField] [Range(25f, 150f)] float lightRange = 150f;


    [Tooltip("Default is 300 (5 minutes).")]
    [SerializeField] float torchLifeTime = 300f;
    float lifeTime;

    [ContextMenu("Torch on")]
    public async void TorchOn()
    {
        //cilinder?.SetActive(true);
        lightRange = 150f;
        torchLifeTime = lifeTime;
        spotLight?.SetActive(true);
        handsAnimations?.SetBool("TorchActive", true);
        await Task.Delay((int)(torchDuration * 1000));
        TorchOff();
    }

    [ContextMenu("Torch off")]
    public void TorchOff()
    {
        //cilinder?.SetActive(false);
        spotLight?.SetActive(false);
        handsAnimations?.SetBool("TorchActive", false);
    }

    private void Awake()
    {
        lifeTime = torchLifeTime;

        if (TorchIsOn)
            TorchOn();
        else
            TorchOff();
    }

    private void Update()
    {
        DecreaseTorch();
        LightRange();
    }


    void LightRange()
    {
        spotLight.GetComponent<Light>().spotAngle = lightRange;
    }

    float CalculateRange(float current, float max)
    {
        return (float)(current * 100 / max);
    }

    float lightProtection;

    public float getLightProtection()
    {
        return this.lightProtection;
    }

    void DecreaseTorch()
    {
        if (torchLifeTime > 0f)
            torchLifeTime -= Time.deltaTime;

        if (torchLifeTime <= 0f)
        {
            lightRange = Mathf.Lerp(lightRange, 25f, Time.deltaTime);
            lightProtection = 0f;
            if (lightRange <= 26f)
                TorchOff();
        }
        else if (torchLifeTime <= lifeTime * 0.3)
        {
            lightRange = Mathf.Lerp(lightRange, 65f, Time.deltaTime);
            lightProtection = 4.25f;
        }
        else if (torchLifeTime <= lifeTime * 0.7)
        {
            lightRange = Mathf.Lerp(lightRange, 110f, Time.deltaTime);
            lightProtection = 8.25f;
        }
        else
        {
            lightRange = Mathf.Lerp(lightRange, 150f, Time.deltaTime);
            lightProtection = 14.25f;
        }
    }

}
