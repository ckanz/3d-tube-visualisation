# 3d-tube-visualisation

This project is a 3-dimensional interactive visualisation showing all depths and heights of the London Underground. The project is created with an older version of Unity and C#, using csv data to create objects in 3-dimensional space.

### Data

The csv data file contains the following information about each station:
- Name
- GPS coordinates
- Height above NORMAL
- Depth (in ordnance datum)
- Zone
- Line
- Amount of annual entries and exits

The data comes from [this source](http://www.ianvisits.co.uk/blog/2011/07/01/how-deep-is-every-tube-station-on-the-underground/).

### Visualisation

![vis](https://github.com/ckanz/3d-tube-visualisation/blob/master/screenshot2.png?raw=true)

All London Underground stations are arranged according to their GPS coordinates. The red bubbles in the scene resemble the station's entrance, the blue represent the station underground. By mapping the position of the Z axis of each object to the depth and height values in the data file, one receives a 3-dimensional map giving an overview of the entire vertical landscape of the London subway system throughout the whole London area.
Shown are each station's entry above normal and the depth of the station itself below its entry.

The transparent plane separating the red from the blue bubbles represents above-normal for the station's entries. For the station's depths however, the plane represents the stations entry point. This way, the actual depth below the ground is shown rather than relating to its position to above-normal.

Displayed in the left corner is the station's name and the exact numbers of the station's depth and height, as well as to bars that visualise both values in relation to each other.

### Interaction

One can select important stations by name on the menu above, as well as skip through all stations alphabetically or jump to random stations. It is possible to move around with the arrow keys, zoom in our out with the mouse wheel or the W/S keys as well as look around in the entire scene and inspect everything below the plane with the mouse holding the right mouse button.

To add more context, the color of the London Underground lines can be switched on, as well as a visualisation of the busyness of each station (according to annual entries and exits).

### Deployment

The project is hosted on [http://3d-tube.clemens-anzmann.com/](http://3d-tube.clemens-anzmann.com/). Unfortunately, Chrome browsers are not supported with this version of the Unity plugin and the project runs best using Firefox or Safari. It is required to install the Unity browser plugin to view the project.

The project took part in the Kantar Information is Beautiful Awards 2013:
http://www.informationisbeautifulawards.com/showcase/310-3d-london-underground-visualization

It has been implemented after working hours at the DataShaka office in Soho, London.

![dev](https://github.com/ckanz/3d-tube-visualisation/blob/master/screenshot1.png?raw=true)
