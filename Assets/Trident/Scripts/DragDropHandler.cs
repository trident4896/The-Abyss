using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public interface DragDropHandler : IEventSystemHandler {
	void HandleGazeTriggerStart();
	void HandleGazeTriggerEnd();
}
