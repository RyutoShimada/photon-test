using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room_ListingsMenu : MonoBehaviourPunCallbacks
{
    [SerializeField] private Transform _content;
    [SerializeField] private RoomListing _roomListing;

    private List<RoomListing> _listing = new List<RoomListing>();

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        foreach (RoomInfo info in roomList)
        {
            // Remove from rooms list.
            if (info.RemovedFromList)
            {
                int index = _listing.FindIndex(x => x.RoomInfo.Name == info.Name);
                if (index != -1)
                {
                    Destroy(_listing[index].gameObject);
                    _listing.RemoveAt(index);
                }
            }
            // Added to rooms list.
            else
            {

            }

            RoomListing listing = (RoomListing)Instantiate(_roomListing, _content);
            if (listing != null)
            {
                listing.SetRoomInfo(info);
                _listing.Add(listing);
            }
        }
    }
}
