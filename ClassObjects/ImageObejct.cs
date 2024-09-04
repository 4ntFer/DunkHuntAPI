﻿using DuckHuntAPI.Models;
using DuckHuntAPI.ObjectFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuckHuntAPI.ClassObjects
{
    /// <summary>
    /// Class <c>ImageObject</c> models a database desassociated image representation.
    /// </summary>
    public class ImageObject : Image
    {
        public string url { get; set; }

        public ImageObject(Image image) {
            this.id = image.id;
            this.data = image.data;
            this.url = Environment.SOURCE_URL + "/image/" + this.id;
        }
    }
}
