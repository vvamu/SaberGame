using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(EnemyVision))]
public class EnemyVisionEditor : Editor
{
    private void OnSceneGUI()
    {
        EnemyVision enemy = (EnemyVision)target;
        Handles.color = Color.red;
        Handles.DrawLine(enemy.transform.position, enemy.transform.position + enemy.transform.forward * enemy.Range);

        Handles.color = Color.white;
        Handles.DrawWireArc(enemy.transform.position, enemy.transform.up, enemy.transform.forward, 360, enemy.Range);
        Handles.DrawWireArc(enemy.transform.position, enemy.transform.right, enemy.transform.up, 360, enemy.Range);

        Handles.color = Color.gray;
        Handles.DrawWireArc(enemy.transform.position, enemy.transform.up, enemy.transform.forward, 360, enemy.RangeApriori);
        Handles.DrawWireArc(enemy.transform.position, enemy.transform.right, enemy.transform.up, 360, enemy.RangeApriori);

        Handles.color = Color.yellow;
        var directionRigth =  Quaternion.AngleAxis(enemy.Angle/2, enemy.transform.up) * enemy.transform.forward * enemy.Range;
        var directionLeft =  Quaternion.AngleAxis(-enemy.Angle/2, enemy.transform.up) * enemy.transform.forward * enemy.Range;

        Handles.DrawLine(enemy.transform.position, enemy.transform.position + directionRigth);
        Handles.DrawLine(enemy.transform.position, enemy.transform.position + directionLeft);

        directionRigth = Quaternion.AngleAxis(enemy.Angle / 2, enemy.transform.right) * enemy.transform.forward * enemy.Range;
        directionLeft = Quaternion.AngleAxis(-enemy.Angle / 2, enemy.transform.right) * enemy.transform.forward * enemy.Range;

        Handles.DrawLine(enemy.transform.position, enemy.transform.position + directionRigth);
        Handles.DrawLine(enemy.transform.position, enemy.transform.position + directionLeft);

    }
}
