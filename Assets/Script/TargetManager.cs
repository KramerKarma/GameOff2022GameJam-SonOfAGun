using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetManager : MonoBehaviour
{
    [SerializeField] List<Transform> enemyTransform = new List<Transform>();
    [SerializeField] Transform spawnPosParent;

    public List<Transform> EnemyTransform{ get { return enemyTransform; } private set { enemyTransform = value; } }
    public void CheckAndRemoveTheNullObject()
    {
        List<int> IndexToDelete = new List<int>();
        for (int i = 0; i < enemyTransform.Count; i++)
        {
            if (enemyTransform[i] == null)
            {
                IndexToDelete.Add(i);
            }
        }
        for (int i = IndexToDelete.Count; i > 0; i--)
        {
            enemyTransform.RemoveAt(IndexToDelete[i - 1]);
        }
    }
    public void AddEnemy(Transform enemyTran)
    {
        enemyTransform.Add(enemyTran);
    }
    public Vector3 FindClosest(Vector3 postion)
    {
        Vector3 nearestEnemy = new Vector3(1f, 0f, 0f);
        float minimumDistance = Mathf.Infinity;
        foreach (Transform tran in enemyTransform)
        {
            if (tran)
            {
                float distance = Vector3.Distance(tran.position, postion);
                if (distance < minimumDistance)
                {
                    minimumDistance = distance;
                    nearestEnemy = tran.position;
                }
            }
        }
        return nearestEnemy;
    }
    public void RotateTheGFX(float angle)
    {
        spawnPosParent.eulerAngles = new Vector3(0, 0, angle);
    }
}
