using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApp.Common.ValidationConstants
{
    public class EntityValidation
    {
        // GuestName
        public const int GuestNameMaxLength = 100;
        public const int GuestNameMinLength = 2;

        // GuestEmail
        public const int GuestEmailMaxLength = 100;
        public const int GuestEmailMinLength = 5;

        // GuestPhone
        public const int GuestPhoneMaxLength = 15;
        public const int GuestPhoneMinLength = 5;

        // RoomNumber
        public const int RoomNumberMinValue = 1;
        public const int RoomNumberMaxValue = 9999;

        // Floor
        public const int FloorMinValue = 0; // for parter 
        public const int FloorMaxValue = 100;

        // RoomType Name
        public const int RoomTypeNameMaxLength = 50;
        public const int RoomTypeNameMinLength = 2;

        // RoomType Description
        public const int RoomTypeDescriptionMaxLength = 500;
    }
}
