using Photon.Pun;
using UnityEngine;

public class Clicker : MonoBehaviour {

    [SerializeField]
    GameObject clickPrefab;

    PhotonView photonView;
    void Start() {
        photonView = GetComponent<PhotonView>();
    }

    void Update() {
        if (!photonView.IsMine && PhotonNetwork.IsConnected) {
            return;
        }

        if (Input.GetButtonDown("Fire1")) {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = Camera.main.nearClipPlane;
            Vector3 mouseInWorld = Camera.main.ScreenToWorldPoint(mousePos);

            Click(mouseInWorld);
        }
    }

    void Click(Vector3 mousePosition) {
        if (PhotonNetwork.IsConnected) {
            PhotonNetwork.Instantiate("Click", mousePosition, Quaternion.identity);
        }
        else {
            Instantiate(clickPrefab, mousePosition, Quaternion.identity);
        }
    }
}
