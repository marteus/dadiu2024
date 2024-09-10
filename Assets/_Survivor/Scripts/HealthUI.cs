using System;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    [SerializeField] Transform _foreground;

    public void SetHealthRatio(float ratio)
    {
        _foreground.localScale = new Vector3(Mathf.Clamp01(ratio), 1, 1);
    }
}
