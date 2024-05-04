using UnityEngine;

public class CitizenClicker : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.TryGetComponent(out Citizen citizen))
                {
                    citizen.Attack();
                }
            }
        }
    }
}
