using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
namespace StarMade_Remote_Start_Server
{
    class whiteListReader
    {
        StreamReader readWhiteList;
        string path;

        /// <summary>
        /// Creates a new readWhiteList object with the path to the current whiteList of IP Addresses
        /// </summary>
        /// <param name="pathToWhiteList"></param>
        public whiteListReader(string pathToWhiteList)
        {
            path = pathToWhiteList;
        }

       /// <summary>
       /// Get the whitelist summarized as a jagged array
       /// </summary>
       /// <returns>A jagged array of byte arrays of IP addresses. Empty array if no IP's present</returns>
        public byte[][] getJaggedIps()
        {
            int counter = 0;
            List<string> ips = new List<string>();
            using (readWhiteList = new StreamReader(path)){
                while(readWhiteList.Peek() >= 0){
                    ips.Add(readWhiteList.ReadLine());
                }
                readWhiteList.Close();
            }

            byte[][] jaggedIps = new byte[ips.Count][];

            foreach (string IP in ips){
                jaggedIps[counter] = IPAddress.Parse(IP).GetAddressBytes();
                counter++;
            }
            return jaggedIps;

        }
    }
}
