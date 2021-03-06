//Do not edit! This file was generated by Unity-ROS MessageGeneration.
using System;
using System.Collections.Generic;

namespace Unity.Robotics.ROSTCPConnector.MessageGeneration
{
    public class MDuration : Message
    {
        public const string RosMessageName = "std_msgs/Duration";

        public int secs;
        public int nsecs;

        public MDuration()
        {
            secs = 0;
            nsecs = 0;
        }

        public MDuration(int secs, int nsecs)
        {
            this.secs = secs;
            this.nsecs = nsecs;
        }

        public override List<byte[]> SerializationStatements()
        {
            var listOfSerializations = new List<byte[]>();
            listOfSerializations.Add(BitConverter.GetBytes(this.secs));
            listOfSerializations.Add(BitConverter.GetBytes(this.nsecs));

            return listOfSerializations;
        }

        public override int Deserialize(byte[] data, int offset)
        {
            this.secs = BitConverter.ToInt32(data, offset);
            offset += 4;
            this.nsecs = BitConverter.ToInt32(data, offset);
            offset += 4;

            return offset;
        }
    }
}