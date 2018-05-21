using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.ML.Runtime.Api;

namespace lol
{
    public class Predict
    {
        [ColumnName("Score")]
        public int price;
    }
}
