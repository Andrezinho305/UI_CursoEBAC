using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;

public class ButtonScaler : MonoBehaviour, IPointerEnterHandler,IPointerExitHandler //interface com a unity
{
    public float animationDuration = .05f;
    public float finalScale = 1.2f;
    public float startScale = 1f;

    private Vector3 _defaultScale;
    private Tween _currentTween;

    private void Awake()
    {
        _defaultScale = transform.localScale; //usa-se para garantir que a escala está standardizada
        //permite que funcione com icones/objetos com escala maior que 1
    }

    public void OnPointerEnter(PointerEventData eventData) //faz parte da interface, a propria unity escreve (depois de identificar a falta dela)
    {//identifica quando o mouse está em cima do objeto/entra em contato com o objeto
        Debug.Log("Enter");
        //transform.localScale = Vector3.one * 1.2f; //cresce sem animação
        _currentTween = transform.DOScale(_defaultScale * finalScale, animationDuration);
    }

    public void OnPointerExit(PointerEventData eventData)
    {//identifica quando o mouse sai de cima do objeto/perde contato com o objeto
        Debug.Log("Exit");
        _currentTween.Kill(); //para a animação antiga no meio, sem que precise finalizar
        transform.DOScale(_defaultScale * startScale, animationDuration);
    }


}
