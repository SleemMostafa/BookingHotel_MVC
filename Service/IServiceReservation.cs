﻿using BookingHotel_MVC.Models;

namespace BookingHotel_MVC.Service
{
    public interface IServiceReservation
    {
        List<Reservation> GetReservationsForGuest(string guestId);

    }
}
