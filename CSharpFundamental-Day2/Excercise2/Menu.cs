using Exercise2;

namespace Excercise2
{
    public class Menu
    {
        private MemberManager _memberManager;
        private List<Member> _listMember;
        public Menu(MemberManager memberManager, List<Member> listMember)
        {
            _memberManager = memberManager;
            _listMember = listMember;
        }
        /// <summary>
        /// Use to display menu
        /// </summary>
        public async Task DisplayMenu()
        {
            int choice;
            string input = "";
            do
            {
                Console.WriteLine("Member Manager Menu:");
                Console.WriteLine("1. Display All Members");
                Console.WriteLine("2. Display Male Members");
                Console.WriteLine("3. Display Oldest Member");
                Console.WriteLine("4. Display Full Names of Members");
                Console.WriteLine("5. Display Members By Year");
                Console.WriteLine("6. Display Members Born in 2000");
                Console.WriteLine("7. Display Members Born After 2000");
                Console.WriteLine("8. Display Members Born Before 2000");
                Console.WriteLine("9. Find First Member from Ha Noi");
                Console.WriteLine("10. Add Member");
                Console.WriteLine("0. Exit");


                do
                {
                    Console.Write("Enter your choice: ");
                    input = Console.ReadLine();
                    if (!int.TryParse(input, out choice) || string.IsNullOrEmpty(input))
                    {
                        Console.WriteLine("Invalid input. Please enter a numeric value.");
                        continue;
                    }
                } while (!int.TryParse(input, out choice) || string.IsNullOrEmpty(input));

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("\n\t--List member--");
                        _memberManager.DisplayMembersInTable(_listMember);
                        break;
                    case 2:
                        var males = _memberManager.GetMaleMembers(_listMember);
                        Console.WriteLine("\n\t--1. Return a list of members who is Male--");
                        _memberManager.DisplayMembersInTable(males);
                        break;
                    case 3:
                        var oldest = _memberManager.GetOldest(_listMember);
                        if (oldest != null)
                        {
                            Console.WriteLine("\n\t--2.Return the oldest one based on “Age”--");
                            _memberManager.DisplayMember(oldest);
                        }
                        break;
                    case 4:
                        var fullNames = _memberManager.GetFullName(_listMember);
                        Console.WriteLine("\n\t--3. Return a new list that contains Full Name only--");
                        fullNames.ForEach(Console.WriteLine);
                        break;
                    case 5:
                        var in2000 = _memberManager.Member2000(_listMember);
                        Console.WriteLine("\n\t--Members by year--");
                        _memberManager.DisplayMembersInTable(in2000);
                        var before2000 = _memberManager.YoungMembers(_listMember);
                        Console.WriteLine("\n\t--4.Members after 2000--");
                        _memberManager.DisplayMembersInTable(before2000);
                        var after2000 = _memberManager.OldMembers(_listMember);
                        Console.WriteLine("\n\t--4.Members after 2000--");
                        _memberManager.DisplayMembersInTable(after2000);
                        break;
                    case 6:
                        var born2000 = _memberManager.Member2000(_listMember);
                        Console.WriteLine("\n\t--4.Members in 2000--");
                        _memberManager.DisplayMembersInTable(born2000);
                        break;
                    case 7:
                        var youngers = _memberManager.YoungMembers(_listMember);
                        Console.WriteLine("\n\t--4.Members after 2000--");
                        _memberManager.DisplayMembersInTable(youngers);
                        break;
                    case 8:
                        var olders = _memberManager.OldMembers(_listMember);
                        Console.WriteLine("\n\t--4.Members before 2000--");
                        _memberManager.DisplayMembersInTable(olders);
                        break;
                    case 9:
                        var fromHanoi = _memberManager.GetMemberForAddress(_listMember, "Ha Noi");
                        if (fromHanoi != null)
                        {
                            Console.WriteLine("\n\t--5. Find the first person who was born in Ha Noi.--");
                            _memberManager.DisplayMember(fromHanoi);
                        }
                        break;
                    case 10:
                        Console.WriteLine("Input member information");
                        _memberManager.AddMember(_listMember);
                        Console.WriteLine("\n\t--List member after add --");
                        _memberManager.DisplayMembersInTable(_listMember);
                        break;
                    case 0:
                        Console.WriteLine("Exiting...");

                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            } while (choice != 0);
        }
    }
}
