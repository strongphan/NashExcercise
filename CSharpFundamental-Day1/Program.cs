namespace Excercise1
{
    public class Program
    {
        public static void DisplayMember(Member member)
        {
            Console.WriteLine("{0,-10} {1,-10} {2,-6} {3,-10} {4,-15} {5,-10} {6,-5}", "FirstName", "LastName", "Gender", "DOB", "Phone", "BirthPlace", "IsGraduate");

            Console.WriteLine("{0,-10} {1,-10} {2,-6} {3,-10:yyyy-MM-dd} {4,-15} {5,-10} {6,-5}",
                member.FirstName,
                member.LastName,
                member.Gender,
                member.DateOfBirth,
                member.PhoneNumber,
                member.BirthPlace,
                member.IsGraduated ? "Yes" : "No");
            Console.WriteLine();
        }

        public static void DisplayMembersInTable(List<Member> listMember)
        {
            Console.WriteLine("{0,-10} {1,-10} {2,-6} {3,-10} {4,-15} {5,-10} {6,-5}", "FirstName", "LastName", "Gender", "DOB", "Phone", "BirthPlace", "IsGraduate");

            foreach (Member member in listMember)
            {
                Console.WriteLine("{0,-10} {1,-10} {2,-6} {3,-10:yyyy-MM-dd} {4,-15} {5,-10} {6,-5}",
                    member.FirstName,
                    member.LastName,
                    member.Gender,
                    member.DateOfBirth,
                    member.PhoneNumber,
                    member.BirthPlace,
                    member.IsGraduated ? "Yes" : "No");
            }
            Console.WriteLine();
        }

        //1. Return a list of members who is Male
        public static List<Member> GetMaleMembers(List<Member> listMember)
        {
            List<Member> list = new List<Member>();
            foreach (Member member in listMember)
            {
                if (member.Gender == Gender.Male)
                {
                    list.Add(member);
                }
            }
            return list;
        }

        //2.Return the oldest one based on “Age”
        public static Member GetOldest(List<Member> listMember)
        {
            var oldest = listMember[0];
            foreach (Member member in listMember)
            {
                if (member.Age > oldest.Age)
                {
                    oldest = member;
                }
            }
            return oldest;

        }
        //3. Return a new list that contains Full Name only
        public static List<String> GetFullName(List<Member> listMember)
        {
            var list = new List<String>();
            foreach (Member member in listMember)
            {
                var fullName = member.FirstName + " " + member.LastName;
                list.Add(fullName);
            }
            return list;
        }

        /*4. Return 3 lists:
    List of members who has birth year is 2000
    List of members who has birth year greater than 2000
    List of members who has birth year less than 2000*/
        public static (List<Member> Member2000, List<Member> OldMembers, List<Member> YoungMembers)
            FilterMemberForYear(List<Member> listMember)
        {
            List<Member> Member2000 = new List<Member>();
            List<Member> OldMembers = new List<Member>();
            List<Member> YoungMembers = new List<Member>();

            foreach (Member member in listMember)
            {
                switch (member.DateOfBirth.Year)
                {
                    case 2000:
                        Member2000.Add(member);
                        break;
                    case < 2000:
                        OldMembers.Add(member);
                        break;
                    case > 2000:
                        YoungMembers.Add(member);
                        break;
                }
            }

            return (Member2000, OldMembers, YoungMembers);
        }

        //5. Return the first person who was born in Ha Noi.
        public static Member GetMemberForAddress(List<Member> listMember, string address)
        {
            var a = new Member();
            foreach (Member member in listMember)
            {
                if (member.BirthPlace == address)
                {
                    a = member;
                }
            }
            return a;
        }
        public static void Main(string[] args)
        {
            List<Member> listMember = new()
            {
                new("Manh", "Phan", Gender.Male, new DateTime(2002, 02, 22), "0975169602", "Ha Noi", false),
                new("Duc", "Hoang", Gender.Male, new DateTime(1996, 01, 11), "0978989900", "Ha Tay", true),
                new("Hai", "Luong", Gender.Male, new DateTime(2001, 06, 21), "2958206928", "Ninh Binh", true),
                new("Ha", "Phan", Gender.Female, new DateTime(1995, 05, 12), "0996781234", "Bac Giang", true),
                new("Dat", "Tuan", Gender.Male, new DateTime(2000, 08, 15), "0988933314", "Bac Ninh", false),
                new("Hieu", "Nguyen", Gender.Male, new DateTime(2002, 03, 01), "0336372726", "Ha Noi", false)
            };
            // Return list member
            Console.WriteLine("\t--List Member--");
            DisplayMembersInTable(listMember);

            //1. Return a list of members who is Male
            var listMale = GetMaleMembers(listMember);
            Console.WriteLine("\n\t--1. Return a list of members who is Male--");
            DisplayMembersInTable(listMale);

            //2.Return the oldest one based on “Age”
            var oldest = GetOldest(listMember);
            Console.WriteLine("\t--2.Return the oldest one based on “Age”--");
            DisplayMember(oldest);

            //3. Return a new list that contains Full Name only
            var lFullName = GetFullName(listMember);
            Console.WriteLine("\t--3. Return a new list that contains Full Name only--");
            Console.WriteLine("Full Name");
            foreach (var name in lFullName)
            {
                Console.WriteLine(name);

            }

            /*4. Return 3 lists:
                List of members who has birth year is 2000
                List of members who has birth year greater than 2000
                List of members who has birth year less than 2000*/
            var filter = FilterMemberForYear(listMember);
            Console.WriteLine("\t--4.Members 2000--");
            DisplayMembersInTable(filter.Member2000);

            Console.WriteLine("\t--4.Members younger than 2000--");
            DisplayMembersInTable(filter.YoungMembers);

            Console.WriteLine("\t--4.Members older than 2000--");
            DisplayMembersInTable(filter.OldMembers);

            //5. Return the first person who was born in Ha Noi.
            var memberInHaNoi = GetMemberForAddress(listMember, "Ha Noi");
            Console.WriteLine("\t--5. Return the first person who was born in Ha Noi.--");
            DisplayMember(memberInHaNoi);
        }
    }
}