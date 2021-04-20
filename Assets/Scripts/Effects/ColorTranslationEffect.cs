using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ColorTranslationEffect : MonoBehaviour
{
    Image img;
    [SerializeField] private float transitionTime;

    private Color currentTarget;
    private Color startingColor;

    void Awake() { 
        img = GetComponent<Image>();
    }
    public void SetStartingColor(Color color) {
        startingColor = color;
        img.color = startingColor;
    }
    public void TranslateToColor(Color targetColor) {
        startingColor = img.color;
        currentTarget = targetColor;
        StopAllCoroutines();
        StartCoroutine(EffectCoroutine(transitionTime));
    }
    private IEnumerator EffectCoroutine(float effectTime) {
        float timer = 0f;
        Vector3 speed = new Vector3(currentTarget.r - startingColor.r, currentTarget.g - startingColor.g, currentTarget.b - startingColor.b) / effectTime;
        float speedAlpha = (currentTarget.a - startingColor.a) / effectTime;
        while(timer < effectTime) {
            Color color = img.color;

            color.r += speed.x * Time.deltaTime;
            color.g += speed.y * Time.deltaTime;
            color.b += speed.z * Time.deltaTime;
            color.a += speedAlpha * Time.deltaTime;

            img.color = color;

            timer += Time.deltaTime;

            yield return null;
        }
        img.color = currentTarget;
    }
}
