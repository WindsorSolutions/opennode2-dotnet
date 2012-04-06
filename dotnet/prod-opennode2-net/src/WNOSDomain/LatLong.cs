#region License
/*
Copyright (c) 2009, The Environmental Council of the States (ECOS)
All rights reserved.

Redistribution and use in source and binary forms, with or without
modification, are permitted provided that the following conditions
are met:

 * Redistributions of source code must retain the above copyright
   notice, this list of conditions and the following disclaimer.
 * Redistributions in binary form must reproduce the above copyright
   notice, this list of conditions and the following disclaimer in the
   documentation and/or other materials provided with the distribution.
 * Neither the name of the ECOS nor the names of its contributors may
   be used to endorse or promote products derived from this software
   without specific prior written permission.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
"AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS
FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE
COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT,
INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING,
BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT
LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN
ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE
POSSIBILITY OF SUCH DAMAGE.
*/
#endregion

using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using Windsor.Commons.Core;

using Windsor.Node2008.WNOSUtility;

namespace Windsor.Node2008.WNOSDomain
{
    [Serializable]
    public class LatLongPoint
    {
        public LatLongPoint()
        {
        }
        public LatLongPoint(decimal latitude, decimal longitude)
        {
            _latitude = latitude;
            _longitude = longitude;
        }
        private decimal _latitude;

        public decimal Latitude
        {
            get { return _latitude; }
            set { _latitude = value; }
        }
        private decimal _longitude;

        public decimal Longitude
        {
            get { return _longitude; }
            set { _longitude = value; }
        }
        public override string ToString()
        {
            return ReflectionUtils.GetPublicPropertiesString(this);
        }
    }
    [Serializable]
    public class LatLongRectangle
    {
        public LatLongRectangle()
        {
        }
        public LatLongRectangle(decimal northLatitude, decimal eastLongitude,
                                decimal southLatitude, decimal westLongitude)
        {
            _northeast = new LatLongPoint(northLatitude, eastLongitude);
            _southwest = new LatLongPoint(southLatitude, westLongitude);
        }
        private LatLongPoint _northeast;

        public LatLongPoint Northeast
        {
            get { return _northeast; }
            set { _northeast = value; }
        }
        private LatLongPoint _southwest;

        public LatLongPoint Southwest
        {
            get { return _southwest; }
            set { _southwest = value; }
        }

        public decimal North
        {
            get { return _northeast.Latitude; }
        }
        public decimal East
        {
            get { return _northeast.Longitude; }
        }
        public decimal South
        {
            get { return _southwest.Latitude; }
        }
        public decimal West
        {
            get { return _southwest.Longitude; }
        }
        public override string ToString()
        {
            return ReflectionUtils.GetPublicPropertiesString(this);
        }
    }
}
