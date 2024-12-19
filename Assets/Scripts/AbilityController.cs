using UnityEngine;

public class AbilityController : MonoBehaviour
{
    public Ability normalShootAbility;  // Referencia a la habilidad de disparo normal
    public Ability burstShootAbility;   // Referencia a la habilidad de disparo en r�faga

    void Update()
    {
        // Usar las habilidades cuando se presionen las teclas correspondientes
        if (normalShootAbility != null)
        {
            normalShootAbility.UseAbility();  // Usar disparo normal
        }

        if (burstShootAbility != null)
        {
            burstShootAbility.UseAbility();  // Usar disparo en r�faga
        }
    }
}