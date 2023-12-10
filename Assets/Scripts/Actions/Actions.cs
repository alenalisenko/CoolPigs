using System.Collections;
using UnityEngine;

public class Actions : MonoBehaviour
{
    public IEnumerator CellsMoveC(GameObject drone,Vector3 movedirection, int cellscount, float speed = 2) // ��������� �� ������������ ����������� ������
    {
        drone.GetComponent<DroneStats>().isaction = true;
        Transform _transform = drone.GetComponent<Transform>();
        Vector3 startposition = _transform.position;
        _transform.rotation = Quaternion.Euler(0, movedirection.x * 180, 0);
        while(_transform.position.x <= startposition.x + movedirection.x * cellscount || _transform.position.y <= startposition.y + movedirection.y * cellscount)
        {
            _transform.position += movedirection * speed * Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }
        drone.GetComponent<DroneStats>().isaction = false;
    }
    public IEnumerator CellsMoveC(GameObject drone, Vector3 movedirection, float speed = 2) // ��������� ���� �� ������ � �����
    {
        drone.GetComponent<DroneStats>().isaction = true;
        Transform _transform = drone.GetComponent<Transform>();
        _transform.rotation = Quaternion.Euler(0, movedirection.x * 180, 0);
        while (!Physics.Raycast(_transform.position, movedirection, 1f, 3))
        {
            _transform.position += movedirection * speed * Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }
        yield return new WaitForSeconds(0.25f);
        drone.GetComponent<DroneStats>().isaction = false;
    }
    public IEnumerator ToolDirectionC(GameObject drone,GameObject Tool, Vector3 lookdirection) //����������� �����������
    {
        drone.GetComponent<DroneStats>().isaction = true;
        Tool.transform.rotation = Quaternion.Euler(lookdirection * 90);
        yield return new WaitForSeconds(0.25f);
    }
    public IEnumerator ReCahrgeC(GameObject drone)// �������������
    {
        drone.GetComponent<DroneStats>().isaction = true;
        Transform _transform = drone.GetComponent<Transform>();
        if (Physics.OverlapSphere(_transform.position, 0.3f, 10) != null)
        {
            drone.GetComponent<DroneStats>().energy = drone.GetComponent<DroneStats>().maxCharge;
        }
        yield return new WaitForSeconds(0.25f);
        drone.GetComponent<DroneStats>().isaction = false;
    }
    public IEnumerator DigC(GameObject drone,GameObject tool)// ������
    {
        drone.GetComponent<DroneStats>().isaction = true;
        tool.GetComponent<Animation>().Play();
        yield return new WaitForSeconds(0.25f);
        RaycastHit hit;
        if(Physics.Raycast(tool.transform.position,tool.transform.forward,out hit ,1f, 9))
        {
            hit.transform.gameObject.GetComponent<Rock>().destroy();
        }
        drone.GetComponent<DroneStats>().isaction = false;
    }

    public IEnumerator TakeItemC(GameObject drone)// ����� �������
    {
        drone.GetComponent<DroneStats>().isaction = true;
        Collider[] item = Physics.OverlapSphere(drone.transform.position, 0.2f, 11);
        if (item != null)
        {
            item[0].GetComponent<item>().TakeItem();
        }
        yield return new WaitForSeconds(0.25f);
        drone.GetComponent<DroneStats>().isaction = false;
    }

    public IEnumerator DropItemC(GameObject drone)// �������� �������
    {
        drone.GetComponent<DroneStats>().isaction = true;
        drone.GetComponent<DroneStats>().Item.GetComponent<item>().DropItem();
        yield return new WaitForSeconds(0.25f);
        drone.GetComponent<DroneStats>().isaction = false;
    }

    public IEnumerator FireC(GameObject drone,GameObject Tool, GameObject projecttile) // ����������
    {
        drone.GetComponent<DroneStats>().isaction = true;
        Instantiate(projecttile, projecttile.transform.position, Tool.transform.rotation);
        yield return new WaitForSeconds(0.25f);
        drone.GetComponent<DroneStats>().isaction = false;
    }

    public IEnumerator ObstacleTriggerC(GameObject drone, Vector3 direction)// ��������� ���� ����������� �������
    {
        drone.GetComponent<DroneStats>().isaction = true;
        yield return new WaitWhile(() => !Physics.Raycast(drone.transform.position, direction, 1f, 3));
        drone.GetComponent<DroneStats>().isaction = false;
    }

    public IEnumerator NearTriggerC(GameObject drone, float radius, int mask)// ��������� ���� ������� ����� �� �������� ����� 
    {
        drone.GetComponent<DroneStats>().isaction = true;
        yield return new WaitWhile(() => Physics.OverlapSphere(drone.transform.position, radius, mask) == null);
        drone.GetComponent<DroneStats>().isaction = false;
    }

    public IEnumerator EnergyTriggerC(GameObject drone, int criticalenergylimit)// ��������� ����� �����
    {
        drone.GetComponent<DroneStats>().isaction = true;
        yield return new WaitWhile(() => drone.GetComponent<DroneStats>().energy >= criticalenergylimit);
        drone.GetComponent<DroneStats>().isaction = false;
    }

}
