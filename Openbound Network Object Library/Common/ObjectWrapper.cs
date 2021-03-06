﻿/* 
 * Copyright (C) 2020, Carlos H.M.S. <carlos_judo@hotmail.com>
 * This file is part of OpenBound.
 * OpenBound is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License
 * as published by the Free Software Foundation, either version 3 of the License, or(at your option) any later version.
 * 
 * OpenBound is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty
 * of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License along with OpenBound. If not, see http://www.gnu.org/licenses/.
 */

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Linq;
using System.Text;

namespace Openbound_Network_Object_Library.Common
{
    public class ObjectWrapper
    {
        private static ASCIIEncoding encoder = new ASCIIEncoding();

        static ObjectWrapper()
        {
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings()
            {
                Formatting = Formatting.None,
                NullValueHandling = NullValueHandling.Ignore,
                //MaxDepth = 3
            };
        }

        public static T ConvertByteArrayToObject<T>(byte[] Param)
        {
            return DeserializeRequest<T>(encoder.GetString(Param));
        }

        public static byte[] ConvertObjectToByteArray<T>(T Param, int ArraySize)
        {
            string text = Serialize(Param);
            byte[] array = encoder.GetBytes(text);

            if (array.Count() > ArraySize)
                throw new Exception();

            Array.Resize(ref array, ArraySize);
            return array;
        }

        public static byte[] ConvertObjectToByteArray<T>(T Param)
        {
            string text = Serialize(Param);
            byte[] array = encoder.GetBytes(text);
            return array;
        }

        public static T TryDeserializeRequest<T>(string Param)
        {
            try
            {
                return DeserializeRequest<T>(Param);
            }
            catch (Exception)
            {
                return default;
            }
        }

        public static T DeserializeRequest<T>(string Param)
        {
            if (!ObjectValidator.ValidateString(Param)) throw new Exception();
            return JsonConvert.DeserializeObject<T>(Param);
        }

        public static T DeserializeCommentedJSONFile<T>(string filePath)
        {
            string str = "";

            File.ReadAllLines(filePath)
                .ToList()
                .Where((x) => x.Length > 0 && (x.Trim()[0] != '/'))
                .ToList()
                .ForEach((x) => str += x);

            return DeserializeRequest<T>(str);
        }

        public static string Serialize<T>(T param, Formatting formatting)
        {
            return JsonConvert.SerializeObject(param, formatting);
        }

        public static string Serialize<T>(T Param)
        {
            return JsonConvert.SerializeObject(Param);
        }
    }
}
