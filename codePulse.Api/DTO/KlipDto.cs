﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class KlipDto
    {

        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string url { get; set; }
        public Guid RegisterId { get; set; }

    }
}
