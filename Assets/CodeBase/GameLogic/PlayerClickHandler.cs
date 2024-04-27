using UnityEngine;

public class PlayerClickHandler : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            var collider = GetRaycastTarget();

            if (collider != null)
            {
                if (collider.TryGetComponent(out Citizen citizen))
                {
                    citizen.SwitchTradeState();
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            var collider = GetRaycastTarget();

            if (collider != null)
            {
                if (collider.TryGetComponent(out Citizen citizen))
                {
                    citizen.StartFlee();
                }
            }
        }
    }

    private Collider GetRaycastTarget()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hitInfo))
            return hitInfo.collider;

        return null;
    }
}