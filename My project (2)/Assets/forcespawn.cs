using UnityEngine;
using AC; // добавляем обязательно

public class ManualPlayerSpawner : MonoBehaviour
{
    [Header("Укажи префаб игрока и точку спавна")]
    public GameObject playerPrefab;
    public Transform spawnPoint;

    void Start()
    {
        if (KickStarter.player == null)
        {
            GameObject playerObj = Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);

            // Зарегистрировать нового игрока в AC
            KickStarter.player = playerObj.GetComponent<Player>();

            if (KickStarter.player != null)
            {
                Debug.Log("Игрок заспавнен и зарегистрирован в AC.");
            }
            else
            {
                Debug.LogError("Не найден компонент Player на префабе!");
            }

            // Найти камеру с компонентом AC._Camera
            _Camera acCamera = Camera.main.GetComponent<_Camera>();

            if (acCamera != null)
            {
                KickStarter.mainCamera.SetGameCamera(acCamera);
                Debug.Log("AC камера зарегистрирована.");
            }
            else
            {
                Debug.LogWarning("AC._Camera не найдена на MainCamera!");
            }
        }
        else
        {
            Debug.Log("Игрок уже есть, спавн не нужен.");
        }
    }
}