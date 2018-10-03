using UnityEngine;
/// <summary>
/// Selector that succeeds if 'tagged' player is within a 'acceptableDistance' radius.
/// </summary>
public class IsTaggedActorNear : Selector
{
    [SerializeField]
    private float acceptableDistance = 0F;

    protected override bool CheckCondition()
    {
        Collider[] detection;

        GameObject currentChaser;

        detection = Physics.OverlapSphere(transform.position, acceptableDistance);
         
        if(detection != null)
        {
            for (int i = 0; i < detection.Length; i++)
            {
                if(detection[i].GetComponent<ActorController>().IsTagged)
                {
                    currentChaser = detection[i].gameObject;
                    break;
                }
            }
        }

        return base.CheckCondition();
    }
}