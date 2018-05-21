using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.ML.Runtime.Api;

namespace lol
{
    public class RandomFone
    {
        [Column(ordinal: "0")]
        public float month;
        [Column(ordinal: "1")]
        public float year;
        [Column(ordinal: "2")]
        public float price;
    }
}
