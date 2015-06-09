using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class StatusView : MonoBehaviour {

    public Person person;
    public BaseStatuses baseStatuses;
    public List<Image> images = new List<Image>();
    public List<StatusSlot> statusSlots = new List<StatusSlot>();
    public List<Sprite> statuses = new List<Sprite>();
    public Dictionary<string, Sprite> statusDict = new Dictionary<string, Sprite>();

    private List<int> holes = new List<int>();

	// Use this for initialization
	public void ViewConstructor (Person person) {
        baseStatuses = person.BaseStatuses;

        foreach (Image image in images) {
            statusSlots.Add (new StatusSlot(image));
        }

        statusDict.Add("Angry", statuses[0]);
        statusDict.Add("Confident", statuses[1]);
        statusDict.Add("Healthy", statuses[2]);
        statusDict.Add("Heartbroken", statuses[3]);
        statusDict.Add("In Love", statuses[4]);
        statusDict.Add("Insecure", statuses[5]);
        statusDict.Add("Motivated", statuses[6]);
        statusDict.Add("Not Confident", statuses[7]);
        statusDict.Add("Not Enough Sleep", statuses[8]);
        statusDict.Add("Not Motivated", statuses[9]);
        statusDict.Add("Secure", statuses[10]);
        statusDict.Add("Sick", statuses[11]);
        statusDict.Add("Well Rested", statuses[12]);

        foreach(Status status in baseStatuses.statuses) {
            status.levelEvent -= UpdateStatus;
            status.levelEvent += UpdateStatus;
            UpdateStatus(status);
        }
	}
	
    public void UpdateStatus(Status status) {
        if(status.Level > 0) {
            foreach (StatusSlot statusSlot in statusSlots) {
                if (statusSlot.image.sprite == null || statusSlot.name == status.Name) {
                    statusSlot.name = status.Name;
                    statusSlot.image.color = Color.white;
                    switch (status.Name) {
                        case "Well Rested":
                            statusSlot.image.sprite = statusDict["Well Rested"];
                            break;
                        case "Motivated":
                            statusSlot.image.sprite = statusDict["Motivated"];
                            break;
                        case "Confident":
                            statusSlot.image.sprite = statusDict["Confident"];
                            break;
                        case "In Love":
                            statusSlot.image.sprite = statusDict["In Love"];
                            break;
                        case "Secure":
                            statusSlot.image.sprite = statusDict["Secure"];
                            break;
                        case "Calm":
                            statusSlot.image.sprite = statusDict["Confident"];
                            break;
                        case "Healthy":
                            statusSlot.image.sprite = statusDict["Healthy"];
                            break;
                        default:
                            Debug.Log("status not found");
                            break;
                    }
                    break;
                }
            }
        }
        else if (status.Level < 0) {
            foreach (StatusSlot statusSlot in statusSlots) {
                if (statusSlot.image.sprite == null || statusSlot.name == status.Name) {
                    statusSlot.name = status.Name;
                    statusSlot.image.color = Color.white;
                    switch (status.Name) {
                        case "Well Rested":
                            statusSlot.image.sprite = statusDict["Not Enough Sleep"];
                            break;
                        case "Motivated":
                            statusSlot.image.sprite = statusDict["Not Motivated"];
                            break;
                        case "Confident":
                            statusSlot.image.sprite = statusDict["Not Confident"];
                            break;
                        case "In Love":
                            statusSlot.image.sprite = statusDict["Heartbroken"];
                            break;
                        case "Secure":
                            statusSlot.image.sprite = statusDict["Insecure"];
                            break;
                        case "Calm":
                            statusSlot.image.sprite = statusDict["Not Confident"];
                            break;
                        case "Healthy":
                            statusSlot.image.sprite = statusDict["Sick"];
                            break;
                        default:
                            Debug.Log("status not found");
                            break;
                    }
                    break;
                }
            }
        }

        else {
            foreach (StatusSlot statusSlot in statusSlots) {
                if (statusSlot.name == status.Name) {
                    statusSlot.name = null;
                    statusSlot.image.sprite = null;
                    statusSlot.image.color = Color.clear;
                    FillHoles();
                }
            }
        }
    }

    private void FillHoles() {
        int count = 0;
        foreach (StatusSlot slot in statusSlots) {
            if (slot.image.sprite == null) {
                holes.Add(count);
            }
            count ++;
        }

        int holesFilled = 0;
        for (int i = 0; i < statusSlots.Count; i++) {
            if (statusSlots[i].image.sprite != null && i > holes[0]) {
                statusSlots[holes[0]].image.color = Color.white;
                statusSlots[holes[0]].image.sprite = statusSlots[i].image.sprite;
                statusSlots[holes[0]].name = statusSlots[i].name;

                statusSlots[i].image.color = Color.clear;
                statusSlots[i].image.sprite = null;
                statusSlots[i].name = null;

                print("--------");
                foreach(int z in holes) {
                    print (z + " number");
                }
                holes.RemoveAt(0);
                holes.Add(i);
                holes.Sort();
            }
        }

        holes.Clear();
    }
  

    public class StatusSlot {
        public string name;
        public Image image;

        public StatusSlot(Image image) {
            this.name = null;
            this.image = image;
            this.image.sprite = null;
            this.image.color = Color.clear;
        }
    }
}
