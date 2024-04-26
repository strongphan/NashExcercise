namespace Exercise2
{
    public class Member
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string BirthPlace { get; set; }
        public int Age { get; set; }
        public bool IsGraduated { get; set; }
        public Member() { }

        public Member(string firstName, string lastName, Gender gender, DateTime dateOfBirth, string phoneNumber, string birthPlace, bool isGraduated)
        {
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            DateOfBirth = dateOfBirth;
            PhoneNumber = phoneNumber;
            Age = DateTime.Now.Year - dateOfBirth.Year;
            IsGraduated = isGraduated;
            BirthPlace = birthPlace;

        }

    }
}
