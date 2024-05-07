using MVCAssignment.Model;
using MVCAssignment.Model.Enum;
using MVCAssignment.Repository.DTOs;

namespace MVCAssignment.Repository.PersonRepository
{
    public class PersonRepository : IPersonRepository
    {

        public static readonly List<Person> _people = new List<Person>()
            {

                new ("Manh", "Phan", Gender.Male, new DateOnly(2002, 02, 22), "0975169602", "Ha Noi", false),
                new ("Duc", "Hoang", Gender.Male, new DateOnly(1996, 01, 11), "0978989900", "Ha Tay", true),
                new ("Hai", "Luong", Gender.Male, new DateOnly(2001, 06, 21), "2958206928", "Ninh Binh", true),
                new ("Ha", "Phan", Gender.Female, new DateOnly(1995, 05, 12), "0996781234", "Bac Giang", true),
                new ("Dat", "Tuan", Gender.Male, new DateOnly(2000, 08, 15), "0988933314", "Bac Ninh", false),
                new ("Hieu", "Nguyen", Gender.Male, new DateOnly(2002, 03, 07), "0336372726", "Ha Noi", false),
                new ("Duc", "Nguyen", Gender.Female, new DateOnly(2002, 02, 15), "03363763726", "Ha Noi", false),
                new ("Hieu", "Pham", Gender.Male, new DateOnly(2002, 03, 16), "0336372126", "Ha Nam", false),
                new ("Hoang", "Nguyen", Gender.Female, new DateOnly(2002, 01, 01), "0254372726", "Hai Phong", false),
            };

        public Guid? AddPerson(Person person)
        {
            _people.Add(person);
            return person.Id;
        }

        public bool UpdatePerson(Person person)
        {
            var another = _people.FirstOrDefault(p => p.Id == person.Id);
            if (another != null)
            {
                _people.Remove(another);
                _people.Add(person);
                return true;
            }
            return false;
        }

        public bool DeletePerson(Guid personId)
        {
            var another = _people.FirstOrDefault(p => p.Id == personId);
            if (another != null)
            {
                _people.Remove(another);
                return true;
            }
            return false;
        }

        public List<Person> GetPeople(FilterPersonDto filter)
        {
            var people = _people;
            if (filter.Gender.HasValue)
            {
                people = _people.Where(p => p.Gender == filter.Gender.Value).ToList();
            }
            if (filter.Year.HasValue)
            {
                people = _people.Where(p => p.DOB.Year == filter.Year.Value).ToList();
            }
            if (filter.BeforeYear.HasValue)
            {
                people = _people.Where(p => p.DOB.Year < filter.BeforeYear.Value).ToList();
            }
            if (filter.AfterYear.HasValue)
            {
                people = _people.Where(p => p.DOB.Year > filter.AfterYear.Value).ToList();
            }
            if (filter.IsGraduated.HasValue)
            {
                people = _people.Where(p => p.IsGraduated == filter.IsGraduated.Value).ToList();
            }

            return people;
        }




        public Person GetOldestPerson()
        {
            return _people.OrderBy(p => p.DOB.Year).FirstOrDefault();
        }

        public List<string> GetFulName()
        {

            return _people.Select(p => p.FirstName + " " + p.LastName).ToList();
        }

        public Person GetPersonById(Guid personId)
        {
            var person = _people.FirstOrDefault(p => p.Id == personId);
            return person;
        }
    }
}
