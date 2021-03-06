//Do not edit! This file was generated by Unity-ROS MessageGeneration.
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;

namespace RosMessageTypes.Sensor
{
    public class MJoyFeedbackArray : Message
    {
        public const string RosMessageName = "sensor_msgs/JoyFeedbackArray";

        //  This message publishes values for multiple feedback at once. 
        public MJoyFeedback[] array;

        public MJoyFeedbackArray()
        {
            this.array = new MJoyFeedback[0];
        }

        public MJoyFeedbackArray(MJoyFeedback[] array)
        {
            this.array = array;
        }
        public override List<byte[]> SerializationStatements()
        {
            var listOfSerializations = new List<byte[]>();
            
            listOfSerializations.Add(BitConverter.GetBytes(array.Length));
            foreach(var entry in array)
                listOfSerializations.Add(entry.Serialize());

            return listOfSerializations;
        }

        public override int Deserialize(byte[] data, int offset)
        {
            
            var arrayArrayLength = DeserializeLength(data, offset);
            offset += 4;
            this.array= new MJoyFeedback[arrayArrayLength];
            for(var i = 0; i < arrayArrayLength; i++)
            {
                this.array[i] = new MJoyFeedback();
                offset = this.array[i].Deserialize(data, offset);
            }

            return offset;
        }

        public override string ToString()
        {
            return "MJoyFeedbackArray: " +
            "\narray: " + System.String.Join(", ", array.ToList());
        }
    }
}
