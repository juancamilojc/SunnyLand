using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FireLightFX : MonoBehaviour {
    private Light2D fireLight;
    [SerializeField] private float intensity = 1.0f;
    [SerializeField] private float randomIntensityRange = 0.25f;
    [SerializeField] private float speed = 0.5f;
    private float originalIntensity;
    private float randomOffset;

    void Start() {
        fireLight = GetComponent<Light2D>();
        originalIntensity = fireLight.intensity;
        randomOffset = Random.Range(0f, 1f);
    }

    void Update() {
        FireFX();
    }

    private void FireFX() {
        float randomIntensity = Random.Range(-randomIntensityRange, randomIntensityRange);
        float ocillation = Mathf.Sin((Time.time + randomOffset) * speed);
        float newIntensity = originalIntensity + ocillation * intensity * randomIntensity;

        fireLight.intensity = Mathf.Max(0, newIntensity);
    }
}
