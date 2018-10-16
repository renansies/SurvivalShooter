using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public PlayerHealth PlayerHealth;
    public float RestartDelay = 5f;

    private Animator _anim;
    private float _restartTimer;


    void Awake()
    {
        _anim = GetComponent<Animator>();
    }


    void Update()
    {
        if (PlayerHealth.currentHealth <= 0)
        {
            _anim.SetTrigger("GameOver");

            _restartTimer += Time.deltaTime;

            if (_restartTimer >= RestartDelay)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
