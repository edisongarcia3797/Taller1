﻿using Taller1.Domain.Interfaces;
using Taller1.Domain.Models;

namespace Taller1.Application.Interfaces
{
    public interface ICalculatorService
    {
        Response GetSumTwoNumbers(ISum sum);
    }
}
