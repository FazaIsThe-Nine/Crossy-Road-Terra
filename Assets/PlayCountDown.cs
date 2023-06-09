using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;
public class PlayCountDown : MonoBehaviour
{
    [SerializeField] TMPro.TMP_Text tmpText;
    [SerializeField] AudioClip countdown;
    public UnityEvent OnStart;
    public UnityEvent OnEnd;

    private void Start() {
        OnStart.Invoke();
        var sequence = DOTween.Sequence();
        tmpText.transform.localScale = Vector3.zero;
        tmpText.text = "3";
        
        sequence.Append(tmpText.transform.DOScale(
            Vector3.one, 1).OnComplete( () => 
            {
                tmpText.transform.localScale = Vector3.zero;
                tmpText.text = "2";
            }));

        sequence.Append(tmpText.transform.DOScale(
            Vector3.one, 1).OnComplete( () => 
            {
                tmpText.transform.localScale = Vector3.zero;
                tmpText.text = "1";
                AudioManager.Instance.PlaySFX(countdown);
            }));
        sequence.Append(tmpText.transform.DOScale(
            Vector3.one, 1).OnComplete( () => 
            {
                tmpText.transform.localScale = Vector3.zero;
                tmpText.text = "Go!";
                OnEnd.Invoke();
            }));

    }
    
}
