using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.ML.Runtime.Api;

namespace lol
{
    public class RandomFone
    {
        [Column(ordinal: "0")]
        public int month;
        [Column(ordinal: "1")]
        public int year;
        [Column(ordinal: "2")]
        public int price;
    }
}
