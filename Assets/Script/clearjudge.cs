using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckCookies : MonoBehaviour
{
    // ���t���[���m�F����
    void Update()
    {
        // cookie�^�O��powercookie�^�O�̃I�u�W�F�N�g��T��
        GameObject[] cookies = GameObject.FindGameObjectsWithTag("cookie");
        GameObject[] powerCookies = GameObject.FindGameObjectsWithTag("Powercookie");

        // �����̔z�񂪋�Ȃ�i=�S�ĉ�����ꂽ�Ȃ�j�N���A�V�[���Ɉړ�
        if (cookies.Length == 0 && powerCookies.Length == 0)
        {
            SceneManager.LoadScene("clear");
        }
    }
}
