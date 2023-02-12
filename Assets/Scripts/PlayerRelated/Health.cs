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
    Cr�er Canvas, ajouter image de fond (Bar), ajouter empty de ref (HealthBar), ajouter image de fill (Health).
    Les sets aux m�mes dimensions (Parentage puis Anchor Presets (Stretch/Stretch) sur Bar + Health).
    Ajouter Slider (None; None), Set les valeurs, et r�f�rencer l'image Health au Slider.
    Cr�er script Health (voir ci-dessus) dans HealthBar.
    Ajouter m�thode TakeDamage au script du Player (voir script PlayerHealth).
    Set les Anchor Preset de HealthBar l� o� elle doit se trouver sur l'�cran.
 */ 