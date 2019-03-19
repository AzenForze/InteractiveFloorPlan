Interactive Floor Plan Documentation

Reynold Guzman
Cody Baker
Tanushree
Hilary Mokolo
User documentation
	This information is aimed towards users of a standalone application. It goes over the basic features of the application.
Views
	The initial view is the First-person view. This is the most realistic view, in which the user can walk around the space.
	The view can be changed at any time by pressing the ‘C’ key. This will enable a “flying” view. This view has two sub-views: The initial “Freecam” view, and the “Overview”. Swapping between them is done with the ‘T’ key. Pressing the ‘C’ key in either sub-view will return to the First-person view.
The Freecam view is the most powerful view. It allows the user to fly around the space, and fly through objects, allowing them to inspect the space from any perspective.
	Overview is a top-down view. It gives the best overall view of the space. This view also supports the dynamic creation of walls. Mouselook is disabled in this view, but the view can be rotated with the “Q” and “E” keys, and the camera’s height can be increased with “R” and decreased with “F”.

Creating walls
	Creating walls can be done in the Overview mode. The furniture menu should not be open. To create a wall, simply click on the ground where you want the wall to start, drag to where you want it to end, and release.
	To force a wall to align to the horizontal or vertical axis, press the X or Z keys respectively. This can make the creation of right angles and parallel walls much simpler.




Placing objects
	In the first-person view or Overview mode, pressing the ‘M’ key will open the furniture placement menu, or close it if it is already open. In first-person, this will disable movement and mouselook, but enables a cursor. In Overview mode, it disables wall placement creation.
A heads-up-display (HUD) will appear allowing the user to select a category of furniture using the dropdown in the top left, or select a furniture item using the hotbar at the bottom.. To place a furniture item, click on the desired item in the item bar, and then click on the desired location.
It is possible to move a previously placed item by clicking and dragging it to a new location.

Resizing, Deleting, or Rotating objects
	Placed items can be resized by clicking it, and then manipulating the “Resize” slider at the bottom right of the screen. Deleting items can be done by clicking it and then pressing the “backspace” button. Rotating items can be done by clicking it and the pressing either the “Z” or “X” button. 
Designer documentation
	This information is aimed towards sellers who want to publish an interactive floor plan of their rooms.
	
	Currently, creating a persistent floor plan requires editing in Unity. The Unity project should make this relatively straightforward, but some knowledge of Unity would be necessary. Once the basic floor plan is complete, the room designer can export a standalone .exe for to that room using File -> Build and Run.

Developer documentation
This information is aimed towards developers who which to extend or modify the project.

Logic
Currently, most logic is handled in the hierarchical state machine class “AgentController.cs”. This handles switching between the various views and menu modes. It it composed of several other classes representing these states. This technique makes state management, which is often be very challenging, relatively straightforward, with each class having few, clear responsibilities.

User Interface
All design elements for the user interface are children of the UI canvas “HUD”. The furniture inventory consists of pictures and clickable buttons that enable the placement of different objects into the scene/room. A dropdown control is used to change the category of the different furniture available to the user. A change in the dropdown corresponds to a change in the furniture inventory pictures and selectable objects. 

Highlighting a furniture object allows for changes to be made to said object, such as deleting, rotating, moving or resizing the object. A highlighted objects is indicated by the yellow hue the object takes.  

A slider control is used to change the size of highlighted furniture, either proportionally smaller or bigger. Rotating is done via button presses “Z” or “X”, and deleting via the button press of “Backspace”

The selection and placement of an object is controlled via the script “GroundPlacementController.cs” and the modification of an object is controlled via the script “DragandDrop.cs”. Any furniture object to be used (“prefab”) within the application must have the “DragandDrop” script attached.




