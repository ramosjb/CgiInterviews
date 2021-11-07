using System;

namespace InterviewSimpleWebApi.Exceptions
{
    public class LicensePlateAlreadyInUseException : Exception
    {
        public LicensePlateAlreadyInUseException(string licencePlate) : base($"License Plate {licencePlate} is already in use")
        {
        }
    }
}
