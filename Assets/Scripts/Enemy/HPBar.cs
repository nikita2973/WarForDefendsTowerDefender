using UnityEngine;

public class HPBar : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void ChangeHpBar(int gHp,int gMaxHp)
    {
        float scaleX = (float)gHp / (float)(gMaxHp*2);
    
       transform.localScale = new Vector3(scaleX, transform.localScale.y,transform.localScale.z);
  
    }
}
