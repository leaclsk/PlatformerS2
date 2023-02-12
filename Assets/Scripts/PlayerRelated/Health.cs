using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] Gradient gradient;
    [SerializeField] Image fill;

    #region Health
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth (int health)
    {
        slider.value = health;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
    #endregion
}

/*  
    Créer Canvas, ajouter image de fond (Bar), ajouter empty de ref (HealthBar), ajouter image de fill (Health).
    Les sets aux mêmes dimensions (Parentage puis Anchor Presets (Stretch/Stretch) sur Bar + Health).
    Ajouter Slider (None; None), Set les valeurs, et référencer l'image Health au Slider.
    Créer script Health (voir ci-dessus) dans HealthBar.
    Ajouter méthode TakeDamage au script du Player (voir script PlayerHealth).
    Set les Anchor Preset de HealthBar là où elle doit se trouver sur l'écran.
 */ 