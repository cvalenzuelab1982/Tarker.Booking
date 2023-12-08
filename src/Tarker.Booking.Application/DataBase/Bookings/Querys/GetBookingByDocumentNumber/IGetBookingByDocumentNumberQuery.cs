﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarker.Booking.Application.DataBase.Bookings.Querys.GetBookingByDocumentNumber
{
    public interface IGetBookingByDocumentNumberQuery
    {
        Task<List<GetBookingByDocumentNumberModel>> Execute(string documentNumber);
    }
}
