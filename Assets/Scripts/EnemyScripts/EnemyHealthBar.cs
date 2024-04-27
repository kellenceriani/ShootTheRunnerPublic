using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public float MaxHealthBarLength = 1.0f;
    private float MaxEnemyHealth;
    private float CurrentEnemyHealth;
    private float HealthPercentage;
    private float CurrentHealthBarLength;

    private RectTransform rt;
    // Start is called before the first frame update
    void Start()
    {
        rt = GetComponent<RectTransform>();
        MaxEnemyHealth = transform.parent.parent.GetComponent<EnemyStats>().EnemyHealth;
        GetComponent<Image>().color = Color.green;
    }

    public void ChangeHealth(float EnemyHealth)
    {
        CurrentEnemyHealth = EnemyHealth;
        HealthPercentage = CurrentEnemyHealth / MaxEnemyHealth;
        CurrentHealthBarLength = MaxHealthBarLength * HealthPercentage;
        rt.sizeDelta = new Vector2(CurrentHealthBarLength, rt.sizeDelta.y);
        ImageHealthColor();
    }
    private void ImageHealthColor()
    {
        if(CurrentEnemyHealth > 2)
        {
            GetComponent<Image>().color = Color.green;
        }
        else if (CurrentEnemyHealth > 1)
        {
            GetComponent<Image>().color = Color.yellow;
        }
        else
        {
            GetComponent<Image>().color = Color.red; 
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
