using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPool : MonoBehaviour {
    [SerializeField] private Color[] colors;
    public int Length { get { return colors.Length; } }
    public Color GetColor(int i) {
        return colors[i];
    }

    public Color GetRandomColor() {
        return colors[Random.Range(0, colors.Length)];
    }
}
