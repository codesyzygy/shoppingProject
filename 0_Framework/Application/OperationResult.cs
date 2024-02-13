﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace _0_Framework.Application
{
    public class OperationResult
    {
        public bool IsSuccedded { get; set; }
        public string Message { get; set; }

        public OperationResult()  //default
        {
            IsSuccedded = false;
        }
        public OperationResult Succedded(string message = "عملیات با موقیت انجام شد " )
        {
            IsSuccedded = true;
            Message = message;
            return this;
        }
        public OperationResult Failed(string message)
        {
            IsSuccedded = false;
            Message = message;
            return this;
        }
    }
}
