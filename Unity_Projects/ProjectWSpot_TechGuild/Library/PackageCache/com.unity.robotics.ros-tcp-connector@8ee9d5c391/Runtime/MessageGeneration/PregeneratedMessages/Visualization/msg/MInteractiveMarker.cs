//Do not edit! This file was generated by Unity-ROS MessageGeneration.
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;
using RosMessageTypes.Std;

namespace RosMessageTypes.Visualization
{
    public class MInteractiveMarker : Message
    {
        public const string RosMessageName = "visualization_msgs/InteractiveMarker";

        //  Time/frame info.
        //  If header.time is set to 0, the marker will be retransformed into
        //  its frame on each timestep. You will receive the pose feedback
        //  in the same frame.
        //  Otherwise, you might receive feedback in a different frame.
        //  For rviz, this will be the current 'fixed frame' set by the user.
        public MHeader header;
        //  Initial pose. Also, defines the pivot point for rotations.
        public Geometry.MPose pose;
        //  Identifying string. Must be globally unique in
        //  the topic that this message is sent through.
        public string name;
        //  Short description (< 40 characters).
        public string description;
        //  Scale to be used for default controls (default=1).
        public float scale;
        //  All menu and submenu entries associated with this marker.
        public MMenuEntry[] menu_entries;
        //  List of controls displayed for this marker.
        public MInteractiveMarkerControl[] controls;

        public MInteractiveMarker()
        {
            this.header = new MHeader();
            this.pose = new Geometry.MPose();
            this.name = "";
            this.description = "";
            this.scale = 0.0f;
            this.menu_entries = new MMenuEntry[0];
            this.controls = new MInteractiveMarkerControl[0];
        }

        public MInteractiveMarker(MHeader header, Geometry.MPose pose, string name, string description, float scale, MMenuEntry[] menu_entries, MInteractiveMarkerControl[] controls)
        {
            this.header = header;
            this.pose = pose;
            this.name = name;
            this.description = description;
            this.scale = scale;
            this.menu_entries = menu_entries;
            this.controls = controls;
        }
        public override List<byte[]> SerializationStatements()
        {
            var listOfSerializations = new List<byte[]>();
            listOfSerializations.AddRange(header.SerializationStatements());
            listOfSerializations.AddRange(pose.SerializationStatements());
            listOfSerializations.Add(SerializeString(this.name));
            listOfSerializations.Add(SerializeString(this.description));
            listOfSerializations.Add(BitConverter.GetBytes(this.scale));
            
            listOfSerializations.Add(BitConverter.GetBytes(menu_entries.Length));
            foreach(var entry in menu_entries)
                listOfSerializations.Add(entry.Serialize());
            
            listOfSerializations.Add(BitConverter.GetBytes(controls.Length));
            foreach(var entry in controls)
                listOfSerializations.Add(entry.Serialize());

            return listOfSerializations;
        }

        public override int Deserialize(byte[] data, int offset)
        {
            offset = this.header.Deserialize(data, offset);
            offset = this.pose.Deserialize(data, offset);
            var nameStringBytesLength = DeserializeLength(data, offset);
            offset += 4;
            this.name = DeserializeString(data, offset, nameStringBytesLength);
            offset += nameStringBytesLength;
            var descriptionStringBytesLength = DeserializeLength(data, offset);
            offset += 4;
            this.description = DeserializeString(data, offset, descriptionStringBytesLength);
            offset += descriptionStringBytesLength;
            this.scale = BitConverter.ToSingle(data, offset);
            offset += 4;
            
            var menu_entriesArrayLength = DeserializeLength(data, offset);
            offset += 4;
            this.menu_entries= new MMenuEntry[menu_entriesArrayLength];
            for(var i = 0; i < menu_entriesArrayLength; i++)
            {
                this.menu_entries[i] = new MMenuEntry();
                offset = this.menu_entries[i].Deserialize(data, offset);
            }
            
            var controlsArrayLength = DeserializeLength(data, offset);
            offset += 4;
            this.controls= new MInteractiveMarkerControl[controlsArrayLength];
            for(var i = 0; i < controlsArrayLength; i++)
            {
                this.controls[i] = new MInteractiveMarkerControl();
                offset = this.controls[i].Deserialize(data, offset);
            }

            return offset;
        }

        public override string ToString()
        {
            return "MInteractiveMarker: " +
            "\nheader: " + header.ToString() +
            "\npose: " + pose.ToString() +
            "\nname: " + name.ToString() +
            "\ndescription: " + description.ToString() +
            "\nscale: " + scale.ToString() +
            "\nmenu_entries: " + System.String.Join(", ", menu_entries.ToList()) +
            "\ncontrols: " + System.String.Join(", ", controls.ToList());
        }
    }
}
