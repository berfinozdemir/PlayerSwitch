using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Stashable : MonoBehaviour
{
    //burada sýkýntý cýkabilir
    public void CollectStashable(Transform stashParent, float yLocalPosition, Vector3 target, Action OnCompleteCollect) 
    {
        var targetPos = stashParent.position + Vector3.up * yLocalPosition;
        transform.parent = stashParent;
        transform.DOLocalJump(target, 1, 1, 1).SetSpeedBased(true).OnComplete(() => {
            transform.localRotation = Quaternion.identity;

            OnCompleteCollect?.Invoke();
        });
        //Tweener tweener = transform.DOMove(targetPos, speed).SetSpeedBased(true);
        //tweener.OnUpdate(delegate () {
        //    // if the tween isn't close enough to the target, set the end position to the target again
        //    if (Vector3.Distance(transform.position, targetPos) > completionRadius)
        //    {
        //        targetPos = stashParent.position + Vector3.up * yLocalPosition;
        //        tweener.ChangeEndValue(targetPos, true);
        //    }

        //}).OnComplete(() => {
        //    transform.parent = stashParent;
        //    transform.localPosition = Vector3.up * yLocalPosition;
        //    transform.localRotation = Quaternion.identity;
        //    OnCompleteCollect?.Invoke();
        //});
    }
    public void PayStashable(Transform target, Action OnCompletePay) 
    {
        transform.parent = null;

        Vector3 targetPos = target.position;
        Vector3 direction = targetPos - transform.position;
        direction.y = 0;

        var middlePos = transform.position + direction / 2f;
        middlePos.y = transform.position.y + 2f;
        var duration = 0.3f;

        transform.DOPath(new Vector3[] { middlePos, targetPos }, duration, PathType.CatmullRom)
                    .OnComplete(() =>
                    {
                        OnCompletePay?.Invoke();
                        Destroy(gameObject);
                    });

    }

    
}
