﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface ISave
{
    //Method to save document as a file and view the saved document
    Task SaveAndView(string filename, string contentType, MemoryStream stream);
}
