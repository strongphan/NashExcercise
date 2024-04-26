using Exercise2;

namespace Excercise2
{
    public class MemberManager
    {
        /// <summary>
        /// Add member
        /// </summary>
        /// <param name="listMember">Current list of member</param>
        public void AddMember(List<Member> listMember)
        {
            var member = new Member();
            Console.Write("First  Name: ");
            member.FirstName = Console.ReadLine();
            Console.Write("Last  Name: ");
            member.LastName = Console.ReadLine();
            Console.Write("Gender: ");
            member.Gender = (Gender)Enum.Parse(typeof(Gender), Console.ReadLine(), true);
            Console.Write("DOB(yyyy-MM-dd): ");
            member.DateOfBirth = DateTime.Parse(Console.ReadLine());
            Console.Write("Phone Number: ");
            member.PhoneNumber = Console.ReadLine();
            Console.Write("Birth Place: ");
            member.BirthPlace = Console.ReadLine();
            Console.Write("Is graduated( true/ false): ");
            member.IsGraduated = bool.Parse(Console.ReadLine());


            listMember.Add(member);
        }
        /// <summary>
        /// Use to display one member
        /// </summary>
        /// <param name="member"></param>
        public void DisplayMember(Member member)
        {
            Console.WriteLine(
                "{0,-10} {1,-10} {2,-6} {3,-10} {4,-15} {5,-10} {6,-5}",
                "FirstName",
                "LastName",
                "Gender",
                "DOB",
                "Phone",
                "BirthPlace",
                "IsGraduate"
            );

            Console.WriteLine(
                "{0,-10} {1,-10} {2,-6} {3,-10:yyyy-MM-dd} {4,-15} {5,-10} {6,-5}",
                member.FirstName,
                member.LastName,
                member.Gender,
                member.DateOfBirth,
                member.PhoneNumber,
                member.BirthPlace,
                member.IsGraduated ? "Yes" : "No"
            );
            Console.WriteLine();
        }
        /// <summary>
        /// Use to display list of member
        /// </summary>
        /// <param name="listMember"></param>
        public void DisplayMembersInTable(List<Member> listMember)
        {
            Console.WriteLine(
                "{0,-10} {1,-10} {2,-6} {3,-10} {4,-15} {5,-10} {6,-5}",
                "FirstName",
                "LastName",
                "Gender",
                "DOB",
                "Phone",
                "BirthPlace",
                "IsGraduate"
            );

            foreach (Member member in listMember)
            {
                Console.WriteLine(
                    "{0,-10} {1,-10} {2,-6} {3,-10:yyyy-MM-dd} {4,-15} {5,-10} {6,-5}",
                    member.FirstName,
                    member.LastName,
                    member.Gender,
                    member.DateOfBirth,
                    member.PhoneNumber,
                    member.BirthPlace,
                    member.IsGraduated ? "Yes" : "No"
                );
            }
            Console.WriteLine();
        }
        /// <summary>
        /// 1. Return a list of members who is Male
        /// </summary>
        /// <param name="listMember"></param>
        /// <returns></returns>
        public List<Member> GetMaleMembers(List<Member> listMember)
        {
            return listMember.Where(m => m.Gender == Gender.Male).ToList();
        }

        /// <summary>
        /// 2.Return the oldest one based on “Age”
        /// </summary>
        /// <param name="listMember"></param>
        /// <returns></returns>
        public Member? GetOldest(List<Member> listMember)
        {
            return listMember.OrderByDescending(m => m.Age).FirstOrDefault();
        }

        /// <summary>
        /// 3. Return a new list that contains Full Name only
        /// </summary>
        /// <param name="listMember"></param>
        /// <returns></returns>
        public List<String> GetFullName(List<Member> listMember)
        {
            return listMember.Select(member => $"{member.FirstName} {member.LastName}").ToList();
        }
        /// <summary>
        /// List of members who has birth year is 2000
        /// </summary>
        /// <param name="listMember"></param>
        /// <returns></returns>
        public List<Member> Member2000(List<Member> listMember)
        {
            return listMember.Where(m => m.DateOfBirth.Year == 2000).ToList();
        }
        /// <summary>
        ///  List of members who has birth year greater than 2000
        /// </summary>
        /// <param name="listMember"></param>
        /// <returns></returns>
        public List<Member> YoungMembers(List<Member> listMember)
        {
            return listMember.Where(m => m.DateOfBirth.Year > 2000).ToList();
        }
        /// <summary>
        /// List of members who has birth year less than 2000
        /// </summary>
        /// <param name="listMember"></param>
        /// <returns></returns>
        public List<Member> OldMembers(List<Member> listMember)
        {
            return listMember.Where(m => m.DateOfBirth.Year < 2000).ToList();
        }

        /// <summary>
        /// 5. Return the first person who was born in Ha Noi.
        /// </summary>
        /// <param name="listMember"></param>
        /// <param name="address"></param>
        /// <returns></returns>
        public Member? GetMemberForAddress(List<Member> listMember, string address)
        {
            return listMember.Where(m => m.BirthPlace == address).FirstOrDefault();
        }
    }
}
