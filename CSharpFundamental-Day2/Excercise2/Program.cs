using Excercise2;

namespace Exercise2
{
    public class Program
    {

        public static void Main(string[] args)
        {
            var manager = new MemberManager();
            List<Member> listMember = new()
            {
                new("Manh", "Phan", Gender.Male, new DateTime(2002, 02, 22), "0975169602", "Ha Noi", false),
                new("Duc", "Hoang", Gender.Male, new DateTime(1996, 01, 11), "0978989900", "Ha Tay", true),
                new("Hai", "Luong", Gender.Male, new DateTime(2001, 06, 21), "2958206928", "Ninh Binh", true),
                new("Ha", "Phan", Gender.Female, new DateTime(1995, 05, 12), "0996781234", "Bac Giang", true),
                new("Dat", "Tuan", Gender.Male, new DateTime(2000, 08, 15), "0988933314", "Bac Ninh", false),
                new("Hieu", "Nguyen", Gender.Male, new DateTime(2002, 03, 01), "0336372726", "Ha Noi", false)
            };
            var menu = new Menu(manager, listMember);
            menu.DisplayMenu();
        }
    }
}