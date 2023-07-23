using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBallViewControl : MonoBehaviour
{

    public MeshRenderer renderer;
    private MaterialPropertyBlock _propertyBlock;

    private Tweener _scaleTween;


    public void SetColor(Color color)
    {
        if(_propertyBlock == null)
            _propertyBlock = new MaterialPropertyBlock();

        renderer.GetPropertyBlock(_propertyBlock);
        _propertyBlock.SetColor("_Color", color);
        renderer.SetPropertyBlock(_propertyBlock);
    }

    public void MoveEndScaleAnimation(GridVector direction, float mag, float duration)
    {
        if (_scaleTween.IsActive())
            _scaleTween.Complete();
        Vector3 directionWorld = Tools.ConvertGridToWord(direction);
        _scaleTween = transform.DOPunchScale(-directionWorld * mag, duration, 5);
    }

    public void InitScaleAnim(float mag, float duration)
    {
       transform.localScale = Vector3.one * mag;
       transform.DOScale(1, duration);
    }

    public void SetActive(bool isActive, float mag, float duration)
    {
        gameObject.SetActive(isActive);
        if (isActive)
        {
            InitScaleAnim(mag, duration);

        }
    }
}
